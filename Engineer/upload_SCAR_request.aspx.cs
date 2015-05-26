using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FYP_WebApp.Old_App_Code;
using System.Net.Mail;
using Notice_Alert;
using CryptoLib;

public partial class Engineer_upload_scar_request: System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        // Reset and clears the upload control
        btnReset.Attributes.Add("onClick", "document.forms[0].reset();return false;");
    }

    // Upload attachments
    protected void Upload_Files(object sender, EventArgs e)
    {

        bool checkSCARType2 = false;
        bool checkSCARType4 = false;
        // Checks if Upload SCAR Type 2 Control has file(s)
        if(uploadSCARType2.HasFile)
        {
            Upload_SCAR_Type_2(); // Read files
        }
        else
        {
            checkSCARType2 = true;
        }

        // Checks if Upload SCAR Type 4 Control has file(s)
        if(uploadSCARType4.HasFile)
        {
            Upload_SCAR_Type_4(); // Read files
        }
        else
        {
            checkSCARType4 = true;
        }

        if (checkSCARType2 && checkSCARType4)
        {
            string message = "No files found! Please Try Again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
        }
    }

    // Read files from Upload SCAR Type 2 Control
    protected void Upload_SCAR_Type_2()
    {
        bool SCARType2 = true;
        string message = null;
        string successful_message = null;
        string failed_message = null;
        try
        {
            foreach (HttpPostedFile postedFile in uploadSCARType2.PostedFiles)
            {
                var allowedExtensions = new[] { ".txt" }; // Only allows .txt files
                var extension = Path.GetExtension(postedFile.FileName);
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;
                
                if (allowedExtensions.Contains(extension))
                {
                    // Reads file contents
                    using (StreamReader sr = new StreamReader(postedFile.InputStream))
                    {
                        String data = sr.ReadToEnd();
                        // Validation to determine if only SCAR Type 2 file is uploaded
                        if (data.Contains("for Type-4"))
                        {
                            SCARType2 = false;

                            message = "Only SCAR Type 2 Attachment(s) is allowed!";
                        }
                        if(SCARType2)
                        {
                            successful_message += filename + ", ";
                            Save_SCAR_Type_2(data, postedFile); // Saves file contents into database
                        }
                    }
                }
                else
                {
                    failed_message += filename + ", ";
                    
                }
            }

        }
        catch (Exception err)
        {
            message = "Unable to upload file(s)! Please Try Again!";
        }
        finally
        {
            // Attachments that failed to be uploaded
            if(failed_message != null)
            {
                failed_message += " failed to be uploaded! Only .txt files are allowed";
            }
            // Attachments that has been uploaded
            if(successful_message != null)
            {
                successful_message += " has been successfully uploaded!";
            }
            message = successful_message + "<br/><br/>" + failed_message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
        }
    }

    protected void Upload_SCAR_Type_4()
    {
        bool SCARType4 = true;
        string message = null;
        string successful_message = null;
        string failed_message = null;
        try
        {
            foreach (HttpPostedFile postedFile in uploadSCARType4.PostedFiles)
            {
                var allowedExtensions = new[] { ".txt" }; // Only allows .txt files
                var extension = Path.GetExtension(postedFile.FileName);
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;
                if (allowedExtensions.Contains(extension))
                {
                    // Reads file contents
                    using (StreamReader sr = new StreamReader(postedFile.InputStream))
                    {
                        String data = sr.ReadToEnd();
                        // Validation to determine if only SCAR Type 4 file is uploaded
                        if (!data.Contains("for Type-4"))
                        {
                            SCARType4 = false;
                            message = "Only SCAR Type 2 Attachment(s) is allowed!";
                        }
                        if (SCARType4)
                        {
                            successful_message += filename + ", ";
                            Save_SCAR_Type_4(data, postedFile); // Saves file contents into database
                        }
                    }
                    
                }
                else
                {
                    failed_message += filename + ", ";

                }
            }

        }
        catch (Exception err)
        {
            message = "Unable to upload file(s)! Please Try Again!";
        }
        finally
        {
            if (failed_message != null)
            {
                failed_message += " failed to be uploaded! Only .txt files are allowed";
            }
            if (successful_message != null)
            {
                successful_message += " has been successfully uploaded!";
            }
            message = successful_message + "<br/><br/>" + failed_message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
        }
    }

    // Saves file contents to database
    protected void Save_SCAR_Type_2(string data, HttpPostedFile postedFile)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        string[] tokensbody = data.Split('\n'); // splits each field into a single array element
        string[] notepad_data = new string[25];
        int count_data = 0;
        for (int jj = 5; jj < 40; jj++)
        {
            if (tokensbody[jj].Contains(":"))
            {
                string[] element_data = tokensbody[jj].Split(':'); // splits field based on the position of the colon (:) in the field
                char last_char = tokensbody[jj][tokensbody[jj].Length - 2]; // Checks last character
                element_data[1] = element_data[1].Trim(); // Removes white space before and after the field data
                if (last_char == ' ')
                {
                    // Sets the field as NA if the field is empty / null
                    notepad_data[count_data] += "N/A";
                    notepad_data[count_data] += element_data[1];
                    count_data++;
                }
                else
                {
                    // Stores the field data into the array 
                    notepad_data[count_data] += element_data[1];
                    count_data++;
                }

            }
            else
            {
                // Concatenate multiline field data into a single variable
                if (System.Text.RegularExpressions.Regex.IsMatch(tokensbody[jj], @"\d\w"))
                {
                    count_data--;
                    notepad_data[count_data] += tokensbody[jj];
                    count_data++;

                }
            }
        }

        con.Open();

        // Stores the respective fields into the object
        SCAR scar_details = new SCAR();
        scar_details.Car_no += notepad_data[0];
        scar_details.Car_revision += notepad_data[1];
        scar_details.Supplier_contact += notepad_data[8];
        scar_details.Issued_date += notepad_data[10];
        scar_details.Part_no += notepad_data[13];
        scar_details.Expected_date_close += notepad_data[22];

        SqlCommand select = new SqlCommand(@"SELECT scar_no, car_revision, supplier_contact, issued_date, part_no, expected_date_close FROM dbo.SCAR_Request 
WHERE scar_no = @scar_no AND car_revision = @car_revision AND supplier_contact = @supplier_contact AND issued_date = @issued_date AND part_no = @part_no AND 
expected_date_close = @expected_date_close", con);
        select.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
        select.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
        select.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
        select.Parameters.AddWithValue("@issued_date", scar_details.Issued_date);
        select.Parameters.AddWithValue("@part_no", scar_details.Part_no);
        select.Parameters.AddWithValue("@expected_date_close", scar_details.Expected_date_close);

        bool checkRows = false;

        // Checks for existing / duplicate records
        using (SqlDataReader reader = select.ExecuteReader())
        {
            if (reader.HasRows)
            {
                checkRows = true;
                string message = "Upload failed! " + scar_details.Car_no + " already existed!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
        }

        // If no duplicate records exist, store data into database
        if(!checkRows)
        {
            // Saves the file attachment to file manager directory
            scar_details.File_name = postedFile.FileName;
            postedFile.SaveAs(Server.MapPath(@"~\Text_Files\Type-2\" + scar_details.File_name.Trim()));
            scar_details.File_path = @"~\Text_Files\" + scar_details.File_name.Trim();

            SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, scar_no, 
car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
defect_type, non_conformity_reported, reject_reason, expected_date_close, save_status, file_name, file_path, scar_request_method, pending_action) VALUES (@scar_stage, @scar_type, @scar_status, @scar_no, @car_revision, @car_type, @pre_alert,
@related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description,
@business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close, @save_status, @file_name, 
@file_path, @scar_request_method, @pending_action)", con);

            DateTime issued_date = Convert.ToDateTime(notepad_data[10]);
            DateTime expected_date_close = Convert.ToDateTime(notepad_data[22]);
            addSite.Parameters.AddWithValue("@scar_stage", "New SCAR");
            addSite.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
            addSite.Parameters.AddWithValue("@scar_status", "Pending");
            addSite.Parameters.AddWithValue("@scar_no", notepad_data[0]);
            addSite.Parameters.AddWithValue("@car_revision", notepad_data[1]);
            addSite.Parameters.AddWithValue("@car_type", notepad_data[2]);
            addSite.Parameters.AddWithValue("@pre_alert", notepad_data[3]);
            addSite.Parameters.AddWithValue("@related_car_no", notepad_data[4]);
            addSite.Parameters.AddWithValue("@related_car_ref", notepad_data[5]);
            addSite.Parameters.AddWithValue("@originator", notepad_data[6]);
            addSite.Parameters.AddWithValue("@recurrence", notepad_data[7]);
            addSite.Parameters.AddWithValue("@supplier_contact", notepad_data[8]);
            addSite.Parameters.AddWithValue("@supplier_email", notepad_data[9]);
            addSite.Parameters.AddWithValue("@issued_date", issued_date);
            addSite.Parameters.AddWithValue("@originator_dept", notepad_data[11]);
            addSite.Parameters.AddWithValue("@originator_contact", notepad_data[12]);
            addSite.Parameters.AddWithValue("@part_no", notepad_data[13]);
            addSite.Parameters.AddWithValue("@part_description", notepad_data[14]);
            addSite.Parameters.AddWithValue("@business_unit", notepad_data[15]);
            addSite.Parameters.AddWithValue("@dept_pl", notepad_data[16]);
            addSite.Parameters.AddWithValue("@commodity", notepad_data[17]);
            addSite.Parameters.AddWithValue("@defect_quantity", Convert.ToInt16(notepad_data[18]));
            addSite.Parameters.AddWithValue("@defect_type", notepad_data[19]);
            addSite.Parameters.AddWithValue("@non_conformity_reported", notepad_data[20]);
            addSite.Parameters.AddWithValue("@reject_reason", notepad_data[21]);
            addSite.Parameters.AddWithValue("@expected_date_close", expected_date_close);
            addSite.Parameters.AddWithValue("@save_status", "submit");
            addSite.Parameters.AddWithValue("@file_name", scar_details.File_name);
            addSite.Parameters.AddWithValue("@file_path", scar_details.File_path);
            addSite.Parameters.AddWithValue("@scar_request_method", "auto");
            addSite.Parameters.AddWithValue("@pending_action", "Awaiting Engineer Response");
            addSite.ExecuteNonQuery();

            // Add into TAT Table
            /*SqlCommand insert_TAT = new SqlCommand(@"INSERT INTO dbo.TAT (SCAR_ID, employee_ID, issued_date, escalation_level, trigger_date, escalation_count, modified_by, last_modified) 
VALUES (@SCAR_ID, @employee_ID, @issued_date, @escalation_level, @trigger_date, @escalation_count, @modified_by, @last_modified)", con);
            insert_TAT.Parameters.AddWithValue("@SCAR_ID", notepad_data[0]);
            insert_TAT.Parameters.AddWithValue("@employee_ID", notepad_data[8]);
            insert_TAT.Parameters.AddWithValue("@issued_date", issued_date);
            insert_TAT.Parameters.AddWithValue("@escalation_level", 0);
            DateTime trigger_date = issued_date.AddDays(6);
            insert_TAT.Parameters.AddWithValue("@trigger_date", trigger_date);
            insert_TAT.Parameters.AddWithValue("@escalation_count", 0);
            insert_TAT.Parameters.AddWithValue("@modified_by", Jabil_Session.JabilSession.Current.employee_name);
            DateTime currentDateTime = DateTime.Now;
            insert_TAT.Parameters.AddWithValue("@last_modified", currentDateTime);
            insert_TAT.ExecuteNonQuery();*/
        }
        con.Close();
    }

    // Save data into database
    protected void Save_SCAR_Type_4(string data, HttpPostedFile postedFile)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();
        string[] tokensbody = data.Split('\n');
        string[] notepad_data = new string[25];
        int count_data = 0;
        SCAR scar_details = new SCAR();

        for (int jj = 5; jj < 40; jj++)
        {
            if (tokensbody[jj].Contains(":"))
            {
                string[] element_data = tokensbody[jj].Split(':'); // splits field based on the position of the colon (:) in the field
                char last_char = tokensbody[jj][tokensbody[jj].Length - 2]; // Checks last character
                element_data[1] = element_data[1].Trim(); // Removes white space before and after the field data
                if (last_char == ' ')
                {
                    // Sets the field as NA if the field is empty / null
                    notepad_data[count_data] += "N/A";
                    notepad_data[count_data] += element_data[1];
                    count_data++;
                }
                else
                {
                    // Stores the field data into the array 
                    notepad_data[count_data] += element_data[1];
                    count_data++;
                }

            }
            else
            {
                // Concatenate multiline field data into a single variable
                if (System.Text.RegularExpressions.Regex.IsMatch(tokensbody[jj], @"\d\w"))
                {
                    count_data--;
                    notepad_data[count_data] += tokensbody[jj];
                    count_data++;

                }
            }
        }

        scar_details.Car_no += notepad_data[0];
        scar_details.Car_revision += notepad_data[1];
        scar_details.Supplier_contact += notepad_data[8];
        scar_details.Issued_date += notepad_data[10];
        scar_details.Part_no += notepad_data[13];
        scar_details.Expected_date_close += notepad_data[22];

        SqlCommand select = new SqlCommand(@"SELECT scar_no, car_revision, supplier_contact, issued_date, part_no, expected_date_close FROM dbo.SCAR_Request 
WHERE scar_no = @scar_no AND car_revision = @car_revision AND supplier_contact = @supplier_contact AND issued_date = @issued_date AND part_no = @part_no AND 
expected_date_close = @expected_date_close", con);
        select.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
        select.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
        select.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
        select.Parameters.AddWithValue("@issued_date", scar_details.Issued_date);
        select.Parameters.AddWithValue("@part_no", scar_details.Part_no);
        select.Parameters.AddWithValue("@expected_date_close", scar_details.Expected_date_close);

        string scar_no = "";
        bool checkRows = false;

        // Check for existing records in the database
        using (SqlDataReader reader = select.ExecuteReader())
        {
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                   scar_no = Convert.ToString(reader["scar_no"]);
                   checkRows = true;
                }
                
            }
            else
            {
                string message = "No records of " + scar_details.Car_no + " have been found! Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
        }

        // If existing records exists, updates the SCAR Stage and SCAR Type of that particular record
        if(checkRows)
        { 
            if (data.Contains("S76-Verify Effectiveness of Corrective Actions Result"))
            {
                try
                {
                    // Update the status of the SCAR to pending and type 4
                    SqlCommand updateSCAR = new SqlCommand(@"UPDATE dbo.SCAR_Request SET scar_stage = @scar_stage, scar_type = @scar_type WHERE scar_no = @scar_no", con);
                    updateSCAR.Parameters.AddWithValue("@scar_stage", "Pending SCAR");
                    updateSCAR.Parameters.AddWithValue("@scar_type", "SCAR Type 4");
                    updateSCAR.Parameters.AddWithValue("@scar_no", scar_no);
                    updateSCAR.ExecuteNonQuery();
                    string message = "SCAR Type 4 Attachment(s) has been succesfully uploaded!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
                catch
                {
                    string message = "Unable to upload file(s)! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
                finally
                {
                    con.Close();
                }
                
            }
        }
       
    }

    /*protected void Send_Email(object sender, EventArgs e)
    {
        try
        {
            string path = "";
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection Sqlcon = new SqlConnection(con.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, file_name, file_path FROM dbo.SCAR_Request", Sqlcon);

                Sqlcon.Open();
               
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    path = Convert.ToString(rdr["file_name"]);
                }
            }
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("leeboonchung92@gmail.com");
            mail.To.Add("uowfypaug14@gmail.com");
            mail.Subject = "Test Mail - 1";
            mail.Body = "mail with attachment";

            string newPath = Server.MapPath(@"~\Text_Files\" + path);

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(newPath);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("leeboonchung92@gmail.com", "boyslikegirls92");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            lblSCARType4.Text = "Mail Send";
        }
        catch (Exception err)
        {
            
        }
    }*/
   
}



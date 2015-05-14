using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class Admin_TAT : System.Web.UI.Page
{
    struct TAT_Relationship
    {
        public string eid;
        public string ename;
        public string email;
        public string qm_name;
        public string qm_email;
        public string wcm_name;
        public string wcm_email;
    };
    
    struct SCAR_Rec
    {
        public string car_no;
        public string supplier_contact;
        public DateTime issued_date;
        public string scar_status;
    };

    struct TAT_Rec
    {
        public string SCAR_ID;
        public string employee_ID;
        public DateTime issued_date;
        public int escalation_level;
        public DateTime trigger_date;
        public int escalation_count;
    };

    struct TAT_Ref
    {
        public int escalation_level;
        public string escalation_level_desc;
        public int days_to_escalation;
        public bool notify_QM;
        public bool notify_WCM;
    };


    protected void Page_Load(object sender, EventArgs e)
    {
        insert1000();
        if (!this.IsPostBack)
        {
            //Populating a DataTable from database.
            DataTable dt = this.GetSCAR();
            DataTable dt2 = this.GetTAT();
            DataTable dt3 = this.GetTATRef();
            DataTable dt4 = this.GetTATRelationship();

            SCAR_Rec[] mTAT = new SCAR_Rec[dt.Rows.Count];  // Get the values from SCAR table
            TAT_Rec[] rTAT = new TAT_Rec[dt2.Rows.Count];   // Get the values from TAT table
            TAT_Ref[] refTAT = new TAT_Ref[dt3.Rows.Count]; // Get the values from TAT Reference table
            TAT_Relationship[] relTAT = new TAT_Relationship[dt4.Rows.Count]; // Get the value from TAT Relationship table

            int x = 0, y = 0, z = 0, r = 0;
            foreach(DataRow row in dt.Rows)
            {
                mTAT[x].car_no = row["car_no"].ToString();
                mTAT[x].supplier_contact = row["supplier_contact"].ToString();
                mTAT[x].issued_date = DateTime.Parse(row["issued_date"].ToString());
                mTAT[x].scar_status = row["scar_status"].ToString();
                x++;
            }

            foreach (DataRow row in dt2.Rows)
            {
                rTAT[y].SCAR_ID = row["SCAR_ID"].ToString();
                rTAT[y].employee_ID = row["employee_ID"].ToString();
                rTAT[y].issued_date = DateTime.Parse(row["issued_date"].ToString());
                rTAT[y].escalation_level = int.Parse(row["escalation_level"].ToString());
                rTAT[y].trigger_date = DateTime.Parse(row["trigger_date"].ToString());
                rTAT[y].escalation_count = int.Parse(row["escalation_count"].ToString());
                y++;
            }

            foreach (DataRow row in dt3.Rows)
            {
                refTAT[z].escalation_level = int.Parse(row["escalation_level"].ToString());
                refTAT[z].escalation_level_desc = row["escalation_level_desc"].ToString();
                refTAT[z].days_to_escalation = int.Parse(row["days_to_escalation"].ToString());
                refTAT[z].notify_QM = bool.Parse(row["notify_QM"].ToString());
                refTAT[z].notify_WCM = bool.Parse(row["notify_WCM"].ToString());
                z++;
            }

            foreach (DataRow row in dt4.Rows)
            {
                relTAT[r].eid = row["employee_ID"].ToString();
                relTAT[r].ename = row["employee_name"].ToString();
                relTAT[r].email = row["employee_email"].ToString();
                relTAT[r].qm_name = row["qm_name"].ToString();
                relTAT[r].qm_email = row["qm_email"].ToString();
                relTAT[r].wcm_name = row["wcm_name"].ToString();
                relTAT[r].wcm_email = row["wcm_email"].ToString();
                r++;
            }

            bool new_record = true;
            for(int i = 0; i < x; i++)
            {
                new_record = true;
                if (mTAT[i].scar_status == "Pending") 
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (mTAT[i].car_no == rTAT[j].SCAR_ID)
                        {
                            new_record = false;
                            if (rTAT[j].trigger_date < DateTime.Now)
                            {
                                if (rTAT[j].escalation_level < 6)
                                {
                                    rTAT[j].escalation_level++;
                                    if(refTAT[rTAT[j].escalation_level].escalation_level_desc.Contains("Escalation"))
                                    {
                                        rTAT[j].escalation_count++;
                                    }
                                    
                                }
                                
                                string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
                                // Update the TAT entry in the database with the next triggering date
                                using (SqlConnection connection = new SqlConnection(constr))
                                {
                                    SqlCommand cmd = new SqlCommand("UPDATE TAT SET escalation_level = @escalation_level, trigger_date = @trigger_date, escalation_count = @escalation_count WHERE SCAR_ID = @SCAR_ID");
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = connection;
                                    cmd.Parameters.AddWithValue("@SCAR_ID", rTAT[j].SCAR_ID);
                                    cmd.Parameters.AddWithValue("@escalation_level", rTAT[j].escalation_level);
                                    cmd.Parameters.AddWithValue("@trigger_date", rTAT[j].trigger_date.AddDays(refTAT[rTAT[j].escalation_level].days_to_escalation));
                                    cmd.Parameters.AddWithValue("@escalation_count", rTAT[j].escalation_count);
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                for (int k = 0; k < r; k++)
                                {
                                    if(relTAT[k].ename == mTAT[i].supplier_contact)
                                    {
                                        // Create a new notification
                                        using (SqlConnection connection = new SqlConnection(constr))
                                        {
                                            SqlCommand cmd = new SqlCommand("INSERT INTO Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @NoticeFrom, @NoticeTo, @NoticeSubject, @NoticeBody, @NoticeTimestamp, @ReadStatus);");
                                            cmd.CommandType = CommandType.Text;
                                            cmd.Connection = connection;
                                            cmd.Parameters.AddWithValue("@hash", CalculateMD5Hash(relTAT[k].ename + mTAT[i].car_no + refTAT[rTAT[j].escalation_level].escalation_level_desc));
                                            cmd.Parameters.AddWithValue("@NoticeFrom", "TAT Reporting Services");
                                            cmd.Parameters.AddWithValue("@NoticeTo", relTAT[k].ename);
                                            cmd.Parameters.AddWithValue("@NoticeSubject", mTAT[i].car_no + " " + refTAT[rTAT[j].escalation_level].escalation_level_desc);
                                            cmd.Parameters.AddWithValue("@NoticeBody", "SCAR Request " + mTAT[i].car_no + " has been created");
                                            cmd.Parameters.AddWithValue("@NoticeTimestamp", DateTime.Now.Date);
                                            cmd.Parameters.AddWithValue("@ReadStatus", false);
                                            connection.Open();
                                            cmd.ExecuteNonQuery();
                                        }

                                        if(refTAT[rTAT[j].escalation_level].notify_QM)
                                        {
                                            // Create a new notification
                                            using (SqlConnection connection = new SqlConnection(constr))
                                            {
                                                SqlCommand cmd = new SqlCommand("INSERT INTO Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @NoticeFrom, @NoticeTo, @NoticeSubject, @NoticeBody, @NoticeTimestamp, @ReadStatus);");
                                                cmd.CommandType = CommandType.Text;
                                                cmd.Connection = connection;
                                                cmd.Parameters.AddWithValue("@hash", CalculateMD5Hash(relTAT[k].qm_name + mTAT[i].car_no + refTAT[rTAT[j].escalation_level].escalation_level_desc));
                                                cmd.Parameters.AddWithValue("@NoticeFrom", "TAT Reporting Services");
                                                cmd.Parameters.AddWithValue("@NoticeTo", relTAT[k].qm_name);
                                                cmd.Parameters.AddWithValue("@NoticeSubject", mTAT[i].car_no + " " + refTAT[rTAT[j].escalation_level].escalation_level_desc);
                                                cmd.Parameters.AddWithValue("@NoticeBody", "SCAR Request " + mTAT[i].car_no + " is not complete");
                                                cmd.Parameters.AddWithValue("@NoticeTimestamp", DateTime.Now.Date);
                                                cmd.Parameters.AddWithValue("@ReadStatus", false);
                                                connection.Open();
                                                cmd.ExecuteNonQuery();
                                            }
                                        }

                                        if (refTAT[rTAT[j].escalation_level].notify_WCM)
                                        {
                                            // Create a new notification
                                            using (SqlConnection connection = new SqlConnection(constr))
                                            {
                                                SqlCommand cmd = new SqlCommand("INSERT INTO Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @NoticeFrom, @NoticeTo, @NoticeSubject, @NoticeBody, @NoticeTimestamp, @ReadStatus);");
                                                cmd.CommandType = CommandType.Text;
                                                cmd.Connection = connection;
                                                cmd.Parameters.AddWithValue("@hash", CalculateMD5Hash(relTAT[k].wcm_name + mTAT[i].car_no + refTAT[rTAT[j].escalation_level].escalation_level_desc));
                                                cmd.Parameters.AddWithValue("@NoticeFrom", "TAT Reporting Services");
                                                cmd.Parameters.AddWithValue("@NoticeTo", relTAT[k].wcm_name);
                                                cmd.Parameters.AddWithValue("@NoticeSubject", mTAT[i].car_no + " " + refTAT[rTAT[j].escalation_level].escalation_level_desc);
                                                cmd.Parameters.AddWithValue("@NoticeBody", "SCAR Request " + mTAT[i].car_no + " is not complete");
                                                cmd.Parameters.AddWithValue("@NoticeTimestamp", DateTime.Now.Date);
                                                cmd.Parameters.AddWithValue("@ReadStatus", false);
                                                connection.Open();
                                                cmd.ExecuteNonQuery();
                                            }
                                        }

                                    }
                                }                                    
                            }
                        }
                    }

                    // Create new TAT record for new SCAR Request
                    if (new_record)
                    {
                        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(constr))
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO TAT (SCAR_ID, employee_ID, issued_date, escalation_level, trigger_date, escalation_count) VALUES (@SCAR_ID, @employee_ID, @issued_date, @escalation_level, @trigger_date, @escalation_count);");
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@SCAR_ID", mTAT[i].car_no);
                            cmd.Parameters.AddWithValue("@employee_ID", mTAT[i].supplier_contact);
                            cmd.Parameters.AddWithValue("@issued_date", mTAT[i].issued_date);
                            cmd.Parameters.AddWithValue("@escalation_level", 0);
                            cmd.Parameters.AddWithValue("@trigger_date", mTAT[i].issued_date.AddDays(refTAT[0].days_to_escalation));
                            cmd.Parameters.AddWithValue("@escalation_count", 0);
                            cmd.ExecuteNonQuery();
                        }
                        // Send notification to QE
                        using (SqlConnection connection = new SqlConnection(constr))
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @NoticeFrom, @NoticeTo, @NoticeSubject, @NoticeBody, @NoticeTimestamp, @ReadStatus);");
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@hash", CalculateMD5Hash(mTAT[i].supplier_contact + mTAT[i].car_no + refTAT[0].escalation_level_desc));
                            cmd.Parameters.AddWithValue("@NoticeFrom", "TAT Reporting Services");
                            cmd.Parameters.AddWithValue("@NoticeTo", mTAT[i].supplier_contact);
                            cmd.Parameters.AddWithValue("@NoticeSubject", mTAT[i].car_no + " " + refTAT[0].escalation_level_desc);
                            cmd.Parameters.AddWithValue("@NoticeBody", "SCAR Request " + mTAT[i].car_no + " has been created");
                            cmd.Parameters.AddWithValue("@NoticeTimestamp", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@ReadStatus", 0);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        for (int k = 0; k < r; k++)
                        {
                            if (relTAT[k].ename == mTAT[i].supplier_contact)
                            {
                                // Send notification to QM
                                using (SqlConnection connection = new SqlConnection(constr))
                                {
                                    SqlCommand cmd = new SqlCommand("INSERT INTO Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @NoticeFrom, @NoticeTo, @NoticeSubject, @NoticeBody, @NoticeTimestamp, @ReadStatus);");
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = connection;
                                    cmd.Parameters.AddWithValue("@hash", CalculateMD5Hash(relTAT[k].qm_name + mTAT[i].car_no + refTAT[0].escalation_level_desc));
                                    cmd.Parameters.AddWithValue("@NoticeFrom", "TAT Reporting Services");
                                    cmd.Parameters.AddWithValue("@NoticeTo", relTAT[k].qm_name);
                                    cmd.Parameters.AddWithValue("@NoticeSubject", mTAT[i].car_no + " " + refTAT[0].escalation_level_desc);
                                    cmd.Parameters.AddWithValue("@NoticeBody", "SCAR Request " + mTAT[i].car_no + " has been created");
                                    cmd.Parameters.AddWithValue("@NoticeTimestamp", DateTime.Now.Date);
                                    cmd.Parameters.AddWithValue("@ReadStatus", 0);
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                }

                                // Send notification to WCM
                                using (SqlConnection connection = new SqlConnection(constr))
                                {
                                    SqlCommand cmd = new SqlCommand("INSERT INTO Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @NoticeFrom, @NoticeTo, @NoticeSubject, @NoticeBody, @NoticeTimestamp, @ReadStatus);");
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = connection;
                                    cmd.Parameters.AddWithValue("@hash", CalculateMD5Hash(relTAT[k].wcm_name + mTAT[i].car_no + refTAT[0].escalation_level_desc));
                                    cmd.Parameters.AddWithValue("@NoticeFrom", "TAT Reporting Services");
                                    cmd.Parameters.AddWithValue("@NoticeTo", relTAT[k].wcm_name);
                                    cmd.Parameters.AddWithValue("@NoticeSubject", mTAT[i].car_no + " " + refTAT[0].escalation_level_desc);
                                    cmd.Parameters.AddWithValue("@NoticeBody", "SCAR Request " + mTAT[i].car_no + " has been created");
                                    cmd.Parameters.AddWithValue("@NoticeTimestamp", DateTime.Now.Date);
                                    cmd.Parameters.AddWithValue("@ReadStatus", 0);
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                else if(mTAT[i].scar_status == "Complete")
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (mTAT[i].car_no == rTAT[j].SCAR_ID)
                        {
                            string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
                            using (SqlConnection connection = new SqlConnection(constr))
                            {
                                SqlCommand cmd = new SqlCommand("DELETE FROM TAT WHERE SCAR_ID = @SCAR_ID");
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = connection;
                                cmd.Parameters.AddWithValue("@SCAR_ID", rTAT[j].SCAR_ID);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            dt2 = this.GetTAT();
            GridView2.DataSource = dt2;
            GridView2.DataBind();
        }
    }

    private DataTable GetTATRelationship()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT employee_ID, employee_name, employee_email, qm_name, qm_email, wcm_name, wcm_email FROM TAT_Relationship"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable GetTAT()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT SCAR_ID, employee_ID, issued_date, escalation_level, trigger_date, escalation_count FROM TAT"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable GetTATRef()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT escalation_level, escalation_level_desc, days_to_escalation, notify_QM, notify_WCM FROM TAT_Reference"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable GetSCAR()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT car_no, supplier_contact, issued_date, scar_status FROM dbo.[SCAR_request]"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    public string CalculateMD5Hash(string input)
    {
        // step 1, calculate MD5 hash from input
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }

    private void insert1000()
    {
        int no = 150920;
        DateTime dd = DateTime.Parse("2014-01-03");
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        string[] dc = new string []{ "Component", "Placement", "Termination", "Assembly", "Non Product"};
        // Send notification to WCM
        for(int i=0; i < 100; i++)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SCAR_Request] ([scar_stage],[scar_type],[scar_status],[car_no],[car_revision],[car_type],[pre_alert],[related_car_no],[related_car_ref],[originator],[recurrence],[supplier_contact],[supplier_email],[issued_date],[originator_dept],[originator_contact],[part_no],[part_description],[business_unit],[dept_pl],[commodity],[defect_quantity],[defect_type],[non_conformity_reported],[reject_reason],[expected_date_close],[save_status],[file_name],[file_path]) VALUES  (@scar_stage, @scar_type, @scar_status, @car_no, @car_revision, @car_type, @pre_alert, @related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description, @business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close, @save_status, @file_name, @file_path)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@scar_stage",  "New SCAR");
                cmd.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
                cmd.Parameters.AddWithValue("@scar_status", "Pending");
                cmd.Parameters.AddWithValue("@car_no", "P-SOQANP-"+no);
                cmd.Parameters.AddWithValue("@car_revision", "A");
                cmd.Parameters.AddWithValue("@car_type", "OQA");
                cmd.Parameters.AddWithValue("@pre_alert", "Yes");
                cmd.Parameters.AddWithValue("@related_car_no", "P-IOQANP-140909");
                cmd.Parameters.AddWithValue("@related_car_ref", "A");
                cmd.Parameters.AddWithValue("@originator", "Hairul Azam bin Hassan");
                cmd.Parameters.AddWithValue("@recurrence", "N/A");
                cmd.Parameters.AddWithValue("@supplier_contact", "Shazmeen Zainudin");
                cmd.Parameters.AddWithValue("@supplier_email", "shazmeen_zainidin@jabil.com");
                cmd.Parameters.AddWithValue("@issued_date", dd);
                cmd.Parameters.AddWithValue("@originator_dept", "WBU-CTD");
                cmd.Parameters.AddWithValue("@originator_contact", "6807891");
                cmd.Parameters.AddWithValue("@part_no", "E5071C");
                cmd.Parameters.AddWithValue("@part_description", "Carnelian");
                cmd.Parameters.AddWithValue("@business_unit", "CTD");
                cmd.Parameters.AddWithValue("@dept_pl", "PLWN-DTA");
                cmd.Parameters.AddWithValue("@commodity", "Box Build");
                cmd.Parameters.AddWithValue("@defect_quantity", 1);
                int n;
                n = new Random().Next(0, 4);
                cmd.Parameters.AddWithValue("@defect_type", dc[n]);
                cmd.Parameters.AddWithValue("@non_conformity_reported", "abc");
                cmd.Parameters.AddWithValue("@reject_reason", "abc");
                cmd.Parameters.AddWithValue("@expected_date_close", dd.AddDays(3));
                cmd.Parameters.AddWithValue("@save_status", "submit");
                cmd.Parameters.AddWithValue("@file_name", "");
                cmd.Parameters.AddWithValue("@file_path", "");
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            dd = dd.AddDays(7);
            no++;
        }
    }
}
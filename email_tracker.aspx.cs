using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
public partial class email_tracker : Page
{
    protected List<Email> Emails
    {
        get { return (List<Email>)ViewState["Emails"]; }
        set { ViewState["Emails"] = value; }
    }
    /*protected void Timer1_Tick(object sender, EventArgs e)
    {
        Read_Emails();
    }*/

    protected void Page_Load(object sender, EventArgs e)
    {

        this.Read_Emails();
    }

    private void Read_Emails()
    {
        Pop3Client pop3Client;
        if (Session["Pop3Client"] == null)
        {
            pop3Client = new Pop3Client();
            pop3Client.Connect("pop.gmail.com", 995, true);
            pop3Client.Authenticate("uowfypaug14@gmail.com", "uowfypaug", AuthenticationMethod.Auto);
            Session["Pop3Client"] = pop3Client;
        }
        else
        {
            pop3Client = (Pop3Client)Session["Pop3Client"];
        }
        int count = pop3Client.GetMessageCount();
        this.Emails = new List<Email>();
        string[] storeAttach = new string[count];
        string[] storeName = new string[count];
        string[] storeTitle = new string[count];
        int counter = 0;
        int count_emails = 0;
        for (int i = count; i >= 1; i--)
        {

            Message message = pop3Client.GetMessage(i);
            Email email = new Email()
            {
                MessageNumber = i,
                Subject = message.Headers.Subject,
                DateSent = message.Headers.DateSent,
                From = string.Format("<a href = 'mailto:{1}'>{0}</a>", message.Headers.From.DisplayName, message.Headers.From.Address),
            };
            string emailAddress = message.Headers.From.Address;
            if (emailAddress == "bclee_92@hotmail.com")
            {
                storeTitle[count_emails] = message.Headers.Subject;
                MessagePart body = message.FindFirstHtmlVersion();
                if (body != null)
                {
                    email.Body = body.GetBodyAsText();
                }
                else
                {
                    body = message.FindFirstPlainTextVersion();
                    if (body != null)
                    {
                        email.Body = body.GetBodyAsText();
                    }
                }
                List<MessagePart> attachments = message.FindAllAttachments();
                foreach (MessagePart attachment in attachments)
                {
                    email.Attachments.Add(new Attachment
                    {
                        FileName = attachment.FileName,
                        ContentType = attachment.ContentType.MediaType,
                        Content = attachment.Body

                    });
                    storeAttach[count_emails] = System.Text.Encoding.Default.GetString(attachment.Body);
                    storeName[count_emails] = attachment.FileName;
                }

                count_emails++;
                this.Emails.Add(email);
                counter++;
            }
        }
        gvEmails.DataSource = this.Emails;
        gvEmails.DataBind();
        //test.Text = storeName[0];
        //test.Text += storeName[1];
        //test.Text = storeAttach[0];
        //test.Text += storeAttach[1];
        //test.Text = storeTitle[0];


        string scarRequest = "Supplier Corrective Action Request";
        string scarNotification = "Supplier Corrective Action";
        string scarType2 = "Type 2";
        string scarType4 = "Type 4";
        string statusCompleted = "Completed";
        string scarClosed = "SCAR Closed";
        string approvalNotification = "Approval Notification";
        string approvalRejected = "Rejected";
        string scarStage;
        bool readTextFile = false;

        for (int ii = 0; ii < count_emails; ii++)
        {
            if (storeTitle[ii].Contains(scarRequest) && storeTitle[ii].Contains(scarType2))
            {
                scarStage = "SCAR Type 2 Request";
                readTextFile = true;
            }
            else if (storeTitle[ii].Contains(scarNotification) && storeTitle[ii].Contains(scarType2) && storeTitle[ii].Contains(statusCompleted))
            {
                scarStage = "SCAR Type 2 Completion";
                readTextFile = true;
            }
            else if (storeTitle[ii].Contains(scarRequest) && storeTitle[ii].Contains(scarType4))
            {
                scarStage = "SCAR Type 4 Request";
                readTextFile = true;
            }
            else if (storeTitle[ii].Contains(scarNotification) && storeTitle[ii].Contains(scarType4) && storeTitle[ii].Contains(statusCompleted))
            {
                scarStage = "SCAR Type 4 Acknowledgement";
                readTextFile = true;
            }
            else if (storeTitle[ii].Contains(scarClosed))
            {
                scarStage = "SCAR Closure";
                readTextFile = true;
            }
            else if (storeTitle[ii].Contains(approvalNotification) && storeTitle[ii].Contains(approvalRejected))
            {
                scarStage = "SCAR Reject";
                readTextFile = true;
            }

            if (readTextFile)
            {
                string fileName = storeName[ii];

                string[] tokens = fileName.Split('_', '.');

                for (int jj = 0; jj < tokens.Count(); jj++)
                {
                    //test.Text += tokens[jj];
                }

                string carNo = tokens[0];
                string revision = tokens[1];
                string engineerName = tokens[2];
            }
        }
        store_textfile_data(storeAttach);
        Session.Abandon();

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Repeater rptAttachments = (e.Row.FindControl("rptAttachments") as Repeater);
            List<Attachment> attachments = this.Emails.Where(email => email.MessageNumber == Convert.ToInt32(gvEmails.DataKeys[e.Row.RowIndex].Value)).FirstOrDefault().Attachments;
            rptAttachments.DataSource = attachments;
            rptAttachments.DataBind();
        }
    }

    protected void store_textfile_data(string[] storeAttach)
    {
        SqlConnection con;
        SqlDataReader reader;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        string emailbody = storeAttach[0];
        bool checkString = false;
        string[] tokensbody = emailbody.Split('\n');
        string [] notepad_data = new string [25];
        int count_data = 0;
        for (int jj = 5; jj < 40; jj++)
        {
            if (tokensbody[jj].Contains(":"))
            {
                string[] element_data = tokensbody[jj].Split(':');
                char last_char = tokensbody[jj][tokensbody[jj].Length - 2];
                if (last_char == ' ')
                {
                    notepad_data[count_data] += "NA";
                    notepad_data[count_data] += element_data[1];
                    count_data++;
                }
                else
                {
                    notepad_data[count_data] += element_data[1];
                    count_data++;
                }
                
            }
            else
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(tokensbody[jj], @"\d\w"))
                {
                    count_data--;
                    notepad_data[count_data] += tokensbody[jj];
                    count_data++;
                   
                }
            }
        }

          con.Open();
        SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, car_no, 
car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
defect_type, non_conformity_reported, reject_reason, expected_date_close) VALUES (@scar_stage, @scar_type, @scar_status, @car_no, @car_revision, @car_type, @pre_alert,
@related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description,
@business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close)", con);

        DateTime issued_date = Convert.ToDateTime(notepad_data[10]);
        DateTime expected_date_close = Convert.ToDateTime(notepad_data[22]);
        addSite.Parameters.AddWithValue("@scar_stage", "New SCAR");
        addSite.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
        addSite.Parameters.AddWithValue("@scar_status", "Pending");
        addSite.Parameters.AddWithValue("@car_no", notepad_data[0]);
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
            
        addSite.ExecuteNonQuery();
        con.Close();
    }

}
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

public partial class email_tracker : Page
{
    protected List<Email> Emails
    {
        get { return (List<Email>)ViewState["Emails"]; }
        set { ViewState["Emails"] = value; }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Read_Emails();
    }

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
   
}
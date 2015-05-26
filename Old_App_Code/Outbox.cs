using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Email_Alert
{
    public class Outbox
    {
        // Declaration of Email Details
        private string EmailFrom = "";
        private string EmailTo = "";
        private string EmailCC_List = "";
        private string EmailSubject = "";
        private string EmailBody = "";
        private string EmailHostID = "";
        private string EmailfileName = "";
        private string EmailfileExt = "";
        private string EmailAttachment = "";
        private string EmailTimestamp = "";

        // Accessors and Mutators for the Email details
        public string Email_From
        {
            get
            {
                return EmailFrom;
            }
            set
            {
                EmailFrom = value;
            }
        }

        public string Email_To
        {
            get
            {
                return EmailTo;
            }
            set
            {
                EmailTo = value;
            }
        }

        public string Email_CC_List
        {
            get
            {
                return EmailCC_List;
            }
            set
            {
                EmailCC_List = value;
            }
        }
        
        public string Email_Subject
        {
            get
            {
                return EmailSubject;
            }
            set
            {
                EmailSubject = value;
            }
        }

        public string Email_Body
        {
            get
            {
                return EmailBody;
            }
            set
            {
                EmailBody = value;
            }
        }
        
        public string Email_HostID
        {
            get
            {
                return EmailHostID;
            }
            set
            {
                EmailHostID = value;
            }
        }
        
        public string Email_fileName
        {
            get
            {
                return EmailfileName;
            }
            set
            {
                EmailfileName = value;
            }
        }

        public string Email_fileExt
        {
            get
            {
                return EmailfileExt;
            }
            set
            {
                EmailfileExt = value;
            }
        }

        public string Email_Attachment
        {
            get
            {
                return EmailAttachment;
            }
            set
            {
                EmailAttachment = value;
            }
        }

        public string Email_Timestamp
        {
            get
            {
                return EmailTimestamp;
            }
            set
            {
                EmailTimestamp = value;
            }
        }

        // Insert all the details into the EmailAlert Table
        public void Insert_Email(string DatabaseName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT dbo.EmailAlert (EmailFrom, EmailTo, EmailCC_List, EmailSubject, EmailBody, EmailHostID, EmailfileName, EmailfileExt, EmailAttachment, EmailTimestamp) VALUES (@EmailFrom, @EmailTo, @EmailCC_List, @EmailSubject, @EmailBody,@ EmailHostID, @EmailfileName, @EmailfileExt, @EmailAttachment, @EmailTimestamp)";
            cmd.Parameters.AddWithValue("@EmailFrom", EmailFrom);
            cmd.Parameters.AddWithValue("@EmailTo", EmailTo);
            cmd.Parameters.AddWithValue("@EmailCC_List", EmailCC_List);
            cmd.Parameters.AddWithValue("@EmailSubject", EmailSubject);
            cmd.Parameters.AddWithValue("@EmailBody", EmailBody);
            cmd.Parameters.AddWithValue("@EmailHostID", EmailHostID);
            cmd.Parameters.AddWithValue("@EmailfileName", EmailfileName);
            cmd.Parameters.AddWithValue("@EmailfileExt", EmailfileExt);
            cmd.Parameters.AddWithValue("@EmailAttachment", EmailAttachment);
            cmd.Parameters.AddWithValue("@EmailTimestamp", EmailTimestamp);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
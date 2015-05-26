using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Notice_Alert
{
    public class Notification
    {
        // Declaration of Email Details
        private string hash = "";
        private string NoticeFrom = "";
        private string NoticeTo = "";
        private string NoticeSubject = "";
        private string NoticeBody = "";
        private string NoticeTimestamp = "";
        private bool ReadStatus = false;
        
        // Accessors and Mutators for the Email details
        public string Hash
        {
            get
            {
                return hash;
            }
            set
            {
                hash = value;
            }
        }

        public string Notice_From
        {
            get
            {
                return NoticeFrom;
            }
            set
            {
                NoticeFrom = value;
            }
        }

        public string Notice_To
        {
            get
            {
                return NoticeTo;
            }
            set
            {
                NoticeTo = value;
            }
        }

        public string Notice_Subject
        {
            get
            {
                return NoticeSubject;
            }
            set
            {
                NoticeSubject = value;
            }
        }

        public string Notice_Body
        {
            get
            {
                return NoticeBody;
            }
            set
            {
                NoticeBody = value;
            }
        }

        public string Notice_Timestamp
        {
            get
            {
                return NoticeTimestamp;
            }
            set
            {
                NoticeTimestamp = value;
            }
        }

        public bool Read_Status
        {
            get
            {
                return ReadStatus;
            }
            set
            {
                ReadStatus = value;
            }
        }

        // Insert all the details into the EmailAlert Table
        public void Insert_Email(string DatabaseName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT dbo.Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) VALUES (@hash, @Notice_From, @Notice_To, @Notice_Subject, @Notice_Body, @Notice_Timestamp, @Read_Status)";
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@Notice_From", Notice_From);
            cmd.Parameters.AddWithValue("@Notice_To", Notice_To);
            cmd.Parameters.AddWithValue("@Notice_Subject", Notice_Subject);
            cmd.Parameters.AddWithValue("@Notice_Body", Notice_Body);
            cmd.Parameters.AddWithValue("@Notice_Timestamp", Notice_Timestamp);
            cmd.Parameters.AddWithValue("@Read_Status", Read_Status);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
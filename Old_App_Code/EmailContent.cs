using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_WebApp.Old_App_Code
{
    public class EmailContent
    {
        private const string email_header = "SCAR - 8D Approval Request";
        public string Email_header { get { return email_header; } }

        private const string email_content = "You have one pending 8D Approval Request!";
        public string Email_content { get { return email_header; } }
    }
}
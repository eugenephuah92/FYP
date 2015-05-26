using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_Escalation_Level
{
    public class NEL
    {
        // Declaration of New Escalation Level Details
        private string nel_description;
        private bool quality_engineer_lead;
        private bool quality_manager;
        private int duration;
        private string email_content;

        // Accessors and Mutators for the SCAR details
        public string NEL_Description
        {
            get
            {
                return nel_description;
            }
            set
            {
                nel_description = value;
            }
        }
        public bool QEL_Checked
        {
            get
            {
                return quality_engineer_lead;
            }
            set
            {
                quality_engineer_lead = value;
            }
        }
        public bool QM_Checked
        {
            get
            {
                return quality_manager;
            }
            set
            {
                quality_manager = value;
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        public string Email_Content
        {
            get
            {
                return email_content;
            }
            set
            {
                email_content = value;
            }
        }
    }
}
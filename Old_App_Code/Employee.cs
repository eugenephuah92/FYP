using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jabil_Employee
{
    public class Employee
    {
        private string employee_ID;
        private string employee_name;
        private string employee_email;
        private string employee_position;
        private string employee_password;
        private string privilege;

        public string Employee_ID
        {
            get
            {
                return employee_ID;
            }
            set
            {
                employee_ID = value;
            }
        }

        public string Employee_name
        {
            get
            {
                return employee_name;
            }
            set
            {
                employee_name = value;
            }
        }

        public string Employee_email
        {
            get
            {
                return employee_email;
            }
            set
            {
                employee_email = value;
            }
        }

        public string Employee_position
        {
            get
            {
                return employee_position;
            }
            set
            {
                employee_position = value;
            }
        }

        public string Employee_password
        {
            get
            {
                return employee_password;
            }
            set
            {
                employee_password = value;
            }
        }

       public string Privilege
        {
           get
           {
                return privilege;
           }
           set
           {
               privilege = value;
           }
        }
    }

    
}
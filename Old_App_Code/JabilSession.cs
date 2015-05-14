using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

namespace Jabil_Session
{
    public class JabilSession
    {
       
        private JabilSession()
        {

        }

        public static JabilSession Current
        {
            get
            {
                JabilSession session =
                  (JabilSession)HttpContext.Current.Session["__JabilSession__"];
                if (session == null)
                {
                    session = new JabilSession();
                    HttpContext.Current.Session["__JabilSession__"] = session;
                }
                return session;
            }
        }

        public string userID {get; set;}
        public string employee_name { get; set; }

        public string employee_position { get; set; }

        public string privilege { get; set; }
    }
}
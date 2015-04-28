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

namespace FYP_WebApp
{
    public partial class Notification : System.Web.UI.Page
    {
        struct Notice
        {
            public string NoticeFrom;
            public string NoticeTo;
            public string NoticeSubject;
            public string NoticeBody;
            public string NoticeTimestamp;
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            
                //Populating a DataTable from database.
                DataTable dt = this.GetNotice();
                Notice[] note = new Notice[dt.Rows.Count];
                StringBuilder html = new StringBuilder(); // building a HTML string
                html.Append("<table border='1'>");
                Placeholder1.Controls.Add(new Literal { Text = html.ToString() });
                int x = 0;
                foreach (DataRow row in dt.Rows)
                {
                    html = new StringBuilder(); // building a HTML string
                    note[x].NoticeFrom = row["NoticeFrom"].ToString();
                    note[x].NoticeTo = row["NoticeTo"].ToString();
                    note[x].NoticeSubject = row["NoticeSubject"].ToString();
                    note[x].NoticeBody = row["NoticeBody"].ToString();
                    note[x].NoticeTimestamp = row["NoticeTimestamp"].ToString();
                    
                    html.Append("<tr>");
                    html.Append("<td>" + note[x].NoticeFrom + "</td>");
                    html.Append("<td>" + note[x].NoticeTo + "</td>");
                    html.Append("<td>" + note[x].NoticeSubject + "<br />" + note[x].NoticeBody + "</td>");
                    html.Append("<td>" + note[x].NoticeTimestamp + "</td>");
                    html.Append("<td>");
                    Placeholder1.Controls.Add(new Literal { Text = html.ToString() });
                    html = new StringBuilder(); // building a HTML string
                    Button btnRead1 = new Button();
                    btnRead1.ID = "btnRead" + x;
                    btnRead1.Text = "I have read the message";
                    btnRead1.CommandArgument = note[x].NoticeSubject;
                    btnRead1.Click += myBtnHandler;
                    Placeholder1.Controls.Add(btnRead1);
                    html.Append("</td>");
                    html.Append("</tr>");
                    x++;
                }
                html.Append("</table>");
                Placeholder1.Controls.Add(new Literal { Text = html.ToString() });

                GridView2.DataSource = dt;
                GridView2.DataBind();

                
           
        }
 
        private DataTable GetNotice()
        {
            string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT NoticeFrom, NoticeTo, NoticeSubject, NoticeBody, NoticeTimestamp FROM Notice WHERE ReadStatus = 'false'"))
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

        protected void myBtnHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Notice SET ReadStatus = 'true' WHERE NoticeSubject = @NoticeSubject");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@NoticeSubject", btn.CommandArgument);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
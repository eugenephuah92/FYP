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
    public partial class Engineer_Notification : System.Web.UI.Page
    {
        struct Notice
        {
            public string hash;
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
                    note[x].hash = row["hash"].ToString();
                    note[x].NoticeFrom = row["Notice_From"].ToString();
                    note[x].NoticeTo = row["Notice_To"].ToString();
                    note[x].NoticeSubject = row["Notice_Subject"].ToString();
                    note[x].NoticeBody = row["Notice_Body"].ToString();
                    note[x].NoticeTimestamp = row["Notice_Timestamp"].ToString();
                    
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
                    btnRead1.CommandArgument = note[x].hash;
                    btnRead1.Click += myBtnHandler;
                    Placeholder1.Controls.Add(btnRead1);
                    html.Append("</td>");
                    html.Append("</tr>");
                    x++;
                }
                html.Append("</table>");
                Placeholder1.Controls.Add(new Literal { Text = html.ToString() });
                
           
        }
 
        private DataTable GetNotice()
        {
            string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp FROM Notice WHERE Read_Status = 'false'"))
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
                SqlCommand cmd = new SqlCommand("UPDATE Notice SET Read_Status = 'true' WHERE hash = @hash");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@hash", btn.CommandArgument);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
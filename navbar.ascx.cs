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
using Jabil_Session;
using System.IO;

public partial class navbar : System.Web.UI.UserControl
{
    string DatabaseName = "JabilDatabase";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string employee_name = JabilSession.Current.employee_name;
            lbl_employee_name.Text += employee_name;
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand retrieveNotice = new SqlCommand(@"SELECT COUNT(*) FROM dbo.Notice WHERE Notice_To = @Notice_To AND Read_Status = 'false'", conn);
                retrieveNotice.Parameters.AddWithValue("@Notice_To", employee_name);
                int count = Convert.ToInt16(retrieveNotice.ExecuteScalar());
                lblNotification.Text = count.ToString();

            }  
        }
        Display_Notifications_Grid_View();

    }

    private DataTable GetNotice()
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection con = new SqlConnection(connect))
        {
            string employee_name = JabilSession.Current.employee_name;
            using (SqlCommand cmd = new SqlCommand(@"SELECT hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp 
FROM dbo.Notice WHERE Notice_To = '" + employee_name + "'"))
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

    protected void Display_Notifications_Grid_View()
    {
        if (!IsPostBack)
        {
            SqlDataReader rdr;
            DataTable dt = new DataTable();

            dt.Columns.Add("Notice From");
            dt.Columns.Add("Notice Subject");
            dt.Columns.Add("Notice Body");
            dt.Columns.Add("Notice Timestamp");

            DataRow dr;


            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand(@"SELECT TOP 15 Notice_From, Notice_Subject, Notice_Body, Notice_Timestamp FROM dbo.Notice WHERE Notice_To = @notice_to",conn);
                select.Parameters.AddWithValue("@notice_to", JabilSession.Current.employee_name);
                rdr = select.ExecuteReader();
                while (rdr.Read())
                {
                    dr = dt.NewRow();
                    dr["Notice From"] = rdr["Notice_From"].ToString();
                    dr["Notice Subject"] = "<b>" + rdr["Notice_Subject"].ToString() + "</b>";
                    dr["Notice Body"] = rdr["Notice_Body"].ToString();
                    dr["Notice Timestamp"] = Convert.ToDateTime(rdr["Notice_Timestamp"]).ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }

            }


            displayNotifications.DataSource = dt;
            displayNotifications.DataBind();


        }

    }
    protected void changeStatus(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();

        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(constr))
        {
            connection.Open();
            SqlCommand retrieveNotice = new SqlCommand(@"SELECT COUNT(*) FROM dbo.Notice WHERE Notice_To = @Notice_To AND Read_Status = 'false'", connection);
            retrieveNotice.Parameters.AddWithValue("@Notice_To", JabilSession.Current.employee_name);
            int count = Convert.ToInt16(retrieveNotice.ExecuteScalar());
            lblNotification.Text = count.ToString();
        }
        //Populating a DataTable from database.
        DataTable dt = this.GetNotice();
        if(dt.Rows.Count == 0)
        {
            lblNoRows.Text = "No new notifications!";
            lblNoRows.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            
            using (SqlConnection connection = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Notice SET Read_Status = 'true'");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
public partial class Manager_8Drequest : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Assigned QE");
        dt.Columns.Add("Sent Date");
        dt.Columns.Add("Sent Time");

        DataRow dr;
        
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT SCAR_Request.scar_no, SCAR_Request.supplier_contact, Approval_8D.sent_date, 
Approval_8D.sent_time FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D ON dbo.SCAR_Request.scar_no = dbo.Approval_8D.scar_no", conn);
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Pending 8D Requests!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["Assigned QE"] = rdr["supplier_contact"].ToString();
                dr["Sent Date"] = "Date: " + Convert.ToDateTime(rdr["sent_date"]).ToString("yyyy-MM-dd");
                dr["Sent Time"] = "Time: " + rdr["sent_time"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

        }
        display8DRequests.DataSource = dt;
        display8DRequests.DataBind();

    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        display8DRequests.PageIndex = e.NewPageIndex;
        display8DRequests.DataBind();
    }
}
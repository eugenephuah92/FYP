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
using Jabil_Session;
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
            if(JabilSession.Current.employee_position.Equals("Quality Manager"))
            {
                SqlCommand select = new SqlCommand(@"SELECT SCAR_Request.scar_no, SCAR_Request.supplier_contact, Approval_8D.sent_date, 
Approval_8D.sent_time FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D ON dbo.SCAR_Request.scar_no = dbo.Approval_8D.scar_no WHERE
dbo.Approval_8D.approval_status_QM = @approval_status_QM", conn);
                select.Parameters.AddWithValue("@approval_status_QM", "pending");
                rdr = select.ExecuteReader();
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
            else if (JabilSession.Current.employee_position.Equals("Work Cell Manager"))
            {
                SqlCommand select = new SqlCommand(@"SELECT SCAR_Request.scar_no, SCAR_Request.supplier_contact, Approval_8D.sent_date, 
Approval_8D.sent_time FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D ON dbo.SCAR_Request.scar_no = dbo.Approval_8D.scar_no WHERE dbo.Approval_8D.approval_status_WCM = @approval_status_WCM", conn);
                select.Parameters.AddWithValue("@approval_status_WCM", "pending");
                rdr = select.ExecuteReader();
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

        }
        display8DRequests.DataSource = dt;
        display8DRequests.DataBind();

    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {

            display8DRequests.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            display8DRequests.DataBind();
        }
        else //Display searched results
        {
            display8DRequests.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            display8DRequests.PageIndex = e.NewPageIndex;
            display8DRequests.DataBind();
        }
        else //Display searched results
        {
            display8DRequests.PageIndex = e.NewPageIndex;
            SearchData();
        }
    }


    private void SearchData() //Search function
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        con.Open();
        string query = string.Empty;
        if(JabilSession.Current.employee_name.Equals("Quality Manager"))
        {
            query = @"SELECT SCAR_Request.scar_no, SCAR_Request.supplier_contact, Approval_8D.sent_date, 
Approval_8D.sent_time FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D ON dbo.SCAR_Request.scar_no = dbo.Approval_8D.scar_no WHERE
dbo.Approval_8D.approval_status_QM = 'pending' AND ";
        }
        else if (JabilSession.Current.employee_name.Equals("Work Cell Manager"))
        {
            query = @"SELECT SCAR_Request.scar_no, SCAR_Request.supplier_contact, Approval_8D.sent_date, 
Approval_8D.sent_time FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D ON dbo.SCAR_Request.scar_no = dbo.Approval_8D.scar_no WHERE
dbo.Approval_8D.approval_status_WCM = 'pending' AND ";
        }
        
        //Normal Search
        if (lstFilter.SelectedValue.ToString() == "CAR No")
        {
            query += "SCAR_Request.scar_no LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Assigned QE")
        {
            query += "SCAR_Request.supplier_contact LIKE '" + txtSearch.Text + "%'";
        }
        //Advanced Search
        if (txtSearch.Text != "")
        {
            if (lstFilter1.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Assigned QE")
            {
                query += "AND SCAR_Request.supplier_contact LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Assigned QE")
            {
                query += "AND SCAR_Request.supplier_contact LIKE '" + txtSearch2.Text + "%'";
            }

        }
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Assigned QE");
        dt.Columns.Add("Sent Date");
        dt.Columns.Add("Sent Time");

        DataRow dr;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            if (JabilSession.Current.employee_position.Equals("Quality Manager"))
            {
                SqlCommand select = new SqlCommand(query, conn);
                rdr = select.ExecuteReader();
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
            else if (JabilSession.Current.employee_position.Equals("Work Cell Manager"))
            {
                SqlCommand select = new SqlCommand(query, conn);
                rdr = select.ExecuteReader();
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

        }
        display8DRequests.DataSource = dt;
        display8DRequests.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e) //Search gridview data
    {
        if (Page.IsValid)
        {
            SearchData();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e) //Clear all search fields
    {
        lstFilter.ClearSelection();
        txtSearch.Text = "";
        lstFilter1.ClearSelection();
        txtSearch1.Text = "";
        lstFilter2.ClearSelection();
        txtSearch2.Text = "";

        display8DRequests.DataBind();
    }
}
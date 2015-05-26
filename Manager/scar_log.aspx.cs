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
using FYP_WebApp.Old_App_Code;

public partial class Manager_scar_log : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        SCAR scar_details = new SCAR();
        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Disapprove Frequency");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("Expected Date Close");

        DataRow dr;
        
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_status, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Request.expected_date_close, 
dbo.Approval_8D_Reject_Count.reject_count_WCM, dbo.Approval_8D_Reject_Count.reject_count_QM FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D_Reject_Count ON 
dbo.SCAR_Request.scar_no = dbo.Approval_8D_Reject_Count.scar_no", conn);
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["Status"] = rdr["scar_status"].ToString();
                int reject_count_QM = Convert.ToInt16(rdr["reject_count_QM"]);
                int reject_count_WCM = Convert.ToInt16(rdr["reject_count_WCM"]);
                int total_reject_count = reject_count_QM + reject_count_WCM;
                dr["Disapprove Frequency"] = total_reject_count;
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                DateTime expected_date_close = (DateTime)rdr["expected_date_close"];
                dr["Expected Date Close"] = expected_date_close.ToString("dd-MM-yyyy");
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
        }
        displaySCARLog.DataSource = dt;
        displaySCARLog.DataBind();

    }


    private void SearchData() //Search function
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;
        query = @"SELECT dbo.SCAR_Request.scar_status, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Request.expected_date_close, 
dbo.Approval_8D_Reject_Count.reject_count_WCM, dbo.Approval_8D_Reject_Count.reject_count_QM FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D_Reject_Count ON 
dbo.SCAR_Request.scar_no = dbo.Approval_8D_Reject_Count.scar_no WHERE ";
        // Normal Search
        if (lstFilter.SelectedValue.ToString() == "Car No")
        {
            query += "dbo.SCAR_Request.scar_no LIKE '" + txtSearch.Text + "%'";
        }
        SqlDataReader rdr;
        SCAR scar_details = new SCAR();
        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Disapprove Frequency");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("Expected Date Close");

        DataRow dr;

        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(query, conn);
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["Status"] = rdr["scar_status"].ToString();
                int reject_count_QM = Convert.ToInt16(rdr["reject_count_QM"]);
                int reject_count_WCM = Convert.ToInt16(rdr["reject_count_WCM"]);
                int total_reject_count = reject_count_QM + reject_count_WCM;
                dr["Disapprove Frequency"] = total_reject_count;
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                DateTime expected_date_close = (DateTime)rdr["expected_date_close"];
                dr["Expected Date Close"] = expected_date_close.ToString("dd-MM-yyyy");
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
        }
        displaySCARLog.DataSource = dt;
        displaySCARLog.DataBind();
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displaySCARLog.PageIndex = e.NewPageIndex;
        displaySCARLog.DataBind();
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

        displaySCARLog.DataBind();
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            displaySCARLog.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
        else
        {
            displaySCARLog.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            displaySCARLog.DataBind();
        }
    }

    protected void SCARLogGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        SqlDataReader rdr;
        SCAR scar_details = new SCAR();
        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Disapprove Frequency");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("Expected Date Close");

        DataRow dr;

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_status, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Request.expected_date_close, 
dbo.Approval_8D_Reject_Count.reject_count_WCM, dbo.Approval_8D_Reject_Count.reject_count_QM FROM dbo.SCAR_Request INNER JOIN dbo.Approval_8D_Reject_Count ON 
dbo.SCAR_Request.scar_no = dbo.Approval_8D_Reject_Count.scar_no", conn);
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["Status"] = rdr["scar_status"].ToString();

                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                DateTime expected_date_close = (DateTime)rdr["expected_date_close"];
                dr["Expected Date Close"] = expected_date_close.ToString("dd-MM-yyyy");
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
        }
        displaySCARLog.DataSource = dt;
        displaySCARLog.DataBind();
        if (dt != null)
        {
            DataView dataView = new DataView(dt);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            displaySCARLog.DataSource = dataView;
            displaySCARLog.DataBind();
        }
    }

    

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }

        return GridViewSortDirection;
    }

    protected void SetSortDirection(string sortDirection)
    {
        if (sortDirection == "ASC")
        {
            sortDirection = "DESC";
        }
        else
        {
            sortDirection = "ASC";
        }
    } 
}
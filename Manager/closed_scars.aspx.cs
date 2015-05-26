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

public partial class Manager_closed_scars : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("SCAR Type");
        dt.Columns.Add("Completion Date");
        dt.Columns.Add("Modified By");
        dt.Columns.Add("Last Modified");

        DataRow dr;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            // SqlCommand select = new SqlCommand ("SELECT scar_type, scar_no, issued_date, defect_modes FROM dbo.SCAR_History WHERE scar_stage = @scar_stage AND supplier_contact = @employee_name", conn);
            // select.Parameters.AddWithValue("@employee_name", JabilSession.Current.employee_name);
            SqlCommand select = new SqlCommand("SELECT scar_type, scar_no, issued_date, completion_date, modified_by, last_modified FROM dbo.SCAR_History WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "Closed SCAR");
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                DateTime completion_date = (DateTime)rdr["completion_date"];
                dr["Completion Date"] = issued_date.ToString("dd-MM-yyyy");
                dr["Modified By"] = rdr["modified_by"].ToString();
                dr["Last Modified"] = rdr["last_modified"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

        }

        displayClosedSCAR.DataSource = dt;
        displayClosedSCAR.DataBind();

    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {

            displayClosedSCAR.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            displayClosedSCAR.DataBind();
        }
        else //Display searched results
        {
            displayClosedSCAR.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            displayClosedSCAR.PageIndex = e.NewPageIndex;
            displayClosedSCAR.DataBind();
        }
        else //Display searched results
        {
            displayClosedSCAR.PageIndex = e.NewPageIndex;
            SearchData();
        }
    }


    private void SearchData() //Search function
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        con.Open();
        string query = string.Empty;
        query = @"SELECT scar_type, scar_no, issued_date, completion_date, modified_by, last_modified FROM dbo.SCAR_History WHERE scar_stage = 'Closed SCAR' AND ";
        //Normal Search
        if (lstFilter.SelectedValue.ToString() == "CAR No")
        {
            query += "SCAR_Request.scar_no LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "SCAR Type")
        {
            query += "SCAR_Request.scar_type LIKE '" + txtSearch.Text + "%'";
        }
        //Advanced Search
        if (txtSearch.Text != "")
        {
            if (lstFilter1.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "SCAR Type")
            {
                query += "AND SCAR_Request.scar_type LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "SCAR Type")
            {
                query += "AND SCAR_Request.scar_type LIKE '" + txtSearch2.Text + "%'";
            }

        }
            SqlDataReader rdr;

            DataTable dt = new DataTable();

            dt.Columns.Add("CAR Number");
            dt.Columns.Add("Creation Date");
            dt.Columns.Add("SCAR Type");
            dt.Columns.Add("Completion Date");
            dt.Columns.Add("Modified By");
            dt.Columns.Add("Last Modified");

            DataRow dr;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                // SqlCommand select = new SqlCommand ("SELECT scar_type, scar_no, issued_date, defect_modes FROM dbo.SCAR_History WHERE scar_stage = @scar_stage AND supplier_contact = @employee_name", conn);
                // select.Parameters.AddWithValue("@employee_name", JabilSession.Current.employee_name);
                SqlCommand select = new SqlCommand(query, conn);
                rdr = select.ExecuteReader();
                while (rdr.Read())
                {
                    dr = dt.NewRow();

                    dr["CAR Number"] = rdr["scar_no"].ToString();
                    dr["SCAR Type"] = rdr["scar_type"].ToString();
                    DateTime issued_date = (DateTime)rdr["issued_date"];
                    dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                    DateTime completion_date = (DateTime)rdr["completion_date"];
                    dr["Completion Date"] = issued_date.ToString("dd-MM-yyyy");
                    dr["Modified By"] = rdr["modified_by"].ToString();
                    dr["Last Modified"] = rdr["last_modified"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

            }

            displayClosedSCAR.DataSource = dt;
            displayClosedSCAR.DataBind();
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

        displayClosedSCAR.DataBind();
    }

    protected void SCARGridView_Sorting(object sender, GridViewSortEventArgs e)
    {

        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("SCAR Type");
        dt.Columns.Add("Completion Date");
        dt.Columns.Add("Modified By");
        dt.Columns.Add("Last Modified");

        DataRow dr;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            // SqlCommand select = new SqlCommand ("SELECT scar_type, scar_no, issued_date, defect_modes FROM dbo.SCAR_History WHERE scar_stage = @scar_stage AND supplier_contact = @employee_name", conn);
            // select.Parameters.AddWithValue("@employee_name", JabilSession.Current.employee_name);
            SqlCommand select = new SqlCommand("SELECT scar_type, scar_no, issued_date, completion_date, modified_by, last_modified FROM dbo.SCAR_History WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "Closed SCAR");
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                DateTime completion_date = (DateTime)rdr["completion_date"];
                dr["Completion Date"] = issued_date.ToString("dd-MM-yyyy");
                dr["Modified By"] = rdr["modified_by"].ToString();
                dr["Last Modified"] = rdr["last_modified"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

        }

        displayClosedSCAR.DataSource = dt;
        displayClosedSCAR.DataBind();

        if (dt != null)
        {
            DataView dataView = new DataView(dt);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            displayClosedSCAR.DataSource = dataView;
            displayClosedSCAR.DataBind();
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
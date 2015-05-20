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

public partial class Admin_closed_scars : System.Web.UI.Page
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
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for Closed SCARS!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
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

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displayClosedSCAR.PageIndex = e.NewPageIndex;
        displayClosedSCAR.DataBind();
    }

    protected void Show_10_Records(object sender, EventArgs e)
    {
        displayClosedSCAR.PageSize = 10;
        displayClosedSCAR.DataBind();
    }

    protected void Show_50_Records(object sender, EventArgs e)
    {
        displayClosedSCAR.PageSize = 50;
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
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for Closed SCARS!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
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
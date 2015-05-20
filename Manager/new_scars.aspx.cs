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

public partial class Manager_new_scars : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("SCAR Type");
        dt.Columns.Add("Current Progress");
        dt.Columns.Add("Level of Escalation");
        dt.Columns.Add("Escalation Date");
        dt.Columns.Add("Modified By");
        dt.Columns.Add("Last Modified");

        DataRow dr;


        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            /*SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_type, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Response.defect_modes 
FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON dbo.SCAR_Request.scar_no = dbo.SCAR_Response.scar_no 
WHERE scar_stage = @scar_stage AND dbo.SCAR_Request.supplier_contact = @supplier_contact", conn);*/
            // select.Parameters.AddWithValue("@supplier_contact", JabilSession.Current.employee_name);
            SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_type, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Request.modified_by,
dbo.SCAR_Request.last_modified, dbo.SCAR_Request.pending_action,
dbo.TAT.escalation_level, dbo.TAT.trigger_date FROM dbo.SCAR_Request INNER JOIN dbo.TAT ON dbo.SCAR_Request.scar_no = dbo.TAT.SCAR_ID WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "New SCAR");
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for New SCARS!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                dr["Current Progress"] = rdr["pending_action"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                dr["Level of Escalation"] = rdr["escalation_level"].ToString();
                dr["Escalation Date"] = rdr["trigger_date"].ToString();
                dr["Modified By"] = rdr["modified_by"].ToString();
                dr["Last Modified"] = rdr["last_modified"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }

        }


        displayNewSCAR.DataSource = dt;
        displayNewSCAR.DataBind();

    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displayNewSCAR.PageIndex = e.NewPageIndex;
        displayNewSCAR.DataBind();
    }

    protected void Show_10_Records(object sender, EventArgs e)
    {
        displayNewSCAR.PageSize = 10;
        displayNewSCAR.DataBind();
    }

    protected void Show_50_Records(object sender, EventArgs e)
    {
        displayNewSCAR.PageSize = 50;
        displayNewSCAR.DataBind();
    }

    protected void SCARGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("SCAR Type");
        dt.Columns.Add("Current Progress");
        dt.Columns.Add("Level of Escalation");
        dt.Columns.Add("Escalation Date");
        dt.Columns.Add("Modified By");
        dt.Columns.Add("Last Modified");

        DataRow dr;


        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            /*SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_type, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Response.defect_modes 
FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON dbo.SCAR_Request.scar_no = dbo.SCAR_Response.scar_no 
WHERE scar_stage = @scar_stage AND dbo.SCAR_Request.supplier_contact = @supplier_contact", conn);*/
            // select.Parameters.AddWithValue("@supplier_contact", JabilSession.Current.employee_name);
            SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_type, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Request.modified_by,
dbo.SCAR_Request.last_modified, dbo.SCAR_Request.pending_action,
dbo.TAT.escalation_level, dbo.TAT.trigger_date FROM dbo.SCAR_Request INNER JOIN dbo.TAT ON dbo.SCAR_Request.scar_no = dbo.TAT.SCAR_ID WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "New SCAR");
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for New SCARS!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                dr["Current Progress"] = rdr["pending_action"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                dr["Level of Escalation"] = rdr["escalation_level"].ToString();
                dr["Escalation Date"] = rdr["trigger_date"].ToString();
                dr["Modified By"] = rdr["modified_by"].ToString();
                dr["Last Modified"] = rdr["last_modified"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }

        }


        displayNewSCAR.DataSource = dt;
        displayNewSCAR.DataBind();

        if (dt != null)
        {
            DataView dataView = new DataView(dt);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            displayNewSCAR.DataSource = dataView;
            displayNewSCAR.DataBind();

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
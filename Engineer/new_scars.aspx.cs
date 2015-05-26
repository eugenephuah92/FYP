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

public partial class Engineer_new_scars : System.Web.UI.Page
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
dbo.TAT.escalation_count, dbo.TAT.trigger_date FROM dbo.SCAR_Request INNER JOIN dbo.TAT ON dbo.SCAR_Request.scar_no = dbo.TAT.SCAR_ID WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "New SCAR");
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                dr["Current Progress"] = rdr["pending_action"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                dr["Level of Escalation"] = rdr["escalation_count"].ToString();
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

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {

            displayNewSCAR.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            displayNewSCAR.DataBind();
        }
        else //Display searched results
        {
            displayNewSCAR.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            displayNewSCAR.PageIndex = e.NewPageIndex;
            displayNewSCAR.DataBind();
        }
        else //Display searched results
        {
            displayNewSCAR.PageIndex = e.NewPageIndex;
            SearchData();
        }
    }


    private void SearchData() //Search function
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        con.Open();
        string query = string.Empty;
        query = @"SELECT dbo.SCAR_Request.scar_type, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Request.modified_by,
dbo.SCAR_Request.last_modified, dbo.SCAR_Request.pending_action,
dbo.TAT.escalation_count, dbo.TAT.trigger_date FROM dbo.SCAR_Request INNER JOIN dbo.TAT ON dbo.SCAR_Request.scar_no = dbo.TAT.SCAR_ID WHERE dbo.SCAR_Request.scar_stage = 'New SCAR' AND ";
        //Normal Search
        if (lstFilter.SelectedValue.ToString() == "CAR No")
        {
            query += "SCAR_Request.scar_no LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "SCAR Type")
        {
            query += "SCAR_Request.scar_type LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Current Progress")
        {
            query += "SCAR_Request.pending_action LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Level of Escalation")
        {
            query += "TAT.escalation_count LIKE '" + txtSearch.Text + "%'";
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
            else if (lstFilter1.SelectedValue.ToString() == "Current Progress")
            {
                query += "AND SCAR_Request.pending_action LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Level of Escalation")
            {
                query += "AND TAT.escalation_count LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "SCAR Type")
            {
                query += "AND SCAR_Request.scar_type LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Current Progress")
            {
                query += "AND SCAR_Request.pending_action LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Level of Escalation")
            {
                query += "AND TAT.escalation_count LIKE '" + txtSearch2.Text + "%'";
            }
        }

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
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            /*SqlCommand select = new SqlCommand(@"SELECT dbo.SCAR_Request.scar_type, dbo.SCAR_Request.scar_no, dbo.SCAR_Request.issued_date, dbo.SCAR_Response.defect_modes 
FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON dbo.SCAR_Request.scar_no = dbo.SCAR_Response.scar_no 
WHERE scar_stage = @scar_stage AND dbo.SCAR_Request.supplier_contact = @supplier_contact", conn);*/
            // select.Parameters.AddWithValue("@supplier_contact", JabilSession.Current.employee_name);
            SqlCommand select = new SqlCommand(query, conn);
            rdr = select.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    dr = dt.NewRow();

                    dr["CAR Number"] = rdr["scar_no"].ToString();
                    dr["SCAR Type"] = rdr["scar_type"].ToString();
                    dr["Current Progress"] = rdr["pending_action"].ToString();
                    DateTime issued_date = (DateTime)rdr["issued_date"];
                    dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                    dr["Level of Escalation"] = rdr["escalation_count"].ToString();
                    dr["Escalation Date"] = rdr["trigger_date"].ToString();
                    dr["Modified By"] = rdr["modified_by"].ToString();
                    dr["Last Modified"] = rdr["last_modified"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            }
        }

        displayNewSCAR.DataSource = dt;
        displayNewSCAR.DataBind();

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
dbo.TAT.escalation_count, dbo.TAT.trigger_date FROM dbo.SCAR_Request INNER JOIN dbo.TAT ON dbo.SCAR_Request.scar_no = dbo.TAT.SCAR_ID WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "New SCAR");
            rdr = select.ExecuteReader();

            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                dr["Current Progress"] = rdr["pending_action"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                dr["Level of Escalation"] = rdr["escalation_count"].ToString();
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
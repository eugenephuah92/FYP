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
using Jabil_Employee;

public partial class Admin_manage_user_accounts : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SqlDataReader rdr;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Employee ID");
            dt.Columns.Add("Employee Name");
            dt.Columns.Add("Employee Email");
            dt.Columns.Add("Employee Position");
            dt.Columns.Add("Privilege");

            DataRow dr;
            Employee employee_details = new Employee();

            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand(@"SELECT id, employee_ID, employee_name, employee_email, employee_position, privilege FROM dbo.Employee", conn);
                rdr = select.ExecuteReader();
                if (!rdr.HasRows)
                {
                    lblNoRows.Text = "No Records Found for Employees!";
                    lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                }
                while (rdr.Read())
                {
                    dr = dt.NewRow();
                    dr["ID"] = rdr["id"].ToString();
                    dr["Employee ID"] = rdr["employee_ID"].ToString();
                    dr["Employee Name"] = rdr["employee_name"].ToString();
                    dr["Employee Email"] = rdr["employee_email"].ToString();
                    dr["Employee Position"] = rdr["employee_position"].ToString();
                    dr["Privilege"] = rdr["privilege"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            Session["EmployeeTable"] = dt;
            displayUsers.DataSource = dt;
            displayUsers.DataBind();
        }
       
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displayUsers.PageIndex = e.NewPageIndex;
        displayUsers.DataBind();
    }

    protected void Show_10_Records(object sender, EventArgs e)
    {
        displayUsers.PageSize = 10;
        displayUsers.DataBind();
    }

    protected void Show_50_Records(object sender, EventArgs e)
    {
        displayUsers.PageSize = 50;
        displayUsers.DataBind();
    }

    protected void UsersGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("Employee ID");
        dt.Columns.Add("Employee Name");
        dt.Columns.Add("Employee Email");
        dt.Columns.Add("Employee Position");
        dt.Columns.Add("Privilege");

        DataRow dr;
        Employee employee_details = new Employee();

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT id, employee_ID, employee_name, employee_email, employee_position, privilege FROM dbo.Employee", conn);
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for Employees!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            while (rdr.Read())
            {
                dr = dt.NewRow();
                dr["ID"] = rdr["id"].ToString();
                dr["Employee ID"] = rdr["employee_ID"].ToString();
                dr["Employee Name"] = rdr["employee_name"].ToString();
                dr["Employee Email"] = rdr["employee_email"].ToString();
                dr["Employee Position"] = rdr["employee_position"].ToString();
                dr["Privilege"] = rdr["privilege"].ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
        }

        displayUsers.DataSource = dt;
        displayUsers.DataBind();

        if (dt != null)
        {
            DataView dataView = new DataView(dt);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            displayUsers.DataSource = dataView;
            displayUsers.DataBind();
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

    protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TableCell cell = displayUsers.Rows[e.RowIndex].Cells[2];
        TableCell employee_name = displayUsers.Rows[e.RowIndex].Cells[3];
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand delete = new SqlCommand("DELETE from dbo.Employee where employee_ID = @employee_ID", conn);
            delete.Parameters.AddWithValue("@employee_ID", cell.Text);
            delete.ExecuteNonQuery();
        }
        string message = employee_name.Text + " has been removed from the system!";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
    }

    protected void UsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        displayUsers.EditIndex = e.NewEditIndex;
        displayUsers.DataSource = Session["EmployeeTable"];
        displayUsers.DataBind();
    }

    protected void UsersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        displayUsers.EditIndex = -1;
        displayUsers.DataSource = Session["EmployeeTable"];
        displayUsers.DataBind();
    }

    protected void UsersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.

        DataTable dt = (DataTable)Session["EmployeeTable"];

        //Update the values.
        
        GridViewRow row = displayUsers.Rows[e.RowIndex];
        dt.Rows[row.DataItemIndex]["Employee ID"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Employee Name"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Employee Email"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Employee Position"] = ((TextBox)(row.Cells[5].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Privilege"] = ((TextBox)(row.Cells[6].Controls[0])).Text;

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            try
            {
                SqlCommand updateUsers = new SqlCommand(@"UPDATE dbo.Employee SET employee_ID = @employee_ID, employee_name = @employee_name, employee_email = @employee_email, 
employee_position = @employee_position, privilege = @privilege WHERE id = @id",conn);
                updateUsers.Parameters.AddWithValue("@id", displayUsers.DataKeys[e.RowIndex].Values[0].ToString());
                updateUsers.Parameters.AddWithValue("@employee_ID", ((TextBox)(row.Cells[2].Controls[0])).Text);
                updateUsers.Parameters.AddWithValue("@employee_name", ((TextBox)(row.Cells[3].Controls[0])).Text);
                updateUsers.Parameters.AddWithValue("@employee_email", ((TextBox)(row.Cells[4].Controls[0])).Text);
                updateUsers.Parameters.AddWithValue("@employee_position", ((TextBox)(row.Cells[5].Controls[0])).Text);
                updateUsers.Parameters.AddWithValue("@privilege", ((TextBox)(row.Cells[6].Controls[0])).Text);
                updateUsers.ExecuteNonQuery();
                string message = "User details has been successfully updated!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
            catch
            {
                string message = "Failed to update user details! Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
            finally
            {
                conn.Close();
            }
            
        }

        //Reset the edit index.
        displayUsers.EditIndex = -1;

        //Bind data to the GridView control.
        displayUsers.DataSource = Session["EmployeeTable"];
        displayUsers.DataBind();
    }
}
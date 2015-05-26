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
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
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
    }

    private void SearchData() //Search function
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;
        query = "SELECT id, employee_ID, employee_name, employee_email, employee_position, privilege FROM dbo.Employee WHERE ";
        // Normal Search
        if (lstFilter.SelectedValue.ToString() == "Employee Name")
        {
            query += "employee_name LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Employee ID")
        {
            query += "employee_id LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Employee Email")
        {
            query += "employee_email LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Employee Position")
        {
            query += "employee_position LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Privilege")
        {
            query += "privilege LIKE '" + txtSearch.Text + "%'";
        }
        //Advanced Search
        if (txtSearch.Text != "")
        {
            if (lstFilter1.SelectedValue.ToString() == "Employee Name")
            {
                query += "AND employee_name LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Employee ID")
            {
                query += "AND employee_id LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Employee Position")
            {
                query += "AND employee_position LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Employee Email")
            {
                query += "AND employee_email LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Privilege")
            {
                query += "AND privilege LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "Employee Name")
            {
                query += "AND employee_name LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Employee ID")
            {
                query += "AND employee_id LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Employee Position")
            {
                query += "AND employee_position LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Employee Email")
            {
                query += "AND employee_email LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Privilege")
            {
                query += "AND privilege LIKE '" + txtSearch2.Text + "%'";
            }
        }
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
            SqlCommand select = new SqlCommand(query, conn);
            rdr = select.ExecuteReader();
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

        BindData();
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            displayUsers.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
        else
        {
            displayUsers.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindData();
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            displayUsers.PageIndex = e.NewPageIndex;
            SearchData();
        }
        else
        {
            displayUsers.PageIndex = e.NewPageIndex;
            BindData();
        }
    }

    protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TableCell cell = displayUsers.Rows[e.RowIndex].Cells[2];
        TableCell employee_name = displayUsers.Rows[e.RowIndex].Cells[3];
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand delete = new SqlCommand("DELETE from dbo.Employee where employee_ID = @employee_ID", conn);
                delete.Parameters.AddWithValue("@employee_ID", cell.Text);
                delete.ExecuteNonQuery();
            }
            string message = employee_name.Text + " has been removed from the system!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            BindData();
        }
        else
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand delete = new SqlCommand("DELETE from dbo.Employee where employee_ID = @employee_ID", conn);
                delete.Parameters.AddWithValue("@employee_ID", cell.Text);
                delete.ExecuteNonQuery();
            }
            string message = employee_name.Text + " has been removed from the system!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            BindData();
        }
        
    }

    protected void UsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            displayUsers.EditIndex = e.NewEditIndex;
            SearchData();
        }
        else
        {
            displayUsers.EditIndex = e.NewEditIndex;
            BindData();
        }       
    }

    protected void UsersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            displayUsers.EditIndex = -1;
            SearchData();
        }
        else
        {
            displayUsers.EditIndex = -1;
            BindData();
        }
    }

    protected void UsersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.

        DataTable dt = (DataTable)Session["EmployeeTable"];

        //Update the values.
        
        GridViewRow row = displayUsers.Rows[e.RowIndex];

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    SqlCommand updateUsers = new SqlCommand(@"UPDATE dbo.Employee SET employee_ID = @employee_ID, employee_name = @employee_name, employee_email = @employee_email, 
employee_position = @employee_position, privilege = @privilege WHERE id = @id", conn);
                    updateUsers.Parameters.AddWithValue("@id", displayUsers.DataKeys[e.RowIndex].Values[0].ToString());
                    updateUsers.Parameters.AddWithValue("@employee_ID", ((TextBox)(row.Cells[2].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@employee_name", ((TextBox)(row.Cells[3].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@employee_email", ((TextBox)(row.Cells[4].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@employee_position", ((TextBox)(row.Cells[5].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@privilege", ((TextBox)(row.Cells[6].Controls[0])).Text);
                    updateUsers.ExecuteNonQuery();
                    string message = "User details has been successfully updated!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    //Reset the edit index.
                    displayUsers.EditIndex = -1;

                    //Bind data to the GridView control.
                    SearchData();
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
            else
            {
                try
                {
                    SqlCommand updateUsers = new SqlCommand(@"UPDATE dbo.Employee SET employee_ID = @employee_ID, employee_name = @employee_name, employee_email = @employee_email, 
employee_position = @employee_position, privilege = @privilege WHERE id = @id", conn);
                    updateUsers.Parameters.AddWithValue("@id", displayUsers.DataKeys[e.RowIndex].Values[0].ToString());
                    updateUsers.Parameters.AddWithValue("@employee_ID", ((TextBox)(row.Cells[2].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@employee_name", ((TextBox)(row.Cells[3].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@employee_email", ((TextBox)(row.Cells[4].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@employee_position", ((TextBox)(row.Cells[5].Controls[0])).Text);
                    updateUsers.Parameters.AddWithValue("@privilege", ((TextBox)(row.Cells[6].Controls[0])).Text);
                    updateUsers.ExecuteNonQuery();
                    string message = "User details has been successfully updated!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    //Reset the edit index.
                    displayUsers.EditIndex = -1;

                    //Bind data to the GridView control.
                    BindData();
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
        }

        
    }
}
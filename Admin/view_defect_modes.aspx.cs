using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_view_defect_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDFM();
        }
    }

    private void BindDFM() //Bind Defect Modes to gridview
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT Defect_Modes.defect_code, IPC_Code.IPC_code, Defect_Modes.defect_name, Defect_Modes.defect_group, Defect_Modes.defect_category, Defect_Modes.defect_description, Defect_Modes.modified_by, Defect_Modes.last_modified, IPC_Code.modified_by, IPC_Code.last_modified FROM dbo.Defect_Modes LEFT JOIN dbo.IPC_Code ON Defect_Modes.defect_code = IPC_Code.defect_code");
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                GridViewDFM.DataSource = dt;
                GridViewDFM.DataBind();
            }
        }
    }

    private void SearchDFM() //Search function
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;
        query = "SELECT Defect_Modes.defect_code, IPC_Code.IPC_code, Defect_Modes.defect_name, Defect_Modes.defect_group, Defect_Modes.defect_category, Defect_Modes.defect_description, Defect_Modes.modified_by, Defect_Modes.last_modified, IPC_Code.modified_by, IPC_Code.last_modified FROM dbo.Defect_Modes LEFT JOIN dbo.IPC_Code ON Defect_Modes.defect_code = IPC_Code.defect_code WHERE ";
        // Normal Search
        if (lstFilter.SelectedValue.ToString() == "Defect Code")
        {
            query += "Defect_Modes.defect_code LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "IPC Code")
        {
            query += "IPC_Code.IPC_code LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Name")
        {
            query += "Defect_Modes.defect_name LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Group")
        {
            query += "Defect_Modes.defect_group LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Category")
        {
            query += "Defect_Modes.defect_category LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Description")
        {
            query += "Defect_Modes.defect_description LIKE '" + txtSearch.Text + "%'";
        }
        //Advanced Search
        if (txtSearch.Text != "")
        {
            if (lstFilter1.SelectedValue.ToString() == "Defect Code")
            {
                query += "AND Defect_Modes.defect_code LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "IPC Code")
            {
                query += "AND IPC_Code.IPC_code LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Name")
            {
                query += "AND Defect_Modes.defect_name LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Group")
            {
                query += "AND Defect_Modes.defect_group LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Category")
            {
                query += "AND Defect_Modes.defect_category LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Description")
            {
                query += "AND Defect_Modes.defect_description LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "Defect Code")
            {
                query += "AND Defect_Modes.defect_code LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "IPC Code")
            {
                query += "AND IPC_Code.IPC_code LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Name")
            {
                query += "AND Defect_Modes.defect_name LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Group")
            {
                query += "AND Defect_Modes.defect_group LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Category")
            {
                query += "AND Defect_Modes.defect_category LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Description")
            {
                query += "AND Defect_Modes.defect_description LIKE '" + txtSearch2.Text + "%'";
            }
        }

        SqlDataAdapter sda = new SqlDataAdapter(query, constr);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridViewDFM.DataSource = ds;
        GridViewDFM.DataBind();
        con.Close();
    }

    protected void btnSearch_Click(object sender, EventArgs e) //Search gridview data
    {
        if (Page.IsValid)
        {
            SearchDFM();
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

        BindDFM();
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            GridViewDFM.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchDFM();
        }
        else
        {
            GridViewDFM.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindDFM();
        }
    }

    protected void GridViewDFM_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            GridViewDFM.PageIndex = e.NewPageIndex;
            SearchDFM();
        }
        else
        {
            GridViewDFM.PageIndex = e.NewPageIndex;
            BindDFM();
        }
    }

    protected void GridViewDFM_RowEditing(object sender, GridViewEditEventArgs e) //Allow data editing
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            GridViewDFM.EditIndex = e.NewEditIndex;
            SearchDFM();
        }
        else
        {
            GridViewDFM.EditIndex = e.NewEditIndex;
            BindDFM();
        }
    }

    protected void GridViewDFM_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) //Cancel data editing
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            GridViewDFM.EditIndex = -1;
            SearchDFM();
        }
        else
        {
            GridViewDFM.EditIndex = -1;
            BindDFM();
        }
    }

    protected void GridViewDFM_RowUpdating(object sender, GridViewUpdateEventArgs e) //Allow data updating
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE dbo.Defect_Modes SET defect_group = @defect_group, defect_category = @defect_category, defect_description = @defect_description WHERE defect_code = @defect_code";
                cmd.Parameters.AddWithValue("@defect_code", Convert.ToInt32(GridViewDFM.DataKeys[e.RowIndex].Value.ToString()));
                cmd.Parameters.AddWithValue("@defect_group", ((DropDownList)GridViewDFM.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue);
                cmd.Parameters.AddWithValue("@defect_category", ((DropDownList)GridViewDFM.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue);
                cmd.Parameters.AddWithValue("@defect_description", ((TextBox)GridViewDFM.Rows[e.RowIndex].Cells[5].Controls[1]).Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "UPDATE dbo.IPC_Code SET IPC_code = @ipc_code WHERE defect_code = @defect_code";
                cmd.Parameters.AddWithValue("@defect_code", Convert.ToInt32(GridViewDFM.DataKeys[e.RowIndex].Value.ToString()));
                cmd.Parameters.AddWithValue("@ipc_code", ((TextBox)GridViewDFM.Rows[e.RowIndex].Cells[1].Controls[1]).Text);
                cmd.ExecuteNonQuery();

                GridViewDFM.EditIndex = -1;
                SearchDFM();
            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE dbo.Defect_Modes SET defect_group = @defect_group, defect_category = @defect_category, defect_description = @defect_description WHERE defect_code = @defect_code";
                cmd.Parameters.AddWithValue("@defect_code", Convert.ToInt32(GridViewDFM.DataKeys[e.RowIndex].Value.ToString()));
                cmd.Parameters.AddWithValue("@defect_group", ((DropDownList)GridViewDFM.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue);
                cmd.Parameters.AddWithValue("@defect_category", ((DropDownList)GridViewDFM.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue);
                cmd.Parameters.AddWithValue("@defect_description", ((TextBox)GridViewDFM.Rows[e.RowIndex].Cells[5].Controls[1]).Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "UPDATE dbo.IPC_Code SET IPC_code = @ipc_code WHERE defect_code = @defect_code";
                cmd.Parameters.AddWithValue("@defect_code", Convert.ToInt32(GridViewDFM.DataKeys[e.RowIndex].Value.ToString()));
                cmd.Parameters.AddWithValue("@ipc_code", ((TextBox)GridViewDFM.Rows[e.RowIndex].Cells[1].Controls[1]).Text);
                cmd.ExecuteNonQuery();

                GridViewDFM.EditIndex = -1;
                BindDFM();
            }
        }
    }

    protected void GridViewDFM_RowDeleting(object sender, GridViewDeleteEventArgs e) //Allow data deleting
    {
        if (!String.IsNullOrEmpty(txtSearch.Text))
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM dbo.Defect_Modes WHERE defect_code = @defect_code";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@defect_code", GridViewDFM.DataKeys[e.RowIndex].Value);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM dbo.IPC_Code WHERE defect_code = @defect_code";
                cmd.ExecuteNonQuery();
                SearchDFM();
            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM dbo.Defect_Modes WHERE defect_code = @defect_code";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@defect_code", GridViewDFM.DataKeys[e.RowIndex].Value);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM dbo.IPC_Code WHERE defect_code = @defect_code";
                cmd.ExecuteNonQuery();
                BindDFM();
            }
        }
    }

    protected void GridViewDFM_RowDataBound(object sender, GridViewRowEventArgs e) //Prompt delete confirmation box
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (DataControlFieldCell cell in e.Row.Cells)
            {
                foreach (Control control in cell.Controls)
                {
                    Button btn = control as Button;
                    if (btn != null && btn.CommandName == "Delete")
                    {
                        //Prompt message box for delete confirmation
                        btn.OnClientClick = "if (!confirm('Are you sure you want to delete this entry?')) return;";
                    }
                }
            }
        }
    }
}
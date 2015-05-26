using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Jabil_Session;

public partial class Admin_view_defect_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDFC();
            BindDFG();
        }
    }

    private void BindDFC() //Bind Defect Category to gridview
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_category_ID, defect_category, modified_by, last_modified FROM dbo.Defect_Category");
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                GridViewDFC.DataSource = dt;
                GridViewDFC.DataBind();
            }
        }
    }

    protected void GridViewDFC_RowEditing(object sender, GridViewEditEventArgs e) //Defect Category data editing
    {
        GridViewDFC.EditIndex = e.NewEditIndex;
        BindDFC();
    }

    protected void GridViewDFC_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) //Cancel Defect Category data editing
    {
        GridViewDFC.EditIndex = -1;
        BindDFC();
    }

    protected void GridViewDFC_RowUpdating(object sender, GridViewUpdateEventArgs e) //Allow Defect Category data updating
    {
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE dbo.Defect_Category SET defect_category = @defect_category, modified_by = @modified_by, last_modified = @last_modified WHERE defect_category_ID = @defect_category_ID";
            cmd.Parameters.AddWithValue("@defect_category_ID", Convert.ToInt32(GridViewDFC.DataKeys[e.RowIndex].Value.ToString()));
            cmd.Parameters.AddWithValue("@defect_category", ((TextBox)GridViewDFC.Rows[e.RowIndex].Cells[1].Controls[1]).Text);
            cmd.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
            DateTime currentDateTime = DateTime.Now;
            cmd.Parameters.AddWithValue("@last_modified", currentDateTime);
            cmd.Connection = con;          
            cmd.ExecuteNonQuery();

            GridViewDFC.EditIndex = -1;
            BindDFC();
        }
    }

    protected void GridViewDFC_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow Defect Category paging
    {
        GridViewDFC.PageIndex = e.NewPageIndex;
        BindDFC();
    }

    protected void ValidateDefectCategory(object source, ServerValidateEventArgs args) //Check if textbox value match with database value
    {
        string defectCategory = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_category_ID, defect_category FROM dbo.Defect_Category WHERE defect_category = @defect_category", con);
            cmd.Parameters.AddWithValue("@defect_category", defectCategory);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }

    private void BindDFG() //Bind Defect Group to gridview
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_group_ID, defect_group, modified_by, last_modified FROM dbo.Defect_Group");
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                GridViewDFG.DataSource = dt;
                GridViewDFG.DataBind();
            }
        }
    }

    protected void GridViewDFG_RowEditing(object sender, GridViewEditEventArgs e) //Allow Defect Group data editing
    {
        GridViewDFG.EditIndex = e.NewEditIndex;
        BindDFG();
    }

    protected void GridViewDFG_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) //Cancel Defect Group data editing
    {
        GridViewDFG.EditIndex = -1;
        BindDFG();
    }

    protected void GridViewDFG_RowUpdating(object sender, GridViewUpdateEventArgs e) //Allow Defect Group data updating
    {
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE dbo.Defect_Group SET defect_group = @defect_group, modified_by = @modified_by, last_modified = @last_modified WHERE defect_group_ID = @defect_group_ID";
            cmd.Parameters.AddWithValue("@defect_group_ID", Convert.ToInt32(GridViewDFG.DataKeys[e.RowIndex].Value.ToString()));
            cmd.Parameters.AddWithValue("@defect_group", ((TextBox)GridViewDFG.Rows[e.RowIndex].Cells[1].Controls[1]).Text.ToUpper());
            cmd.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
            DateTime currentDateTime = DateTime.Now;
            cmd.Parameters.AddWithValue("@last_modified", currentDateTime);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();

            GridViewDFG.EditIndex = -1;
            BindDFG();
        }
    }

    protected void GridViewDFG_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow Defect Group paging
    {
        GridViewDFG.PageIndex = e.NewPageIndex;
        BindDFG();
    }

    protected void ValidateDefectGroup(object source, ServerValidateEventArgs args) //Check if textbox value match with database value
    {
        string defectGroup = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_group_ID, defect_group FROM dbo.Defect_Group WHERE defect_group = @defect_group", con);
            cmd.Parameters.AddWithValue("@defect_group", defectGroup);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }

    protected void GridViewDFG_RowDeleting(object sender, GridViewDeleteEventArgs e) //Allow Defect Group data deleting
    {
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            GridViewRow row = (GridViewRow)GridViewDFG.Rows[e.RowIndex];
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Defect_Group WHERE defect_group_id='" + Convert.ToInt32(GridViewDFG.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
            cmd.ExecuteNonQuery();
            BindDFG();
        }      
    }

    protected void GridViewDFG_RowDataBound(object sender, GridViewRowEventArgs e) //Prompt delete confirmation box
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_view_defect_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridViewDFC_DeleteConfirm(object sender, GridViewRowEventArgs e)
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
    protected void GridViewDFC_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Capitalize first letter of Defect Category
        string temp = e.NewValues["defect_category"].ToString().ToUpper().Substring(0, 1) + e.NewValues["defect_category"].ToString().Substring(1);
        e.NewValues["defect_category"] = temp;
    }

    protected void GridViewDFG_DeleteConfirm(object sender, GridViewRowEventArgs e)
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
    protected void GridViewDFG_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Convert Defect Group to uppercase
        string temp = e.NewValues["defect_group"].ToString().ToUpper();
        e.NewValues["defect_group"] = temp;
    }

    protected void ValidateDefectCategory(object source, ServerValidateEventArgs args)
    {
        string defectCategory = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Defect_Category WHERE defect_category=@defect_category", con);
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
    protected void ValidateDefectGroup(object source, ServerValidateEventArgs args)
    {
        string defectGroup = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Defect_Group WHERE defect_group=@defect_group", con);
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_add_new_defect_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmitDC_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Defect_Category(defect_category) Values (@defect_category)", conn);
                //Capitalize first letter of the text
                insert.Parameters.AddWithValue("@defect_category", txtNewDefectCategory.Text.ToUpper().Substring(0, 1) + txtNewDefectCategory.Text.Substring(1));

                conn.Open();
                insert.ExecuteNonQuery();

                txtNewDefectCategory.Text = "";

                //Prompt message box to indicate record is saved into database
                string message = "New Defect Category is saved successfully!";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
    }

    protected void btnSubmitDG_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Defect_Group(defect_group) Values (@defect_group)", conn);
                //Convert text to uppercase
                insert.Parameters.AddWithValue("@defect_group", txtNewDefectGroup.Text.ToUpper());

                conn.Open();
                insert.ExecuteNonQuery();

                txtNewDefectGroup.Text = "";

                //Prompt message box to indicate record is saved into database
                string message = "New Defect Group is saved successfully!";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Jabil_Session;

public partial class Admin_add_new_defect_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmitDC_Click(object sender, EventArgs e) //Insert new Defect Category
    {
        if (Page.IsValid)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand insert = new SqlCommand("INSERT INTO dbo.Defect_Category(defect_category, modified_by, last_modified) Values (@defect_category, @modified_by, @last_modified)", conn);
                //Capitalize first letter of the text
                insert.Parameters.AddWithValue("@defect_category", txtNewDefectCategory.Text.ToUpper().Substring(0, 1) + txtNewDefectCategory.Text.Substring(1));
                insert.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                DateTime currentDateTime = DateTime.Now;
                insert.Parameters.AddWithValue("@last_modified", currentDateTime);

                conn.Open();
                insert.ExecuteNonQuery();

                txtNewDefectCategory.Text = "";

                //Prompt alert box to indicate record is saved into database
                string message = "New Defect Category has been successfully added !";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
        }
    }

    protected void btnSubmitDG_Click(object sender, EventArgs e) //Insert new Defect Group
    {
        if (Page.IsValid)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand insert = new SqlCommand("INSERT INTO dbo.Defect_Group(defect_group, modified_by, last_modified) Values (@defect_group, @modified_by, @last_modified)", conn);
                //Convert text to uppercase
                insert.Parameters.AddWithValue("@defect_group", txtNewDefectGroup.Text.ToUpper());
                insert.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                DateTime currentDateTime = DateTime.Now;
                insert.Parameters.AddWithValue("@last_modified", currentDateTime);

                conn.Open();
                insert.ExecuteNonQuery();

                txtNewDefectGroup.Text = "";

                //Prompt alert box to indicate record is saved into database
                string message = "New Defect Group has been successfully added !";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
        }
    }

    protected void ValidateDefectCategory(object source, ServerValidateEventArgs args) //Check if textbox value match with database value
    {
        string defectCategory = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_category_ID, defect_category, modified_by, last_modified FROM dbo.Defect_Category WHERE defect_category = @defect_category", con);
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

    protected void ValidateDefectGroup(object source, ServerValidateEventArgs args) //Check if textbox value match with database value
    {
        string defectGroup = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_group_ID, defect_group, modified_by, last_modified FROM dbo.Defect_Group WHERE defect_group = @defect_group", con);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_add_new_defect_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDefectGroup();
            ddlDefectCategory();
        }
    }

    protected void ddlDefectGroup() //Populate Defect Group dropdownlist from database
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defect_group_ID, defect_group FROM Defect_Group", conn);
            conn.Open();

            lstNewDefectGroup.DataSource = select.ExecuteReader();
            lstNewDefectGroup.DataTextField = "defect_group";
            lstNewDefectGroup.DataBind();
            lstNewDefectGroup.Items.Insert(0, new ListItem("Please Select Defect Group", "0"));
        }
    }

    protected void ddlDefectCategory() //Populate Defect Category dropdownlist from database
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defect_category_ID, defect_category FROM Defect_Category", conn);
            conn.Open();

            lstNewDefectCategory.DataSource = select.ExecuteReader();
            lstNewDefectCategory.DataTextField = "defect_category";
            lstNewDefectCategory.DataBind();
            lstNewDefectCategory.Items.Insert(0, new ListItem("Please Select Defect Category", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            if (IsPostBack)
            {
                if (Page.IsValid)
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO Defect_Modes(defect_code, IPC_code, defect_name, defect_group, defect_category, defect_description) Values (@defect_code, @IPC_code, @defect_name, @defect_group, @defect_category, @defect_description)", conn);

                    insert.Parameters.AddWithValue("@defect_code", txtNewDefectCode.Text);
                    insert.Parameters.AddWithValue("@IPC_code", txtNewIPCCode.Text);
                    if (!String.IsNullOrEmpty(txtNewIPCCode.Text)) //Check if textbox contains value
                    {
                        insert.Parameters["@IPC_code"].Value = txtNewIPCCode.Text; //If not empty, pass value
                    }
                    else
                    {
                        insert.Parameters["@IPC_code"].Value = DBNull.Value; //If empty, set to NULL
                    }
                    insert.Parameters.AddWithValue("@defect_name", txtNewDefectName.Text.ToUpper()); //Convert text to uppercase
                    insert.Parameters.AddWithValue("@defect_group", lstNewDefectGroup.SelectedValue);
                    insert.Parameters.AddWithValue("@defect_category", lstNewDefectCategory.SelectedValue);
                    insert.Parameters.AddWithValue("@defect_description", txtNewDefectDescription.Text);

                    conn.Open();
                    insert.ExecuteNonQuery();

                    ClearFields(); //Clear all text fields

                    //Prompt message box to indicate record is saved into database
                    string message = "Record is saved successfully!";
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
    }

    protected void ClearFields() //Clear all text fields
    {
        txtNewDefectCode.Text = "";
        txtNewIPCCode.Text = "";
        txtNewDefectName.Text = "";
        lstNewDefectGroup.ClearSelection();
        lstNewDefectCategory.ClearSelection();
        txtNewDefectDescription.Text = "";
    }
}
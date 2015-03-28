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

    protected void ddlDefectGroup()
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defectGroupID, defectGroup FROM DefectGroup", conn);
            conn.Open();
            lstNewDefectGroup.DataSource = select.ExecuteReader();
            lstNewDefectGroup.DataTextField = "defectGroup";
            lstNewDefectGroup.DataBind();
            lstNewDefectGroup.Items.Insert(0, new ListItem("Please Select Defect Group", "0"));
        }
    }

    protected void ddlDefectCategory()
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defectCategoryID, defectCategory FROM DefectCategory", conn);
            conn.Open();

            lstNewDefectCategory.DataSource = select.ExecuteReader();
            lstNewDefectCategory.DataTextField = "defectCategory";
            lstNewDefectCategory.DataBind();
            lstNewDefectCategory.Items.Insert(0, new ListItem("Please Select Defect Category", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            if(IsPostBack)
            {
                if (Page.IsValid)
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO DefectModes(defectCode, ipcCode, defectName, defectGroup, defectCategory, defectDescription) Values (@defectCode, @ipcCode, @defectName, @defectGroup, @defectCategory, @defectDescription)", conn);

                    insert.Parameters.AddWithValue("@defectCode", txtNewDefectCode.Text);
                    insert.Parameters.AddWithValue("@ipcCode", txtNewIPCCode.Text);
                    if(!String.IsNullOrEmpty(txtNewIPCCode.Text)) //Check if textbox contains value
                    {
                        insert.Parameters["@ipcCode"].Value = txtNewIPCCode.Text; //If not empty, pass value
                    }
                    else
                    {
                        insert.Parameters["@ipcCode"].Value = DBNull.Value; //If empty, set to NULL
                    }
                    insert.Parameters.AddWithValue("@defectName", txtNewDefectName.Text.ToUpper()); //Convert to uppercase
                    insert.Parameters.AddWithValue("@defectGroup", lstNewDefectGroup.SelectedValue);
                    insert.Parameters.AddWithValue("@defectCategory", lstNewDefectCategory.SelectedValue);
                    insert.Parameters.AddWithValue("@defectDescription", txtNewDefectDescription.Text);
   
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

    public void ClearFields()
    {
        txtNewDefectCode.Text = "";
        txtNewIPCCode.Text = "";
        txtNewDefectName.Text = "";
        lstNewDefectGroup.ClearSelection();
        lstNewDefectCategory.ClearSelection();
        txtNewDefectDescription.Text = "";
    }
}
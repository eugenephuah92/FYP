using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Jabil_Session;

public partial class Admin_add_new_defect_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDefectGroup();
            ddlDefectCategory();
            ddlDefectCode();
        }
    }

    protected void ddlDefectGroup() //Populate Defect Group dropdownlist from database
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defect_group_ID, defect_group FROM dbo.Defect_Group", con);
            con.Open();

            lstNewDefectGroup.DataSource = select.ExecuteReader();
            lstNewDefectGroup.DataTextField = "defect_group";
            lstNewDefectGroup.DataBind();
            lstNewDefectGroup.Items.Insert(0, new ListItem("Please Select Defect Group", "0"));
        }
    }

    protected void ddlDefectCategory() //Populate Defect Category dropdownlist from database
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defect_category_ID, defect_category FROM dbo.Defect_Category", con);
            con.Open();

            lstNewDefectCategory.DataSource = select.ExecuteReader();
            lstNewDefectCategory.DataTextField = "defect_category";
            lstNewDefectCategory.DataBind();
            lstNewDefectCategory.Items.Insert(0, new ListItem("Please Select Defect Category", "0"));
        }
    }

    protected void ddlDefectCode() //Populate Defect Code dropdownlist from database
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connect))
        {
            SqlCommand select = new SqlCommand("SELECT defect_code FROM dbo.Defect_Modes", con);
            con.Open();

            lstDefectCode.DataSource = select.ExecuteReader();
            lstDefectCode.DataTextField = "defect_code";
            lstDefectCode.DataBind();
            lstDefectCode.Items.Insert(0, new ListItem("Please Select Defect Code", "0"));
        }
    }

    protected void btnSubmitDFM_Click(object sender, EventArgs e) //Insert new Defect Modes
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connect))
        {
            if (IsPostBack)
            {
                if (Page.IsValid)
                {
                    con.Open();
                    SqlCommand insert = new SqlCommand();
                    insert.CommandText = "INSERT INTO dbo.Defect_Modes(defect_code, defect_name, defect_group, defect_category, defect_description, modified_by, last_modified) Values (@defect_code, @defect_name, @defect_group, @defect_category, @defect_description, @modified_by, @last_modified)";
                    insert.Parameters.AddWithValue("@defect_code", txtNewDefectCode.Text);
                    insert.Parameters.AddWithValue("@defect_name", txtNewDefectName.Text.ToUpper()); //Convert text to uppercase
                    insert.Parameters.AddWithValue("@defect_group", lstNewDefectGroup.SelectedValue);
                    insert.Parameters.AddWithValue("@defect_category", lstNewDefectCategory.SelectedValue);
                    insert.Parameters.AddWithValue("@defect_description", txtNewDefectDescription.Text);
                    insert.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                    DateTime currentDateTime = DateTime.Now;
                    insert.Parameters.AddWithValue("@last_modified", currentDateTime);

                    insert.Connection = con;
                    insert.ExecuteNonQuery();
                    insert.Parameters.Clear();

                    insert.CommandText = "INSERT INTO dbo.IPC_Code(IPC_code, defect_code, modified_by, last_modified) Values (@ipc_code, @defect_code, @modified_by, @last_modified)";

                    if (!String.IsNullOrEmpty(txtNewIPCCode.Text)) //Check if textbox not empty only insert data
                    {
                        insert.Parameters.AddWithValue("@ipc_code", txtNewIPCCode.Text);
                        insert.Parameters.AddWithValue("@defect_code", txtNewDefectCode.Text);
                        insert.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                        insert.Parameters.AddWithValue("@last_modified", currentDateTime);

                        insert.ExecuteNonQuery();
                    }

                    ClearFields(); //Clear all text fields   

                    //Prompt alert box to indicate record is saved into database
                    string message = "New Defect Modes have been successfully added !";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
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

    protected void txtNewDefectCode_TextChanged(object sender, EventArgs e) //Check if textbox value match with database value once textbox is off-focus (autopostback)
    {
        int code;
        if (int.TryParse(txtNewDefectCode.Text, out code)) //Check if input value is numeric
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand();
                Object returnValue;

                cmd.CommandText = "SELECT defect_code FROM dbo.Defect_Modes WHERE defect_code = @defect_code";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@defect_code", txtNewDefectCode.Text);
                cmd.Connection = con;

                con.Open();
                returnValue = cmd.ExecuteScalar();

                if (Convert.ToInt32(returnValue) > 0) //If match, disabled all text fields and button for data insertion
                {
                    txtCheck.Text = "* Defect Code entered is already existed in the database.<br />You can either re-enter to Add New Defect Modes OR proceed to Add New IPC Code in the form below.";
                    txtNewIPCCode.Enabled = false;
                    txtNewDefectName.Enabled = false;
                    lstNewDefectGroup.Enabled = false;
                    lstNewDefectCategory.Enabled = false;
                    txtNewDefectDescription.Enabled = false;
                    btnSubmitDFM.Enabled = false;
                }
                else //If no match, enable all text fields and button for data insertion
                {
                    txtCheck.Text = "You can proceed to add new Defect Modes";
                    txtNewIPCCode.Enabled = true;
                    txtNewDefectName.Enabled = true;
                    lstNewDefectGroup.Enabled = true;
                    lstNewDefectCategory.Enabled = true;
                    txtNewDefectDescription.Enabled = true;
                    btnSubmitDFM.Enabled = true;
                }
            }
        }
        else //If input value is not numeric
        {
            txtCheck.Text = "* Defect Code ONLY accept integers";
        }
    }

    protected void CustomValidatorIPCCode_ServerValidate(object source, ServerValidateEventArgs args) //Check if textbox value match with database value
    {
        string ipcCode = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT IPC_code FROM dbo.IPC_Code WHERE IPC_code = @ipc_code", con);
            cmd.Parameters.AddWithValue("@ipc_code", ipcCode);
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

    protected void CustomValidatorDefectName_ServerValidate(object source, ServerValidateEventArgs args) //Check if textbox value match with database value
    {
        string defectName = args.Value;
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT defect_name FROM dbo.Defect_Modes WHERE defect_name = @defect_name", con);
            cmd.Parameters.AddWithValue("@defect_name", defectName);
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

    protected void btnSubmitIPC_Click(object sender, EventArgs e) //Insert new IPC Code
    {
        string connect = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connect))
        {
            if (IsPostBack)
            {
                if (Page.IsValid)
                {
                    con.Open();
                    SqlCommand insert = new SqlCommand();
                    insert.CommandText = "INSERT INTO dbo.IPC_Code(IPC_code, defect_code, modified_by, last_modified) Values (@ipc_code, @defect_code, @modified_by, @last_modified)";
                    insert.Parameters.AddWithValue("@ipc_code", txtIPCCode.Text);
                    insert.Parameters.AddWithValue("@defect_code", lstDefectCode.SelectedValue);
                    insert.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                    DateTime currentDateTime = DateTime.Now;
                    insert.Parameters.AddWithValue("@last_modified", currentDateTime);

                    insert.Connection = con;
                    insert.ExecuteNonQuery();

                    lstDefectCode.ClearSelection();
                    txtIPCCode.Text = "";

                    //Prompt alert box to indicate record is saved into database
                    string message = "New IPC Code has been successfully added !";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
            }
        }
    }
}
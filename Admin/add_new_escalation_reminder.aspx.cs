using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Jabil_Session;
using New_Escalation_Level;

public partial class Admin_add_new_escalation_reminder : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblEscalationLevel();
        }
    }

    protected void lblEscalationLevel()
    {
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand select = new SqlCommand("SELECT COUNT(*) FROM dbo.Escalation_Level", conn);
                conn.Open();
                Int32 lvl = (Int32)select.ExecuteScalar();
                lblEscalationLvl.Text = lvl.ToString();
            }
        }
    }

    protected void Submit_NEL(object sender, EventArgs e)
    {
        NEL new_escalation_level = new NEL();
        bool checkEmptyFields = true;

        if (!string.IsNullOrEmpty(txtNELN.Text)) // New Escalation Level
        {
            new_escalation_level.NEL_Description = txtNELN.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        new_escalation_level.QEL_Checked = chkbUsersInvolved.Items[0].Selected; // Quality Engineer Lead Checked
        new_escalation_level.QM_Checked = chkbUsersInvolved.Items[1].Selected;  // Quality Manager Checked
        if (!string.IsNullOrEmpty(txtDuration.Text)) // Escalation Level Duration
        {
            new_escalation_level.Duration = int.Parse(txtDuration.Text);
        }
        else
        {
            checkEmptyFields = false;
        }

        if (!string.IsNullOrEmpty(txtEmail.Text)) // Email Content
        {
            new_escalation_level.Email_Content = txtEmail.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

        if (checkEmptyFields)
        {
            Insert_Request_Into_Database(new_escalation_level);
        }
    }

    // Insert Data from New Escalation Level into Database 
    protected void Insert_Request_Into_Database(NEL new_escalation_level)
    {
        // Establish Connection to Database
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        try
        {
            // SQL command to insert data into database
            SqlCommand addNEL = new SqlCommand(@"INSERT INTO dbo.Escalation_Level (escalation_level, escalation_level_desc, days_to_escalation, 
            notify_QEL, notify_QM, email_message, modified_by, last_modified) VALUES (@escalation_level, @escalation_level_desc, @days_to_escalation, 
            @notify_QEL, @notify_QM, @email_message, @modified_by, @last_modified)", con);

            addNEL.Parameters.AddWithValue("@escalation_level", lblEscalationLvl.Text);
            addNEL.Parameters.AddWithValue("@escalation_level_desc", new_escalation_level.NEL_Description);
            addNEL.Parameters.AddWithValue("@days_to_escalation", new_escalation_level.Duration);
            addNEL.Parameters.AddWithValue("@notify_QEL", new_escalation_level.QEL_Checked);
            addNEL.Parameters.AddWithValue("@notify_QM", new_escalation_level.QM_Checked);
            addNEL.Parameters.AddWithValue("@email_message", new_escalation_level.Email_Content);
            addNEL.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
            addNEL.Parameters.AddWithValue("@last_modified", DateTime.Now);
            addNEL.ExecuteNonQuery();

            string message = "New Escalation Level Reminder has been created!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + new_escalation_level.NEL_Description + "','" + message + "')", true);
        }
        catch (Exception err)
        {
            string message = "New Escalation Level Reminder cannnot be created!! Please try again!";
            string temp_no = "0";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + temp_no + "','" + message + "')", true);
        }
        finally
        {
            con.Close();
        }
    }

}
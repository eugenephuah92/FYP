using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using Jabil_Employee;
using Jabil_Session;
using CryptoLib;

public partial class Engineer_change_password : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Click_Change_Password(object sender, EventArgs e)
    {
        bool checkRows = false;
        bool checkMatch = false;
        Employee employee_details = new Employee();
        employee_details.Employee_ID = JabilSession.Current.userID;
        employee_details.Employee_password = txtNewPassword.Text;
        employee_details.Employee_password = Encryptor.MD5HASH(employee_details.Employee_password);

        string confirmPassword = txtConfirmNewPassword.Text;
        confirmPassword = Encryptor.MD5HASH(confirmPassword);

        string oldPassword = txtOldPassword.Text;
        oldPassword = Encryptor.MD5HASH(oldPassword);

        if(confirmPassword.Equals(employee_details.Employee_password))
        {
            checkMatch = true;
        }
        else
        {
            string message = "New Password and Confirm New Password do not match! Please Try Again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
        }

        if(checkMatch)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                SqlCommand retrievePassword = new SqlCommand(@"SELECT password FROM dbo.Employee WHERE employee_id = @employee_id AND password = @oldpassword", conn);
                retrievePassword.Parameters.AddWithValue("@employee_id", employee_details.Employee_ID);
                retrievePassword.Parameters.AddWithValue("@oldpassword", oldPassword);
                SqlDataReader reader = retrievePassword.ExecuteReader();
                if (reader.HasRows)
                {
                    checkRows = true;
                }
                else
                {
                    string message = "Invalid old password! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
                reader.Close();
                if (checkRows)
                {
                    try
                    {
                        SqlCommand updatePassword = new SqlCommand(@"UPDATE dbo.Employee SET password = @password WHERE employee_ID = @employee_ID", conn);
                        updatePassword.Parameters.AddWithValue("@password", employee_details.Employee_password);
                        updatePassword.Parameters.AddWithValue("@employee_ID", employee_details.Employee_ID);
                        updatePassword.ExecuteNonQuery();

                        string message = "Your password has been successfully updated!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    catch
                    {
                        string message = "Failed to update your password! Please Try Again!";
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
}
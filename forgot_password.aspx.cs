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
using Jabil_Employee;
using System.Net.Mail;
using CryptoLib;

public partial class forgot_password : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Reset_Password(object sender, EventArgs e)
    {
        bool check_rows = false;
        Employee employee_details = new Employee();
        employee_details.Employee_email = txtEmail.Text;
        string new_password = null;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT employee_id, employee_name, employee_email FROM dbo.Employee WHERE employee_email = @employee_email", conn);
            select.Parameters.AddWithValue("@employee_email", employee_details.Employee_email);
            SqlDataReader reader = select.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string temp_password = reader["employee_id"].ToString() + reader["employee_name"].ToString();
                    new_password = Encryptor.MD5HASH(temp_password);
                    new_password = new_password.Substring(0, 6);
                    employee_details.Employee_ID = reader["employee_id"].ToString();
                    employee_details.Employee_name = reader["employee_name"].ToString();
                }
                
                string email_subject = "AUTO SCAR & TAT - Account Password Reset";
                string email_body = "Greetings " + employee_details.Employee_name + ". <br/> Your password has been reset successfully. Here is your temporary password: " + new_password + " <br/> It is advisable to change your password immediately! Thank you. ";
                reader.Close();
                check_rows = true;
            }
            else
            {
                string message = "Incorrect Email Address! Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }

            if(check_rows)
            {
                SqlCommand update = new SqlCommand(@"UPDATE dbo.Employee SET password = @password WHERE employee_id = @employee_id AND employee_name = @employee_name", conn);
                update.Parameters.AddWithValue("@password", new_password);
                update.Parameters.AddWithValue("@employee_id", employee_details.Employee_ID);
                update.Parameters.AddWithValue("@employee_name", employee_details.Employee_name);
                update.ExecuteNonQuery();
                string message = "Your new password has been sent to your email address!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
        }
    }
}
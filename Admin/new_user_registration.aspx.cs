using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using Jabil_Employee;
using CryptoLib;
public partial class Admin_new_user_registration : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Create_New_User(object sender, EventArgs e)
    {
        Employee employee_details = new Employee();
        bool records_exists = false;
        bool ID_exists = false;
        bool email_exists = false;
        bool name_exists = false;
        employee_details.Employee_ID = txtEmployeeID.Text;
        employee_details.Employee_name = txtEmployeeName.Text;
        employee_details.Employee_email = txtEmployeeEmail.Text;
        employee_details.Employee_position = txtEmployeePosition.Text;
        employee_details.Privilege = lstPrivilege.SelectedItem.Value;
        employee_details.Employee_password = Encryptor.MD5HASH("jabilautoscar");
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand retrieveEmployeeData = new SqlCommand(@"SELECT employee_name, employee_ID, employee_email FROM dbo.Employee",conn);
           
            SqlDataReader reader = retrieveEmployeeData.ExecuteReader();
            while(reader.Read())
            {
                if(employee_details.Employee_ID.Equals(reader["employee_ID"].ToString()))
                {
                    records_exists = true;
                    ID_exists = true;
                    vldEmployeeID.ErrorMessage = "User ID: " + employee_details.Employee_ID + " already exists!";
                }
                if(employee_details.Employee_email.Equals(reader["employee_email"].ToString()))
                {
                    records_exists = true;
                    email_exists = true;
                    vldEmployeeEmail.ErrorMessage = "Email Address: " + employee_details.Employee_email + " already exists!";
                }
                if (employee_details.Employee_name.Equals(reader["employee_name"].ToString()) && ID_exists || email_exists)
                {
                    records_exists = true;
                    name_exists = true;
                    vldEmployeeName.ErrorMessage = "User already exists!";
                }
            }
            reader.Close();
            if(records_exists)
            {
                string message = "User already exists in the system! Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
            else
            {
                try
                {

                    SqlCommand insertUser = new SqlCommand(@"INSERT INTO dbo.Employee (employee_ID, employee_name, employee_email, employee_position, password, privilege) 
VALUES (@employee_ID, @employee_name, @employee_email, @employee_position, @password, @privilege)", conn);
                    insertUser.Parameters.AddWithValue("@employee_ID", employee_details.Employee_ID);
                    insertUser.Parameters.AddWithValue("@employee_name", employee_details.Employee_name);
                    insertUser.Parameters.AddWithValue("@employee_email", employee_details.Employee_email);
                    insertUser.Parameters.AddWithValue("@employee_position", employee_details.Employee_position);
                    insertUser.Parameters.AddWithValue("@password", employee_details.Employee_password);
                    insertUser.Parameters.AddWithValue("@privilege", employee_details.Privilege);
                    insertUser.ExecuteNonQuery();
                    string message = "User: " + employee_details.Employee_name + " has been successfully added into the system!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
                catch (Exception err)
                {
                    string message = "Failed to add new user: " + employee_details.Employee_name + " ! Please Try Again!" + err.Message;
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
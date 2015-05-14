using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jabil_Session;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using Jabil_Employee;
using CryptoLib;

public partial class Index : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Click_Login(object sender, EventArgs e)
    {
            bool checkEmptyFields = false;
            if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                checkEmptyFields = true;
            }

            if (!checkEmptyFields)
            {
                Employee employee_details = new Employee();
                employee_details.Employee_email = txtEmail.Text;
                employee_details.Employee_password = txtPassword.Text;
                employee_details.Employee_password = Encryptor.MD5HASH(employee_details.Employee_password);
                string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand select = new SqlCommand(@"SELECT employee_ID, employee_name, employee_position, privilege FROM dbo.Employee WHERE employee_email = @employee_email AND 
password = @password", conn);
                    select.Parameters.AddWithValue("@employee_email", employee_details.Employee_email);
                    select.Parameters.AddWithValue("@password", employee_details.Employee_password);
                    SqlDataReader rdr = select.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            employee_details.Employee_ID = Convert.ToString(rdr["employee_ID"]);
                            employee_details.Employee_name = Convert.ToString(rdr["employee_name"]);
                            employee_details.Employee_position = Convert.ToString(rdr["employee_position"]);
                            employee_details.Privilege = Convert.ToString(rdr["privilege"]);

                            JabilSession.Current.userID = Convert.ToString(rdr["employee_ID"]);
                            JabilSession.Current.employee_name = Convert.ToString(rdr["employee_name"]);
                            JabilSession.Current.employee_position = Convert.ToString(rdr["employee_position"]);
                            JabilSession.Current.privilege = Convert.ToString(rdr["privilege"]);
                        }
                        if (employee_details.Privilege.Equals("Admin"))
                        {
                            Response.Redirect("Admin/home.aspx");
                        }
                        else if (employee_details.Privilege.Equals("Manager"))
                        {
                            Response.Redirect("Manager/home.aspx");
                        }
                        else if (employee_details.Privilege.Equals("Engineer"))
                        {
                            Response.Redirect("Engineer/home.aspx");
                        }
                        else
                        {
                            Response.Redirect("Logout.aspx");
                        }
                    }
                    else
                    {
                        lblInvalid.Text = "Login Failed! Invalid Email Address or Password!";
                        txtEmail.Text = null;
                        txtPassword.Text = null;
                    }
                }
            }
     
    }
}
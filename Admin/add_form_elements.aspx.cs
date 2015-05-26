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
public partial class Admin_add_form_elements : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            formElements.Text = Session["SelectedElement"].ToString();
        }
    }

    protected void Click_Add(object sender, EventArgs e)
    {
        string newElement = txtAddElement.Text;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            if (Session["SelectedElement"].ToString().Equals("Defect Type"))
            {
                SqlCommand select = new SqlCommand(@"SELECT defect_type FROM dbo.SCAR_Defect_type WHERE defect_type = @defect_type",conn);
                select.Parameters.AddWithValue("@defect_type", newElement);
                SqlDataReader reader = select.ExecuteReader();
                if(reader.HasRows)
                {
                    string message = newElement + " already exists! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    try
                    {
                        SqlCommand insert = new SqlCommand("INSERT INTO dbo.SCAR_Defect_type (defect_type) VALUES (@defect_type)", conn);
                        insert.Parameters.AddWithValue("@defect_type", newElement);
                        insert.ExecuteNonQuery();
                        string message = "Defect Type has been successfully added!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    catch (Exception err)
                    {
                        string message = "Failed to add Defect Type! Please Try Again!" + err.Message;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }  
            }
            else if (Session["SelectedElement"].ToString().Equals("Root Cause Options"))
            {
                SqlCommand select = new SqlCommand(@"SELECT defect_type FROM dbo.Root_Cause_Option WHERE root_cause = @root_cause", conn);
                select.Parameters.AddWithValue("@root_cause", newElement);
                SqlDataReader reader = select.ExecuteReader();
                if (reader.HasRows)
                {
                    string message = newElement + " already exists! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    try
                    {
                        SqlCommand insert = new SqlCommand("INSERT INTO dbo.Root_Cause_Option (root_cause) VALUES (@root_cause)", conn);
                        insert.Parameters.AddWithValue("@root_cause", newElement);
                        insert.ExecuteNonQuery();
                        string message = "Root Cause Option has been successfully added!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    catch
                    {
                        string message = "Failed to add Root Cause Option! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                
            }
            else if (Session["SelectedElement"].ToString().Equals("Screening Area for Containment Action"))
            {
                SqlCommand select = new SqlCommand(@"SELECT screening_area FROM dbo.SCAR_Screening_Area WHERE screening_area = @screening_area", conn);
                select.Parameters.AddWithValue("@screening_area", newElement);
                SqlDataReader reader = select.ExecuteReader();
                if (reader.HasRows)
                {
                    string message = newElement + " already exists! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    reader.Close();

                }
                else
                {
                    reader.Close();
                    try
                    {
                        SqlCommand insert = new SqlCommand("INSERT INTO dbo.SCAR_Screening_Area (screening_area) VALUES (@screening_area)", conn);
                        insert.Parameters.AddWithValue("@screeing_area", newElement);
                        insert.ExecuteNonQuery();
                        string message = "Screening Area has been successfully added!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    catch
                    {
                        string message = "Failed to add Screening Area! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }   
            }
            else if (Session["SelectedElement"].ToString().Equals("Failure Analysis"))
            {
                SqlCommand select = new SqlCommand(@"SELECT failure_analysis FROM dbo.Failure_Analysis WHERE failure_analysis = @failure_analysis", conn);
                select.Parameters.AddWithValue("@failure_analysis", newElement);
                SqlDataReader reader = select.ExecuteReader();
                if (reader.HasRows)
                {
                    string message = newElement + " already exists! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    try
                    {
                        SqlCommand insert = new SqlCommand("INSERT INTO dbo.SCAR_Failure_Analysis (failure_analysis) VALUES (@failure_analysis)", conn);
                        insert.Parameters.AddWithValue("@failure_analysis", newElement);
                        insert.ExecuteNonQuery();
                        string message = "Failure Analysis has been successfully added!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                    catch
                    {
                        string message = "Failed to add Failure Analysis! Please Try Again!";
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

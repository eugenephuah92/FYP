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
                try
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO dbo.SCAR_Defect_type (defect_type) VALUES (@defect_type)", conn);
                    insert.Parameters.AddWithValue("@defect_type", newElement);
                    insert.ExecuteNonQuery();
                    string message = "Defect Type has been successfully added!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to add Defect Type! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (Session["SelectedElement"].ToString().Equals("Root Cause Options"))
            {
                try
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO dbo.Root_Cause_Option (root_cause) VALUES (@root_cause)", conn);
                    insert.Parameters.AddWithValue("@root_cause", newElement);
                    insert.ExecuteNonQuery();
                    string message = "Root Cause Option has been successfully added!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to add Root Cause Option! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (Session["SelectedElement"].ToString().Equals("Screening Area for Containment Action"))
            {
                try
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO dbo.SCAR_Screening_Area (screening_area) VALUES (@screening_area)", conn);
                    insert.Parameters.AddWithValue("@screeing_area", newElement);
                    insert.ExecuteNonQuery();
                    string message = "Screening Area has been successfully added!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to add Screening Area! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (Session["SelectedElement"].ToString().Equals("Failure Analysis"))
            {
                try
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO dbo.SCAR_Failure_Analysis (failure_analysis) VALUES (@failure_analysis)", conn);
                    insert.Parameters.AddWithValue("@failure_analysis", newElement);
                    insert.ExecuteNonQuery();
                    string message = "Failure Analysis has been successfully added!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to add Failure Analysis! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }
    }

}

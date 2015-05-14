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
public partial class Admin_manage_form_elements : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            formElements.Text = Session["SelectedElement"].ToString();
            if (Session["SelectedElement"].ToString().Equals("Defect Type"))
            {
                ddlDefectType();
            }
            else if (Session["SelectedElement"].ToString().Equals("Root Cause Options"))
            {
                ddlRootCause();
            }
            else if (Session["SelectedElement"].ToString().Equals("Screening Area for Containment Action"))
            {
                ddlScreeningArea();
            }
            else if (Session["SelectedElement"].ToString().Equals("Failure Analysis"))
            {
                ddlFailureAnalysis();
            }
        }
        
    }

    protected void ddlDefectType()
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT id, defect_type FROM dbo.SCAR_Defect_type", conn);
            lstElements.DataSource = select.ExecuteReader();
            lstElements.DataTextField = "defect_type";
            lstElements.DataValueField = "id";
            lstElements.DataBind();
            lstElements.Items.Insert(0, new ListItem("Please Select Defect Type", "0"));
        }
    }

    protected void ddlRootCause()
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT id, root_cause FROM dbo.Root_Cause_Option", conn);

            lstElements.DataSource = select.ExecuteReader();
            lstElements.DataTextField = "root_cause";
            lstElements.DataValueField = "id";
            lstElements.DataBind();
            lstElements.Items.Insert(0, new ListItem("Please Select Root Cause", "0"));
        }
    }

    protected void ddlScreeningArea()
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT id, screening_area FROM dbo.SCAR_Screening_Area", conn);

            lstElements.DataSource = select.ExecuteReader();
            lstElements.DataTextField = "screening_area";
            lstElements.DataValueField = "id";
            lstElements.DataBind();
            lstElements.Items.Insert(0, new ListItem("Please Select Screening Area", "0"));
        }
    }

    protected void ddlFailureAnalysis()
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT id, failure_analysis FROM dbo.SCAR_Failure_Analysis", conn);

            lstElements.DataSource = select.ExecuteReader();
            lstElements.DataTextField = "failure_analysis";
            lstElements.DataValueField = "id";
            lstElements.DataBind();
            lstElements.Items.Insert(0, new ListItem("Please Select Failure Analysis", "0"));
        }
    }

    protected void Click_Modify(object sender, EventArgs e)
    {
        string newElement = txtModifyElement.Text;
        string oldElement = lstElements.SelectedValue;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            if (Session["SelectedElement"].ToString().Equals("Defect Type"))
            {
                try
                {

                    SqlCommand update = new SqlCommand("UPDATE dbo.SCAR_Defect_type SET defect_type = @defect_type WHERE id = @oldElement", conn);
                    update.Parameters.AddWithValue("@defect_type", newElement);
                    update.Parameters.AddWithValue("@oldElement", oldElement);
                    update.ExecuteNonQuery();
                    string message = "Defect Type has been updated!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to update Defect Type! Please Try Again!";
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
                    SqlCommand update = new SqlCommand("UPDATE dbo.Root_Cause_Option SET root_cause = @root_cause WHERE id = @oldElement", conn);
                    update.Parameters.AddWithValue("@root_cause", newElement);
                    update.Parameters.AddWithValue("@oldElement", oldElement);
                    update.ExecuteNonQuery();
                    string message = "Root Cause Option has been updated!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to update Root Cause Option! Please Try Again!";
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
                    SqlCommand update = new SqlCommand("UPDATE dbo.SCAR_Screening_Area SET screening_area = @screening_area WHERE id = @oldElement", conn);
                    update.Parameters.AddWithValue("@screening_area", newElement);
                    update.Parameters.AddWithValue("@oldElement", oldElement);
                    update.ExecuteNonQuery();
                    string message = "Screening Area has been updated!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to update Screening Area! Please Try Again!";
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
                    SqlCommand update = new SqlCommand("UPDATE dbo.SCAR_Failure_Analysis SET failure_analysis = @failure_analysis WHERE id = @oldElement", conn);
                    update.Parameters.AddWithValue("@failure_analysis", newElement);
                    update.Parameters.AddWithValue("@oldElement", oldElement);
                    update.ExecuteNonQuery();
                    string message = "Failure Analysis has been updated!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to update Failure Analysis! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }
    }

    protected void Click_Delete(object sender, EventArgs e)
    {
        string oldElement = lstElements.SelectedValue;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            if (Session["SelectedElement"].ToString().Equals("Defect Type"))
            {
                try
                {
                    SqlCommand delete = new SqlCommand("DELETE FROM dbo.SCAR_Defect_type WHERE id = @oldElement", conn);
                    delete.Parameters.AddWithValue("@oldElement", oldElement);
                    delete.ExecuteNonQuery();
                    string message = "Defect Type has been deleted!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to delete Defect Type! Please Try Again!";
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
                    SqlCommand delete = new SqlCommand("DELETE FROM dbo.Root_Cause_Option WHERE id = @oldElement", conn);
                    delete.Parameters.AddWithValue("@oldElement", oldElement);
                    delete.ExecuteNonQuery();
                    string message = "Root Cause Option has been deleted!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to delete Root Cause Option! Please Try Again!";
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
                    SqlCommand delete = new SqlCommand("DELETE FROM dbo.SCAR_Screening_Area WHERE id = @oldElement", conn);
                    delete.Parameters.AddWithValue("@oldElement", oldElement);
                    delete.ExecuteNonQuery();
                    string message = "Screening Area has been deleted!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to delete Screening Area! Please Try Again!";
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
                    SqlCommand delete = new SqlCommand("DELETE FROM dbo.SCAR_Failure_Analysis WHERE id = @oldElement", conn);
                    delete.Parameters.AddWithValue("@oldElement", oldElement);
                    delete.ExecuteNonQuery();
                    string message = "Failure Analysis has been deleted!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
                }
                catch
                {
                    string message = "Failed to delete Failure Analysis! Please Try Again!";
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

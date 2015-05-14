using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_form_elements : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            lstElements.Items.Insert(0, new ListItem("Please Select Form Elements", "N/A"));
            lstElements.Items.Insert(1, new ListItem("Defect Type", "Defect Type"));
            lstElements.Items.Insert(2, new ListItem("Root Cause Options", "Root Cause Options"));
            lstElements.Items.Insert(3, new ListItem("Screening Area for Containment Action", "Screening Area for Containment Action"));
            lstElements.Items.Insert(4, new ListItem("Failure Analysis", "Failure Analysis"));
        }
 
    }

    protected void Click_Add(object sender, EventArgs e)
    {
        if(Selected_Form_Elements().Equals("N/A"))
        {
            string message = "Please Select Form Elements!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
        }
        else
        {
            Session["SelectedElement"] = Selected_Form_Elements();
            Response.Redirect("add_form_elements.aspx");
        }
        
    }

    protected void Click_Modify(object sender, EventArgs e)
    {
        if (Selected_Form_Elements().Equals("N/A"))
        {
            string message = "Please Select Form Elements!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "ShowMessage('" + message + "')", true);
        }
        else
        {
            Session["SelectedElement"] = Selected_Form_Elements();
            Response.Redirect("manage_form_elements.aspx");
        }
    }

    protected string Selected_Form_Elements()
    {
        string selectedElement = lstElements.SelectedItem.Value;
        return selectedElement;      
    }
}
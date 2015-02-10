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
        lstElements.Items.Add("Defect Type");
        lstElements.Items.Add("Root Cause Options");
        lstElements.Items.Add("Screening Area for Containment Action");

        lstRootCause.Items.Add(new ListItem("1. Agilent and CM joint issue - Material", "1"));
        lstRootCause.Items.Add(new ListItem("2. CM (Product) - Assembly", "2"));
        lstRootCause.Items.Add(new ListItem("3. CM (Product) - Documentation", "3"));
    }
}
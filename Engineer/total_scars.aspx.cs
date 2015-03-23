using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineer_total_scars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add(new ListItem("CAR Number"));
        lstFilter.Items.Add(new ListItem("Defect Name"));
        lstFilter.Items.Add(new ListItem("Description"));
        lstFilter.Items.Add(new ListItem("Creation Date"));
        lstFilter.Items.Add(new ListItem("SCAR Type"));
        lstFilter.Items.Add(new ListItem("Escalation Level"));
        lstFilter.Items.Add(new ListItem("Days Till Next Escalation"));

    }
}
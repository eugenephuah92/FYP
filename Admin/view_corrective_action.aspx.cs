using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_corrective_actions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("Corrective / Preventive Actions");
        lstFilter.Items.Add("SCAR Request Date");
        lstFilter.Items.Add("SCAR Completion Date");
        lstFilter.Items.Add("CAR Number");
        lstFilter.Items.Add("Assigned Quality Engineer");
    }
}
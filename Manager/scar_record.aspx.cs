using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_scar_record : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("CAR Number");
        lstFilter.Items.Add("QE Name");
        lstFilter.Items.Add("Escalation Level");
        lstFilter.Items.Add("Days Till Next Escalation");
    }
}
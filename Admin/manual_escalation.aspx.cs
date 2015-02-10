using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manual_escalation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("CAR Number");
        lstFilter.Items.Add("QE Name");
        lstFilter.Items.Add("Escalation Level");
        lstFilter.Items.Add("Days Till Next Escalation");

        lstQE.Items.Add("Tony Hudson");
        lstQE.Items.Add("Jeff Long");
        lstQE.Items.Add("Blake Shelton");

        lstEscalationLevel.Items.Add("1");
        lstEscalationLevel.Items.Add("2");
    }
}
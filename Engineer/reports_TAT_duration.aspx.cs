using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineer_reports_TAT_duration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("Frequency of Cases");
        lstFilter.Items.Add("Month");
    }
}
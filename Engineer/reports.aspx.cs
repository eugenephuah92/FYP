using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineer_reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        lstReport.Items.Add("1st Quadrant Report");
        lstReport.Items.Add("2nd Quadrant Report");
        lstReport.Items.Add("3rd Quadrant Report");
        lstReport.Items.Add("4th Quadrant Report");
        lstReport.Items.Add("Corrective Action / Preventive Action");
        lstReport.Items.Add("TAT Triggering and Escalation");
    }
}
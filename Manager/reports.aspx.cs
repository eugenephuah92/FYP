using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lstReport.Items.Add("1st Quadrant Report");
            lstReport.Items.Add("2nd Quadrant Report");
            lstReport.Items.Add("3rd Quadrant Report");
            lstReport.Items.Add("4th Quadrant Report");
            lstReport.Items.Add("Corrective Action / Preventive Action");
            lstReport.Items.Add("Frequency of Cases of TAT Triggering");
            lstReport.Items.Add("Duration needed to close SCAR");
        }
    }

    protected void onClick_btnGenerate(object sender, EventArgs e)
    {
        string reportOption = lstReport.Text;
        switch(reportOption)
        {
            case "1st Quadrant Report":
                Response.Redirect("reports_Q1.aspx");
                break;
            case "2nd Quadrant Report":
                Response.Redirect("reports_Q2.aspx");
                break;
            case "3rd Quadrant Report":
                Response.Redirect("reports_Q3.aspx");
                break;
            case "4th Quadrant Report":
                Response.Redirect("reports_Q4.aspx");
                break;
            case "Corrective Action / Preventive Action":
                Response.Redirect("reports_CAPA.aspx");
                break;
            case "Frequency of Cases of TAT Triggering":
                Response.Redirect("reports_TAT_frequency.aspx");
                break;
            case "Duration needed to close SCAR":
                Response.Redirect("reports_TAT_duration.aspx");
                break;

        }
    }
}
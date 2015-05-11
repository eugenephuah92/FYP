using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineer_reports_TAT_frequency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Search_TAT_Count()
    {
        
    }
    // Connect & fetch data from database
    private DataTable GetData()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT issued_date, escalation_count FROM TAT"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // Parse the value of the selected month
        int month = int.Parse(lstFilter.SelectedValue.ToString());
        int[] TATcount = new int[2];

        DataTable dt = this.GetData();

        foreach (DataRow row in dt.Rows)
        {
            // Compare the selected month with the month of the data fetched
            if (DateTime.Parse(row["issued_date"].ToString()).Month == month)
            {
                // Counter for 1st level escalation
                if (row["escalation_count"].ToString() == "1")
                {
                    TATcount[0]++;
                }
                // Counter for 2nd level escalation
                else if (row["escalation_count"].ToString() == "2")
                {
                    TATcount[1]++;
                }
            }
        }
        StringBuilder html = new StringBuilder(); // building a HTML string
        html.Append("<table class='table' style='text-align:center'>");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th style='text-align:center'>Month</th>");
        html.Append("<th style='text-align:center'>Frequency of Cases for Level 1 Trigger</th>");
        html.Append("<th style='text-align:center'>Frequency of Cases for Level 2 Trigger</th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody>");
        html.Append("<tr>");
        html.Append("<td>" + lstFilter.SelectedItem.ToString() + "</td>");
        html.Append("<td>" + TATcount[0] + "</td>");
        html.Append("<td>" + TATcount[1] + "</td>");
        html.Append("</tr>");
        html.Append("</tbody>");
        html.Append("</table>");

        Placeholder1.Controls.Add(new Literal { Text = html.ToString() });
    }
}
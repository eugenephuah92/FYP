using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class Manager_reports_TAT_frequency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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

    protected void Search_TAT_Count()
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // Parse the value of the selected year and month
        int year = int.Parse(lstYear.SelectedValue.ToString());
        //int month = int.Parse(lstMonth.SelectedValue.ToString());
        int[,] TATcount = new int[12, 2];
        string[] monthText = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        DataTable dt = this.GetData();

        foreach (DataRow row in dt.Rows)
        {
            // Compare the selected month with the month of the data fetched
            if (DateTime.Parse(row["issued_date"].ToString()).Year == year)
            {
                int month = DateTime.Parse(row["issued_date"].ToString()).Month;
                // Counter for 1st level escalation
                if (row["escalation_count"].ToString() == "1")
                {
                    TATcount[month - 1, 0]++;
                }
                // Counter for 2nd level escalation
                else if (row["escalation_count"].ToString() == "2")
                {
                    TATcount[month - 1, 1]++;
                }
            }
        }
        StringBuilder html = new StringBuilder(); // building a HTML string
        html.Append("<table class='table'>");
        html.Append("<thead>");
        html.Append("<tr>");
        html.Append("<th>Month</th>");
        html.Append("<th>Frequency for Level 1 Trigger</th>");
        html.Append("<th>Frequency for Level 2 Trigger</th>");
        html.Append("</tr>");
        html.Append("</thead>");
        html.Append("<tbody>");
        for (int i = 0; i < 12; i++)
        {
            html.Append("<tr>");
            html.Append("<td><a href='scars_by_month.aspx?month=" + monthText[i] + "&year=" + year + "'>" + monthText[i] + "</a></td>");
            html.Append("<td>" + TATcount[i, 0] + "</td>");
            html.Append("<td>" + TATcount[i, 1] + "</td>");
            html.Append("</tr>");
        }
        html.Append("</tbody>");
        html.Append("</table>");

        Placeholder1.Controls.Add(new Literal { Text = html.ToString() });
        btnExport.Visible = true;
        btnPrint.Visible = true;
    }
}

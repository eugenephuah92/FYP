using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using getWorkWeek;

public partial class Engineer_reports_Q4 : System.Web.UI.Page
{
    struct Case
    {
        public DateTime issued_date;
        public string defect_category;
    };

    DataTable dt;  // Populating a DataTable from database.
    DataTable dt1;
    Case[] q4;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Connect & fetch data from database
    private DataTable GetDate()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT issued_date, defect_type FROM SCAR_Request"))
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

    private DataTable GetDFM()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT defect_category FROM Defect_Category"))
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

    protected void generateQ4()
    {
        dt = this.GetDate();  // Populating a DataTable from database.
        dt1 = this.GetDFM();
        q4 = new Case[dt.Rows.Count];  // Struct to contain all SCAR records
        int r = 0; // Rows for q1
        getWW workWeek;
        workWeek = new getWW();
        //int[] count1 = new int[2];
        //int[,] ww_count = new int[2, 52]; // 2-D array to store total number of open/closed based on WW
        //int[,] ww_count0 = new int[2, 52]; // 2-D array to store total number of open/closed based on last year's WW
        int selectedWeek = workWeek.retWW(DateTime.Parse(cldStartDate1.Value.ToString()));
        int startweek = selectedWeek - 4; // Which week to start displaying data
        int weekcount = selectedWeek - startweek + 1;   // Total count of weeks including startweek
        string[] defect_modes = new string[dt1.Rows.Count];
        int dfm = 0; // defect category counter
        int[,] defect_modes_count = new int[weekcount, dt1.Rows.Count];
        // to store all the defect categories into the string array
        foreach (DataRow row1 in dt1.Rows)
        {
            defect_modes[dfm] = row1["defect_category"].ToString();
            dfm++;
        }
        foreach (DataRow row in dt.Rows)
        {
            q4[r].issued_date = DateTime.Parse(row["issued_date"].ToString());
            q4[r].defect_category = row["defect_type"].ToString();
            
            int ww = workWeek.retWW(q4[r].issued_date);
            if (ww >= startweek && ww <= selectedWeek)
            {
                for (int i = 0; i < dfm; i++)
                {
                    if (q4[r].defect_category == defect_modes[i])
                    {
                        defect_modes_count[ww-startweek, i]++;  // Count the total number of categories
                    }
                }

            }
        }

        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Top 5 Defect By Week";
        Chart_Q4.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        // Set the anchor for the chart
        Chart_Q4.ChartAreas[0].Position.Width = 80; // Specify the width of chartarea in percentage
        Chart_Q4.ChartAreas[0].Position.Height = 80;    // Specify the height of chartarea in percentage
        //Chart_Q4.ChartAreas[0].Position.X = 10;
        //Chart_Q4.ChartAreas[0].Position.Y = 20;

        for (int i = 0; i < dfm; i++)
        {
            Series series = Chart_Q4.Series.Add(defect_modes[i]);
            series.ChartType = SeriesChartType.StackedColumn;
            series.Name = defect_modes[i];
            series.IsValueShownAsLabel = false;
            series.SmartLabelStyle.Enabled = true;
            series["DrawingStyle"] = "Emboss";

            // Create chart legend
            Chart_Q4.Legends.Add(new Legend(defect_modes[i]));  // Create each individual legend         
            Chart_Q4.Legends[defect_modes[i]].IsDockedInsideChartArea = false;
            //Chart_Q4.Legends[defect_modes[i]].Position = new ElementPosition(100, 0, 15, 30);  // Parameters (x, y, width, height)

        }
        
        Chart_Q4.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q4.ChartAreas["ChartArea1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q4.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label
        Chart_Q4.ChartAreas["ChartArea1"].AxisX.Title = "Work Week";  // X-axis title    
        Chart_Q4.ChartAreas["ChartArea1"].AxisY.Title = "No. of Issues";  // Y-axis title

        // Create chart legend
        //Chart_Q4.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        //Chart_Q4.Legends["Legend1"].DockedToChartArea = "ChartArea1";  // Set docking of the chart legend to the ChartArea1
        //Chart_Q4.Legends["Legend1"].Position.Auto = false;
        //Chart_Q4.Legends["Legend1"].Position = new ElementPosition(85, 0, 15, 10);  // Parameters (x, y, width, height)

        // Assign the legend to Open
        //Chart_Q4.Series["DefectModes"].Legend = "Legend1";
        //Chart_Q4.Series["DefectModes"].IsVisibleInLegend = true;
        //Chart_Q4.DataSource = defect_category_count;

        //Chart_Q4.DataBind();
       // StringBuilder html = new StringBuilder();  // Building an HTML string.


        // For loop to populate the graph
        for (int i = 0; i < dfm; i++)
        {
            for (int j = 0; j < weekcount; j++)
            {
                if (defect_modes_count[j, i] < 0)
                {
                    Chart_Q4.Series[i].Points.Add(new DataPoint(startweek + j, 0));
                }
                else
                {
                    Chart_Q4.Series[i].Points.Add(new DataPoint(startweek + j, defect_modes_count[j, i]));
                }                
            }
                
            //html.Append(defect_modes_count[i]);
         
        }
        // Append the HTML string to Placeholder.
        //PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    protected void btnGenerateQ4_Click(object sender, EventArgs e)
    {
        generateQ4();
    }
}

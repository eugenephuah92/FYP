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

public partial class Engineer_reports_Q2 : System.Web.UI.Page
{
    struct Case
    {
        public DateTime issued_date;
        public string defect_category;
    };

    DataTable dt;  // Populating a DataTable from database.
    DataTable dt1;
    Case[] q2;

    protected void Page_Load(object sender, EventArgs e)
    { }

    protected void generateQ2()
    {
        dt = this.GetSCAR();  // Populating a DataTable from database.
        dt1 = this.GetDefectCategory();
        q2 = new Case[dt.Rows.Count];  // Struct to contain all SCAR records
        int r = 0; // Rows for q1
        getWW workWeek;
        workWeek = new getWW();
        int[] count1 = new int[2];
        int[,] ww_count = new int[2, 52]; // 2-D array to store total number of open/closed based on WW
        int[,] ww_count0 = new int[2, 52]; // 2-D array to store total number of open/closed based on last year's WW
        int selectedWeek = workWeek.retWW(DateTime.Parse(cldStartDate1.Value.ToString()));
        int startweek = selectedWeek - 4; // Which week to start displaying data
        int[] defect_category_count = new int[dt1.Rows.Count];
        string[] defect_category = new string[dt1.Rows.Count];
        int dfc = 0; // defect category counter
        
        // to store all the defect categories into the string array
        foreach(DataRow row1 in dt1.Rows)
        {
            defect_category[dfc] = row1["defect_category"].ToString();
            dfc++;
        }

        foreach (DataRow row in dt.Rows)
        {
            q2[r].issued_date = DateTime.Parse(row["issued_date"].ToString());
            q2[r].defect_category = row["defect_type"].ToString();
            // If issued_date(year) equals to the selected year
            //if (q1[r].issued_date.Year == DateTime.Parse(cldStartDate1.Value.ToString()).Year)

            if(workWeek.retWW(q2[r].issued_date) >= startweek && workWeek.retWW(q2[r].issued_date) <= selectedWeek)
            {
                int a = 0;

                for(int i = 0; i < dfc; i++)
                {
                    if (q2[r].defect_category == defect_category[i])
                    {
                        defect_category_count[a]++;  // Count the total number of categories
                    }
                    a++;
                }
                
            }
        }

        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Overall SCAR Pareto for 5 Weeks";
        Chart_Q2.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

        Chart_Q2.Series["Categories"].ChartType = SeriesChartType.Column;
        Chart_Q2.Series["Categories"]["DrawingStyle"] = "Emboss";
        Chart_Q2.Series["Categories"].IsValueShownAsLabel = false;  // show value of each bar or category 
        Chart_Q2.Series["Categories"].SmartLabelStyle.Enabled = true;
        Chart_Q2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label
        Chart_Q2.ChartAreas["ChartArea1"].AxisX.Title = "Defect Modes";  // X-axis title    
        Chart_Q2.ChartAreas["ChartArea1"].AxisY.Title = "No. of Issues";  // Y-axis title

        // Create chart legend
        Chart_Q2.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q2.Legends["Legend1"].DockedToChartArea = "ChartArea1";  // Set docking of the chart legend to the ChartArea1
        Chart_Q2.Legends["Legend1"].Position.Auto = false;
        Chart_Q2.Legends["Legend1"].Position = new ElementPosition(85, 13, 15, 10);  // Parameters (x, y, width, height)

        // Assign the legend to Open
        Chart_Q2.Series["Categories"].Legend = "Legend1";
        Chart_Q2.Series["Categories"].IsVisibleInLegend = true;
        //Chart_Q2.DataSource = defect_category_count;
        
        Chart_Q2.DataBind();

        // For loop to populate the graph
        for (int i = 0; i < defect_category_count.Count(); i++)
        {            
            Chart_Q2.Series["Categories"].Points.AddXY(defect_category[i], defect_category_count[i]);
        }

    }

    protected void btnGenerateQ2_Click(object sender, EventArgs e)
    {
        generateQ2();
    }

    // Connect & fetch data from database
    private DataTable GetSCAR()
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

    private DataTable GetDefectCategory()
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

    protected void exportChart()
    {
        string tmpChartName = "2ndQuardrant.jpg";

        string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName;
        Chart_Q2.SaveImage(imgPath);

        string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName);

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment; filename=testQ2.xls;");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";
        Response.Write(headerTable);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    // Export graph to picture and excel
    protected void btnExport_Q2_Click(object sender, EventArgs e)
    {
        generateQ2();
        exportChart();
    }
}
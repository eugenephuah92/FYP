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
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using getWorkWeek;

public partial class Engineer_reports_Q1 : System.Web.UI.Page
{
    public double[] test { get; set; }
    protected double[] totalRecord { get; set; }
    
    struct Case
    {
        public DateTime issued_date;
        public string status;
        public string defect_category;
    };
    
    DataTable dt, dt1;  // Populating a DataTable from database.
    Case[] record;
    string[] defect_category;
    getWW workWeek = new getWW();

    protected void Page_Load(object sender, EventArgs e)
    {
        //DateTime joinDate;
        Chart_Q1.DataBind();
        getSCARRecord();
        getDefectCategoryRecord();
        getGenerateOptions();        
    }

    // Get the record details 
    protected void getSCARRecord()
    {
        dt = this.GetSCAR();
        record = new Case[dt.Rows.Count];
        int i = 0;
        foreach (DataRow row in dt.Rows)
        {
            record[i].issued_date = DateTime.Parse(row["issued_date"].ToString());
            record[i].status = row["scar_status"].ToString();
            record[i].defect_category = row["defect_type"].ToString();
            i++;
        }
    }

    // to store all the defect categories into the string array
    protected void getDefectCategoryRecord()
    {
        dt1 = this.GetDefectCategory();
        defect_category = new string[dt1.Rows.Count];
        int i = 0;
        foreach (DataRow row in dt1.Rows)
        {
            defect_category[i] = row["defect_category"].ToString();
            i++;
        }
    }
    // Options to generate the graph based on user's selection
    protected void getGenerateOptions()
    {
        if (!IsPostBack)
        {
            lstGenerateOptions.Items.Add("Yearly");
            lstGenerateOptions.Items.Add("Monthly");
            lstGenerateOptions.Items.Add("Working Week");
        }

        getYearOptions();
        getMonthOptions();
        getWWOptions();
    }

    protected void getYearOptions()
    {
        if (lstGenerateOptions.SelectedItem.ToString() == "Yearly")
        {
            lblYearOptions.Visible = true;
            lstYearOptions.Visible = true;
            btnGenerateYear.Visible = true;

            // Add selection items into another dropdown list
            lstYearOptions.Items.Add("1995"); lstYearOptions.Items.Add("1996"); lstYearOptions.Items.Add("1997");
            lstYearOptions.Items.Add("1998"); lstYearOptions.Items.Add("1999"); lstYearOptions.Items.Add("2000");
            lstYearOptions.Items.Add("2001"); lstYearOptions.Items.Add("2002"); lstYearOptions.Items.Add("2003");
            lstYearOptions.Items.Add("2004"); lstYearOptions.Items.Add("2005"); lstYearOptions.Items.Add("2006");
            lstYearOptions.Items.Add("2007"); lstYearOptions.Items.Add("2008"); lstYearOptions.Items.Add("2009");
            lstYearOptions.Items.Add("2010"); lstYearOptions.Items.Add("2011"); lstYearOptions.Items.Add("2012");
            lstYearOptions.Items.Add("2013"); lstYearOptions.Items.Add("2014"); lstYearOptions.Items.Add("2015");
        }
        else 
        {
            lblYearOptions.Visible = false;
            lstYearOptions.Visible = false;
            btnGenerateYear.Visible = false;
        }
    }

    protected void generateYear()
    {
        int selectedYear = int.Parse(lstYearOptions.SelectedItem.ToString());
        int diff = DateTime.Now.Year - selectedYear; // To calculate the number of years of data to display
        int[] count1 = new int[2];
        int[,] ww_count = new int[2, diff + 1]; // 2-D array to store total number of open/closed based on WW

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if(record[r].issued_date.Year >= selectedYear)
            {
                
                if (record[r].status == "Open")
                {
                    ww_count[0, DateTime.Now.Year - record[r].issued_date.Year]++; // Counting the total Open SCAR according to their respective work weeks
                }
                else
                {
                    ww_count[1, DateTime.Now.Year - record[r].issued_date.Year]++; // Counting the total Closed SCAR according to their respective work weeks
                }
            }            
        }

        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "PCA / HLA Voice of Customer Trend (Agilent)";
        Chart_Q1.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

        Chart_Q1.Series["Open"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Open"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Open"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Open"].SmartLabelStyle.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorTickMark.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q1.ChartAreas["Q1"].AxisX.LabelStyle.Enabled = false; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q1.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q1.Legends["Legend1"].DockedToChartArea = "Q1";  // Set docking of the chart legend to the Q1
        Chart_Q1.Legends["Legend1"].Position.Auto = false;
        Chart_Q1.Legends["Legend1"].Position = new ElementPosition(85, 13, 15, 10);  // Parameters (x, y, width, height)

        // Assign the legend to Open
        Chart_Q1.Series["Open"].Legend = "Legend1";
        Chart_Q1.Series["Open"].IsVisibleInLegend = true;

        StringBuilder html = new StringBuilder();  // Building an HTML string.

        // Table start.
        html.Append("<table border = '1'>");
        string[,] rowHeader = new String[3, 20];

        html.Append("<tr>");
        html.Append("<td>");
        html.Append("</td>");

        for (int i = diff; i >= 0; i-- )
        {
            html.Append("<td>");
            html.Append(DateTime.Now.Year - i);
            html.Append("</td>");
        }

        html.Append("</tr>");

        // For loop to populate the graph
        for (int i = diff; i >= 0; i--)
        {
            Chart_Q1.Series["Open"].Points.AddY(ww_count[0, i]);
            Chart_Q1.Series["Closed"].Points.AddY(ww_count[1, i]);
        }

        // For loop to display the date in table
        for (int i = 0; i < 2; i++)
        {
            html.Append("<tr>");

            if (i == 0)
            {
                html.Append("<td>");
                html.Append("Open");
                html.Append("</td>");
            }
            else
            {
                html.Append("<td>");
                html.Append("Closed");
                html.Append("</td>");
            }

            for (int j = diff; j >= 0; j--)
            {
                html.Append("<td>");
                html.Append(ww_count[i, j]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
        html.Append("<tr>");
        html.Append("<td>Total</td>");

        // For loop to display the total number of scar status
        for (int i = diff; i >= 0; i--)
        {
            html.Append("<td>");
            html.Append(ww_count[0, i] + ww_count[1, i]); // sum total of open or closed according to WW
            html.Append("</td>");
        }

        html.Append("</table>");  // Table end.

        // Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    // Button to generate graph based on the year selected
    protected void btnGenerateYear_Click(object sender, EventArgs e)
    {
        generateYear();
    }

    protected void getMonthOptions()
    {
        if (lstGenerateOptions.SelectedItem.ToString() == "Monthly")
        {
            lblMonthOptions1.Visible = true;
            lblMonthOptions2.Visible = true;
            lstMonthOptions1.Visible = true;
            lstMonthOptions2.Visible = true;
            lblMonthYear.Visible = true;
            lstMonthYear.Visible = true;
            btnGenerateMonth.Visible = true;

            lstMonthYear.Items.Add("1995"); lstMonthYear.Items.Add("1996"); lstMonthYear.Items.Add("1997");
            lstMonthYear.Items.Add("1998"); lstMonthYear.Items.Add("1999"); lstMonthYear.Items.Add("2000");
            lstMonthYear.Items.Add("2001"); lstMonthYear.Items.Add("2002"); lstMonthYear.Items.Add("2003");
            lstMonthYear.Items.Add("2004"); lstMonthYear.Items.Add("2005"); lstMonthYear.Items.Add("2006");
            lstMonthYear.Items.Add("2007"); lstMonthYear.Items.Add("2008"); lstMonthYear.Items.Add("2009");
            lstMonthYear.Items.Add("2010"); lstMonthYear.Items.Add("2011"); lstMonthYear.Items.Add("2012");
            lstMonthYear.Items.Add("2013"); lstMonthYear.Items.Add("2014"); lstMonthYear.Items.Add("2015");
        }
        else
        {
            lblMonthOptions1.Visible = false;
            lblMonthOptions2.Visible = false;
            lstMonthOptions1.Visible = false;
            lstMonthOptions2.Visible = false;
            lblMonthYear.Visible = false;
            lstMonthYear.Visible = false;
            btnGenerateMonth.Visible = false;
        }
    }

    // Function to generate graph based on the criteria selected by month
    protected void generateMonth()
    {
        int selectedStartMonth = int.Parse(lstMonthOptions1.SelectedItem.Value.ToString());
        int selectedEndMonth = int.Parse(lstMonthOptions2.SelectedItem.Value.ToString());
        int selectedMonthYear = int.Parse(lstMonthYear.SelectedItem.ToString());
        int diff = selectedEndMonth - selectedStartMonth; // To calculate the number of years of data to display
        int[] count1 = new int[2];
        /*
         * the idea is to use endmonth minus startmonth to get a diff
         * then using the diff to declare the array size, and during the actual code, when u loop through the data u will use issue_date.month - startmonth, and then compare if its >= 0 && < diff
         * example , choose june until sept ( 6, 9)  , endmonth-startmonth = 9-6 = 3
         * when we run the data from the db, example if we get value from month june, it will be 6-6=0; hence index[0], july = 7-6, hence index[1].....so forth
         */
        int[,] ww_count = new int[2, diff + 1]; // 2-D array to store total number of open/closed based on WW

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if (record[r].issued_date.Year == selectedMonthYear && record[r].issued_date.Month >= selectedStartMonth && record[r].issued_date.Month <= selectedEndMonth)
            {
                if (record[r].issued_date.Month - selectedStartMonth >= 0 && record[r].issued_date.Month - selectedStartMonth <= diff)
                {
                    if (record[r].status == "Open")
                    {
                        ww_count[0, record[r].issued_date.Month - selectedStartMonth]++; // Counting the total Open SCAR according to their respective work weeks
                    }
                    else if (record[r].status == "Closed")
                    {
                        ww_count[1, record[r].issued_date.Month - selectedStartMonth]++; // Counting the total Closed SCAR according to their respective work weeks
                    }
                }
            }
        }

        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "PCA / HLA Voice of Customer Trend (Agilent)";
        Chart_Q1.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

        Chart_Q1.Series["Open"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Open"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Open"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Open"].SmartLabelStyle.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorTickMark.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q1.ChartAreas["Q1"].AxisX.LabelStyle.Enabled = false; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q1.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q1.Legends["Legend1"].DockedToChartArea = "Q1";  // Set docking of the chart legend to the ChartArea1
        Chart_Q1.Legends["Legend1"].Position.Auto = false;
        Chart_Q1.Legends["Legend1"].Position = new ElementPosition(85, 13, 15, 10);  // Parameters (x, y, width, height)

        // Assign the legend to Open
        Chart_Q1.Series["Open"].Legend = "Legend1";
        Chart_Q1.Series["Open"].IsVisibleInLegend = true;

        StringBuilder html = new StringBuilder();  // Building an HTML string.

        // Table start.
        html.Append("<table border = '1'>");
        string[,] rowHeader = new String[3, 20];
 
        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
        //DateTime yy = new DateTime(selectedMonthYear);

        html.Append("<tr>");
        html.Append("<td>");
        html.Append("</td>");

        for (int i = 0; i <= diff; i++)
        {
            html.Append("<td>");
            html.Append(mfi.GetMonthName(selectedStartMonth + i).ToString());
            //html.Append(selectedMonthYear.ToString("YY"));
            html.Append("</td>");
        }

        html.Append("</tr>");
        
        // For loop to populate the graph
        for (int i = 0; i <= diff; i++)
        {
            Chart_Q1.Series["Open"].Points.AddY(ww_count[0, i]);
            Chart_Q1.Series["Closed"].Points.AddY(ww_count[1, i]);
        }

        // For loop to display the date in table
        for (int i = 0; i < 2; i++)
        {
            html.Append("<tr>");

            if (i == 0)
            {
                html.Append("<td>");
                html.Append("Open");
                html.Append("</td>");
            }
            else
            {
                html.Append("<td>");
                html.Append("Closed");
                html.Append("</td>");
            }

            for (int j = 0; j <= diff; j++)
            {
                html.Append("<td>");
                html.Append(ww_count[i, j]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
        html.Append("<tr>");
        html.Append("<td>Total</td>");

        // For loop to display the total number of scar status
        for (int i = 0; i <= diff; i++)
        {
            html.Append("<td>");
            html.Append(ww_count[0, i] + ww_count[1, i]); // sum total of open or closed according to WW
            html.Append("</td>");
        }

        html.Append("</table>");  // Table end.

        // Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    // Button to generate graph based on the criteria selected
    protected void btnGenerateMonth_Click(object sender, EventArgs e)
    {
        generateMonth();
    }

    protected void getWWOptions()
    {
        if (lstGenerateOptions.SelectedItem.ToString() == "Working Week")
        {
            lblStartDate.Visible = true;
            cldStartDate.Visible = true;
            btnGenerateWW.Visible = true;
        }
        else
        {
            lblStartDate.Visible = false;
            cldStartDate.Visible = false;
            btnGenerateWW.Visible = false;
        }
    }

    // Function to generate graph based on selected date (work week)
    protected void generateWW()
    {
        int[] count1 = new int[2];
        int[,] ww_count = new int[2, 52]; // 2-D array to store total number of open/closed based on WW
        int[,] ww_count0 = new int[2, 52]; // 2-D array to store total number of open/closed based on last year's WW
        int selectedWeek = workWeek.retWW(DateTime.Parse(cldStartDate.Value.ToString()));
        int startweek = selectedWeek - 12; // Which week to start displaying data

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            // If issued_date(year) equals to the selected year
            if (record[r].issued_date.Year == DateTime.Parse(cldStartDate.Value.ToString()).Year)
            {
                if (record[r].status == "Open")
                {
                    ww_count[0, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Open SCAR according to their respective work weeks
                }
                else
                {
                    ww_count[1, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Closed SCAR according to their respective work weeks
                }
            }
            // Also capture 1 year before the selected year
            else if (record[r].issued_date.Year == DateTime.Parse(cldStartDate.Value.ToString()).Year - 1)
            {
                if (record[r].status == "Open")
                {
                    ww_count0[0, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Open SCAR according to their respective work weeks
                }
                else
                {
                    ww_count0[1, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Closed SCAR according to their respective work weeks
                }
            }
        }

        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "PCA / HLA Voice of Customer Trend (Agilent)";
        Chart_Q1.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

        Chart_Q1.Series["Open"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Open"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Open"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Open"].SmartLabelStyle.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorTickMark.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q1.ChartAreas["Q1"].AxisX.LabelStyle.Enabled = false; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q1.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q1.Legends["Legend1"].DockedToChartArea = "Q1";  // Set docking of the chart legend to the Q1
        Chart_Q1.Legends["Legend1"].Position.Auto = false;
        Chart_Q1.Legends["Legend1"].Position = new ElementPosition(85, 13, 15, 10);  // Parameters (x, y, width, height)

        // Assign the legend to Open
        Chart_Q1.Series["Open"].Legend = "Legend1";
        Chart_Q1.Series["Open"].IsVisibleInLegend = true;

        StringBuilder html = new StringBuilder();  // Building an HTML string.

        // Table start.
        html.Append("<table border = '1'>");
        string[,] rowHeader = new String[3, 20];

        html.Append("<tr>");
        html.Append("<td>");
        html.Append("</td>");
        
        for (int i = startweek; i <= selectedWeek; i++)
        {
            html.Append("<td>Week ");
            
            if(i < 0)
            {
                html.Append(i + 53);
            }
            else
            {
                html.Append(i + 1);
            }

            html.Append("</td>");
        }
        
        html.Append("</tr>");
        
        // For loop to populate the graph
        for (int i = startweek; i <= selectedWeek; i++)
        {
            if(i < 0)
            {
                Chart_Q1.Series["Open"].Points.AddY(ww_count0[0, i + 52]);
                Chart_Q1.Series["Closed"].Points.AddY(ww_count0[1, i + 52]);
            }
            else
            {
                Chart_Q1.Series["Open"].Points.AddY(ww_count[0, i]);
                Chart_Q1.Series["Closed"].Points.AddY(ww_count[1, i]);
            }
        }

        // For loop to display the data in table
        for (int i = 0; i < 2; i++)
        {
            html.Append("<tr>");

            if (i == 0)
            {
                html.Append("<td>");
                html.Append("Open");
                html.Append("</td>");
            }
            else
            {
                html.Append("<td>");
                html.Append("Closed");
                html.Append("</td>");
            }

            for (int j = startweek; j <= selectedWeek; j++)
            {
                html.Append("<td>");
                
                if(j < 0)
                {
                    html.Append(ww_count0[i, j + 52]);
                }
                else
                {
                    html.Append(ww_count[i, j]);
                }
                
                html.Append("</td>");
            }

            html.Append("</tr>");
        }

        html.Append("<tr>");
        html.Append("<td>Total</td>");

        // For loop to display the total number of scar status
        for (int i = startweek; i <= selectedWeek; i++)
        {
            html.Append("<td>");
            
            if(i < 0)
            {
                html.Append(ww_count0[0, i + 52] + ww_count0[1, i + 52]); // sum total of open or closed according to WW
            }
            else
            {
                html.Append(ww_count[0, i] + ww_count[1, i]); // sum total of open or closed according to WW
            }
            
            html.Append("</td>");
        }

        html.Append("</table>");  // Table end.

        // Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    protected void btnGenerateWW_Click(object sender, EventArgs e)
    {
        generateWW();
        generateQ2();
        generateQ4();
    }

    protected void generateQ2()
    {
        int selectedWeek = workWeek.retWW(DateTime.Parse(cldStartDate.Value.ToString()));
        int startweek = selectedWeek - 4; // Which week to start displaying data
        int[] defect_category_count = new int[dt1.Rows.Count];

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if (workWeek.retWW(record[r].issued_date) >= startweek && workWeek.retWW(record[r].issued_date) <= selectedWeek)
            {
                int a = 0;

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (record[r].defect_category == defect_category[i])
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
        Chart_Q2.ChartAreas["Q2"].AxisX.MajorGrid.Enabled = false;
        Chart_Q2.ChartAreas["Q2"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q2.ChartAreas["Q2"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label
        Chart_Q2.ChartAreas["Q2"].AxisX.Title = "Defect Modes";  // X-axis title    
        Chart_Q2.ChartAreas["Q2"].AxisY.Title = "No. of Issues";  // Y-axis title

        // Create chart legend
        Chart_Q2.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q2.Legends["Legend1"].DockedToChartArea = "Q2";  // Set docking of the chart legend to the ChartArea1
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


    protected void generateQ4()
    {
        int selectedWeek = workWeek.retWW(DateTime.Parse(cldStartDate.Value.ToString()));
        int startweek = selectedWeek - 4; // Which week to start displaying data
        int weekcount = selectedWeek - startweek + 1;   // Total count of weeks including startweek
        int[,] defect_modes_count = new int[weekcount, dt1.Rows.Count];

        for(int r = 0; r < dt.Rows.Count; r++)
        {
            int ww = workWeek.retWW(record[r].issued_date);
            if (ww >= startweek && ww <= selectedWeek)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (record[r].defect_category == defect_category[i])
                    {
                        defect_modes_count[ww - startweek, i]++;  // Count the total number of categories
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

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            Series series = Chart_Q4.Series.Add(defect_category[i]);
            series.ChartType = SeriesChartType.StackedColumn;
            series.Name = defect_category[i];
            series.IsValueShownAsLabel = false;
            series.SmartLabelStyle.Enabled = true;
            series["DrawingStyle"] = "Emboss";

            // Create chart legend
            Chart_Q4.Legends.Add(new Legend(defect_category[i]));  // Create each individual legend         
            Chart_Q4.Legends[defect_category[i]].IsDockedInsideChartArea = false;
            //Chart_Q4.Legends[defect_modes[i]].Position = new ElementPosition(100, 0, 15, 30);  // Parameters (x, y, width, height)

        }

        Chart_Q4.ChartAreas["Q4"].AxisX.MajorGrid.Enabled = false;
        Chart_Q4.ChartAreas["Q4"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q4.ChartAreas["Q4"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label
        Chart_Q4.ChartAreas["Q4"].AxisX.Title = "Work Week";  // X-axis title    
        Chart_Q4.ChartAreas["Q4"].AxisY.Title = "No. of Issues";  // Y-axis title

        // For loop to populate the graph
        for (int i = 0; i < dt1.Rows.Count; i++)
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
        }
    }

    // Connect & fetch data from database
    private DataTable GetSCAR()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT issued_date, scar_status, defect_type FROM SCAR_Request"))
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
        string tmpChartName = "1stQuardrant.jpg";

        string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName;
        Chart_Q1.SaveImage(imgPath, ChartImageFormat.Png);

        string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment; filename=testQ1.xls;");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";
        Response.Write(headerTable);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    // Export graph to picture and excel file
    protected void btnExport_Q1_Click(object sender, EventArgs e)
    {
        generateWW();
        exportChart();
    }
}

/*  protected void printRepOne(object sender, EventArgs e)
    {
        Session["printType"] = 2;
        Response.Redirect("print.aspx");
    }
    protected void printRepTwo(object sender, EventArgs e)
    {
        Session["printType"] = 3;
        Response.Redirect("print.aspx");
    }
*/
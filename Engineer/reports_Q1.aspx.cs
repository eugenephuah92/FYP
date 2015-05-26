using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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

    // Store all the defect categories into the string array
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
        //getMonthOptions();
        //getWWOptions();
    }

    protected void getYearOptions()
    {
        if (lstGenerateOptions.SelectedItem.ToString() == "Yearly")
        {
            monthFieldNotVisible();
            wwFieldNotVisible();
            yearFieldVisible();

            for (int i = 4; i >= 0; i--)
            {
                lstYearOptions1.Items.Add((DateTime.Now.Year - i).ToString());  // Add selection items into dropdown list 1 (from year)
                lstYearOptions2.Items.Add((DateTime.Now.Year - i).ToString());  // Add selection items into dropdown list 2 (to year)
            }
        }
        else if (lstGenerateOptions.SelectedItem.ToString() == "Monthly")
        {
            yearFieldNotVisible();
            wwFieldNotVisible();
            monthFieldVisible();

            for (int i = 4; i >= 0; i--)
            {
                lstMonthYear.Items.Add((DateTime.Now.Year - i).ToString());
            }
        }
        else if (lstGenerateOptions.SelectedItem.ToString() == "Working Week")
        {
            yearFieldNotVisible();
            monthFieldNotVisible();
            wwFieldVisible();
        }
        else
        {
            yearFieldNotVisible();
            monthFieldNotVisible();
            wwFieldNotVisible();
        }
    }

    protected void yearFieldVisible()
    {
        lblYearOptions1.Visible = true;
        lblYearOptions2.Visible = true;
        lstYearOptions1.Visible = true;
        lstYearOptions2.Visible = true;
        btnGenerateYear.Visible = true;
    }

    protected void yearFieldNotVisible()
    {
        lblYearOptions1.Visible = false;
        lblYearOptions2.Visible = false;
        lstYearOptions1.Visible = false;
        lstYearOptions2.Visible = false;
        btnGenerateYear.Visible = false;
    }

    protected void monthFieldVisible()
    {
        lblMonthOptions1.Visible = true;
        lblMonthOptions2.Visible = true;
        lstMonthOptions1.Visible = true;
        lstMonthOptions2.Visible = true;
        lblMonthYear.Visible = true;
        lstMonthYear.Visible = true;
        btnGenerateMonth.Visible = true;
    }

    protected void monthFieldNotVisible()
    {
        lblMonthOptions1.Visible = false;
        lblMonthOptions2.Visible = false;
        lstMonthOptions1.Visible = false;
        lstMonthOptions2.Visible = false;
        lblMonthYear.Visible = false;
        lstMonthYear.Visible = false;
        btnGenerateMonth.Visible = false;
    }

    protected void wwFieldVisible()
    {
        lblNote1.Visible = true;
        lblStartDate.Visible = true;
        cldStartDate.Visible = true;
        btnGenerateWW.Visible = true;
    }

    protected void wwFieldNotVisible()
    {
        lblNote1.Visible = false;
        lblStartDate.Visible = false;
        cldStartDate.Visible = false;
        btnGenerateWW.Visible = false;
    }

    protected void generateQ1Year()
    {
        int selectedFromYear = int.Parse(lstYearOptions1.SelectedItem.ToString());
        int selectedToYear = int.Parse(lstYearOptions2.SelectedItem.ToString());
        int diff = selectedToYear - selectedFromYear; // To calculate the number of years of data to display
        int[] count1 = new int[2];
        int[,] ww_count = new int[2, diff + 1]; // 2-D array to store total number of open/closed based on WW

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if (record[r].issued_date.Year >= selectedFromYear && record[r].issued_date.Year <= selectedToYear)
            {
                if (record[r].status == "Closed")
                {
                    ww_count[1, selectedToYear - record[r].issued_date.Year]++; // Counting the total Closed SCAR according to their respective work weeks
                }
                else
                {
                    ww_count[0, selectedToYear - record[r].issued_date.Year]++; // Counting the total Open SCAR according to their respective work weeks
                }
            }
        }

        /* Graph settings based on the year selected */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "PCA / HLA Voice of Customer Trend (Agilent)";
        Chart_Q1.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q1.ChartAreas["Q1"].AxisX.Title = "Year";  // X-axis title    
        Chart_Q1.ChartAreas["Q1"].AxisY.Title = "Quantity";  // Y-axis title

        Chart_Q1.Series["Open"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Open"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Open"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Open"].SmartLabelStyle.Enabled = true;
        Chart_Q1.Series["Closed"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Closed"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Closed"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Closed"].SmartLabelStyle.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorTickMark.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisY.MajorGrid.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q1.ChartAreas["Q1"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q1.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q1.Legends["Legend1"].IsDockedInsideChartArea = false;
        Chart_Q1.Legends["Legend1"].Position.Auto = true;
        Chart_Q1.Legends["Legend1"].Title = "Category";
        Chart_Q1.Legends["Legend1"].BorderColor = System.Drawing.Color.LightGray;
        Chart_Q1.Legends["Legend1"].BorderWidth = 1;

        // Assign the legend
        Chart_Q1.Series["Open"].Legend = "Legend1";
        Chart_Q1.Series["Open"].IsVisibleInLegend = true;

        DataTable dt_table = new DataTable();
        dt_table.Columns.Add(" ", Type.GetType("System.String"));
        dt_table.Columns.Add("Open", Type.GetType("System.String"));
        dt_table.Columns.Add("Closed", Type.GetType("System.String"));
        dt_table.Columns.Add("Total", Type.GetType("System.String"));

        for (int i = diff; i >= 0; i--)
        {
            dt_table.Rows.Add();
            dt_table.Rows[dt_table.Rows.Count - 1][" "] = selectedToYear - i;
            dt_table.Rows[dt_table.Rows.Count - 1]["Open"] = ww_count[0, i];
            dt_table.Rows[dt_table.Rows.Count - 1]["Closed"] = ww_count[1, i];
            dt_table.Rows[dt_table.Rows.Count - 1]["Total"] = ww_count[0, i] + ww_count[1, i];
        }

        Chart_Q1.DataBind();

        // For loop to populate the graph
        for (int i = diff; i >= 0; i--)
        {
            Chart_Q1.Series["Open"].Points.AddXY((selectedToYear - i).ToString(), ww_count[0, i]);
            Chart_Q1.Series["Closed"].Points.AddXY((selectedToYear - i).ToString(), ww_count[1, i]);
        }

        GridView1.DataSource = dt_table;
        GridView1.DataBind();
    }

    // Button to generate graph based on the year selected
    protected void btnGenerateYear_Click(object sender, EventArgs e)
    {
        generateQ1Year();
        generateQ2Year();
        generateQ4Year();
    }

    /*
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
     */

    // Function to generate graph based on the criteria selected by month
    protected void generateQ1Month()
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
                    if (record[r].status == "Closed")
                    {
                        ww_count[1, record[r].issued_date.Month - selectedStartMonth]++; // Counting the total Open SCAR according to their respective work weeks
                    }
                    else
                    {
                        ww_count[0, record[r].issued_date.Month - selectedStartMonth]++; // Counting the total Closed SCAR according to their respective work weeks
                    }
                }
            }
        }

        /* Graph settings based on the month selected */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "PCA / HLA Voice of Customer Trend (Agilent)";
        Chart_Q1.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q1.ChartAreas["Q1"].AxisX.Title = "Month";  // X-axis title    
        Chart_Q1.ChartAreas["Q1"].AxisY.Title = "Quantity";  // Y-axis title

        Chart_Q1.Series["Open"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Open"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Open"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Open"].SmartLabelStyle.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorTickMark.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q1.ChartAreas["Q1"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q1.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q1.Legends["Legend1"].IsDockedInsideChartArea = false;
        Chart_Q1.Legends["Legend1"].Position.Auto = true;
        Chart_Q1.Legends["Legend1"].Title = "Category";
        Chart_Q1.Legends["Legend1"].BorderColor = System.Drawing.Color.LightGray;
        Chart_Q1.Legends["Legend1"].BorderWidth = 1;

        // Assign the legend
        Chart_Q1.Series["Open"].Legend = "Legend1";
        Chart_Q1.Series["Open"].IsVisibleInLegend = true;

        DateTimeFormatInfo mfi = new DateTimeFormatInfo();

        DataTable dt_table = new DataTable();
        dt_table.Columns.Add(" ", Type.GetType("System.String"));
        dt_table.Columns.Add("Open", Type.GetType("System.String"));
        dt_table.Columns.Add("Closed", Type.GetType("System.String"));
        dt_table.Columns.Add("Total", Type.GetType("System.String"));

        for (int i = diff; i >= 0; i--)
        {
            dt_table.Rows.Add();
            dt_table.Rows[dt_table.Rows.Count - 1][" "] = mfi.GetMonthName(selectedEndMonth - i).ToString();
            dt_table.Rows[dt_table.Rows.Count - 1]["Open"] = ww_count[0, i];
            dt_table.Rows[dt_table.Rows.Count - 1]["Closed"] = ww_count[1, i];
            dt_table.Rows[dt_table.Rows.Count - 1]["Total"] = ww_count[0, i] + ww_count[1, i];
        }

        Chart_Q1.DataBind();

        // For loop to populate the graph
        for (int i = diff; i >= 0; i--)
        {
            Chart_Q1.Series["Open"].Points.AddXY(mfi.GetMonthName(selectedEndMonth - i).ToString(), ww_count[0, i]);
            Chart_Q1.Series["Closed"].Points.AddXY(mfi.GetMonthName(selectedEndMonth - i).ToString(), ww_count[1, i]);
        }

        GridView1.DataSource = dt_table;
        GridView1.DataBind();
    }

    // Button to generate graph based on the criteria selected
    protected void btnGenerateMonth_Click(object sender, EventArgs e)
    {
        generateQ1Month();
        generateQ2Month();
        generateQ4Month();
    }

    /*
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
    */

    // Function to generate graph based on selected date (work week)
    protected void generateQ1WW()
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
                if (record[r].status == "Closed")
                {
                    ww_count[1, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Open SCAR according to their respective work weeks
                }
                else
                {
                    ww_count[0, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Closed SCAR according to their respective work weeks
                }
            }
            // Also capture 1 year before the selected year
            else if (record[r].issued_date.Year == DateTime.Parse(cldStartDate.Value.ToString()).Year - 1)
            {
                if (record[r].status == "Closed")
                {
                    ww_count0[1, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Open SCAR according to their respective work weeks
                }
                else
                {
                    ww_count0[0, workWeek.retWW(record[r].issued_date) - 1]++; // Counting the total Closed SCAR according to their respective work weeks
                }
            }
        }

        /* Graph settings based on the work week selected */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "PCA / HLA Voice of Customer Trend (Agilent)";
        Chart_Q1.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q1.ChartAreas["Q1"].AxisX.Title = "Work Week";  // X-axis title    
        Chart_Q1.ChartAreas["Q1"].AxisY.Title = "Quantity";  // Y-axis title

        Chart_Q1.Series["Open"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Open"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Open"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Open"].SmartLabelStyle.Enabled = true;
        Chart_Q1.Series["Closed"].ChartType = SeriesChartType.Column;
        Chart_Q1.Series["Closed"]["DrawingStyle"] = "Emboss";
        Chart_Q1.Series["Closed"].IsValueShownAsLabel = false;  // Show value of each bar or category 
        Chart_Q1.Series["Closed"].SmartLabelStyle.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorGrid.Enabled = false;
        Chart_Q1.ChartAreas["Q1"].AxisX.MajorTickMark.Enabled = true;
        Chart_Q1.ChartAreas["Q1"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q1.ChartAreas["Q1"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q1.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q1.Legends["Legend1"].IsDockedInsideChartArea = false;  // Set docking of the chart legend to the Q1
        Chart_Q1.Legends["Legend1"].Position.Auto = true;
        Chart_Q1.Legends["Legend1"].Title = "Category";
        Chart_Q1.Legends["Legend1"].BorderColor = System.Drawing.Color.LightGray;
        Chart_Q1.Legends["Legend1"].BorderWidth = 1;

        // Assign the legend to Open
        Chart_Q1.Series["Open"].Legend = "Legend1";
        Chart_Q1.Series["Open"].IsVisibleInLegend = true;

        DataTable dt_table = new DataTable();
        dt_table.Columns.Add(" ", Type.GetType("System.String"));
        dt_table.Columns.Add("Open", Type.GetType("System.String"));
        dt_table.Columns.Add("Closed", Type.GetType("System.String"));
        dt_table.Columns.Add("Total", Type.GetType("System.String"));

        for (int i = startweek; i <= selectedWeek; i++)
        {
            dt_table.Rows.Add();

            if (i < 0)
            {
                dt_table.Rows[dt_table.Rows.Count - 1][" "] = "Week " + (i + 53);
                dt_table.Rows[dt_table.Rows.Count - 1]["Open"] = ww_count0[0, (i + 52)];
                dt_table.Rows[dt_table.Rows.Count - 1]["Closed"] = ww_count0[1, (i + 52)];
                dt_table.Rows[dt_table.Rows.Count - 1]["Total"] = ww_count0[0, (i + 52)] + ww_count0[1, (i + 52)];
            }
            else
            {
                dt_table.Rows[dt_table.Rows.Count - 1][" "] = "Week " + i;
                dt_table.Rows[dt_table.Rows.Count - 1]["Open"] = ww_count[0, i];
                dt_table.Rows[dt_table.Rows.Count - 1]["Closed"] = ww_count[1, i];
                dt_table.Rows[dt_table.Rows.Count - 1]["Total"] = ww_count[0, i] + ww_count[1, i];
            }
        }

        Chart_Q1.DataBind();

        // For loop to populate the graph
        for (int i = startweek; i <= selectedWeek; i++)
        {
            if (i < 0)
            {
                Chart_Q1.Series["Open"].Points.AddXY("Week " + (i + 53), ww_count0[0, (i + 52)]);
                Chart_Q1.Series["Closed"].Points.AddXY("Week " + (i + 53), ww_count0[1, (i + 52)]);
            }
            else
            {
                Chart_Q1.Series["Open"].Points.AddXY("Week " + i, ww_count[0, i]);
                Chart_Q1.Series["Closed"].Points.AddXY("Week " + i, ww_count[1, i]);
            }
        }

        GridView1.DataSource = dt_table;
        GridView1.DataBind();
    }

    protected void btnGenerateWW_Click(object sender, EventArgs e)
    {
        generateQ1WW();
        generateQ2WW();
        generateQ4WW();
    }

    protected void generateQ2Year()
    {
        int selectedFromYear = int.Parse(lstYearOptions1.SelectedItem.ToString());
        int selectedToYear = int.Parse(lstYearOptions2.SelectedItem.ToString());
        int[] defect_category_count = new int[dt1.Rows.Count];

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if (record[r].issued_date.Year >= selectedFromYear && record[r].issued_date.Year <= selectedToYear)
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

        /* Graph settings for second quadrant(Q2) */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Overall SCAR Pareto for 5 Weeks";
        Chart_Q2.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q2.ChartAreas["Q2"].AxisX.Title = "Defect Modes";  // X-axis title    
        Chart_Q2.ChartAreas["Q2"].AxisY.Title = "No. of Issues";  // Y-axis title

        Chart_Q2.Series["Categories"].ChartType = SeriesChartType.Column;
        Chart_Q2.Series["Categories"]["DrawingStyle"] = "Emboss";
        Chart_Q2.Series["Categories"].IsValueShownAsLabel = false;  // show value of each bar or category 
        Chart_Q2.Series["Categories"].SmartLabelStyle.Enabled = true;
        Chart_Q2.ChartAreas["Q2"].AxisX.MajorGrid.Enabled = false;
        Chart_Q2.ChartAreas["Q2"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q2.ChartAreas["Q2"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q2.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q2.Legends["Legend1"].IsDockedInsideChartArea = false;  // Set docking of the chart legend to the ChartArea1
        Chart_Q2.Legends["Legend1"].Position.Auto = true;
        Chart_Q2.Legends["Legend1"].Title = "Defect Modes";
        Chart_Q2.Legends["Legend1"].BorderColor = System.Drawing.Color.LightGray;
        Chart_Q2.Legends["Legend1"].BorderWidth = 1;

        Chart_Q2.Series["Categories"].Legend = "Legend1";
        Chart_Q2.Series["Categories"].IsVisibleInLegend = true;

        Chart_Q2.DataBind();

        // For loop to populate the graph
        for (int i = 0; i < defect_category_count.Count(); i++)
        {
            Chart_Q2.Series["Categories"].Points.AddXY(defect_category[i], defect_category_count[i]);
        }
    }

    protected void generateQ2Month()
    {
        int selectedStartMonth = int.Parse(lstMonthOptions1.SelectedItem.Value.ToString());
        int selectedEndMonth = int.Parse(lstMonthOptions2.SelectedItem.Value.ToString());
        int selectedMonthYear = int.Parse(lstMonthYear.SelectedItem.ToString());
        int diff = selectedEndMonth - selectedStartMonth; // To calculate the number of years of data to display
        int[] defect_category_count = new int[dt1.Rows.Count];

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if (record[r].issued_date.Year == selectedMonthYear && record[r].issued_date.Month >= selectedStartMonth && record[r].issued_date.Month <= selectedEndMonth)
            {
                if (record[r].issued_date.Month - selectedStartMonth >= 0 && record[r].issued_date.Month - selectedStartMonth <= diff)
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
        }

        /* Graph settings for second quadrant(Q2) */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Overall SCAR Pareto for 5 Weeks";
        Chart_Q2.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q2.ChartAreas["Q2"].AxisX.Title = "Defect Modes";  // X-axis title    
        Chart_Q2.ChartAreas["Q2"].AxisY.Title = "No. of Issues";  // Y-axis title

        Chart_Q2.Series["Categories"].ChartType = SeriesChartType.Column;
        Chart_Q2.Series["Categories"]["DrawingStyle"] = "Emboss";
        Chart_Q2.Series["Categories"].IsValueShownAsLabel = false;  // show value of each bar or category 
        Chart_Q2.Series["Categories"].SmartLabelStyle.Enabled = true;
        Chart_Q2.ChartAreas["Q2"].AxisX.MajorGrid.Enabled = false;
        Chart_Q2.ChartAreas["Q2"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q2.ChartAreas["Q2"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q2.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q2.Legends["Legend1"].IsDockedInsideChartArea = false;  // Set docking of the chart legend to the ChartArea1
        Chart_Q2.Legends["Legend1"].Position.Auto = true;
        Chart_Q2.Legends["Legend1"].Title = "Defect Modes";
        Chart_Q2.Legends["Legend1"].BorderColor = System.Drawing.Color.LightGray;
        Chart_Q2.Legends["Legend1"].BorderWidth = 1;

        // Assign the legend
        Chart_Q2.Series["Categories"].Legend = "Legend1";
        Chart_Q2.Series["Categories"].IsVisibleInLegend = true;

        Chart_Q2.DataBind();

        // For loop to populate the graph
        for (int i = 0; i < defect_category_count.Count(); i++)
        {
            Chart_Q2.Series["Categories"].Points.AddXY(defect_category[i], defect_category_count[i]);
        }
    }

    // Generate second quadrant(Q2)
    protected void generateQ2WW()
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

        /* Graph settings for second quadrant(Q2) */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Overall SCAR Pareto for 5 Weeks";
        Chart_Q2.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q2.ChartAreas["Q2"].AxisX.Title = "Defect Modes";  // X-axis title    
        Chart_Q2.ChartAreas["Q2"].AxisY.Title = "No. of Issues";  // Y-axis title

        Chart_Q2.Series["Categories"].ChartType = SeriesChartType.Column;
        Chart_Q2.Series["Categories"]["DrawingStyle"] = "Emboss";
        Chart_Q2.Series["Categories"].IsValueShownAsLabel = false;  // show value of each bar or category 
        Chart_Q2.Series["Categories"].SmartLabelStyle.Enabled = true;
        Chart_Q2.ChartAreas["Q2"].AxisX.MajorGrid.Enabled = false;
        Chart_Q2.ChartAreas["Q2"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q2.ChartAreas["Q2"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Create chart legend
        Chart_Q2.Legends.Add(new Legend("Legend1"));  // Create a legend called "Legend1"
        Chart_Q2.Legends["Legend1"].IsDockedInsideChartArea = false;  // Set docking of the chart legend to the ChartArea1
        Chart_Q2.Legends["Legend1"].Position.Auto = true;
        Chart_Q2.Legends["Legend1"].Title = "Defect Modes";
        Chart_Q2.Legends["Legend1"].BorderColor = System.Drawing.Color.LightGray;
        Chart_Q2.Legends["Legend1"].BorderWidth = 1;

        // Assign the legend
        Chart_Q2.Series["Categories"].Legend = "Legend1";
        Chart_Q2.Series["Categories"].IsVisibleInLegend = true;

        Chart_Q2.DataBind();

        // For loop to populate the graph
        for (int i = 0; i < defect_category_count.Count(); i++)
        {
            Chart_Q2.Series["Categories"].Points.AddXY(defect_category[i], defect_category_count[i]);
        }
    }

    protected void generateQ4Year()
    {
        int selectedFromYear = int.Parse(lstYearOptions1.SelectedItem.ToString());
        int selectedToYear = int.Parse(lstYearOptions2.SelectedItem.ToString());
        int diff = selectedToYear - selectedFromYear + 1; // To calculate the number of years of data to display
        int[,] defect_modes_count = new int[diff, dt1.Rows.Count];

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            int ww = record[r].issued_date.Year;

            if (ww >= selectedFromYear && ww <= selectedToYear)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (record[r].defect_category == defect_category[i])
                    {
                        defect_modes_count[ww - selectedFromYear, i]++;  // Count the total number of categories
                    }
                }

            }
        }

        /* Graph settings for fourth quadrant(Q4) */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Top 5 Defect By Year";
        Chart_Q4.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q4.ChartAreas["Q4"].AxisX.Title = "Year";  // X-axis title    
        Chart_Q4.ChartAreas["Q4"].AxisY.Title = "No. of Issues";  // Y-axis title

        Chart_Q4.ChartAreas["Q4"].AxisX.MajorGrid.Enabled = false;
        Chart_Q4.ChartAreas["Q4"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q4.ChartAreas["Q4"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

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
            Chart_Q4.Legends[defect_category[i]].Title = "Defect Modes Category";
            Chart_Q4.Legends[defect_category[i]].BorderColor = System.Drawing.Color.LightGray;
            Chart_Q4.Legends[defect_category[i]].BorderWidth = 1;
        }

        Chart_Q4.DataBind();

        // For loop to populate the graph
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            for (int j = 0; j < diff; j++)
            {
                if (defect_modes_count[j, i] < 0)
                {
                    Chart_Q4.Series[i].Points.AddXY((selectedFromYear + j).ToString(), 0);
                }
                else
                {
                    Chart_Q4.Series[i].Points.AddXY((selectedFromYear + j).ToString(), defect_modes_count[j, i]);
                }
            }
        }
    }

    protected void generateQ4Month()
    {
        int selectedStartMonth = int.Parse(lstMonthOptions1.SelectedItem.Value.ToString());
        int selectedEndMonth = int.Parse(lstMonthOptions2.SelectedItem.Value.ToString());
        int selectedMonthYear = int.Parse(lstMonthYear.SelectedItem.ToString());
        int diff = selectedEndMonth - selectedStartMonth + 1; // To calculate the number of years of data to display
        int[,] defect_modes_count = new int[diff, dt1.Rows.Count];

        for (int r = 0; r < dt.Rows.Count; r++)
        {
            if (record[r].issued_date.Year == selectedMonthYear && record[r].issued_date.Month >= selectedStartMonth && record[r].issued_date.Month <= selectedEndMonth)
            {
                if (record[r].issued_date.Month - selectedStartMonth >= 0 && record[r].issued_date.Month - selectedStartMonth <= diff)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (record[r].defect_category == defect_category[i])
                        {
                            defect_modes_count[record[r].issued_date.Month - selectedStartMonth, i]++;  // Count the total number of categories
                        }
                    }
                }
            }
        }

        /* Graph settings for fourth quadrant(Q4) */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Top 5 Defect By Month";
        Chart_Q4.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q4.ChartAreas["Q4"].AxisX.Title = "Month";  // X-axis title    
        Chart_Q4.ChartAreas["Q4"].AxisY.Title = "No. of Issues";  // Y-axis title

        Chart_Q4.ChartAreas["Q4"].AxisX.MajorGrid.Enabled = false;
        Chart_Q4.ChartAreas["Q4"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q4.ChartAreas["Q4"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

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
            Chart_Q4.Legends[defect_category[i]].Position.Auto = true;
            Chart_Q4.Legends[defect_category[i]].Title = "Defect Modes Category";
            Chart_Q4.Legends[defect_category[i]].BorderColor = System.Drawing.Color.LightGray;
            Chart_Q4.Legends[defect_category[i]].BorderWidth = 1;
        }

        DateTimeFormatInfo mfi = new DateTimeFormatInfo();

        // For loop to populate the graph
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            for (int j = 0; j < diff; j++)
            {
                if (defect_modes_count[j, i] < 0)
                {
                    Chart_Q4.Series[i].Points.AddXY(mfi.GetMonthName(selectedStartMonth + j).ToString(), 0);
                }
                else
                {
                    Chart_Q4.Series[i].Points.AddXY(mfi.GetMonthName(selectedStartMonth + j).ToString(), defect_modes_count[j, i]);
                }
            }
        }
    }

    // Generate fourth quadrant(Q4)
    protected void generateQ4WW()
    {
        int selectedWeek = workWeek.retWW(DateTime.Parse(cldStartDate.Value.ToString()));
        int startweek = selectedWeek - 4; // Which week to start displaying data
        int weekcount = selectedWeek - startweek + 1;   // Total count of weeks including startweek
        int[,] defect_modes_count = new int[weekcount, dt1.Rows.Count];

        for (int r = 0; r < dt.Rows.Count; r++)
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

        /* Graph settings for fourth quadrant(Q4) */
        // Graph title
        Title graphTitle = new Title();
        graphTitle.Name = "tTitle";
        graphTitle.Text = "Top 5 Defect By Week";
        Chart_Q4.Titles.Add(graphTitle);
        graphTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Chart_Q4.ChartAreas["Q4"].AxisX.Title = "Work Week";  // X-axis title    
        Chart_Q4.ChartAreas["Q4"].AxisY.Title = "No. of Issues";  // Y-axis title

        Chart_Q4.ChartAreas["Q4"].AxisX.MajorGrid.Enabled = false;
        Chart_Q4.ChartAreas["Q4"].AxisY.LabelStyle.Interval = 1;  // X-axis interval
        Chart_Q4.ChartAreas["Q4"].AxisX.LabelStyle.Enabled = true; // Enable or disable X-axis label

        // Set the anchor for the chart
        /*
        Chart_Q4.ChartAreas[0].Position.Width = 80; // Specify the width of chartarea in percentage
        Chart_Q4.ChartAreas[0].Position.Height = 80;    // Specify the height of chartarea in percentage
        */

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
            Chart_Q4.Legends[defect_category[i]].Position.Auto = true;
            Chart_Q4.Legends[defect_category[i]].Title = "Defect Modes Category";
            Chart_Q4.Legends[defect_category[i]].BorderColor = System.Drawing.Color.LightGray;
            Chart_Q4.Legends[defect_category[i]].BorderWidth = 1;
        }

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
            using (SqlCommand cmd = new SqlCommand("SELECT [issued_date], [scar_status], [defect_type] FROM dbo.[SCAR_Request]"))
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
            using (SqlCommand cmd = new SqlCommand("SELECT [defect_category] FROM dbo.[Defect_Category]"))
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

    // Export graph to picture and excel file
    protected void exportChart()
    {
        string tmpChartName = "1stQuardrant.jpg";

        string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName;
        Chart_Q1.SaveImage(imgPath, ChartImageFormat.Png);

        string imgPaths = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment; filename=testQ1.xls;");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        string headerTable = @"<Table><tr><td><img src='" + imgPaths + @"' \></td></tr></Table>";
        Response.Write(headerTable);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        generateQ1WW();
        exportChart();
    }
}
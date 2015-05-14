using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using FYP_WebApp.Old_App_Code;

public partial class Engineer_scar_log : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        SCAR scar_details = new SCAR();
        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Disapprove Frequency");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("Completion Date");

        int jj = 0;
        int j = 0;
        DataRow dr;
        int countRows = Count_History_Rows();
        int countMore = Count_Request_Rows();
        int total = countMore + countRows;
        string[] scar_no_closed = new string[countRows];
        string[] frequency = new string[total];
        int[] row_no_closed = new int[countRows];
        int[] row_frequency = new int[total];
        
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT scar_status, scar_no, issued_date FROM dbo.SCAR_Request UNION 
SELECT scar_status, scar_no, issued_date FROM dbo.SCAR_History", conn);
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No SCARS Records Found!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            
            while (rdr.Read())
            {
                dr = dt.NewRow();
                
                dr["CAR Number"] = rdr["scar_no"].ToString();
                scar_details.Car_no = rdr["scar_no"].ToString();
                frequency[jj] = scar_details.Car_no;
                row_frequency[jj] = jj;
                string scar_status = rdr["scar_status"].ToString();
                if (scar_status.Equals("SCAR Type 4 Accepted") || scar_status.Equals("SCAR Type 4 Rejected") || scar_status.Equals("SCAR Type 2 Rejected"))
                {
                    scar_no_closed[j] = scar_details.Car_no; 
                    row_no_closed[j] = jj;
                    j++;
                   
                }
                else
                {
                    dr["Completion Date"] = "Ongoing";
                }
                
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                jj++;
            }

        }
        
        

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT scar_no, reject_count_WCM, reject_count_QM FROM dbo.Approval_8D_Reject_Count", conn);
            int total_reject_count = 0;
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                for(int ii = 0; ii < countRows; ii++)
                {
                    if(frequency[ii].Equals(rdr["scar_no"].ToString()))
                    {
                        int reject_count_WCM = Convert.ToInt16(rdr["reject_count_WCM"]);
                        int reject_count_QM = Convert.ToInt16(rdr["reject_count_QM"]);
                        total_reject_count = reject_count_QM + reject_count_WCM;
                        dt.Rows[row_frequency[ii]]["Disapprove Frequency"] = total_reject_count;
                    }
                }
                
            }
        }

        int k = 0;
        int t = 0;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT scar_no, completion_date FROM dbo.SCAR_History", conn);

            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                if(scar_no_closed[t].Equals(rdr["scar_no"].ToString()))
                {
                    DateTime completion_date = Convert.ToDateTime(rdr["completion_date"]);
                    dt.Rows[row_no_closed[t]]["Completion Date"] = completion_date.ToString("dd-MM-yyyy");
                    t++;
                }
                k++;
            }
        }

        displaySCARLog.DataSource = dt;
        displaySCARLog.DataBind();

    }

    protected int Count_History_Rows()
    {
        int count = 0;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT COUNT(*) FROM dbo.SCAR_History", conn);
            count = (int)select.ExecuteScalar();
        }
        return count;
    }

    protected int Count_Request_Rows()
    {
        int count = 0;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT COUNT(*) FROM dbo.SCAR_Request", conn);
            count = (int)select.ExecuteScalar();
        }
        return count;
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displaySCARLog.PageIndex = e.NewPageIndex;
        displaySCARLog.DataBind();
    }

    protected void Show_10_Records(object sender, EventArgs e)
    {
        displaySCARLog.PageSize = 10;
        displaySCARLog.DataBind();
    }

    protected void Show_50_Records(object sender, EventArgs e)
    {
        displaySCARLog.PageSize = 50;
        displaySCARLog.DataBind();
    }

    protected void SCARLogGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        SqlDataReader rdr;
        SCAR scar_details = new SCAR();
        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Disapprove Frequency");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("Completion Date");

        int jj = 0;
        int j = 0;
        DataRow dr;
        int countRows = Count_History_Rows();
        int countMore = Count_Request_Rows();
        int total = countMore + countRows;
        string[] scar_no_closed = new string[countRows];
        string[] frequency = new string[total];
        int[] row_no_closed = new int[countRows];
        int[] row_frequency = new int[total];

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT scar_status, scar_no, issued_date FROM dbo.SCAR_Request UNION 
SELECT scar_status, scar_no, issued_date FROM dbo.SCAR_History", conn);
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No SCARS Records Found!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }

            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                scar_details.Car_no = rdr["scar_no"].ToString();
                frequency[jj] = scar_details.Car_no;
                row_frequency[jj] = jj;
                string scar_status = rdr["scar_status"].ToString();
                if (scar_status.Equals("SCAR Type 4 Accepted") || scar_status.Equals("SCAR Type 4 Rejected") || scar_status.Equals("SCAR Type 2 Rejected"))
                {
                    scar_no_closed[j] = scar_details.Car_no;
                    row_no_closed[j] = jj;
                    j++;

                }
                else
                {
                    dr["Completion Date"] = "Ongoing";
                }

                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                jj++;
            }

        }



        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT scar_no, reject_count_WCM, reject_count_QM FROM dbo.Approval_8D_Reject_Count", conn);
            int total_reject_count = 0;
            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                for (int ii = 0; ii < countRows; ii++)
                {
                    if (frequency[ii].Equals(rdr["scar_no"].ToString()))
                    {
                        int reject_count_WCM = Convert.ToInt16(rdr["reject_count_WCM"]);
                        int reject_count_QM = Convert.ToInt16(rdr["reject_count_QM"]);
                        total_reject_count = reject_count_QM + reject_count_WCM;
                        dt.Rows[row_frequency[ii]]["Disapprove Frequency"] = total_reject_count;
                    }
                }

            }
        }

        int k = 0;
        int t = 0;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT scar_no, completion_date FROM dbo.SCAR_History", conn);

            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                if (scar_no_closed[t].Equals(rdr["scar_no"].ToString()))
                {
                    DateTime completion_date = Convert.ToDateTime(rdr["completion_date"]);
                    dt.Rows[row_no_closed[t]]["Completion Date"] = completion_date.ToString("dd-MM-yyyy");
                    t++;
                }
                k++;
            }
        }

        displaySCARLog.DataSource = dt;
        displaySCARLog.DataBind();

        if (dt != null)
        {
            DataView dataView = new DataView(dt);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            displaySCARLog.DataSource = dataView;
            displaySCARLog.DataBind();
        }
    }

    

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }

        return GridViewSortDirection;
    }

    protected void SetSortDirection(string sortDirection)
    {
        if (sortDirection == "ASC")
        {
            sortDirection = "DESC";
        }
        else
        {
            sortDirection = "ASC";
        }
    } 
}
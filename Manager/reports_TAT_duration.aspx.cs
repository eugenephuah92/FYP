using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

public partial class Manager_reports_TAT_duration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT car_no, supplier_contact, issued_date, expected_date_close FROM SCAR_Request");
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                int totalCount = dt.Rows.Count; //Get total number of records
                txtRowCount.Text = totalCount.ToString();
                GridViewTAT_Duration.DataSource = dt;
                GridViewTAT_Duration.DataBind();
            }
        }
    }
    
    private void SearchData()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;

        query = "SELECT car_no, supplier_contact, issued_date, expected_date_close FROM SCAR_Request WHERE DATEDIFF(dd, issued_date, expected_date_close) LIKE '" + txtDuration.Text + "'";

        SqlDataAdapter sda = new SqlDataAdapter(query, constr);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridViewTAT_Duration.DataSource = ds;
        GridViewTAT_Duration.DataBind();
        con.Close();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SearchData();
        }   
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtDuration.Text = "";
        BindData();
    }

    protected void GridViewTAT_Duration_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (txtDuration.Text == "")
        {
            GridViewTAT_Duration.PageIndex = e.NewPageIndex;
            BindData();
        }
        else
        {
            GridViewTAT_Duration.PageIndex = e.NewPageIndex;
            SearchData();
        }
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (txtDuration.Text == "")
        {
            GridViewTAT_Duration.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindData();
        }
        else
        {
            GridViewTAT_Duration.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }

    protected string CalculateDuration(string startDate, string endDate) //Calculate days between 2 dates
    {
        DateTime start = DateTime.Parse(startDate);
        DateTime end = DateTime.Parse(endDate);

        TimeSpan duration = end.Subtract(start);

        return duration.Days.ToString();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=TAT_Duration_Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridViewTAT_Duration.AllowPaging = false;
            this.DataBind();

            GridViewTAT_Duration.BorderColor = Color.Black;
            GridViewTAT_Duration.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridViewTAT_Duration.HeaderRow.Cells)
            {
                cell.BackColor = GridViewTAT_Duration.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridViewTAT_Duration.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    cell.BackColor = GridViewTAT_Duration.RowStyle.BackColor;
                }
            }
            GridViewTAT_Duration.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}
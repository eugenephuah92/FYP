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
using System.Text;

public partial class Engineer_reports_TAT_duration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData() //Bind data to gridview
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT scar_no, supplier_contact, issued_date, expected_date_close, modified_by, last_modified FROM dbo.SCAR_Request");
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

    private void SearchData() //Search function
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;

        query = "SELECT scar_no, supplier_contact, issued_date, expected_date_close, modified_by, last_modified FROM SCAR_Request WHERE DATEDIFF(dd, issued_date, expected_date_close) LIKE '" + txtDuration.Text + "'";

        SqlDataAdapter sda = new SqlDataAdapter(query, constr);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridViewTAT_Duration.DataSource = ds;
        GridViewTAT_Duration.DataBind();
        con.Close();
    }

    protected void btnSearch_Click(object sender, EventArgs e) //Search gridview data
    {
        if (Page.IsValid)
        {
            SearchData();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e) //Clear all search fields
    {
        txtDuration.Text = "";
        BindData();
    }

    protected void GridViewTAT_Duration_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (String.IsNullOrEmpty(txtDuration.Text)) //Display all data
        {
            GridViewTAT_Duration.PageIndex = e.NewPageIndex;
            BindData();
        }
        else //Display searched results
        {
            GridViewTAT_Duration.PageIndex = e.NewPageIndex;
            SearchData();
        }
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (String.IsNullOrEmpty(txtDuration.Text)) //Display all data
        {
            GridViewTAT_Duration.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindData();
        }
        else //Display searched results
        {
            GridViewTAT_Duration.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }

    protected string CalculateDuration(string startDate, string endDate) //Calculate days between 2 dates for column Duration
    {
        DateTime start = DateTime.Parse(startDate);
        DateTime end = DateTime.Parse(endDate);

        TimeSpan duration = end.Subtract(start);

        return duration.Days.ToString();
    }

    protected void GridViewTAT_Duration_DataBound(object sender, EventArgs e) //Disable Export and Print button when gridview is empty
    {
        btnExport.Visible = GridViewTAT_Duration.Rows.Count > 0;
        btnPrint.Visible = GridViewTAT_Duration.Rows.Count > 0;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtDuration.Text)) //Export all data
        {
            string attachment = "attachment; filename=TAT_Duration_Report.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridViewTAT_Duration.AllowPaging = false;
                BindData();

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
                        if (row.RowIndex % 2 == 1)
                        {
                            cell.BackColor = GridViewTAT_Duration.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridViewTAT_Duration.RowStyle.BackColor;
                        }
                    }
                }
                GridViewTAT_Duration.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        else //Export searched data
        {
            string attachment = "attachment; filename=TAT_Duration_Report_Search.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridViewTAT_Duration.AllowPaging = false;
                SearchData();

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
                        if (row.RowIndex % 2 == 1)
                        {
                            cell.BackColor = GridViewTAT_Duration.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridViewTAT_Duration.RowStyle.BackColor;
                        }
                    }
                }
                GridViewTAT_Duration.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e) //Print gridview
    {
        if (String.IsNullOrEmpty(txtDuration.Text)) //Print all data
        {
            GridViewTAT_Duration.AllowPaging = false;
            BindData();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewTAT_Duration.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'")
                .Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            GridViewTAT_Duration.AllowPaging = true;
            BindData();
        }
        else //Print searched data
        {
            GridViewTAT_Duration.AllowPaging = false;
            SearchData();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewTAT_Duration.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'")
                .Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            GridViewTAT_Duration.AllowPaging = true;
            SearchData();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}
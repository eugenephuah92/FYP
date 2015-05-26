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
using System.IO;
using System.Drawing;

public partial class Manager_reports_TAT_frequency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private DataTable GetData() //Fetch data from database
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT issued_date, escalation_count, modified_by, last_modified FROM dbo.TAT"))
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

    protected void search_TAT_frequency()
    {
        //Parse the value of the selected year
        int year = int.Parse(lstYear.SelectedValue.ToString());
        int[,] TATcount = new int[12,2];
        string[] monthText = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        DataTable dt = this.GetData();

        foreach (DataRow row in dt.Rows)
        {
            //Compare the selected month with the month of the data fetched
            if (DateTime.Parse(row["issued_date"].ToString()).Year == year)
            {
                int month = DateTime.Parse(row["issued_date"].ToString()).Month;
                //Counter for 1st level escalation
                if (row["escalation_count"].ToString() == "1")
                {
                    TATcount[month-1, 0]++;
                }
                //Counter for 2nd level escalation
                else if (row["escalation_count"].ToString() == "2")
                {
                    TATcount[month-1, 1]++;
                }
            }
        }

        DataTable dt_frequency = new DataTable();
        dt_frequency.Columns.Add("Month", Type.GetType("System.String"));
        dt_frequency.Columns.Add("Frequency for Level 1 Trigger", Type.GetType("System.String"));
        dt_frequency.Columns.Add("Frequency for Level 2 Trigger", Type.GetType("System.String"));
        dt_frequency.Columns.Add("Modified By", Type.GetType("System.String"));
        dt_frequency.Columns.Add("Last Modified", Type.GetType("System.String"));

        for (int i = 0; i < 12; i++)
        {
            dt_frequency.Rows.Add();
            dt_frequency.Rows[dt_frequency.Rows.Count - 1]["Month"] = monthText[i];
            dt_frequency.Rows[dt_frequency.Rows.Count - 1]["Frequency for Level 1 Trigger"] = TATcount[i, 0];
            dt_frequency.Rows[dt_frequency.Rows.Count - 1]["Frequency for Level 2 Trigger"] = TATcount[i, 1];
        }

        GridViewTAT_Frequency.DataSource = dt_frequency;
        GridViewTAT_Frequency.DataBind();

        btnExport.Visible = true;
        btnPrint.Visible = true;
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_TAT_frequency(); 
    }

    protected void btnExport_Click(object sender, EventArgs e) // Export to Excel
    {
        string attachment = "attachment; filename=TAT_Frequency_Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridViewTAT_Frequency.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridViewTAT_Frequency.HeaderRow.Cells)
            {
                cell.BackColor = GridViewTAT_Frequency.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridViewTAT_Frequency.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 1)
                    {
                        cell.BackColor = GridViewTAT_Frequency.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridViewTAT_Frequency.RowStyle.BackColor;
                    }
                }
            }
            GridViewTAT_Frequency.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e) //Print gridview
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewTAT_Frequency.RenderControl(hw);
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
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}
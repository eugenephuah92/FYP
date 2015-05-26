using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class Admin_reports_export_SCAR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void BindData(string startDate, string endDate) //Bind SCAR data to gridview between the selected date range
    {
        DateTime issueDate;
        DateTime closeDate;
        DataTable dt = new DataTable();

        //Check if the string has the valid date format
        if (DateTime.TryParse(startDate, out issueDate) && DateTime.TryParse(endDate, out closeDate))
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON SCAR_Request.scar_no = SCAR_Response.scar_no WHERE SCAR_Request.issued_date >= @DateFrom AND SCAR_Request.expected_date_close <= @DateTo", con);
                cmd.Parameters.AddWithValue("@DateFrom", issueDate);
                cmd.Parameters.AddWithValue("@DateTo", closeDate);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count > 0) //If true, export data to Excel
                {
                    GridViewSCAR.DataSource = dt;
                    GridViewSCAR.DataBind();
                }
                else //Prompt gridview error message
                {
                    GridViewSCAR.DataSource = null;
                    GridViewSCAR.DataBind();
                }
            }
        }
    }

    protected void btnExport_Click(object sender, EventArgs e) //Export data to Excel
    {
        BindData(txtStartDate.Text, txtEndDate.Text); //Parse the selected dates from textboxes

        if(GridViewSCAR.Rows.Count > 0)
        {
            string attachment = "attachment; filename=SCAR_RawData_Report.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                BindData(txtStartDate.Text, txtEndDate.Text);

                GridViewSCAR.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridViewSCAR.HeaderRow.Cells)
                {
                    cell.BackColor = GridViewSCAR.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridViewSCAR.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 1)
                        {
                            cell.BackColor = GridViewSCAR.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridViewSCAR.RowStyle.BackColor;
                        }
                    }
                }
                GridViewSCAR.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}

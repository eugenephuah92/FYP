using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;

public partial class Admin_reports_export_SCAR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=SCAR_RawData_Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridViewSCAR.AllowPaging = false;
            this.DataBind();

            GridViewSCAR.BorderColor = Color.Black;
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
                    cell.BackColor = GridViewSCAR.RowStyle.BackColor;
                }
            }
            GridViewSCAR.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}

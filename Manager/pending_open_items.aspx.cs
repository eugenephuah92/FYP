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
using System.Drawing;
using System.IO;
public partial class Manager_pending_open_items : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("CAR Number");
        dt.Columns.Add("S21 Containment Action");
        dt.Columns.Add("S22 Implementation Date");
        dt.Columns.Add("S23 Responsible Person");
        dt.Columns.Add("S2 Track Containment Action");
        dt.Columns.Add("S51 Corrective Action");
        dt.Columns.Add("S52 Implementation Date");
        dt.Columns.Add("S53 Responsible Person");
        dt.Columns.Add("S5 Track Corrective Action");
        dt.Columns.Add("S61 Permanent Corrective Action");
        dt.Columns.Add("S62 Implementation Date");
        dt.Columns.Add("S63 Responsible Person");
        dt.Columns.Add("S6 Track Permanent Corrective Action");
        DataRow dr;
        
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT SCAR_Request.scar_no, SCAR_Response.s21_containment_action, SCAR_Response.s22_implementation_date, 
SCAR_Response.s23_responsible_person, SCAR_Response.screening_area, SCAR_Response.track_containment_action, SCAR_Response.s51_corrective_action, 
SCAR_Response.s52_implementation_date, SCAR_Response.s53_responsible_person, SCAR_Response.track_corrective_action, SCAR_Response.s61_permanent_corrective_action,
SCAR_Response.s62_implementation_date, SCAR_Response.s63_responsible_person, SCAR_Response.track_permanent_corrective_action FROM dbo.SCAR_Request INNER JOIN 
dbo. SCAR_Response ON SCAR_Request.scar_no = SCAR_Response.scar_no", conn);
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for Pending Open Items!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr["CAR Number"] = rdr["scar_no"].ToString();
                dr["S21 Containment Action"] = "Containment Action: " + rdr["s21_containment_action"].ToString();
                dr["S22 Implementation Date"] = "Implementation Date: " + Convert.ToDateTime(rdr["s22_implementation_date"]).ToString("yyyy-MM-dd");
                dr["S23 Responsible Person"] = "Responsible Person: " + rdr["s23_responsible_person"].ToString();
                dr["S2 Track Containment Action"] = Convert.ToBoolean(Convert.ToInt16(rdr["track_containment_action"]));
                dr["S51 Corrective Action"] = "Corrective Action: " + rdr["s51_corrective_action"].ToString();
                dr["S52 Implementation Date"] = "Implementation Date: " + Convert.ToDateTime(rdr["s52_implementation_date"]).ToString("yyyy-MM-dd");
                dr["S53 Responsible Person"] = "Responsible Person: " + rdr["s53_responsible_person"].ToString();
                dr["S5 Track Corrective Action"] = Convert.ToBoolean(Convert.ToInt16(rdr["track_corrective_action"]));
                dr["S61 Permanent Corrective Action"] = "Corrective Action: " + rdr["s61_permanent_corrective_action"].ToString();
                dr["S62 Implementation Date"] = "Implementation Date: " + Convert.ToDateTime(rdr["s62_implementation_date"]).ToString("yyyy-MM-dd");
                dr["S63 Responsible Person"] = "Responsible Person: " + rdr["s63_responsible_person"].ToString();
                dr["S6 Track Permanent Corrective Action"] = Convert.ToBoolean(Convert.ToInt16(rdr["track_permanent_corrective_action"]));
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            
        }
        displayPendingOpenItems.DataSource = dt;
        displayPendingOpenItems.DataBind();

    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displayPendingOpenItems.PageIndex = e.NewPageIndex;
        displayPendingOpenItems.DataBind();
    }

    protected void Export_Items(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=Action_Items_Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            displayPendingOpenItems.AllowPaging = false;
            this.DataBind();

            displayPendingOpenItems.BorderColor = Color.Black;
            displayPendingOpenItems.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in displayPendingOpenItems.HeaderRow.Cells)
            {
                cell.BackColor = displayPendingOpenItems.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in displayPendingOpenItems.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    cell.BackColor = displayPendingOpenItems.RowStyle.BackColor;
                }
            }
            displayPendingOpenItems.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}
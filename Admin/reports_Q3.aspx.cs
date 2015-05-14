using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;

public partial class Admin_reports_Q3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AddFirstRecord();
        }
    }

    private void AddFirstRecord()
    {
        //Creating DataTable
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "Q3Report";
        dt.Columns.Add(new DataColumn("WW", typeof(string)));
        dt.Columns.Add(new DataColumn("Defect", typeof(string)));
        dt.Columns.Add(new DataColumn("CAPA", typeof(string)));
        dt.Columns.Add(new DataColumn("PIC", typeof(string)));
        dt.Columns.Add(new DataColumn("DueDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //Saving datatable into viewstate
        ViewState["Q3Report"] = dt;
        //Bind gridview
        GridViewQ3.DataSource = dt;
        GridViewQ3.DataBind();
        GridViewQ3.Visible = false;
    }

    private void AddRecordToGridview()
    {
        //Check viewstate is not null
        if (ViewState["Q3Report"] != null)
        {
            //Get datatable from viewstate
            DataTable dtCurrentTable = (DataTable)ViewState["Q3Report"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //Add row into datatable
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["WW"] = txtWW.Text;
                    drCurrentRow["Defect"] = txtDefect.Text;
                    drCurrentRow["CAPA"] = txtCAPA.Text;
                    drCurrentRow["PIC"] = txtPIC.Text;
                    drCurrentRow["DueDate"] = txtDueDate.Text;
                    drCurrentRow["Status"] = txtStatus.Text;
                }

                //Remove initial blank row
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();
                }

                //Add created rows into datatable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Save datatable into viewstate after create row
                ViewState["Q3Report"] = dtCurrentTable;
                //Bind gridview with latest row
                GridViewQ3.DataSource = dtCurrentTable;
                GridViewQ3.DataBind();
                GridViewQ3.Visible = true;
            }
        }
    }

    protected void CheckEmptyField(object source, ServerValidateEventArgs args) //Check if all text fields are empty
    {
        string ww = txtWW.Text;
        string defect = txtDefect.Text;
        string capa = txtCAPA.Text;
        string pic = txtPIC.Text;
        string date = txtDueDate.Text;
        string status = txtStatus.Text;

        if (ww == string.Empty && defect == string.Empty && capa == string.Empty && pic == string.Empty && date == string.Empty && status == string.Empty)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void GridViewQ3_RowDataBound(object sender, GridViewRowEventArgs e) //Break into newline in gridview when user press 'enter'key in CAPA textarea
    {
        GridViewRow row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            row.Cells[2].Text = row.Cells[2].Text.Replace("\n", "<br />");
        }
    }

    protected void ClearFields() //Clear all text fields
    {
        txtWW.Text = "";
        txtDefect.Text = "";
        txtCAPA.Text = "";
        txtPIC.Text = "";
        txtDueDate.Text = "";
        txtStatus.Text = "";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AddRecordToGridview();
            lblInfo.Visible = true;
            btnExport.Visible = true;
            btnPrint.Visible = true;
        }

        ClearFields();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    protected void btnExport_Click(object sender, EventArgs e) //Export to Excel
    {
        string attachment = "attachment; filename=Q3_Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridViewQ3.BorderColor = Color.Black;
            GridViewQ3.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridViewQ3.HeaderRow.Cells)
            {
                cell.BackColor = GridViewQ3.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridViewQ3.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    cell.BackColor = GridViewQ3.RowStyle.BackColor;
                }
            }
            GridViewQ3.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}

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

public partial class Manager_reports_CAPA : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("SELECT SCAR_Request.scar_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Request.modified_by, SCAR_Request.last_modified, SCAR_Response.s51_corrective_action FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON SCAR_Request.scar_no = SCAR_Response.scar_no");
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                GridViewCAPA.DataSource = dt;
                GridViewCAPA.DataBind();
            }
        }
    }

    private void SearchData() //Search function
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;
        query = "SELECT SCAR_Request.scar_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action, SCAR_Request.modified_by, SCAR_Request.last_modified FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON SCAR_Request.scar_no = SCAR_Response.scar_no WHERE ";
        //Normal Search
        if (lstFilter.SelectedValue.ToString() == "CAR No")
        {
            query += "SCAR_Request.scar_no LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Part No")
        {
            query += "SCAR_Request.part_no LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Part Desc")
        {
            query += "SCAR_Request.part_description LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Business Unit")
        {
            query += "SCAR_Request.business_unit LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "CAPA")
        {
            query += "SCAR_Response.s51_corrective_action LIKE '" + txtSearch.Text + "%'";
        }
        //Advanced Search
        if(txtSearch.Text != "")
        {
            if (lstFilter1.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Part No")
            {
                query += "AND SCAR_Request.part_no LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Part Desc")
            {
                query += "AND SCAR_Request.part_description LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Business Unit")
            {
                query += "AND SCAR_Request.business_unit LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "CAPA")
            {
                query += "AND SCAR_Response.s51_corrective_action LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "CAR No")
            {
                query += "AND SCAR_Request.scar_no LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Part No")
            {
                query += "AND SCAR_Request.part_no LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Part Desc")
            {
                query += "AND SCAR_Request.part_description LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Business Unit")
            {
                query += "AND SCAR_Request.business_unit LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "CAPA")
            {
                query += "AND SCAR_Response.s51_corrective_action LIKE '" + txtSearch2.Text + "%'";
            }
        }
        
        SqlDataAdapter sda = new SqlDataAdapter(query, constr);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridViewCAPA.DataSource = ds;
        GridViewCAPA.DataBind();
        con.Close();
    }

    protected void btnSearch_Click(object sender, EventArgs e) //Search gridview data
    {
        if(Page.IsValid)
        {
            SearchData();
        }       
    }

    protected void btnClear_Click(object sender, EventArgs e) //Clear all search fields
    {
        lstFilter.ClearSelection();
        txtSearch.Text = "";
        lstFilter1.ClearSelection();
        txtSearch1.Text = "";
        lstFilter2.ClearSelection();
        txtSearch2.Text = "";

        BindData();
    }

    protected void GridViewCAPA_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            GridViewCAPA.PageIndex = e.NewPageIndex;
            BindData();
        }
        else //Display searched results
        {
            GridViewCAPA.PageIndex = e.NewPageIndex;
            SearchData();
        }       
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            GridViewCAPA.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindData();
        }
        else //Display searched results
        {
            GridViewCAPA.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }

    protected void GridViewCAPA_DataBound(object sender, EventArgs e) //Disable Export and Print button when gridview is empty
    {
        btnExport.Visible = GridViewCAPA.Rows.Count > 0;
        btnPrint.Visible = GridViewCAPA.Rows.Count > 0;
    }

    protected void btnExport_Click(object sender, EventArgs e) //Export to Excel
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Export all data
        {
            string attachment = "attachment; filename=CAPA_Report.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridViewCAPA.AllowPaging = false;
                BindData();

                GridViewCAPA.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridViewCAPA.HeaderRow.Cells)
                {
                    cell.BackColor = GridViewCAPA.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridViewCAPA.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 1)
                        {
                            cell.BackColor = GridViewCAPA.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridViewCAPA.RowStyle.BackColor;
                        }
                    }
                }
                GridViewCAPA.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        else //Export searched data 
        {
            string attachment = "attachment; filename=CAPA_Report_Search.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridViewCAPA.AllowPaging = false;
                SearchData();

                GridViewCAPA.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridViewCAPA.HeaderRow.Cells)
                {
                    cell.BackColor = GridViewCAPA.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridViewCAPA.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 1)
                        {
                            cell.BackColor = GridViewCAPA.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridViewCAPA.RowStyle.BackColor;
                        }
                    }
                }
                GridViewCAPA.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }        
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Print all data
        {
            GridViewCAPA.AllowPaging = false;
            BindData();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewCAPA.RenderControl(hw);
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
            GridViewCAPA.AllowPaging = true;
            BindData();
        }
        else //Print searched data
        {
            GridViewCAPA.AllowPaging = false;
            SearchData();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridViewCAPA.RenderControl(hw);
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
            GridViewCAPA.AllowPaging = true;
            SearchData();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}
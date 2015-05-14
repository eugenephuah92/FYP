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

public partial class Admin_reports_CAPA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            SqlCommand cmd = new SqlCommand("SELECT SCAR_Request.car_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action FROM SCAR_Request INNER JOIN SCAR_Response ON SCAR_Request.id = SCAR_Response.id");
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

    private void SearchData()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;

        query = "SELECT SCAR_Request.car_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action FROM SCAR_Request INNER JOIN SCAR_Response ON SCAR_Request.id = SCAR_Response.id WHERE ";

        if (lstFilter.SelectedValue.ToString() == "CAR No")
        {
            query += "SCAR_Request.car_no LIKE '" + txtSearch.Text + "%'";
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
        /*
        if (lstFilter1.SelectedValue.ToString() == "CAR No")
        {
            query += "AND SCAR_Request.car_no LIKE '" + txtSearch1.Text + "%'";
        }
        else if (lstFilter1.SelectedValue.ToString() == "Part No")
        {
            query = "SELECT SCAR_Request.car_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action FROM SCAR_Request INNER JOIN SCAR_Response ON SCAR_Request.id = SCAR_Response.id WHERE SCAR_Request.part_no LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Part Desc")
        {
            query = "SELECT SCAR_Request.car_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action FROM SCAR_Request INNER JOIN SCAR_Response ON SCAR_Request.id = SCAR_Response.id WHERE SCAR_Request.part_description LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Business Unit")
        {
            query = "SELECT SCAR_Request.car_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action FROM SCAR_Request INNER JOIN SCAR_Response ON SCAR_Request.id = SCAR_Response.id WHERE SCAR_Request.business_unit LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "CAPA")
        {
            query = "SELECT SCAR_Request.car_no, SCAR_Request.part_no, SCAR_Request.part_description, SCAR_Request.business_unit, SCAR_Response.s51_corrective_action FROM SCAR_Request INNER JOIN SCAR_Response ON SCAR_Request.id = SCAR_Response.id WHERE SCAR_Response.s51_corrective_action LIKE '" + txtSearch.Text + "%'";
        }*/
        SqlDataAdapter sda = new SqlDataAdapter(query, constr);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridViewCAPA.DataSource = ds;
        GridViewCAPA.DataBind();
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
        lstFilter.ClearSelection();
        txtSearch.Text = "";
        BindData();
    }

    protected void GridViewCAPA_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (txtSearch.Text == "")
        {
            GridViewCAPA.PageIndex = e.NewPageIndex;
            BindData();
        }
        else
        {
            GridViewCAPA.PageIndex = e.NewPageIndex;
            SearchData();
        }
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (txtSearch.Text == "")
        {
            GridViewCAPA.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindData();
        }
        else
        {
            GridViewCAPA.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchData();
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=CAPA_Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridViewCAPA.AllowPaging = false;
            this.DataBind();

            GridViewCAPA.BorderColor = Color.Black;
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
                    cell.BackColor = GridViewCAPA.RowStyle.BackColor;
                }
            }
            GridViewCAPA.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
}
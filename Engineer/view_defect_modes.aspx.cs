using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Engineer_view_defect_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDFM();
        }
    }

    private void BindDFM() //Bind data to gridview
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT Defect_Modes.defect_code, IPC_Code.IPC_code, Defect_Modes.defect_name, Defect_Modes.defect_group, Defect_Modes.defect_category, Defect_Modes.defect_description, Defect_Modes.modified_by, Defect_Modes.last_modified, IPC_Code.modified_by, IPC_Code.last_modified FROM dbo.Defect_Modes LEFT JOIN dbo.IPC_Code ON Defect_Modes.defect_code = IPC_Code.defect_code");
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                GridViewDFM.DataSource = dt;
                GridViewDFM.DataBind();
            }
        }
    }

    private void SearchDFM() //Search function
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string query = string.Empty;
        query = "SELECT Defect_Modes.defect_code, IPC_Code.IPC_code, Defect_Modes.defect_name, Defect_Modes.defect_group, Defect_Modes.defect_category, Defect_Modes.defect_description, Defect_Modes.modified_by, Defect_Modes.last_modified, IPC_Code.modified_by, IPC_Code.last_modified FROM dbo.Defect_Modes LEFT JOIN dbo.IPC_Code ON Defect_Modes.defect_code = IPC_Code.defect_code WHERE ";
        // Normal Search
        if (lstFilter.SelectedValue.ToString() == "Defect Code")
        {
            query += "Defect_Modes.defect_code LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "IPC Code")
        {
            query += "IPC_Code.IPC_code LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Name")
        {
            query += "Defect_Modes.defect_name LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Group")
        {
            query += "Defect_Modes.defect_group LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Category")
        {
            query += "Defect_Modes.defect_category LIKE '" + txtSearch.Text + "%'";
        }
        else if (lstFilter.SelectedValue.ToString() == "Defect Description")
        {
            query += "Defect_Modes.defect_description LIKE '" + txtSearch.Text + "%'";
        }
        //Advanced Search
        if (txtSearch.Text != "")
        {
            if (lstFilter1.SelectedValue.ToString() == "Defect Code")
            {
                query += "AND Defect_Modes.defect_code LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "IPC Code")
            {
                query += "AND IPC_Code.IPC_code LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Name")
            {
                query += "AND Defect_Modes.defect_name LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Group")
            {
                query += "AND Defect_Modes.defect_group LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Category")
            {
                query += "AND Defect_Modes.defect_category LIKE '" + txtSearch1.Text + "%'";
            }
            else if (lstFilter1.SelectedValue.ToString() == "Defect Description")
            {
                query += "AND Defect_Modes.defect_description LIKE '" + txtSearch1.Text + "%'";
            }

            if (lstFilter2.SelectedValue.ToString() == "Defect Code")
            {
                query += "AND Defect_Modes.defect_code LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "IPC Code")
            {
                query += "AND IPC_Code.IPC_code LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Name")
            {
                query += "AND Defect_Modes.defect_name LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Group")
            {
                query += "AND Defect_Modes.defect_group LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Category")
            {
                query += "AND Defect_Modes.defect_category LIKE '" + txtSearch2.Text + "%'";
            }
            else if (lstFilter2.SelectedValue.ToString() == "Defect Description")
            {
                query += "AND Defect_Modes.defect_description LIKE '" + txtSearch2.Text + "%'";
            }
        }

        SqlDataAdapter sda = new SqlDataAdapter(query, constr);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridViewDFM.DataSource = ds;
        GridViewDFM.DataBind();
        con.Close();
    }

    protected void btnSearch_Click(object sender, EventArgs e) //Search gridview data
    {
        if (Page.IsValid)
        {
            SearchDFM();
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

        BindDFM();
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Change page size
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            GridViewDFM.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            BindDFM();
        }
        else //Display searched data
        {
            GridViewDFM.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
            SearchDFM();
        }
    }

    protected void GridViewDFM_PageIndexChanging(object sender, GridViewPageEventArgs e) //Allow paging
    {
        if (String.IsNullOrEmpty(txtSearch.Text)) //Display all data
        {
            GridViewDFM.PageIndex = e.NewPageIndex;
            BindDFM();
        }
        else //Display searched data
        {
            GridViewDFM.PageIndex = e.NewPageIndex;
            SearchDFM();
        }
    }
}
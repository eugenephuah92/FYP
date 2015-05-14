using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_view_defect_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("Defect Name");
        lstFilter.Items.Add("Defect Code");
        lstFilter.Items.Add("IPC Code");
        lstFilter.Items.Add("Defect Category");
        lstFilter.Items.Add("Defect Type");
    }

    protected void GridviewDFM_DeleteConfirm(object sender, GridViewRowEventArgs e) //Delete selected row when button is clicked
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (DataControlFieldCell cell in e.Row.Cells)
            {
                foreach (Control control in cell.Controls)
                {
                    Button btn = control as Button;
                    if (btn != null && btn.CommandName == "Delete")
                    {
                        //Prompt message box for delete confirmation
                        btn.OnClientClick = "if (!confirm('Are you sure you want to delete this entry?')) return;";
                    }
                }
            }
        }
    }

    protected void PageSizeChanged(object sender, EventArgs e) //Paging
    {
        GridViewDFM.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
    }

    protected void GridViewDFM_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Convert Defect Name to uppercase
        string temp = e.NewValues["defect_name"].ToString().ToUpper();
        e.NewValues["defect_name"] = temp;
    }
}
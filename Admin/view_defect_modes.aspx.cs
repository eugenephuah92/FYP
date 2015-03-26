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

    protected void Gridview1_DeleteConfirm(object sender, GridViewRowEventArgs e)
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
                        btn.OnClientClick = "if (!confirm('Are you sure you want to delete this entry?')) return;";
                    }
                }
            }
        }
    }

    protected void PageSizeChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(lstPageSize.SelectedValue);
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string temp = e.NewValues["defectName"].ToString().ToUpper();
        e.NewValues["defectName"] = temp;
    }
}
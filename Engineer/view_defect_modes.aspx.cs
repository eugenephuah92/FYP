using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineer_view_defect_modes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("Defect Name");
        lstFilter.Items.Add("Defect Code");
        lstFilter.Items.Add("IPC Code");
        lstFilter.Items.Add("Defect Category");
        lstFilter.Items.Add("Defect Type");
    }
}
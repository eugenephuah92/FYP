using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Engineer_reports_CAPA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("Part Number");
        lstFilter.Items.Add("Part Description");
        lstFilter.Items.Add("Business Unit");
        lstFilter.Items.Add("Corrective Action / Preventive Action");
        lstFilter.Items.Add("CAR Number");
    }
}
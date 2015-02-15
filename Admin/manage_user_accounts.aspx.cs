using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_user_accounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lstFilter.Items.Add("Employee Name");
        lstFilter.Items.Add("Employee Email");
        lstFilter.Items.Add("Employee Position");

        /*lstFilter2.Items.Add("Employee Name");
        lstFilter2.Items.Add("Employee Email");
        lstFilter2.Items.Add("Employee Position");

        lstFilter3.Items.Add("Employee Name");
        lstFilter3.Items.Add("Employee Email");
        lstFilter3.Items.Add("Employee Position");*/
    }
}
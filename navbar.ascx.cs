using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jabil_Session;

public partial class navbar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = JabilSession.Current.employee_name;
        lbl_employee_name.Text += employee_name;
    }
}
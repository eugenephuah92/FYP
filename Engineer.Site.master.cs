using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Jabil_Session;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
public partial class Engineer_SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    string DatabaseName = "JabilDatabase";
    protected void Page_Init(object sender, EventArgs e)
    {
        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Gets the file name of the current page without the extension    
        string pageName = Path.GetFileNameWithoutExtension(Request.Path);
        GetPageName.Value = pageName;

        string checkPrivilege = JabilSession.Current.privilege;
        if (checkPrivilege == null)
        {
            Response.Redirect("../Logout.aspx");
        }
        if(!JabilSession.Current.privilege.Equals("Engineer"))
        {
            Response.Redirect("../Logout.aspx");
        }

        SqlDataReader rdr;

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        int newSCAR = 0;
        int pendingSCAR = 0;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT scar_stage FROM dbo.SCAR_Request", conn);

            rdr = select.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr["scar_stage"].ToString().Equals("New SCAR"))
                {
                    newSCAR++;
                }
                else if (rdr["scar_stage"].ToString().Equals("Pending SCAR"))
                {
                    pendingSCAR++;
                }
            }
            rdr.Close();
        }

        lblNewSCAR.Text = Convert.ToString(newSCAR);
        lblPendingSCAR.Text = Convert.ToString(pendingSCAR);
    }
}
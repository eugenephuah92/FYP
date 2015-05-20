using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using Jabil_Session;

public partial class Manager_home : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        string checkPrivilege = JabilSession.Current.privilege;
        if (checkPrivilege == null)
        {
            Response.Redirect("../Logout.aspx");
        }

        SqlDataReader rdr;

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        int newSCAR = 0;
        int closedSCAR = 0;
        int pendingSCAR = 0;
        int request8D = 0;

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

            SqlCommand selectClosed = new SqlCommand("SELECT COUNT(*) FROM dbo.SCAR_History", conn);
            int count = Convert.ToInt16(selectClosed.ExecuteScalar());
            closedSCAR = count;
            

            if(JabilSession.Current.employee_position.Equals("Work Cell Manager"))
            {
                SqlCommand select8D = new SqlCommand(@"SELECT COUNT(*) FROM dbo.Approval_8D WHERE name_WCM = @name_WCM", conn);
                select8D.Parameters.AddWithValue("@name_WCM", JabilSession.Current.employee_name);
                request8D = Convert.ToInt16(select8D.ExecuteScalar());
            }
            else if(JabilSession.Current.employee_position.Equals("Quality Manager"))
            {
                SqlCommand select8D = new SqlCommand(@"SELECT COUNT(*) FROM dbo.Approval_8D WHERE name_QM = @name_QM", conn);
                select8D.Parameters.AddWithValue("@name_QM", JabilSession.Current.employee_name);
                request8D = Convert.ToInt16(select8D.ExecuteScalar());
            }
            
        }

        lblNewSCAR.Text = Convert.ToString(newSCAR);
        lblClosedSCAR.Text = Convert.ToString(closedSCAR);
        lblPendingSCAR.Text = Convert.ToString(pendingSCAR);
        lbl8DRequest.Text = Convert.ToString(request8D);
    }

}
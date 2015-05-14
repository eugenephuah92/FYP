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

public partial class Engineer_home : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;

        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        int newSCAR = 0;
        int closedSCAR = 0;
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

            SqlCommand selectClosed = new SqlCommand("SELECT COUNT(*) FROM dbo.SCAR_History", conn);
            int count = Convert.ToInt16(selectClosed.ExecuteScalar());
            closedSCAR = count;
        }

        lblNewSCAR.Text = Convert.ToString(newSCAR);
        lblClosedSCAR.Text = Convert.ToString(closedSCAR);
        lblPendingSCAR.Text = Convert.ToString(pendingSCAR);
    }

}
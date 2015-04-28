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

public partial class Engineer_pending_scars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataReader rdr;

        DataTable dt = new DataTable();

        dt.Columns.Add("id");
        dt.Columns.Add("CAR Number");
        dt.Columns.Add("Defect Name");
        dt.Columns.Add("Description");
        dt.Columns.Add("Creation Date");
        dt.Columns.Add("SCAR Type");
        dt.Columns.Add("Level of Escalation");
        dt.Columns.Add("Days Till Next Escalation");
        dt.Columns.Add("Response ID");
        
        DataRow dr;

        string DatabaseName = "AutoSCARConnectionString";
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT id, scar_type, car_no, issued_date FROM dbo.SCAR_Request WHERE scar_stage = @scar_stage", conn);
            select.Parameters.AddWithValue("@scar_stage", "Pending SCAR");
            rdr = select.ExecuteReader();
            if (!rdr.HasRows)
            {
                lblNoRows.Text = "No Records Found for Pending SCARS!";
                lblNoRows.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            while(rdr.Read())
            {
                dr = dt.NewRow();

                dr["id"] = rdr["id"].ToString();
                dr["CAR Number"] = rdr["car_no"].ToString();
            
                dr["SCAR Type"] = rdr["scar_type"].ToString();
                DateTime issued_date = (DateTime)rdr["issued_date"];
                dr["Creation Date"] = issued_date.ToString("dd-MM-yyyy");

                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }
            
        }

        int i = 0;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT defectName, defectDescription FROM dbo.DefectModes", conn);

            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dt.Rows[i]["Defect Name"] = rdr["defectName"].ToString();
                dt.Rows[i]["Description"] = rdr["defectDescription"].ToString();
                i++;
            }
        }
        
        int j = 0;

        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT escalation_level, reminder_date FROM dbo.TAT", conn);

            rdr = select.ExecuteReader();
            while (rdr.Read())
            {
                dt.Rows[j]["Level of Escalation"] = rdr["escalation_level"].ToString();
                dt.Rows[j]["Days Till Next Escalation"] = rdr["reminder_date"].ToString();
                j++;
            }
        }

        displayPendingSCAR.DataSource = dt;
        displayPendingSCAR.DataBind();

    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        displayPendingSCAR.PageIndex = e.NewPageIndex;
        displayPendingSCAR.DataBind();
    }

    protected void Show_10_Records(object sender, EventArgs e)
    {
        displayPendingSCAR.PageSize = 10;
        displayPendingSCAR.DataBind();
    }

    protected void Show_50_Records(object sender, EventArgs e)
    {
        displayPendingSCAR.PageSize = 50;
        displayPendingSCAR.DataBind();
    }
}
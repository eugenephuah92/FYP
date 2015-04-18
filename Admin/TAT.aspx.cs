using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_TAT : System.Web.UI.Page
{
    struct SCAR_Rec
    {
        public string car_no;
        public string supplier_contact;
        public DateTime issued_date;
        public string scar_status;
    };

    struct TAT_Rec
    {
        public string SCAR_ID;
        public string employee_ID;
        public DateTime issued_date;
        public int escalation_level;
        public DateTime trigger_date;
        public int escalation_count;
    };

    struct TAT_Ref
    {
        public int escalation_level;
        public string escalation_level_desc;
        public int days_to_escalation;
        public bool notify_QE;
        public bool notify_QM;
        public bool notify_WCM;
    };


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //Populating a DataTable from database.
            DataTable dt = this.GetSCAR();
            DataTable dt2 = this.GetTAT();
            DataTable dt3 = this.GetTATRef();

            SCAR_Rec[] mTAT = new SCAR_Rec[dt.Rows.Count];
            TAT_Rec[] rTAT = new TAT_Rec[dt2.Rows.Count];
            TAT_Ref[] refTAT = new TAT_Ref[dt3.Rows.Count];

            int x = 0, y = 0, z = 0;
            foreach(DataRow row in dt.Rows)
            {
                mTAT[x].car_no = row["car_no"].ToString();
                mTAT[x].supplier_contact = row["supplier_contact"].ToString();
                mTAT[x].issued_date = DateTime.Parse(row["issued_date"].ToString());
                mTAT[x].scar_status = row["scar_status"].ToString();
                x++;
            }

            foreach (DataRow row in dt2.Rows)
            {
                rTAT[y].SCAR_ID = row["SCAR_ID"].ToString();
                rTAT[y].employee_ID = row["employee_ID"].ToString();
                rTAT[y].issued_date = DateTime.Parse(row["issued_date"].ToString());
                rTAT[y].escalation_level = int.Parse(row["escalation_level"].ToString());
                rTAT[y].trigger_date = DateTime.Parse(row["trigger_date"].ToString());
                rTAT[y].escalation_count = int.Parse(row["escalation_count"].ToString());
                y++;
            }

            foreach (DataRow row in dt3.Rows)
            {
                refTAT[z].escalation_level = int.Parse(row["escalation_level"].ToString());
                refTAT[z].escalation_level_desc = row["escalation_level_desc"].ToString();
                refTAT[z].days_to_escalation = int.Parse(row["days_to_escalation"].ToString());
                refTAT[z].notify_QE = bool.Parse(row["notify_QE"].ToString());
                refTAT[z].notify_QM = bool.Parse(row["notify_QM"].ToString());
                refTAT[z].notify_WCM = bool.Parse(row["notify_WCM"].ToString());
                z++;
            }

            bool new_record = true;
            for(int i = 0; i < x; i++)
            {
                new_record = true;
                if (mTAT[i].scar_status == "Pending") 
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (mTAT[i].car_no == rTAT[j].SCAR_ID)
                        {
                            new_record = false;
                            if (rTAT[j].trigger_date < DateTime.Now)
                            {
                                if (rTAT[j].escalation_level < 6)
                                {
                                    rTAT[j].escalation_level++;
                                    rTAT[j].escalation_count++;
                                }

                                string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
                                using (SqlConnection connection = new SqlConnection(constr))
                                {
                                    SqlCommand cmd = new SqlCommand("UPDATE TAT SET escalation_level = @escalation_level, trigger_date = @trigger_date, escalation_count = @escalation_count WHERE SCAR_ID = @SCAR_ID");
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = connection;
                                    cmd.Parameters.AddWithValue("@SCAR_ID", rTAT[j].SCAR_ID);
                                    cmd.Parameters.AddWithValue("@escalation_level", rTAT[j].escalation_level);
                                    cmd.Parameters.AddWithValue("@trigger_date", rTAT[j].trigger_date.AddDays(refTAT[rTAT[j].escalation_level].days_to_escalation));
                                    cmd.Parameters.AddWithValue("@escalation_count", rTAT[j].escalation_count);
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    if (new_record)
                    {
                        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(constr))
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO TAT (SCAR_ID, employee_ID, issued_date, escalation_level, trigger_date, escalation_count) VALUES (@SCAR_ID, @employee_ID, @issued_date, @escalation_level, @trigger_date, @escalation_count)");
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@SCAR_ID", mTAT[i].car_no);
                            cmd.Parameters.AddWithValue("@employee_ID", mTAT[i].supplier_contact);
                            cmd.Parameters.AddWithValue("@issued_date", mTAT[i].issued_date);
                            cmd.Parameters.AddWithValue("@escalation_level", 0);
                            cmd.Parameters.AddWithValue("@trigger_date", mTAT[i].issued_date.AddDays(refTAT[0].days_to_escalation));
                            cmd.Parameters.AddWithValue("@escalation_count", 0);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                
            }

            dt2 = this.GetTAT();
            GridView2.DataSource = dt2;
            GridView2.DataBind();
        }
    }



    private DataTable GetTAT()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT SCAR_ID, employee_ID, issued_date, escalation_level, trigger_date, escalation_count FROM TAT"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable GetTATRef()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT escalation_level, escalation_level_desc, days_to_escalation, notify_QE, notify_QM, notify_WCM FROM TAT_Reference"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable GetSCAR()
    {
        string constr = ConfigurationManager.ConnectionStrings["JabilDatabase"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT car_no, supplier_contact, issued_date, scar_status FROM SCAR_request"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
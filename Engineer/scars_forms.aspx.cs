using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYP_WebApp.Old_App_Code;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class Engineer_scars_forms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlDefectType();
        ddlRootCauseOption();
        ddlWCMApproval();
        ddlQMApproval();

        string tempID = Request.QueryString["scar_id"];

        if(!String.IsNullOrEmpty(tempID))
        {
            Read_Existing_Records(tempID);
        }
       
    }

    protected void ddlDefectType()
    {
        if (!IsPostBack)
        {
            lstDefectType.Items.Add("Performance");
            lstDefectType.Items.Add("Non-Performance");
        }    
    }

    protected void ddlRootCauseOption()
    { 
        if (!IsPostBack)
        {
            string DatabaseName = "AutoSCARConnectionString";
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                
                SqlCommand select = new SqlCommand("SELECT id, root_cause FROM dbo.Root_Cause_Option", conn);
                conn.Open();
                
                lstRootCause.DataSource = select.ExecuteReader();
                lstRootCause.DataTextField = "root_cause";
                lstRootCause.DataValueField = "id";
                lstRootCause.DataBind();
                lstRootCause.Items.Insert(0, new ListItem("Please Select Root Cause", "0"));
            }
        }
    }

    protected void ddlWCMApproval()
    {
        if (!IsPostBack)
        {
            string DatabaseName = "AutoSCARConnectionString";
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand selectWCM = new SqlCommand("SELECT employee_ID, employee_name, employee_position FROM dbo.Employee WHERE employee_position = @employee_position", conn);
                conn.Open();
                selectWCM.Parameters.AddWithValue("employee_position", "Work Cell Manager");

                lstWCM.DataSource = selectWCM.ExecuteReader();
                lstWCM.DataTextField = "employee_name";
                lstWCM.DataValueField = "employee_ID";
                lstWCM.DataBind();
            }
        }
    }

    protected void ddlQMApproval()
    {
        
        if (!IsPostBack)
        {
            string DatabaseName = "AutoSCARConnectionString";
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand selectQM = new SqlCommand("SELECT employee_ID, employee_name, employee_position FROM dbo.Employee WHERE employee_position = @employee_position", conn);
                conn.Open();
                selectQM.Parameters.AddWithValue("employee_position", "Quality Manager");

                lstQM.DataSource = selectQM.ExecuteReader();
                lstQM.DataTextField = "employee_name";
                lstQM.DataValueField = "employee_ID";
                lstQM.DataBind();
            }
        }
    }

    protected void Read_Existing_Records(string scar_id)
    {
        btnSaveSec1.Enabled = false;
        btnSubmitSec1.Enabled = false;
        if (!IsPostBack)
        {
            string DatabaseName = "AutoSCARConnectionString";
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand("SELECT id, car_no, car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity, defect_type, non_conformity_reported, reject_reason, expected_date_close FROM dbo.SCAR_Request WHERE id = @scar_id", conn);
                select.Parameters.AddWithValue("scar_id", scar_id);
                SqlDataReader reader;
                reader = select.ExecuteReader();

                while(reader.Read())
                {
                    txtCarNo.Text += Convert.ToString(reader["car_no"]);
                    txtCarNo.ReadOnly = true;
                    txtCarRev.Text += Convert.ToString(reader["car_revision"]);
                    txtCarRev.ReadOnly = true;
                    txtCarType.Text += Convert.ToString(reader["car_type"]);
                    txtCarType.ReadOnly = true;
                    rdbPreAlert.SelectedValue += Convert.ToString(reader["pre_alert"]);
                    rdbPreAlert.Enabled = false;
                    txtRelatedCarNo.Text += Convert.ToString(reader["related_car_no"]);
                    txtRelatedCarNo.ReadOnly = true;
                    txtRelatedCarRev.Text += Convert.ToString(reader["related_car_ref"]);
                    txtRelatedCarRev.ReadOnly = true;
                    txtOriginator.Text += Convert.ToString(reader["originator"]);
                    txtOriginator.ReadOnly = true;
                    txtRecurrence.Text += Convert.ToString(reader["recurrence"]);
                    txtRecurrence.ReadOnly = true;
                    txtSupplierContact.Text += Convert.ToString(reader["supplier_contact"]);
                    txtSupplierContact.ReadOnly = true;
                    txtSupplierEmail.Text += Convert.ToString(reader["supplier_email"]);
                    txtSupplierEmail.ReadOnly = true;
                    txtIssuedDate.Text = Convert.ToDateTime(reader["issued_date"]).ToString("yyyy-MM-dd");
                    txtIssuedDate.ReadOnly = true;
                    txtOriginatorDept.Text += Convert.ToString(reader["originator_dept"]);
                    txtOriginatorDept.ReadOnly = true;
                    txtOriginatorContact.Text += Convert.ToString(reader["originator_contact"]);
                    txtOriginatorContact.ReadOnly = true;
                    txtPartNo.Text += Convert.ToString(reader["part_no"]);
                    txtPartNo.ReadOnly = true;
                    txtPartDesc.Text += Convert.ToString(reader["part_description"]);
                    txtPartDesc.ReadOnly = true;
                    txtBusinessUnit.Text += Convert.ToString(reader["business_unit"]);
                    txtBusinessUnit.ReadOnly = true;
                    txtDeptPL.Text += Convert.ToString(reader["dept_pl"]);
                    txtDeptPL.ReadOnly = true;
                    txtCommodity.Text += Convert.ToString(reader["commodity"]);
                    txtCommodity.ReadOnly = true;
                    txtDefectQty.Text += reader["defect_quantity"];
                    txtDefectQty.ReadOnly = true;
                    lstDefectType.SelectedValue = Convert.ToString(reader["defect_type"]);
                    lstDefectType.Enabled = false;
                    txtNonConformity.Text += Convert.ToString(reader["non_conformity_reported"]);
                    txtNonConformity.ReadOnly = true;
                    txtRejectReason.Text += Convert.ToString(reader["reject_reason"]);
                    txtRejectReason.ReadOnly = true;
                    txtDateClose.Text = Convert.ToDateTime(reader["expected_date_close"]).ToString("yyyy-MM-dd");
                    txtDateClose.ReadOnly = true;

                }
            }
        }
    }

    /* SCAR Request Section */
    protected void Save_Section_1(object sender, EventArgs e)
    {
        int save_button_click = 0;
        Read_From_Textbox(save_button_click);
    }

    protected void Submit_Section_1(object sender, EventArgs e)
    {
        int submit_button_click = 1;
        Read_From_Textbox(submit_button_click); 
    }

    protected void Read_From_Textbox(int clicked_button)
    {
        SCAR scar_details = new SCAR();
        bool checkEmptyFields = true;
        
        if (!string.IsNullOrEmpty(txtCarNo.Text)) // Car Number
        {
            scar_details.Car_no = txtCarNo.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtCarRev.Text)) // Car Revision
        {
            scar_details.Car_revision = txtCarRev.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtCarType.Text)) // Car Type
        {
            scar_details.Car_type = txtCarType.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(rdbPreAlert.Text)) // Pre-Alert
        {
            scar_details.Pre_alert = rdbPreAlert.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtRelatedCarNo.Text)) // Related Car Number
        {
            scar_details.Related_car_no = txtRelatedCarNo.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtRelatedCarRev.Text)) // Related Car Revision
        {
            scar_details.Related_car_rev = txtRelatedCarRev.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtOriginator.Text)) // Originator
        {
            scar_details.Originator = txtOriginator.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtRecurrence.Text)) // Recurrence
        {
            scar_details.Recurrence = txtRecurrence.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtSupplierContact.Text)) // Supplier Contact
        {
            scar_details.Supplier_contact = txtSupplierContact.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtSupplierEmail.Text)) // Supplier Email
        {
            scar_details.Supplier_email = txtSupplierEmail.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtIssuedDate.Text)) // Issued Date
        {
            scar_details.Issued_date = txtIssuedDate.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtOriginatorDept.Text)) // Originator Department
        {
            scar_details.Originator_department = txtOriginatorDept.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtOriginatorContact.Text)) // Originator Contact
        {
            scar_details.Originator_contact = txtOriginatorContact.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtPartNo.Text)) // Part Number
        {
            scar_details.Part_no = txtPartNo.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtPartDesc.Text)) // Part Description
        {
            scar_details.Part_description = txtPartDesc.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtBusinessUnit.Text)) // Business Unit
        {
            scar_details.Business_unit = txtBusinessUnit.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtDeptPL.Text)) // Dept / PL
        {
            scar_details.Dept_pl = txtDeptPL.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtCommodity.Text)) // Commodity
        {
            scar_details.Commodity = txtCommodity.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtDefectQty.Text)) // Defect Quantity
        {
            scar_details.Defect_quantity = Convert.ToInt16(txtDefectQty.Text);
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(lstDefectType.SelectedValue)) // Defect Type
        {
            scar_details.Defect_type = lstDefectType.SelectedValue;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtNonConformity.Text)) // Non-Conformity
        {
            scar_details.Non_conformity_reported = txtNonConformity.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtRejectReason.Text)) // Reject Reason
        {
            scar_details.Reject_reason = txtRejectReason.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtDateClose.Text)) // Expected Date Close
        {
            scar_details.Expected_date_close = txtDateClose.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

        if(checkEmptyFields)
        {
            Insert_Into_Database(scar_details, clicked_button); 
        }
             
    }

    // Insert Data from SCAR Request Form into Database
    protected void Insert_Into_Database(SCAR scar_details, int clicked_button)
    {
        // Establish Connection to Database
        SqlConnection con;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();
       
        // Calculates difference between SCAR issued date and SCAR expected date close
        bool check_date_difference = true;

        string[] split_issue_date = scar_details.Issued_date.Split('-');
        string temp_issue_date = split_issue_date[2] + "/" + split_issue_date[1] + "/" + split_issue_date[0];
        DateTime issued_date = DateTime.ParseExact(temp_issue_date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        string[] split_closure_date = scar_details.Expected_date_close.Split('-');
        string temp_closure_date = split_closure_date[2] + "/" + split_closure_date[1] + "/" + split_closure_date[0];
        DateTime expected_date_close = DateTime.ParseExact(temp_issue_date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        scar_details.Issued_date = Convert.ToString(issued_date);
        scar_details.Expected_date_close = Convert.ToString(expected_date_close);
        TimeSpan ts = expected_date_close - issued_date;

        if(ts.Days < 0)
        {
            check_date_difference = false;
        }
        if (check_date_difference)
        {
            if (clicked_button == 0)
            {
                if (Check_Duplicate_Data(scar_details, clicked_button) == true) // Checks for duplicate records
                {
                    try
                    {
                        // SQL command to insert data into database
                        SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, car_no, 
            car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
            supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
            defect_type, non_conformity_reported, reject_reason, expected_date_close, save_status) VALUES (@scar_stage, @scar_type, @scar_status, @car_no, @car_revision, @car_type, @pre_alert,
            @related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description,
            @business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close, @save_status)", con);

                        addSite.Parameters.AddWithValue("@scar_stage", "New SCAR");
                        addSite.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
                        addSite.Parameters.AddWithValue("@scar_status", "Pending");
                        addSite.Parameters.AddWithValue("@car_no", scar_details.Car_no);
                        addSite.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
                        addSite.Parameters.AddWithValue("@car_type", scar_details.Car_type);
                        addSite.Parameters.AddWithValue("@pre_alert", scar_details.Pre_alert);
                        addSite.Parameters.AddWithValue("@related_car_no", scar_details.Related_car_no);
                        addSite.Parameters.AddWithValue("@related_car_ref", scar_details.Related_car_rev);
                        addSite.Parameters.AddWithValue("@originator", scar_details.Originator);
                        addSite.Parameters.AddWithValue("@recurrence", scar_details.Recurrence);
                        addSite.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
                        addSite.Parameters.AddWithValue("@supplier_email", scar_details.Supplier_email);
                        addSite.Parameters.AddWithValue("@issued_date", issued_date);
                        addSite.Parameters.AddWithValue("@originator_dept", scar_details.Originator_department);
                        addSite.Parameters.AddWithValue("@originator_contact", scar_details.Originator_contact);
                        addSite.Parameters.AddWithValue("@part_no", scar_details.Part_no);
                        addSite.Parameters.AddWithValue("@part_description", scar_details.Part_description);
                        addSite.Parameters.AddWithValue("@business_unit", scar_details.Business_unit);
                        addSite.Parameters.AddWithValue("@dept_pl", scar_details.Dept_pl);
                        addSite.Parameters.AddWithValue("@commodity", scar_details.Commodity);
                        addSite.Parameters.AddWithValue("@defect_quantity", scar_details.Defect_quantity);
                        addSite.Parameters.AddWithValue("@defect_type", scar_details.Defect_type);
                        addSite.Parameters.AddWithValue("@non_conformity_reported", scar_details.Non_conformity_reported);
                        addSite.Parameters.AddWithValue("@reject_reason", scar_details.Reject_reason);
                        addSite.Parameters.AddWithValue("@expected_date_close", expected_date_close);
                        addSite.Parameters.AddWithValue("@save_status", "save");
                        addSite.ExecuteNonQuery();

                        ProcessedMessage.Text = "SCAR Request has been saved!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                    }
                    catch (Exception err)
                    {
                        ProcessedMessage.Text = "SCAR Request cannot be saved! Please try again!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    try
                    {
                        SqlCommand select = new SqlCommand("SELECT car_no, car_revision, issued_date, save_status FROM dbo.SCAR_Request", con);
                        SqlDataReader reader;
                        bool process_submit = false;
                        reader = select.ExecuteReader();
                        while (reader.Read())
                        {
                            if (scar_details.Car_no.CompareTo(Convert.ToString(reader["car_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "save")
                            {
                                SqlCommand update_data = new SqlCommand(@"UPDATE TABLE dbo.SCAR_Request SET car_no = @car_no, car_revision = @car_revision, car_type = @car_type, pre_alert = @pre_alert, related_car_no = @related_car_no, related_car_rev = @related_car_rev, originator = @originator, recurrence = @recurrence, supplier_contact = @supplier_contact, supplier_email = @supplier_email, issued_date = @issued_date, originator_dept = @originator_dept, originator_contact = @originator_contact, part_no = @part_no, part_description = @part_description, business_unit = @business_unit, dept_pl = @dept_pl, commodity = @commodity, defect_quantity = @defect_quantity, defect_type = @defect_type, non_conformity_reported = @non_conformity_reported, reject_reason = @reject_reason, expected_date_close = @expected_date_close, save_status = @save_status", con);
                                update_data.Parameters.AddWithValue("@car_no", scar_details.Car_no);
                                update_data.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
                                update_data.Parameters.AddWithValue("@car_type", scar_details.Car_type);
                                update_data.Parameters.AddWithValue("@pre_alert", scar_details.Pre_alert);
                                update_data.Parameters.AddWithValue("@related_car_no", scar_details.Related_car_no);
                                update_data.Parameters.AddWithValue("@related_car_ref", scar_details.Related_car_rev);
                                update_data.Parameters.AddWithValue("@originator", scar_details.Originator);
                                update_data.Parameters.AddWithValue("@recurrence", scar_details.Recurrence);
                                update_data.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
                                update_data.Parameters.AddWithValue("@supplier_email", scar_details.Supplier_email);
                                update_data.Parameters.AddWithValue("@issued_date", issued_date);
                                update_data.Parameters.AddWithValue("@originator_dept", scar_details.Originator_department);
                                update_data.Parameters.AddWithValue("@originator_contact", scar_details.Originator_contact);
                                update_data.Parameters.AddWithValue("@part_no", scar_details.Part_no);
                                update_data.Parameters.AddWithValue("@part_description", scar_details.Part_description);
                                update_data.Parameters.AddWithValue("@business_unit", scar_details.Business_unit);
                                update_data.Parameters.AddWithValue("@dept_pl", scar_details.Dept_pl);
                                update_data.Parameters.AddWithValue("@commodity", scar_details.Commodity);
                                update_data.Parameters.AddWithValue("@defect_quantity", scar_details.Defect_quantity);
                                update_data.Parameters.AddWithValue("@defect_type", scar_details.Defect_type);
                                update_data.Parameters.AddWithValue("@non_conformity_reported", scar_details.Non_conformity_reported);
                                update_data.Parameters.AddWithValue("@reject_reason", scar_details.Reject_reason);
                                update_data.Parameters.AddWithValue("@expected_date_close", expected_date_close);
                                update_data.Parameters.AddWithValue("@save_status", "save");
                                update_data.ExecuteNonQuery();

                                ProcessedMessage.Text = "SCAR Request has been updated!";
                                ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                                process_submit = true;
                            }
                        }
                        if (!process_submit)
                        {
                            ProcessedMessage.Text = "SCAR Request has NOT been updated! Please Try Again!";
                            ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                        }
                    }
                    catch (Exception err)
                    {
                        ProcessedMessage.Text = "SCAR Request has not been updated! Please Try Again!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else if (clicked_button == 1)
            {
                if (Check_Duplicate_Data(scar_details, clicked_button) == true) // Checks for duplicate records
                {
                    try
                    {
                        
                        // SQL command to insert data into database
                        SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, car_no, 
            car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
            supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
            defect_type, non_conformity_reported, reject_reason, expected_date_close, save_status) VALUES (@scar_stage, @scar_type, @scar_status, @car_no, @car_revision, @car_type, @pre_alert,
            @related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description,
            @business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close, @save_status)", con);

                        addSite.Parameters.AddWithValue("@scar_stage", "New SCAR");
                        addSite.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
                        addSite.Parameters.AddWithValue("@scar_status", "Pending");
                        addSite.Parameters.AddWithValue("@car_no", scar_details.Car_no);
                        addSite.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
                        addSite.Parameters.AddWithValue("@car_type", scar_details.Car_type);
                        addSite.Parameters.AddWithValue("@pre_alert", scar_details.Pre_alert);
                        addSite.Parameters.AddWithValue("@related_car_no", scar_details.Related_car_no);
                        addSite.Parameters.AddWithValue("@related_car_ref", scar_details.Related_car_rev);
                        addSite.Parameters.AddWithValue("@originator", scar_details.Originator);
                        addSite.Parameters.AddWithValue("@recurrence", scar_details.Recurrence);
                        addSite.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
                        addSite.Parameters.AddWithValue("@supplier_email", scar_details.Supplier_email);
                        addSite.Parameters.AddWithValue("@issued_date", issued_date);
                        addSite.Parameters.AddWithValue("@originator_dept", scar_details.Originator_department);
                        addSite.Parameters.AddWithValue("@originator_contact", scar_details.Originator_contact);
                        addSite.Parameters.AddWithValue("@part_no", scar_details.Part_no);
                        addSite.Parameters.AddWithValue("@part_description", scar_details.Part_description);
                        addSite.Parameters.AddWithValue("@business_unit", scar_details.Business_unit);
                        addSite.Parameters.AddWithValue("@dept_pl", scar_details.Dept_pl);
                        addSite.Parameters.AddWithValue("@commodity", scar_details.Commodity);
                        addSite.Parameters.AddWithValue("@defect_quantity", scar_details.Defect_quantity);
                        addSite.Parameters.AddWithValue("@defect_type", scar_details.Defect_type);
                        addSite.Parameters.AddWithValue("@non_conformity_reported", scar_details.Non_conformity_reported);
                        addSite.Parameters.AddWithValue("@reject_reason", scar_details.Reject_reason);
                        addSite.Parameters.AddWithValue("@expected_date_close", expected_date_close);
                        addSite.Parameters.AddWithValue("@save_status", "submit");
                        addSite.ExecuteNonQuery();

                        ProcessedMessage.Text = "SCAR Request is successful!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                    }
                    catch (Exception err)
                    {
                        ProcessedMessage.Text = "SCAR Request is not successful! Please try again!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else 
                {
                    try
                    {
                        SqlCommand select = new SqlCommand("SELECT car_no, car_revision, issued_date, save_status FROM dbo.SCAR_Request", con);
                        SqlDataReader reader;
                        bool process_submit = false;
                        reader = select.ExecuteReader();
                        while (reader.Read())
                        {
                            if (scar_details.Car_no.CompareTo(Convert.ToString(reader["car_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "save")
                            {
                                SqlCommand update_data = new SqlCommand(@"UPDATE TABLE dbo.SCAR_Request SET car_no = @car_no, car_revision = @car_revision, car_type = @car_type, pre_alert = @pre_alert, related_car_no = @related_car_no, related_car_rev = @related_car_rev, originator = @originator, recurrence = @recurrence, supplier_contact = @supplier_contact, supplier_email = @supplier_email, issued_date = @issued_date, originator_dept = @originator_dept, originator_contact = @originator_contact, part_no = @part_no, part_description = @part_description, business_unit = @business_unit, dept_pl = @dept_pl, commodity = @commodity, defect_quantity = @defect_quantity, defect_type = @defect_type, non_conformity_reported = @non_conformity_reported, reject_reason = @reject_reason, expected_date_close = @expected_date_close, save_status = @save_status", con);
                                update_data.Parameters.AddWithValue("@car_no", scar_details.Car_no);
                                update_data.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
                                update_data.Parameters.AddWithValue("@car_type", scar_details.Car_type);
                                update_data.Parameters.AddWithValue("@pre_alert", scar_details.Pre_alert);
                                update_data.Parameters.AddWithValue("@related_car_no", scar_details.Related_car_no);
                                update_data.Parameters.AddWithValue("@related_car_ref", scar_details.Related_car_rev);
                                update_data.Parameters.AddWithValue("@originator", scar_details.Originator);
                                update_data.Parameters.AddWithValue("@recurrence", scar_details.Recurrence);
                                update_data.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
                                update_data.Parameters.AddWithValue("@supplier_email", scar_details.Supplier_email);
                                update_data.Parameters.AddWithValue("@issued_date", issued_date);
                                update_data.Parameters.AddWithValue("@originator_dept", scar_details.Originator_department);
                                update_data.Parameters.AddWithValue("@originator_contact", scar_details.Originator_contact);
                                update_data.Parameters.AddWithValue("@part_no", scar_details.Part_no);
                                update_data.Parameters.AddWithValue("@part_description", scar_details.Part_description);
                                update_data.Parameters.AddWithValue("@business_unit", scar_details.Business_unit);
                                update_data.Parameters.AddWithValue("@dept_pl", scar_details.Dept_pl);
                                update_data.Parameters.AddWithValue("@commodity", scar_details.Commodity);
                                update_data.Parameters.AddWithValue("@defect_quantity", scar_details.Defect_quantity);
                                update_data.Parameters.AddWithValue("@defect_type", scar_details.Defect_type);
                                update_data.Parameters.AddWithValue("@non_conformity_reported", scar_details.Non_conformity_reported);
                                update_data.Parameters.AddWithValue("@reject_reason", scar_details.Reject_reason);
                                update_data.Parameters.AddWithValue("@expected_date_close", expected_date_close);
                                update_data.Parameters.AddWithValue("@save_status", "submit");
                                update_data.ExecuteNonQuery();
                               
                                ProcessedMessage.Text = "SCAR Request is successful!";
                                ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                                process_submit = true;
                            }
                        }
                        if (!process_submit)
                        {
                            ProcessedMessage.Text = "SCAR Request is not successful! Record already exists!";
                            ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                        }
                    }
                    catch (Exception err)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }  
                }
            }
        }
    }

    // Checks for duplicate records
    protected bool Check_Duplicate_Data(SCAR scar_details, int clicked_button)
    {
        SqlConnection con;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();
        SqlCommand select = new SqlCommand("SELECT car_no, car_revision, issued_date, save_status FROM dbo.SCAR_Request", con);
        SqlDataReader reader;
        bool compare_data = true;
        reader = select.ExecuteReader();
        while (reader.Read())
        {
            if(clicked_button == 0)
            {
                if (scar_details.Car_no.CompareTo(Convert.ToString(reader["car_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"])=="save")
                { compare_data = false;
                } 
            }
            else if (clicked_button == 1)
            {
                if (scar_details.Car_no.CompareTo(Convert.ToString(reader["car_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "submit" || Convert.ToString(reader["save_status"]) == "save")
                { compare_data = false;}
            }
        }
        return compare_data;
    }
    /* End of Section 1 */

    /* SCAR Response Section */
    protected void Save_Response(object sender, EventArgs e)
    {
        int save_response_button_click = 0;
        Read_From_Form(save_response_button_click); 
    }

    protected void Submit_Response(object sender, EventArgs e)
    {
        int submit_response_button_click = 1;
        Read_From_Form(submit_response_button_click);
    }


    protected void Save_8D_Request(object sender, EventArgs e)
    {
        SCAR_Response scar_response_details = new SCAR_Response();
        bool checkEmptyFields = true;
        /* 8D Approval Section */
        if (!string.IsNullOrEmpty(lstWCM.Text)) // Work Cell Manager
        {
            scar_response_details.Work_cell_manager = lstWCM.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(lstQM.Text)) // Man
        {
            scar_response_details.Quality_manager = lstQM.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

    }


    protected void Read_From_Form(int response_clicked_button)
    {
        SCAR_Response scar_response_details = new SCAR_Response();
        bool checkEmptyFields = true;

        /* Validation on text fields */
        if (!string.IsNullOrEmpty(lstRootCause.Text)) // Root Cause
        {
            scar_response_details.Root_cause_option = lstRootCause.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtOverallSummary.Text)) // Overall Summary
        {
            scar_response_details.Overall_summary = txtOverallSummary.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtProbVerification.Text)) // Problem Verification
        {
            scar_response_details.Problem_verification = txtProbVerification.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(rdbProbVerificationStatus.Text)) // Problem Verification Status
        {
            scar_response_details.Problem_verification_status = rdbProbVerificationStatus.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

        /* Section 2 */
        if (!string.IsNullOrEmpty(txtContainmentAction.Text)) // Containment Action
        {
            scar_response_details.S21_containment_action = txtContainmentAction.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(cldS2ImplementationDate.Value)) // Containment Action Implementation Date
        {
            scar_response_details.S22_implementation_date = cldS2ImplementationDate.Value;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS2ResponsiblePerson.Text)) // Containment Action Responsible Person
        {
            scar_response_details.S23_responsible_person = txtS2ResponsiblePerson.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtContainmentResult.Text)) // Containment Action Result
        {
            scar_response_details.S24_containment_result = txtContainmentResult.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(lstScreeningArea.Text)) // Screening Area
        {
            scar_response_details.Screening_area = lstScreeningArea.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

        scar_response_details.S2_track_action_item = chkS2TrackActionItem.Checked; // Track Action Item for Containment Action
        /* End of Section 2 */

        /* Section 3 */

        if (!string.IsNullOrEmpty(lstFailureAnalysis.Text)) // Failure Analysis
        {
            scar_response_details.S31_failure_analysis = lstFailureAnalysis.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtFailureResult.Text)) // Failure Analysis Result
        {
            scar_response_details.S32_failure_analysis_results = txtFailureResult.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        /* End of Section 3 */

        /* Section 4 */

        if (!string.IsNullOrEmpty(txtMan.Text)) // Man
        {
            scar_response_details.Man = txtMan.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtMachine.Text)) // Machine
        {
            scar_response_details.Machine = txtMachine.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtMethod.Text)) // Method
        {
            scar_response_details.Method = txtMethod.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtMaterial.Text)) // Material
        {
            scar_response_details.Material = txtMaterial.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        /* End of Section 4 */

        /* Section 5 */

        if (!string.IsNullOrEmpty(txtCorrectiveAction.Text)) // Corrective Action
        {
            scar_response_details.S51_corrective_action = txtCorrectiveAction.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(cldS5ImplementationDate.Value)) // Corrective Action Implementation Date
        {
            scar_response_details.S52_implementation_date = cldS5ImplementationDate.Value;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS5ResponsiblePerson.Text)) // Corrective Action Responsible Person
        {
            scar_response_details.S53_responsible_person = txtS5ResponsiblePerson.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

        scar_response_details.S5_track_action_item = chkS5TrackActionItem.Checked; // Corrective Action Track Action Item
        /* End of Section 5 */

        /* Section 6 */

        if (!string.IsNullOrEmpty(txtPermanentCA.Text)) // Permanent Corrective Action
        {
            scar_response_details.S61_permanent_corrective_action = txtPermanentCA.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(cldS6ImplementationDate.Value)) // Permanent Corrective Action Implementation Date
        {
            scar_response_details.S62_implementation_date = cldS6ImplementationDate.Value;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS6ResponsiblePerson.Text)) // Permanent Corrective Action Responsible Person
        {
            scar_response_details.S63_responsible_person = txtS6ResponsiblePerson.Text;
        }
        else
        {
            checkEmptyFields = false;
        }

        scar_response_details.S6_track_action_item = chkS6TrackActionItem.Checked; // Permanent Corrective Action Track Action Item

        /* End of Section 6 */

        /* Section 7 */

        if (!string.IsNullOrEmpty(txtVerifyCA.Text)) // Verify Effectiveness of Corrective Action
        {
            scar_response_details.S71_verify_effectiveness_of_corrective_actions = txtVerifyCA.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(cldS7ImplementationDate.Value)) // Verify Effectiveness of Corrective Action Implementation Date
        {
            scar_response_details.S72_implementation_date = cldS7ImplementationDate.Value;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS7ResponsiblePerson.Text)) // Verify Effectiveness of Corrective Action Responsible Person
        {
            scar_response_details.S73_responsible_person = txtS7ResponsiblePerson.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtVerifier.Text)) // Verify Effectiveness of Corrective Action Verifier
        {
            scar_response_details.S74_verifier = txtVerifier.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtVerifierEmail.Text)) // Verify Effectiveness of Corrective Action Verifier Email
        {
            scar_response_details.S75_verifier_email = txtVerifierEmail.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtVerifyCAResult.Text)) // Verify Effectiveness of Corrective Action Result
        {
            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = txtVerifyCAResult.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        /* End of Section 7 */

        if (!string.IsNullOrEmpty(lstDefectMode.Text)) // Defect Mode
        {
            scar_response_details.Defect_mode = lstDefectMode.Text;
        }
        else
        {
            scar_response_details.Defect_mode = "N/A";
        }

        //scar_response_details.Require_8D_approval = chk8Dapproval.Checked; // Require 8D Approval
        scar_response_details.MOR_Calculated = chkMOR.Checked; // MOR Calculated

        if (checkEmptyFields)
        {
            Insert_Into_Response_Database(scar_response_details, response_clicked_button);
        }
    }

    protected void Upload_Files()
    {
        try
        {
            foreach (HttpPostedFile postedFile in uploadFile.PostedFiles)
            {
                var disallowedExtensions = new[] { ".txt", ".msi" };
                var extension = Path.GetExtension(postedFile.FileName);
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;

                if (!disallowedExtensions.Contains(extension))
                {
                    using (Stream fs = postedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string DatabaseName = "AutoSCARConnectionString";
                            string constr = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                string query = "insert into dbo.SCAR_attachments (file_name, file_type, data, scar_id)values (@Name, @ContentType, @Data, @id)";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {
                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Name", filename);
                                    cmd.Parameters.AddWithValue("@ContentType", contentType);
                                    cmd.Parameters.AddWithValue("@Data", bytes);
                                    cmd.Parameters.AddWithValue("@id", 1);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    ProcessedMessage.Text = "Your files have been uploaded succesfully!";
                                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                                    con.Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    ProcessedMessage.Text = ".exe and .msi files are not allowed! Please Try Again!";
                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                }
            }

        }
        catch (Exception err)
        {

        }
        finally
        {

        }
    }
    protected void Insert_Into_Response_Database(SCAR_Response scar_response_details, int response_clicked_button)
    {
        SqlConnection con;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        if(response_clicked_button == 0)
        {
            if(Check_Duplicate_Response_Data(scar_response_details, response_clicked_button) == true)
            {
                try
                {
                    string temp_SCAR_ID = Request.QueryString["scar_id"];
                    // SQL command to insert data into database
                    SqlCommand addResponse = new SqlCommand(@"INSERT INTO dbo.SCAR_Response (root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, 
s21_containment_action, s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, 
s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, 
s61_permanent_corrective_action, s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, 
s72_implementation_date, s73_responsible_person, s74_verifier, s75_verifer_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, status, scar_id) 
VALUES (@root_cause_option, @overall_summary, @problem_verification, @problem_verification_status, @s21_containment_action, @s22_implementation_date, @s23_responsible_person, 
@s24_containment_result, @screening_area, @track_containment_action, @s31_failure_analysis, @s32_failure_analysis_results, @s4_man, @s4_method, @s4_material, @s4_machine, 
@s51_corrective_action, @s52_implementation_date, @s53_responsible_person, @track_corrective_action, @s61_permanent_corrective_action, @s62_implementation_date, 
@s63_responsible_person, @track_permanent_corrective_action, @s71_verify_corrective_action_effectiveness, @s72_implementation_date, @s73_responsible_person, @s74_verifier,
@s75_verifier_email, @s76_verify_corrective_action_result_effectiveness, @defect_modes, @mor_calculated, @status, @scar_id)", con);

                    addResponse.Parameters.AddWithValue("@root_cause_option", scar_response_details.Root_cause_option);
                    addResponse.Parameters.AddWithValue("@overall_summary", scar_response_details.Overall_summary);
                    addResponse.Parameters.AddWithValue("@problem_verification", scar_response_details.Problem_verification);
                    addResponse.Parameters.AddWithValue("@problem_verification_status", scar_response_details.Problem_verification_status);
                    addResponse.Parameters.AddWithValue("@s21_containment_action", scar_response_details.S21_containment_action);
                    addResponse.Parameters.AddWithValue("@s22_implementation_date", scar_response_details.S22_implementation_date);
                    addResponse.Parameters.AddWithValue("@s23_responsible_person", scar_response_details.S23_responsible_person);
                    addResponse.Parameters.AddWithValue("@s24_containment_result", scar_response_details.S24_containment_result);
                    addResponse.Parameters.AddWithValue("@screening_area", scar_response_details.Screening_area);
                    addResponse.Parameters.AddWithValue("@track_containment_action", scar_response_details.S2_track_action_item);
                    addResponse.Parameters.AddWithValue("@s31_failure_analysis", scar_response_details.S31_failure_analysis);
                    addResponse.Parameters.AddWithValue("@s32_failure_analysis_results", scar_response_details.S32_failure_analysis_results);
                    addResponse.Parameters.AddWithValue("@s4_man", scar_response_details.Man);
                    addResponse.Parameters.AddWithValue("@s4_method", scar_response_details.Method);
                    addResponse.Parameters.AddWithValue("@s4_material", scar_response_details.Material);
                    addResponse.Parameters.AddWithValue("@s4_machine", scar_response_details.Machine);
                    addResponse.Parameters.AddWithValue("@s51_corrective_action", scar_response_details.S51_corrective_action);
                    addResponse.Parameters.AddWithValue("@s52_implementation_date", scar_response_details.S52_implementation_date);
                    addResponse.Parameters.AddWithValue("@s53_responsible_person", scar_response_details.S53_responsible_person);
                    addResponse.Parameters.AddWithValue("@track_corrective_action", scar_response_details.S5_track_action_item);
                    addResponse.Parameters.AddWithValue("@s61_permanent_corrective_action", scar_response_details.S61_permanent_corrective_action);
                    addResponse.Parameters.AddWithValue("@s62_implementation_date", scar_response_details.S62_implementation_date);
                    addResponse.Parameters.AddWithValue("@s63_responsible_person", scar_response_details.S63_responsible_person);
                    addResponse.Parameters.AddWithValue("@track_permanent_corrective_action", scar_response_details.S6_track_action_item);
                    addResponse.Parameters.AddWithValue("@s71_verify_corrective_action_effectiveness", scar_response_details.S71_verify_effectiveness_of_corrective_actions);
                    addResponse.Parameters.AddWithValue("@s72_implementation_date", scar_response_details.S72_implementation_date);
                    addResponse.Parameters.AddWithValue("@s73_responsible_person", scar_response_details.S73_responsible_person);
                    addResponse.Parameters.AddWithValue("@s74_verifier", scar_response_details.S74_verifier);
                    addResponse.Parameters.AddWithValue("@s75_verifier_email", scar_response_details.S75_verifier_email);
                    addResponse.Parameters.AddWithValue("@s76_verify_corrective_action_result_effectiveness", scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results);
                    addResponse.Parameters.AddWithValue("@defect_modes", scar_response_details.Defect_mode);
                    addResponse.Parameters.AddWithValue("@mor_calculated", scar_response_details.MOR_Calculated);
                    addResponse.Parameters.AddWithValue("@status", "save");
                    addResponse.Parameters.AddWithValue("@scar_id", temp_SCAR_ID);

                    addResponse.ExecuteNonQuery();

                    ProcessedMessage.Text = "SCAR Response has been saved!";
                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                }
                catch (Exception err)
                {
                    ProcessedMessage.Text = "SCAR Response cannot be saved! Please try again!";
                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                try
                {
                    string temp_SCAR_ID = Request.QueryString["scar_id"];

                    SqlCommand select = new SqlCommand("SELECT scar_id, status FROM dbo.SCAR_Response", con);
                    SqlDataReader reader;
                    bool process_submit = false;
                    reader = select.ExecuteReader();
                    while (reader.Read())
                    {
                        if (temp_SCAR_ID.CompareTo(reader["scar_id"]) == 0 && reader["status"].Equals("save"))
                        {
                            SqlCommand update_response = new SqlCommand(@"UPDATE TABLE dbo.SCAR_Response SET root_cause_option = @root_cause_option, 
s0_overall_summary = @overall_summary, s1_problem_verification = @problem_verification, problem_verification_status = @problem_verification_status,
s21_containment_action = @s21_containment_action, s22_implementation_date = @s22_implementation_date, s23_responsible_person = @s23_responsible_person, 
s24_containment_result = @s24_containment_result, screening_area = @screening_area, track_containment_action = @track_containment_action, 
s31_failure_analysis = @s31_failure_analysis, s32_failure_analysis_results = @s32_failure_analysis_results, s4_man = @s4_man, s4_method = @s4_method, 
s4_material = @s4_material, s4_machine = @s4_machine, s51_corrective_action = @s51_corrective_action, s52_implementation_date = @s52_implementation_date,
s53_responsible_person = @s53_responsible_person, track_corrective_action = @track_corrective_action, s61_permanent_corrective_action = @s61_permanent_corrective_action, 
s62_implementation_date = @s62_implementation_date, s63_responsible_person = @s63_responsible_person, track_permanent_corrective_action = @track_permanent_corrective_action, 
s71_verify_corrective_action_effectiveness = @s71_verify_correctiveness_action_effectiveness, s72_implementation_date = @s72_implementation_date,
s73_responsible_person = @s73_responsible_person, s74_verifier = @s74_verifer, s75_verifier_email = @s75_verifier_email, 
s76_verify_correctiveness_action_result_effectiveness = @s76_verify_correctiveness_action_result_effectiveness, defect_modes = @defect_modes, 
mor_calculated = @mor_calculated WHERE scar_id = @scar_id", con);

                            update_response.Parameters.AddWithValue("@scar_id", temp_SCAR_ID);
                            update_response.Parameters.AddWithValue("@root_cause_option", scar_response_details.Root_cause_option);
                            update_response.Parameters.AddWithValue("@overall_summary", scar_response_details.Overall_summary);
                            update_response.Parameters.AddWithValue("@problem_verification", scar_response_details.Problem_verification);
                            update_response.Parameters.AddWithValue("@problem_verification_status", scar_response_details.Problem_verification_status);
                            update_response.Parameters.AddWithValue("@s21_containment_action", scar_response_details.S21_containment_action);
                            update_response.Parameters.AddWithValue("@s22_implementation_date", scar_response_details.S22_implementation_date);
                            update_response.Parameters.AddWithValue("@s23_responsible_person", scar_response_details.S23_responsible_person);
                            update_response.Parameters.AddWithValue("@s24_containment_result", scar_response_details.S24_containment_result);
                            update_response.Parameters.AddWithValue("@screening_area", scar_response_details.Screening_area);
                            update_response.Parameters.AddWithValue("@track_containment_action", scar_response_details.S2_track_action_item);
                            update_response.Parameters.AddWithValue("@s31_failure_analysis", scar_response_details.S31_failure_analysis);
                            update_response.Parameters.AddWithValue("@s32_failure_analysis_results", scar_response_details.S32_failure_analysis_results);
                            update_response.Parameters.AddWithValue("@s4_man", scar_response_details.Man);
                            update_response.Parameters.AddWithValue("@s4_method", scar_response_details.Method);
                            update_response.Parameters.AddWithValue("@s4_material", scar_response_details.Material);
                            update_response.Parameters.AddWithValue("@s4_machine", scar_response_details.Machine);
                            update_response.Parameters.AddWithValue("@s51_corrective_action", scar_response_details.S51_corrective_action);
                            update_response.Parameters.AddWithValue("@s52_implementation_date", scar_response_details.S52_implementation_date);
                            update_response.Parameters.AddWithValue("@s53_responsible_person", scar_response_details.S53_responsible_person);
                            update_response.Parameters.AddWithValue("@track_corrective_action", scar_response_details.S5_track_action_item);
                            update_response.Parameters.AddWithValue("@s61_permanent_corrective_action", scar_response_details.S61_permanent_corrective_action);
                            update_response.Parameters.AddWithValue("@s62_implementation_date", scar_response_details.S62_implementation_date);
                            update_response.Parameters.AddWithValue("@s63_responsible_person", scar_response_details.S63_responsible_person);
                            update_response.Parameters.AddWithValue("@track_permanent_corrective_action", scar_response_details.S6_track_action_item);
                            update_response.Parameters.AddWithValue("@s71_verify_corrective_action_effectiveness", scar_response_details.S71_verify_effectiveness_of_corrective_actions);
                            update_response.Parameters.AddWithValue("@s72_implementation_date", scar_response_details.S72_implementation_date);
                            update_response.Parameters.AddWithValue("@s73_responsible_person", scar_response_details.S73_responsible_person);
                            update_response.Parameters.AddWithValue("@s74_verifier", scar_response_details.S74_verifier);
                            update_response.Parameters.AddWithValue("@s75_verifier_email", scar_response_details.S75_verifier_email);
                            update_response.Parameters.AddWithValue("@s76_verify_corrective_action_result_effectiveness", scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results);
                            update_response.Parameters.AddWithValue("@defect_modes", scar_response_details.Defect_mode);
                            update_response.Parameters.AddWithValue("@mor_calculated", scar_response_details.MOR_Calculated);

                            update_response.ExecuteNonQuery();

                            ProcessedMessage.Text = "SCAR Response has been updated!";
                            ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                        }
                    }
                    if (!process_submit)
                    {
                        ProcessedMessage.Text = "SCAR Request has NOT been updated! Please Try Again!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                    }
                }
                catch (Exception err)
                {

                }
                finally
                {
                    con.Close();
                }  
            }
            
        }
        else if (response_clicked_button == 1)
        {
            if(Check_Duplicate_Response_Data(scar_response_details, response_clicked_button) == true)
            {
                try
                {
                    string temp_SCAR_ID = Request.QueryString["scar_id"];
                    // SQL command to insert data into database
                    SqlCommand addResponse = new SqlCommand(@"INSERT INTO dbo.SCAR_Response (root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, 
s21_containment_action, s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, 
s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, 
s61_permanent_corrective_action, s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, 
s72_implementation_date, s73_responsible_person, s74_verifier, s75_verifer_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, status, scar_id) 
VALUES (@root_cause_option, @overall_summary, @problem_verification, @problem_verification_status, @s21_containment_action, @s22_implementation_date, @s23_responsible_person, 
@s24_containment_result, @screening_area, @track_containment_action, @s31_failure_analysis, @s32_failure_analysis_results, @s4_man, @s4_method, @s4_material, @s4_machine, 
@s51_corrective_action, @s52_implementation_date, @s53_responsible_person, @track_corrective_action, @s61_permanent_corrective_action, @s62_implementation_date, 
@s63_responsible_person, @track_permanent_corrective_action, @s71_verify_corrective_action_effectiveness, @s72_implementation_date, @s73_responsible_person, @s74_verifier,
@s75_verifier_email, @s76_verify_corrective_action_result_effectiveness, @defect_modes, @mor_calculated, @status, @scar_id)", con);

                    addResponse.Parameters.AddWithValue("@root_cause_option", scar_response_details.Root_cause_option);
                    addResponse.Parameters.AddWithValue("@overall_summary", scar_response_details.Overall_summary);
                    addResponse.Parameters.AddWithValue("@problem_verification", scar_response_details.Problem_verification);
                    addResponse.Parameters.AddWithValue("@problem_verification_status", scar_response_details.Problem_verification_status);
                    addResponse.Parameters.AddWithValue("@s21_containment_action", scar_response_details.S21_containment_action);
                    addResponse.Parameters.AddWithValue("@s22_implementation_date", scar_response_details.S22_implementation_date);
                    addResponse.Parameters.AddWithValue("@s23_responsible_person", scar_response_details.S23_responsible_person);
                    addResponse.Parameters.AddWithValue("@s24_containment_result", scar_response_details.S24_containment_result);
                    addResponse.Parameters.AddWithValue("@screening_area", scar_response_details.Screening_area);
                    addResponse.Parameters.AddWithValue("@track_containment_action", scar_response_details.S2_track_action_item);
                    addResponse.Parameters.AddWithValue("@s31_failure_analysis", scar_response_details.S31_failure_analysis);
                    addResponse.Parameters.AddWithValue("@s32_failure_analysis_results", scar_response_details.S32_failure_analysis_results);
                    addResponse.Parameters.AddWithValue("@s4_man", scar_response_details.Man);
                    addResponse.Parameters.AddWithValue("@s4_method", scar_response_details.Method);
                    addResponse.Parameters.AddWithValue("@s4_material", scar_response_details.Material);
                    addResponse.Parameters.AddWithValue("@s4_machine", scar_response_details.Machine);
                    addResponse.Parameters.AddWithValue("@s51_corrective_action", scar_response_details.S51_corrective_action);
                    addResponse.Parameters.AddWithValue("@s52_implementation_date", scar_response_details.S52_implementation_date);
                    addResponse.Parameters.AddWithValue("@s53_responsible_person", scar_response_details.S53_responsible_person);
                    addResponse.Parameters.AddWithValue("@track_corrective_action", scar_response_details.S5_track_action_item);
                    addResponse.Parameters.AddWithValue("@s61_permanent_corrective_action", scar_response_details.S61_permanent_corrective_action);
                    addResponse.Parameters.AddWithValue("@s62_implementation_date", scar_response_details.S62_implementation_date);
                    addResponse.Parameters.AddWithValue("@s63_responsible_person", scar_response_details.S63_responsible_person);
                    addResponse.Parameters.AddWithValue("@track_permanent_corrective_action", scar_response_details.S6_track_action_item);
                    addResponse.Parameters.AddWithValue("@s71_verify_corrective_action_effectiveness", scar_response_details.S71_verify_effectiveness_of_corrective_actions);
                    addResponse.Parameters.AddWithValue("@s72_implementation_date", scar_response_details.S72_implementation_date);
                    addResponse.Parameters.AddWithValue("@s73_responsible_person", scar_response_details.S73_responsible_person);
                    addResponse.Parameters.AddWithValue("@s74_verifier", scar_response_details.S74_verifier);
                    addResponse.Parameters.AddWithValue("@s75_verifier_email", scar_response_details.S75_verifier_email);
                    addResponse.Parameters.AddWithValue("@s76_verify_corrective_action_result_effectiveness", scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results);
                    addResponse.Parameters.AddWithValue("@defect_modes", scar_response_details.Defect_mode);
                    addResponse.Parameters.AddWithValue("@mor_calculated", scar_response_details.MOR_Calculated);
                    addResponse.Parameters.AddWithValue("@status", "submit");
                    addResponse.Parameters.AddWithValue("@scar_id", temp_SCAR_ID);

                    addResponse.ExecuteNonQuery();

                    ProcessedMessage.Text = "SCAR Response has been submitted successfully!";
                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                }
                catch (Exception err)
                {
                    ProcessedMessage.Text = "SCAR Response cannot be submitted! Please try again!";
                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                }
                finally
                {
                    con.Close();
                }
            }

        }
        else
        {
            try
            {
                string temp_SCAR_ID = Request.QueryString["scar_id"];

                SqlCommand select = new SqlCommand("SELECT scar_id, status FROM dbo.SCAR_Response", con);
                SqlDataReader reader;
                bool process_submit = false;
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    if (temp_SCAR_ID.CompareTo(reader["scar_id"]) == 0 && reader["status"].Equals("save"))
                    {
                        SqlCommand update_response = new SqlCommand(@"UPDATE TABLE dbo.SCAR_Response SET root_cause_option = @root_cause_option, 
s0_overall_summary = @overall_summary, s1_problem_verification = @problem_verification, problem_verification_status = @problem_verification_status,
s21_containment_action = @s21_containment_action, s22_implementation_date = @s22_implementation_date, s23_responsible_person = @s23_responsible_person, 
s24_containment_result = @s24_containment_result, screening_area = @screening_area, track_containment_action = @track_containment_action, 
s31_failure_analysis = @s31_failure_analysis, s32_failure_analysis_results = @s32_failure_analysis_results, s4_man = @s4_man, s4_method = @s4_method, 
s4_material = @s4_material, s4_machine = @s4_machine, s51_corrective_action = @s51_corrective_action, s52_implementation_date = @s52_implementation_date,
s53_responsible_person = @s53_responsible_person, track_corrective_action = @track_corrective_action, s61_permanent_corrective_action = @s61_permanent_corrective_action, 
s62_implementation_date = @s62_implementation_date, s63_responsible_person = @s63_responsible_person, track_permanent_corrective_action = @track_permanent_corrective_action, 
s71_verify_corrective_action_effectiveness = @s71_verify_correctiveness_action_effectiveness, s72_implementation_date = @s72_implementation_date,
s73_responsible_person = @s73_responsible_person, s74_verifier = @s74_verifer, s75_verifier_email = @s75_verifier_email, 
s76_verify_correctiveness_action_result_effectiveness = @s76_verify_correctiveness_action_result_effectiveness, defect_modes = @defect_modes, 
mor_calculated = @mor_calculated, status = @status WHERE scar_id = @scar_id", con);

                        update_response.Parameters.AddWithValue("@scar_id", temp_SCAR_ID);
                        update_response.Parameters.AddWithValue("@root_cause_option", scar_response_details.Root_cause_option);
                        update_response.Parameters.AddWithValue("@overall_summary", scar_response_details.Overall_summary);
                        update_response.Parameters.AddWithValue("@problem_verification", scar_response_details.Problem_verification);
                        update_response.Parameters.AddWithValue("@problem_verification_status", scar_response_details.Problem_verification_status);
                        update_response.Parameters.AddWithValue("@s21_containment_action", scar_response_details.S21_containment_action);
                        update_response.Parameters.AddWithValue("@s22_implementation_date", scar_response_details.S22_implementation_date);
                        update_response.Parameters.AddWithValue("@s23_responsible_person", scar_response_details.S23_responsible_person);
                        update_response.Parameters.AddWithValue("@s24_containment_result", scar_response_details.S24_containment_result);
                        update_response.Parameters.AddWithValue("@screening_area", scar_response_details.Screening_area);
                        update_response.Parameters.AddWithValue("@track_containment_action", scar_response_details.S2_track_action_item);
                        update_response.Parameters.AddWithValue("@s31_failure_analysis", scar_response_details.S31_failure_analysis);
                        update_response.Parameters.AddWithValue("@s32_failure_analysis_results", scar_response_details.S32_failure_analysis_results);
                        update_response.Parameters.AddWithValue("@s4_man", scar_response_details.Man);
                        update_response.Parameters.AddWithValue("@s4_method", scar_response_details.Method);
                        update_response.Parameters.AddWithValue("@s4_material", scar_response_details.Material);
                        update_response.Parameters.AddWithValue("@s4_machine", scar_response_details.Machine);
                        update_response.Parameters.AddWithValue("@s51_corrective_action", scar_response_details.S51_corrective_action);
                        update_response.Parameters.AddWithValue("@s52_implementation_date", scar_response_details.S52_implementation_date);
                        update_response.Parameters.AddWithValue("@s53_responsible_person", scar_response_details.S53_responsible_person);
                        update_response.Parameters.AddWithValue("@track_corrective_action", scar_response_details.S5_track_action_item);
                        update_response.Parameters.AddWithValue("@s61_permanent_corrective_action", scar_response_details.S61_permanent_corrective_action);
                        update_response.Parameters.AddWithValue("@s62_implementation_date", scar_response_details.S62_implementation_date);
                        update_response.Parameters.AddWithValue("@s63_responsible_person", scar_response_details.S63_responsible_person);
                        update_response.Parameters.AddWithValue("@track_permanent_corrective_action", scar_response_details.S6_track_action_item);
                        update_response.Parameters.AddWithValue("@s71_verify_corrective_action_effectiveness", scar_response_details.S71_verify_effectiveness_of_corrective_actions);
                        update_response.Parameters.AddWithValue("@s72_implementation_date", scar_response_details.S72_implementation_date);
                        update_response.Parameters.AddWithValue("@s73_responsible_person", scar_response_details.S73_responsible_person);
                        update_response.Parameters.AddWithValue("@s74_verifier", scar_response_details.S74_verifier);
                        update_response.Parameters.AddWithValue("@s75_verifier_email", scar_response_details.S75_verifier_email);
                        update_response.Parameters.AddWithValue("@s76_verify_corrective_action_result_effectiveness", scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results);
                        update_response.Parameters.AddWithValue("@defect_modes", scar_response_details.Defect_mode);
                        update_response.Parameters.AddWithValue("@mor_calculated", scar_response_details.MOR_Calculated);
                        update_response.Parameters.AddWithValue("@status", "submit");

                        update_response.ExecuteNonQuery();

                        ProcessedMessage.Text = "SCAR Response has been updated!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                    }
                }
                if (!process_submit)
                {
                    ProcessedMessage.Text = "SCAR Request has NOT been updated! Please Try Again!";
                    ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                }
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();
            }  
        }

        Upload_Files();
    }

    protected bool Check_Duplicate_Response_Data(SCAR_Response scar_response_details, int response_clicked_button)
    {
        SqlConnection con;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        string temp_SCAR_ID = Request.QueryString["scar_id"];
        SqlCommand select = new SqlCommand("SELECT scar_id, status FROM SCAR_Response", con);
        SqlDataReader reader;
        bool compare_data = true;
        reader = select.ExecuteReader();
        while (reader.Read())
        {
            if (response_clicked_button == 0)
            {
                if (temp_SCAR_ID.CompareTo(reader["scar_id"]) == 0 && reader["status"].Equals("save"))
                {
                    compare_data = false;
                }
            }
            else if (response_clicked_button == 1)
            {
                if (temp_SCAR_ID.CompareTo(reader["scar_id"]) == 0 && reader["status"].Equals("save") || reader["status"].Equals("submit"))
                {
                    compare_data = false;
                }
            }
        }
        return compare_data;
    }

    protected void Click_Request_Approval(object sender, EventArgs e)
    {
        // Establish Connection to Database
        SqlConnection con;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        string tempID = Request.QueryString["scar_id"];

        Employee WCM_details = new Employee();
        Employee QM_details = new Employee();
        EmailContent email_details = new EmailContent();

        WCM_details.Employee_name = lstWCM.SelectedItem.Text;
        WCM_details.Employee_ID = lstWCM.SelectedItem.Value;
        QM_details.Employee_name = lstQM.SelectedItem.Text;
        QM_details.Employee_ID = lstQM.SelectedItem.Value;

        SqlCommand select = new SqlCommand("SELECT employee_ID, employee_name, employee_email, employee_position FROM Employee", con);
        SqlDataReader reader;
        reader = select.ExecuteReader();
        while (reader.Read())
        {
            if(WCM_details.Employee_name.CompareTo(reader["employee_name"]) == 0 && WCM_details.Employee_ID.CompareTo(reader["employee_ID"]) == 0)
            {
                WCM_details.Employee_email = Convert.ToString(reader["employee_email"]);
                WCM_details.Employee_position = Convert.ToString(reader["employee_position"]);
            }

            if (QM_details.Employee_name.CompareTo(reader["employee_name"]) == 0 && QM_details.Employee_ID.CompareTo(reader["employee_ID"]) == 0)
            {
                QM_details.Employee_email = Convert.ToString(reader["employee_email"]);
                QM_details.Employee_position = Convert.ToString(reader["employee_position"]);
            }
        }

        bool insert_WCM_email_data = false;
        bool insert_QM_email_data = false;

        try
        {
            // SQL command to insert data into database
            if(WCM_details.Employee_position.CompareTo("Work Cell Manager") == 0)
            {
                SqlCommand addWCM = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (recipient_email_address, recipient_name, email_subject, email_content)
VALUES (@recipient_email_address, @recipient_name, @email_subject, @email_content)", con);

                addWCM.Parameters.AddWithValue("@recipient_email_address", WCM_details.Employee_email);
                addWCM.Parameters.AddWithValue("@recipient_name", WCM_details.Employee_name);
                addWCM.Parameters.AddWithValue("@email_subject", email_details.Email_header);
                addWCM.Parameters.AddWithValue("@email_content", email_details.Email_content);

                addWCM.ExecuteNonQuery();
                insert_WCM_email_data = true;
            }
            else if (QM_details.Employee_position.CompareTo("Quality Manager") == 0)
            {
                SqlCommand addQM = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (recipient_email_address, recipient_name, email_subject, email_content)
VALUES (@recipient_email_address, @recipient_name, @email_subject, @email_content)", con);

                addQM.Parameters.AddWithValue("@recipient_email_address", QM_details.Employee_email);
                addQM.Parameters.AddWithValue("@recipient_name", QM_details.Employee_name);
                addQM.Parameters.AddWithValue("@email_subject", email_details.Email_header);
                addQM.Parameters.AddWithValue("@email_content", email_details.Email_content);

                addQM.ExecuteNonQuery();
                insert_QM_email_data = true;
            }
            
            if(insert_QM_email_data && insert_WCM_email_data)
            {
                ProcessedMessage.Text = "8D Approval Request has been successfully sent!";
                ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
            }      
        }
        catch (Exception err)
        {
            ProcessedMessage.Text = "8D Approval Request cannot be sent! Please try again!";
            ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
        }
        finally
        {
            con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYP_WebApp.Old_App_Code;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class Engineer_scars_forms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlDefectType();
        ddlRootCauseOption();

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
                lstRootCause.DataBind();
                lstRootCause.Items.Insert(0, new ListItem("Please Select Root Cause", "0"));
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
        if (!string.IsNullOrEmpty(cldIssuedDate.Value)) // Issued Date
        {
            scar_details.Issued_date = cldIssuedDate.Value;
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
        if (!string.IsNullOrEmpty(cldDateClose.Value)) // Expected Date Close
        {
            scar_details.Expected_date_close = cldDateClose.Value;
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

                        ProcessedMessage.Text = "SCAR Request update is successful!";
                        ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
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
                                SqlCommand update_data = new SqlCommand("UPDATE TABLE dbo.SCAR_Request SET save_status = @save_status", con);
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
                if (scar_details.Car_no.CompareTo(Convert.ToString(reader["car_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "submit")
                { compare_data = false;}
            }
        }
        return compare_data;
    }


    /* SCAR Response Section */
    protected void Save_Response(object sender, EventArgs e)
    {
        SCAR_Response scar_response_details = new SCAR_Response();
        bool checkEmptyFields = true;
       
        /* Validation on text fields */
        if (!string.IsNullOrEmpty(lstRootCause.Text)) // Car Number
        {
            scar_response_details.Root_cause_option = lstRootCause.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtOverallSummary.Text)) // Car Number
        {
            scar_response_details.Overall_summary = txtOverallSummary.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtProbVerification.Text)) // Car Number
        {
            scar_response_details.Problem_verification = txtProbVerification.Text;
        }
        else
        {
            checkEmptyFields = false;
        }
    }

    protected void Submit_Response(object sender, EventArgs e)
    {

    }
}
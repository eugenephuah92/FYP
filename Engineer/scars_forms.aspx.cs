using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYP_WebApp.Old_App_Code;
using System.Data.SqlClient;
using System.Configuration;

public partial class Engineer_scars_forms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            lstDefectType.Items.Add("Performance");
            lstDefectType.Items.Add("Non-Performance");
        }    
    }

    protected void Save_Section_1(object sender, EventArgs e)
    {
        SCAR scar_details = new SCAR();
        bool checkEmptyFields = true;

        /* Validation on text fields */
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

        // Insert data into database if all fields pass the validation.
        if(checkEmptyFields)
        {
            Insert_Into_Database(scar_details);
        }
    }


    protected void Insert_Into_Database(SCAR scar_details)
    {
        SqlConnection con;
        con = new SqlConnection();
        string DatabaseName = "AutoSCARConnectionString";
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        bool check_date_difference = true;
        DateTime issued_date = Convert.ToDateTime(scar_details.Issued_date);
        DateTime expected_date_close = Convert.ToDateTime(scar_details.Expected_date_close);
        TimeSpan ts = expected_date_close - issued_date;

        if(ts.Days < 0)
        {
            check_date_difference = false;
        }

        if (check_date_difference)
        {
            try
            {
                SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, car_no, 
    car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
    supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
    defect_type, non_conformity_reported, reject_reason, expected_date_close) VALUES (@scar_stage, @scar_type, @scar_status, @car_no, @car_revision, @car_type, @pre_alert,
    @related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description,
    @business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close)", con);

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

                addSite.ExecuteNonQuery();

                ProcessedMessage.Text = "SCAR Request is successful!";
                ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
            }
            catch (Exception err)
            {
                ProcessedMessage.Text = "SCAR Request is not successful! Please try again!" + err.Message;
                ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
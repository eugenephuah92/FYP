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
using Jabil_Employee;
using Jabil_Session;
using CryptoLib;
public partial class Engineer_scars_forms : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string Temp_SCAR_No = Request.QueryString["scar_no"];   // Gets SCAR Number from URL

            /* Populate dropdrown list */
            ddlDefectType();
            ddlRootCauseOption();
            ddlFailureAnalysis();
            ddlSCARStatus();
            ddlScreeningArea();
            ddlDefectCategory();
            txtVerifyCAResult.Visible = false;
            lblfortxtVerifyCAResults.Visible = false;

            if (!String.IsNullOrEmpty(Temp_SCAR_No))
            {
                Display_Approval_GridView();    //  Displays the 8D Approval Status and Comments
                Display_Attachments_Grid_View(Temp_SCAR_No);    // Displays the attachments related to the SCAR
                SCAR_Status_Control(Temp_SCAR_No);  // Disable / Hides certain fields in the form based on the SCAR's current stage
                Read_Existing_Request_Records(Temp_SCAR_No);    // Reads existing SCAR request data into form
                Check_Manager_Approval(Temp_SCAR_No);
                string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    // Reads existing SCAR Response data
                    SqlCommand select = new SqlCommand(@"SELECT scar_no, scar_stage FROM dbo.SCAR_Request WHERE scar_no = @temp_SCAR_No AND scar_stage = @scarStage", conn);
                    select.Parameters.AddWithValue("temp_SCAR_No", Temp_SCAR_No);
                    select.Parameters.AddWithValue("scarStage", "Pending SCAR");
                    SqlDataReader reader;
                    reader = select.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Read_Existing_Response_Records(Temp_SCAR_No);

                    }
                }
            }
            else
            {
                btnSubmit.Enabled = false;
                btnSave2.Enabled = false;
                uploadFile.Enabled = false;
                btnChangeStatus.Enabled = false;

            }
        }  
    }


    protected void Check_Manager_Approval(string scar_no)
    {
        bool check_rows = false;
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            if(!IsPostBack)
            {
                conn.Open();
                // Reads existing SCAR Response data
                SqlCommand select = new SqlCommand(@"SELECT scar_no, approval_status_WCM, approval_status_QM FROM dbo.Approval_8D WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("scar_no", scar_no);

                SqlDataReader reader;
                reader = select.ExecuteReader();

                if (reader.HasRows)
                {
                    check_rows = true;
                }
                if(check_rows)
                {
                    while(reader.Read())
                    {
                        if(reader["approval_status_WCM"].Equals("Reject") || reader["approval_status_QM"].Equals("Reject"))
                        {
                            btnSubmit.Enabled = false;
                        }

                    }
                }
            }
            conn.Close();
        }
    }

   // Checks current SCAR stage in order to modify form dynamics and elements (hides / disable certain form elements)
    protected void SCAR_Status_Control(string scar_no)
    {
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand("SELECT scar_status, scar_type FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("@scar_no", scar_no);
                SqlDataReader reader = select.ExecuteReader();

                while(reader.Read())
                {
                    if(Convert.ToString(reader["scar_status"]).Equals("SCAR Type 2 Accepted"))
                    {
                        Read_Only_Response_Form(scar_no, "SCAR Type 2 Accepted");
                    }
                    else if (Convert.ToString(reader["scar_status"]).Equals("SCAR Type 2 Rejected"))
                    {
                        
                        Read_Only_Response_Form(scar_no, "SCAR Type 2 Rejected");
                    }
                    else if (Convert.ToString(reader["scar_status"]).Equals("SCAR Type 4 Accepted"))
                    {
                        lstCurrentStatus.Enabled = false;
                        btnChangeStatus.Enabled = false;
                        btnSubmit.Enabled = false;
                        btnSave2.Enabled = false;
                        chk8Dapproval.Enabled = false;
                        AttachmentsGridView.AutoGenerateDeleteButton = false;
                        uploadFile.Enabled = false;
                        Read_Only_Response_Form(scar_no, null);
                    }
                    else if (Convert.ToString(reader["scar_status"]).Equals("SCAR Type 4 Rejected"))
                    {
                        
                        Read_Only_Response_Form(scar_no, "SCAR Type 4 Rejected");
                    }
                    else
                    {
                        Read_Only_Response_Form(scar_no, null);
                    }
                }
            }
        }
    }

    // Hides / Disables certain fields in the response form
    protected void Read_Only_Response_Form(string scar_no, string scar_status)
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand("SELECT status FROM dbo.SCAR_Response WHERE scar_no = @scar_no", conn);
            select.Parameters.AddWithValue("@scar_no", scar_no);
            SqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToString(reader["status"]).Equals("submit"))
                {
                    lstRootCause.Enabled = false;
                    txtOverallSummary.ReadOnly = true;
                    txtProbVerification.ReadOnly = true;
                    rdbProbVerificationStatus.Enabled = false;
                    txtContainmentAction.ReadOnly = true;
                    txtS2ImplementationDate.ReadOnly = true;
                    txtS2ResponsiblePerson.ReadOnly = true;
                    txtContainmentResult.ReadOnly = true;
                    lstScreeningArea.Enabled = false;
                    chkS2TrackActionItem.Enabled = false;
                    lstFailureAnalysis.Enabled = false;
                    txtFailureResult.ReadOnly = true;
                    txtMachine.ReadOnly = true;
                    txtMan.ReadOnly = true;
                    txtMaterial.ReadOnly = true;
                    txtMethod.ReadOnly = true;
                    txtCorrectiveAction.ReadOnly = true;
                    txtS5ResponsiblePerson.ReadOnly = true;
                    txtS5ImplementationDate.ReadOnly = true;
                    chkS5TrackActionItem.Enabled = false;
                    txtPermanentCA.ReadOnly = true;
                    txtS6ImplementationDate.ReadOnly = true;
                    txtS6ResponsiblePerson.ReadOnly = true;
                    chkS6TrackActionItem.Enabled = false;
                    txtVerifyCA.ReadOnly = true;
                    txtVerifier.ReadOnly = true;
                    txtS7ImplementationDate.ReadOnly = true;
                    txtS7ResponsiblePerson.ReadOnly = true;
                    txtVerifierEmail.ReadOnly = true;
                    if(!string.IsNullOrEmpty(scar_status))
                    {
                        
                        if (scar_status.Equals("SCAR Type 2 Accepted"))
                        {
                            txtVerifyCAResult.Visible = true;
                            lblfortxtVerifyCAResults.Visible = true;
                        }     
                    }
                    else
                    {
                        txtVerifyCAResult.Visible = false;
                        lblfortxtVerifyCAResults.Visible = false;
                    }
                    lstDefectMode.Enabled = false;
                    chkMOR.Enabled = false;
                }
            }
        }
        
    }

    // Moves SCAR data into dbo.SCAR_History database table once the SCAR reaches a particular stage (SCAR Type 2 Rejected, SCAR Type 4 Accepted or SCAR Type 4 Rejected)
    protected void Move_Data_To_History(string scar_no, string scar_status, string scar_type)
    {
        SCAR scar_details = new SCAR();
        SCAR_Response scar_response_details = new SCAR_Response();
        
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            // Reads SCAR Request data and stores into object
            SqlCommand selectRequest = new SqlCommand(@"SELECT scar_no, car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, 
supplier_contact, supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity, 
defect_type, non_conformity_reported, reject_reason, expected_date_close, file_name, file_path FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
            selectRequest.Parameters.AddWithValue("@scar_no", scar_no);
            SqlDataReader readerRequest = selectRequest.ExecuteReader();

            while (readerRequest.Read())
            {
                scar_details.Car_no = Convert.ToString(readerRequest["scar_no"]);
                scar_details.Car_revision = Convert.ToString(readerRequest["car_revision"]);
                scar_details.Car_type = Convert.ToString(readerRequest["car_type"]);
                scar_details.Pre_alert = Convert.ToString(readerRequest["pre_alert"]);
                scar_details.Related_car_no = Convert.ToString(readerRequest["related_car_no"]);
                scar_details.Related_car_rev = Convert.ToString(readerRequest["related_car_ref"]);
                scar_details.Originator = Convert.ToString(readerRequest["originator"]);
                scar_details.Recurrence = Convert.ToString(readerRequest["recurrence"]);
                scar_details.Supplier_contact = Convert.ToString(readerRequest["supplier_contact"]);
                scar_details.Supplier_email = Convert.ToString(readerRequest["supplier_email"]);
                scar_details.Issued_date = Convert.ToDateTime(readerRequest["issued_date"]).ToString("yyyy-MM-dd");
                scar_details.Originator_department = Convert.ToString(readerRequest["originator_dept"]);
                scar_details.Originator_contact = Convert.ToString(readerRequest["originator_contact"]);
                scar_details.Part_no = Convert.ToString(readerRequest["part_no"]);
                scar_details.Part_description = Convert.ToString(readerRequest["part_description"]);
                scar_details.Business_unit = Convert.ToString(readerRequest["business_unit"]);
                scar_details.Dept_pl = Convert.ToString(readerRequest["dept_pl"]);
                scar_details.Commodity = Convert.ToString(readerRequest["commodity"]);
                scar_details.Defect_quantity = Convert.ToInt16(readerRequest["defect_quantity"]);
                scar_details.Defect_type = Convert.ToString(readerRequest["defect_type"]);
                scar_details.Non_conformity_reported = Convert.ToString(readerRequest["non_conformity_reported"]);
                scar_details.Reject_reason = Convert.ToString(readerRequest["reject_reason"]);
                scar_details.Expected_date_close = Convert.ToDateTime(readerRequest["expected_date_close"]).ToString("yyyy-MM-dd");
                scar_details.File_name = Convert.ToString(readerRequest["file_name"]);
                scar_details.File_path = Convert.ToString(readerRequest["file_path"]);
            }
            readerRequest.Close();

            // Reads SCAR Response data and stores into object
            SqlCommand selectResponse = new SqlCommand(@"SELECT root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, 
s21_containment_action, s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, 
s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, 
s61_permanent_corrective_action, s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, 
s72_implementation_date, s73_responsible_person, s74_verifier, s75_verifier_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated FROM dbo.SCAR_Response WHERE scar_no = @scar_no", conn);
            selectResponse.Parameters.AddWithValue("@scar_no", scar_no);
            SqlDataReader readerResponse = selectResponse.ExecuteReader();

            while(readerResponse.Read())
            {
                scar_response_details.Root_cause_option = Convert.ToString(readerResponse["root_cause_option"]);
                scar_response_details.Overall_summary = Convert.ToString(readerResponse["s0_overall_summary"]);
                scar_response_details.Problem_verification = Convert.ToString(readerResponse["s1_problem_verification"]);
                scar_response_details.Problem_verification_status = Convert.ToString(readerResponse["problem_verification_status"]);
                scar_response_details.S21_containment_action = Convert.ToString(readerResponse["s21_containment_action"]);
                scar_response_details.S22_implementation_date = Convert.ToString(readerResponse["s22_implementation_date"]);
                scar_response_details.S23_responsible_person = Convert.ToString(readerResponse["s23_responsible_person"]);
                scar_response_details.S24_containment_result = Convert.ToString(readerResponse["s24_containment_result"]);
                scar_response_details.Screening_area = Convert.ToString(readerResponse["screening_area"]);
                scar_response_details.S2_track_action_item = Convert.ToBoolean(Convert.ToInt16(readerResponse["track_containment_action"]));
                scar_response_details.S31_failure_analysis = Convert.ToString(readerResponse["s31_failure_analysis"]);
                scar_response_details.S32_failure_analysis_results = Convert.ToString(readerResponse["s32_failure_analysis_results"]);
                scar_response_details.Man = Convert.ToString(readerResponse["s4_man"]);
                scar_response_details.Method = Convert.ToString(readerResponse["s4_method"]);
                scar_response_details.Material = Convert.ToString(readerResponse["s4_material"]);
                scar_response_details.Machine = Convert.ToString(readerResponse["s4_machine"]);
                scar_response_details.S51_corrective_action = Convert.ToString(readerResponse["s51_corrective_action"]);
                scar_response_details.S52_implementation_date = Convert.ToDateTime(readerResponse["s52_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S53_responsible_person = Convert.ToString(readerResponse["s53_responsible_person"]);
                scar_response_details.S5_track_action_item = Convert.ToBoolean(Convert.ToInt16(readerResponse["track_corrective_action"]));
                scar_response_details.S61_permanent_corrective_action = Convert.ToString(readerResponse["s61_permanent_corrective_action"]);
                scar_response_details.S62_implementation_date = Convert.ToDateTime(readerResponse["s62_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S63_responsible_person = Convert.ToString(readerResponse["s63_responsible_person"]);
                scar_response_details.S6_track_action_item = Convert.ToBoolean(Convert.ToInt16(readerResponse["track_permanent_corrective_action"]));
                scar_response_details.S71_verify_effectiveness_of_corrective_actions = Convert.ToString(readerResponse["s71_verify_corrective_action_effectiveness"]);
                scar_response_details.S72_implementation_date = Convert.ToDateTime(readerResponse["s72_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S73_responsible_person = Convert.ToString(readerResponse["s73_responsible_person"]);
                scar_response_details.S74_verifier = Convert.ToString(readerResponse["s74_verifier"]);
                scar_response_details.S75_verifier_email = Convert.ToString(readerResponse["s75_verifier_email"]);
                scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = Convert.ToString(readerResponse["s76_verify_corrective_action_result_effectiveness"]);
                scar_response_details.Defect_mode = Convert.ToString(readerResponse["defect_modes"]);
                scar_response_details.MOR_Calculated = Convert.ToBoolean(Convert.ToInt16(readerResponse["mor_calculated"]));
            }
            readerResponse.Close();

            // Inserts the SCAR Data into the dbo.SCAR_History table in the database
            SqlCommand insert = new SqlCommand(@"INSERT INTO dbo.SCAR_History (scar_stage, scar_type, scar_status, scar_no, car_revision, car_type, pre_alert, related_car_no, 
related_car_ref, originator, recurrence, supplier_contact, supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, 
dept_pl, commodity, defect_quantity, defect_type, non_conformity_reported, reject_reason, expected_date_close, file_name, file_path, 
root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, s21_containment_action, s22_implementation_date, s23_responsible_person, 
s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, 
s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, s61_permanent_corrective_action, s62_implementation_date, 
s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, s72_implementation_date, s73_responsible_person, s74_verifier,
s75_verifier_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, completion_date, modified_by, last_modified) 
VALUES 
(@scar_stage, @scar_type, @scar_status, @scar_no, @car_revision, @car_type, @pre_alert, @related_car_no, @related_car_ref, @originator, @recurrence, @supplier_contact, @supplier_email, 
@issued_date, @originator_dept, @originator_contact, @part_no, @part_description, @business_unit, @dept_pl, @commodity, @defect_quantity, @defect_type, @non_conformity_reported, 
@reject_reason, @expected_date_close, @file_name, @file_path, 
@root_cause_option, @s0_overall_summary, @s1_problem_verification, @problem_verification_status, @s21_containment_action, @s22_implementation_date, @s23_responsible_person, 
@s24_containment_result, @screening_area, @track_containment_action, @s31_failure_analysis, @s32_failure_analysis_results, @s4_man, @s4_method, @s4_material, @s4_machine, 
@s51_corrective_action, @s52_implementation_date, @s53_responsible_person, @track_corrective_action, @s61_permanent_corrective_action, @s62_implementation_date, 
@s63_responsible_person, @track_permanent_corrective_action, @s71_verify_corrective_action_effectiveness, @s72_implementation_date, @s73_responsible_person, @s74_verifier,
@s75_verifier_email, @s76_verify_corrective_action_result_effectiveness, @defect_modes, @mor_calculated, @completion_date, @modified_by, @last_modified)", conn);

            insert.Parameters.AddWithValue("@scar_stage", "Closed SCAR");
            insert.Parameters.AddWithValue("@scar_type", scar_type);
            insert.Parameters.AddWithValue("@scar_status", scar_status);
            insert.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
            insert.Parameters.AddWithValue("@car_revision", scar_details.Car_revision);
            insert.Parameters.AddWithValue("@car_type", scar_details.Car_type);
            insert.Parameters.AddWithValue("@pre_alert", scar_details.Pre_alert);
            insert.Parameters.AddWithValue("@related_car_no", scar_details.Related_car_no);
            insert.Parameters.AddWithValue("@related_car_ref", scar_details.Related_car_rev);
            insert.Parameters.AddWithValue("@originator", scar_details.Originator);
            insert.Parameters.AddWithValue("@recurrence", scar_details.Recurrence);
            insert.Parameters.AddWithValue("@supplier_contact", scar_details.Supplier_contact);
            insert.Parameters.AddWithValue("@supplier_email", scar_details.Supplier_email);
            insert.Parameters.AddWithValue("@issued_date", scar_details.Issued_date);
            insert.Parameters.AddWithValue("@originator_dept", scar_details.Originator_department);
            insert.Parameters.AddWithValue("@originator_contact", scar_details.Originator_contact);
            insert.Parameters.AddWithValue("@part_no", scar_details.Part_no);
            insert.Parameters.AddWithValue("@part_description", scar_details.Part_description);
            insert.Parameters.AddWithValue("@business_unit", scar_details.Business_unit);
            insert.Parameters.AddWithValue("@dept_pl", scar_details.Dept_pl);
            insert.Parameters.AddWithValue("@commodity", scar_details.Commodity);
            insert.Parameters.AddWithValue("@defect_quantity", scar_details.Defect_quantity);
            insert.Parameters.AddWithValue("@defect_type", scar_details.Defect_type);
            insert.Parameters.AddWithValue("@non_conformity_reported", scar_details.Non_conformity_reported);
            insert.Parameters.AddWithValue("@reject_reason", scar_details.Reject_reason);
            insert.Parameters.AddWithValue("@expected_date_close", scar_details.Expected_date_close);
            insert.Parameters.AddWithValue("@file_name", scar_details.File_name);
            insert.Parameters.AddWithValue("@file_path", scar_details.File_path);

            insert.Parameters.AddWithValue("@root_cause_option", scar_response_details.Root_cause_option);
            insert.Parameters.AddWithValue("@s0_overall_summary", scar_response_details.Overall_summary);
            insert.Parameters.AddWithValue("@s1_problem_verification", scar_response_details.Problem_verification);
            insert.Parameters.AddWithValue("@problem_verification_status", scar_response_details.Problem_verification_status);
            insert.Parameters.AddWithValue("@s21_containment_action", scar_response_details.S21_containment_action);
            insert.Parameters.AddWithValue("@s22_implementation_date", scar_response_details.S22_implementation_date);
            insert.Parameters.AddWithValue("@s23_responsible_person", scar_response_details.S23_responsible_person);
            insert.Parameters.AddWithValue("@s24_containment_result", scar_response_details.S24_containment_result);
            insert.Parameters.AddWithValue("@screening_area", scar_response_details.Screening_area);
            insert.Parameters.AddWithValue("@track_containment_action", scar_response_details.S2_track_action_item);
            insert.Parameters.AddWithValue("@s31_failure_analysis", scar_response_details.S31_failure_analysis);
            insert.Parameters.AddWithValue("@s32_failure_analysis_results", scar_response_details.S32_failure_analysis_results);
            insert.Parameters.AddWithValue("@s4_man", scar_response_details.Man);
            insert.Parameters.AddWithValue("@s4_method", scar_response_details.Method);
            insert.Parameters.AddWithValue("@s4_material", scar_response_details.Material);
            insert.Parameters.AddWithValue("@s4_machine", scar_response_details.Machine);
            insert.Parameters.AddWithValue("@s51_corrective_action", scar_response_details.S51_corrective_action);
            insert.Parameters.AddWithValue("@s52_implementation_date", scar_response_details.S52_implementation_date);
            insert.Parameters.AddWithValue("@s53_responsible_person", scar_response_details.S53_responsible_person);
            insert.Parameters.AddWithValue("@track_corrective_action", scar_response_details.S5_track_action_item);
            insert.Parameters.AddWithValue("@s61_permanent_corrective_action", scar_response_details.S61_permanent_corrective_action);
            insert.Parameters.AddWithValue("@s62_implementation_date", scar_response_details.S62_implementation_date);
            insert.Parameters.AddWithValue("@s63_responsible_person", scar_response_details.S63_responsible_person);
            insert.Parameters.AddWithValue("@track_permanent_corrective_action", scar_response_details.S6_track_action_item);
            insert.Parameters.AddWithValue("@s71_verify_corrective_action_effectiveness", scar_response_details.S71_verify_effectiveness_of_corrective_actions);
            insert.Parameters.AddWithValue("@s72_implementation_date", scar_response_details.S72_implementation_date);
            insert.Parameters.AddWithValue("@s73_responsible_person", scar_response_details.S73_responsible_person);
            insert.Parameters.AddWithValue("@s74_verifier", scar_response_details.S74_verifier);
            insert.Parameters.AddWithValue("@s75_verifier_email", scar_response_details.S75_verifier_email);
            insert.Parameters.AddWithValue("@s76_verify_corrective_action_result_effectiveness", scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results);
            insert.Parameters.AddWithValue("@defect_modes", scar_response_details.Defect_mode);
            insert.Parameters.AddWithValue("@mor_calculated", scar_response_details.MOR_Calculated);
            insert.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);

            DateTime currentDateTime = DateTime.Now;
            insert.Parameters.AddWithValue("@last_modified", currentDateTime);

            DateTime completion_date = DateTime.Now;
            insert.Parameters.AddWithValue("@completion_date", completion_date);

            insert.ExecuteNonQuery();

            // Removes the SCAR data from the dbo.SCAR_Request and dbo.SCAR_Response table
            SqlCommand deleteResponse = new SqlCommand(@"DELETE FROM dbo.SCAR_Response WHERE scar_no = @scar_no", conn);
            deleteResponse.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
            deleteResponse.ExecuteNonQuery();

            SqlCommand deleteRequest = new SqlCommand(@"DELETE FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
            deleteRequest.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
            deleteRequest.ExecuteNonQuery();

            string message = "SCAR Response has been updated!" + scar_details.Car_no + " - Revision: " + scar_details.Car_revision + " has been closed!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
            
        }
    }

    // SCAR Status dropdown list that specifies whether the SCAR is accepted or rejected
    protected void ddlSCARStatus()
    {
        if (!IsPostBack)
        {
            string scar_no = Request.QueryString["scar_no"];
            if (!String.IsNullOrEmpty(scar_no))
            {
                string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand select = new SqlCommand(@"SELECT SCAR_Request.scar_no, SCAR_Request.scar_status, SCAR_Request.scar_type, SCAR_Response.status 
FROM dbo.SCAR_Request INNER JOIN dbo.SCAR_Response ON SCAR_Request.scar_no = SCAR_Response.scar_no WHERE SCAR_Request.scar_no = @scar_no", conn);
                        select.Parameters.AddWithValue("@scar_no", scar_no);
                        SqlDataReader reader = select.ExecuteReader();
                        if(!reader.HasRows)
                        {
                            lstCurrentStatus.Enabled = false;
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                if (Convert.ToString(reader["scar_type"]).Equals("SCAR Type 2") && Convert.ToString(reader["status"]).Equals("submit"))
                                {
                                    lstCurrentStatus.Items.Insert(0, new ListItem("SCAR Type 2 Accepted", "SCAR Type 2 Accepted"));
                                    lstCurrentStatus.Items.Insert(1, new ListItem("SCAR Type 2 Rejected", "SCAR Type 2 Rejected"));
                                }
                                else if (Convert.ToString(reader["scar_type"]).Equals("SCAR Type 4") && Convert.ToString(reader["status"]).Equals("submit"))
                                {
                                    lstCurrentStatus.Items.Insert(0, new ListItem("SCAR Type 4 Accepted", "SCAR Type 4 Accepted"));
                                    lstCurrentStatus.Items.Insert(1, new ListItem("SCAR Type 4 Rejected", "SCAR Type 4 Rejected"));
                                }
                                else
                                {
                                    lstCurrentStatus.Enabled = false;
                                }
                            }
                        }
                        
                    }
                    catch (Exception err)
                    {
                        
                    }
                }
            }
            else
            {
                lstCurrentStatus.Enabled = false;
            }
        }
    }

    // Screening Area dropdown list
    protected void ddlScreeningArea()
    {
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand select = new SqlCommand("SELECT screening_area FROM dbo.SCAR_Screening_Area", conn);
                conn.Open();

                lstScreeningArea.DataSource = select.ExecuteReader();
                lstScreeningArea.DataTextField = "screening_area";
                lstScreeningArea.DataValueField = "screening_area";
                lstScreeningArea.DataBind();
            }
        }
    }

    // Defect Type dropdown list
    protected void ddlDefectType()
    {
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand select = new SqlCommand("SELECT defect_type FROM dbo.SCAR_Defect_type", conn);
                conn.Open();

                lstDefectType.DataSource = select.ExecuteReader();
                lstDefectType.DataTextField = "defect_type";
                lstDefectType.DataValueField = "defect_type";
                lstDefectType.DataBind();
                lstDefectType.Items.Insert(0, new ListItem("Please Select Defect Type", "0"));
            }
        }    
    }

    // Root Cause Option dropdown list
    protected void ddlRootCauseOption()
    { 
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                
                SqlCommand select = new SqlCommand("SELECT id, root_cause FROM dbo.Root_Cause_Option", conn);
                conn.Open();
                
                lstRootCause.DataSource = select.ExecuteReader();
                lstRootCause.DataTextField = "root_cause";
                lstRootCause.DataValueField = "root_cause";
                lstRootCause.DataBind();
                lstRootCause.Items.Insert(0, new ListItem("Please Select Root Cause", "0"));
            }
        }
    }

    // Failure Analysis dropdown list
    protected void ddlFailureAnalysis()
    {
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand select = new SqlCommand("SELECT failure_analysis FROM dbo.SCAR_Failure_Analysis", conn);
                conn.Open();

                lstFailureAnalysis.DataSource = select.ExecuteReader();
                lstFailureAnalysis.DataTextField = "failure_analysis";
                lstFailureAnalysis.DataValueField = "failure_analysis";
                lstFailureAnalysis.DataBind();
                lstFailureAnalysis.Items.Insert(0, new ListItem("Please Select Failure Analysis", "0"));
            }
        }
    }

    protected void ddlDefectCategory()
    {
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {

                SqlCommand select = new SqlCommand("SELECT defect_category FROM dbo.Defect_Category", conn);
                conn.Open();

                lstDefectMode.DataSource = select.ExecuteReader();
                lstDefectMode.DataTextField = "defect_category";
                lstDefectMode.DataValueField = "defect_category";
                lstDefectMode.DataBind();
                lstDefectMode.Items.Insert(0, new ListItem("Please Select Defect Mode", "0"));
            }
        }
    }

    /* Populate Request Form based on existing data */
    protected void Read_Existing_Request_Records(string scar_no)
    {
        btnSaveSec1.Enabled = false;
        btnSubmitSec1.Enabled = false;
        if (!IsPostBack)
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand(@"SELECT scar_no, car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, 
supplier_contact,supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity, 
defect_type, non_conformity_reported, reject_reason, expected_date_close, save_status FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("scar_no", scar_no);
                select.Parameters.AddWithValue("save_status", "submit");
                SqlDataReader reader;
                reader = select.ExecuteReader();

                while(reader.Read())
                {
                    if(Convert.ToString(reader["save_status"]).Equals("save"))
                    {

                    }
                    else if (Convert.ToString(reader["save_status"]).Equals("submit"))
                    {

                    }
                    txtCarNo.Text += Convert.ToString(reader["scar_no"]);
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

    /* Populate Response Form based on existing data */
    protected void Read_Existing_Response_Records(string scar_no)
    {
        if (!IsPostBack)
        {
            
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand(@"SELECT root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, 
s21_containment_action, s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, 
s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, 
s61_permanent_corrective_action, s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, 
s72_implementation_date, s73_responsible_person, s74_verifier, s75_verifier_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, 
status, scar_no FROM dbo.SCAR_Response WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("scar_no", scar_no);
                SqlDataReader reader;
                reader = select.ExecuteReader();

                while (reader.Read())
                {
                    lstRootCause.SelectedValue = Convert.ToString(reader["root_cause_option"]);
                    txtOverallSummary.Text = Convert.ToString(reader["s0_overall_summary"]);
                    txtProbVerification.Text = Convert.ToString(reader["s1_problem_verification"]);
                    rdbProbVerificationStatus.SelectedValue = Convert.ToString(reader["problem_verification_status"]);
                    txtContainmentAction.Text = Convert.ToString(reader["s21_containment_action"]);
                    txtS2ImplementationDate.Text = Convert.ToDateTime(reader["s22_implementation_date"]).ToString("yyyy-MM-dd");
                    txtS2ResponsiblePerson.Text = Convert.ToString(reader["s23_responsible_person"]);
                    txtContainmentResult.Text = Convert.ToString(reader["s24_containment_result"]);

                    string tempScreeningArea = Convert.ToString(reader["screening_area"]);
                    if(tempScreeningArea.Contains("Production"))
                    {
                        lstScreeningArea.Items[0].Selected = true;
                    }
                    if (tempScreeningArea.Contains("FGI"))
                    {
                        lstScreeningArea.Items[1].Selected = true;
                    }
                    if (tempScreeningArea.Contains("Remaining units with customers"))
                    {
                        lstScreeningArea.Items[2].Selected = true;
                    }
                    if (tempScreeningArea.Contains("N/A"))
                    {
                        lstScreeningArea.Items[3].Selected = true;
                    }
                    if (tempScreeningArea.Contains("Units in Field (with other customers)"))
                    {
                        lstScreeningArea.Items[4].Selected = true;
                    }

                    if (Convert.ToInt16(reader["track_containment_action"]) == 1)
                    {
                        chkS2TrackActionItem.Checked = true;
                    }
                    else
                    {
                        chkS2TrackActionItem.Checked = false;
                    }

                    lstFailureAnalysis.SelectedValue = Convert.ToString(reader["s31_failure_analysis"]);
                    txtFailureResult.Text = Convert.ToString(reader["s32_failure_analysis_results"]);
                    txtMan.Text = Convert.ToString(reader["s4_man"]);
                    txtMethod.Text = Convert.ToString(reader["s4_method"]);
                    txtMaterial.Text = Convert.ToString(reader["s4_material"]);
                    txtMachine.Text = Convert.ToString(reader["s4_machine"]);
                    txtCorrectiveAction.Text = Convert.ToString(reader["s51_corrective_action"]);
                    txtS5ImplementationDate.Text = Convert.ToDateTime(reader["s52_implementation_date"]).ToString("yyyy-MM-dd");
                    txtS5ResponsiblePerson.Text = Convert.ToString(reader["s53_responsible_person"]);

                    if (Convert.ToInt16(reader["track_corrective_action"]) == 1)
                    {
                        chkS5TrackActionItem.Checked = true;
                    }
                    else
                    {
                        chkS5TrackActionItem.Checked = false;
                    }

                    txtPermanentCA.Text = Convert.ToString(reader["s61_permanent_corrective_action"]);
                    txtS6ImplementationDate.Text = Convert.ToDateTime(reader["s62_implementation_date"]).ToString("yyyy-MM-dd");
                    txtS6ResponsiblePerson.Text = Convert.ToString(reader["s63_responsible_person"]);

                    if (Convert.ToInt16(reader["track_permanent_corrective_action"]) == 1)
                    {
                        chkS6TrackActionItem.Checked = true;
                    }
                    else
                    {
                        chkS6TrackActionItem.Checked = false;
                    }

                    txtVerifyCA.Text = Convert.ToString(reader["s71_verify_corrective_action_effectiveness"]);
                    txtS7ImplementationDate.Text = Convert.ToDateTime(reader["s72_implementation_date"]).ToString("yyyy-MM-dd");
                    txtS7ResponsiblePerson.Text = Convert.ToString(reader["s73_responsible_person"]);
                    txtVerifier.Text = Convert.ToString(reader["s74_verifier"]);
                    txtVerifierEmail.Text = Convert.ToString(reader["s75_verifier_email"]);
                    txtVerifyCAResult.Text = Convert.ToString(reader["s76_verify_corrective_action_result_effectiveness"]);
                    lstDefectMode.SelectedValue = Convert.ToString(reader["defect_modes"]);

                    if (Convert.ToInt16(reader["mor_calculated"]) == 1)
                    {
                        chkMOR.Checked = true;
                    }
                    else
                    {
                        chkMOR.Checked = false;
                    }
                }
            }
        }
    }

    /* SCAR Request Section */

    // SCAR Request Form Save Button
    protected void Save_Request(object sender, EventArgs e)
    {
        int save_button_click = 0;
        Read_From_Section_1(save_button_click);
    }

    // SCAR Request Form Submit Button
    protected void Submit_Request(object sender, EventArgs e)
    {
        int submit_button_click = 1;
        Read_From_Section_1(submit_button_click); 
    }

    // Read data from Request Form 
    protected void Read_From_Section_1(int clicked_button)
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
            Insert_Request_Into_Database(scar_details, clicked_button); 
        }
             
    }

    // Insert Data from SCAR Request Form into Database 
    protected void Insert_Request_Into_Database(SCAR scar_details, int clicked_button)
    {
        // Establish Connection to Database
        SqlConnection con;
        con = new SqlConnection();
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
            if (clicked_button == 0) // Save button clicked
            {
                if (Check_Duplicate_Data(scar_details, clicked_button) == true) // Checks for duplicate records
                {
                    // If no duplicate records

                    try
                    {
                        // SQL command to insert data into database
                        SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, scar_no, 
            car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
            supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
            defect_type, non_conformity_reported, reject_reason, expected_date_close, save_status, modified_by, last_modified, pending_action, scar_request_method) 
VALUES (@scar_stage, @scar_type, @scar_status, @scar_no, @car_revision, @car_type, @pre_alert,@related_car_no, @related_car_ref, @originator, @recurrence, 
@supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description, @business_unit, @dept_pl, @commodity, 
@defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close, @save_status, @modified_by, @last_modified, @pending_action, @scar_request_method)", con);

                        DateTime currentDateTime = DateTime.Now;

                        addSite.Parameters.AddWithValue("@scar_stage", "New SCAR");
                        addSite.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
                        addSite.Parameters.AddWithValue("@scar_status", "Pending");
                        addSite.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
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
                        addSite.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);                        
                        addSite.Parameters.AddWithValue("@last_modified", currentDateTime);
                        addSite.Parameters.AddWithValue("@pending_action", "Awaiting SCAR Request Submission");
                        addSite.Parameters.AddWithValue("@scar_request_method", "manual");
                        addSite.ExecuteNonQuery();

                        string message = "SCAR Request for : " + scar_details.Car_no  + " has been saved!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                    }
                    catch (Exception err)
                    {
                        string message = "SCAR Request for : " + scar_details.Car_no + " cannot be saved! Please try again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    // If there is duplicate records
                    try
                    {
                        SqlCommand select = new SqlCommand("SELECT scar_no, car_revision, issued_date, save_status FROM dbo.SCAR_Request", con);
                        SqlDataReader reader;
                        bool process_submit = false;
                        reader = select.ExecuteReader();
                        while (reader.Read())
                        {
                            if (scar_details.Car_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "save")
                            {
                                SqlCommand update_data = new SqlCommand(@"UPDATE TABLE dbo.SCAR_Request SET scar_no = @scar_no, car_revision = @car_revision, 
car_type = @car_type, pre_alert = @pre_alert, related_car_no = @related_car_no, related_car_rev = @related_car_rev, originator = @originator, recurrence = @recurrence, 
supplier_contact = @supplier_contact, supplier_email = @supplier_email, issued_date = @issued_date, originator_dept = @originator_dept, originator_contact = @originator_contact, 
part_no = @part_no, part_description = @part_description, business_unit = @business_unit, dept_pl = @dept_pl, commodity = @commodity, defect_quantity = @defect_quantity, 
defect_type = @defect_type, non_conformity_reported = @non_conformity_reported, reject_reason = @reject_reason, expected_date_close = @expected_date_close, 
save_status = @save_status, modified_by = @modified_by, last_modified = @last_modified", con);

                                DateTime currentDateTime = DateTime.Now;
                                update_data.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
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
                                update_data.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                                update_data.Parameters.AddWithValue("@last_modified", currentDateTime);
                                update_data.ExecuteNonQuery();

                                string message = "SCAR Request for : " + scar_details.Car_no + " has been updated!";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                                process_submit = true;
                            }
                        }
                        if (!process_submit)
                        {
                            string message = "SCAR Request for : " + scar_details.Car_no + " has NOT been updated! Please Try Again!";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                        }
                    }
                    catch (Exception err)
                    {
                        string message = "SCAR Request for : " + scar_details.Car_no + " has NOT been updated! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else if (clicked_button == 1) // Submit button clicked
            {
                if (Check_Duplicate_Data(scar_details, clicked_button) == true) // Checks for duplicate records
                {
                    // If there is no duplicate records
                    try
                    {
                        // SQL command to insert data into database
                        SqlCommand addSite = new SqlCommand(@"INSERT INTO dbo.SCAR_Request (scar_stage, scar_type, scar_status, scar_no, 
            car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, supplier_contact,
            supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity,
            defect_type, non_conformity_reported, reject_reason, expected_date_close, save_status, modified_by, last_modified, pending_action, scar_request_method) 
VALUES (@scar_stage, @scar_type, @scar_status, @scar_no, @car_revision, @car_type, @pre_alert,@related_car_no, @related_car_ref, @originator, @recurrence, 
@supplier_contact, @supplier_email, @issued_date, @originator_dept, @originator_contact, @part_no, @part_description, @business_unit, @dept_pl, @commodity, 
@defect_quantity, @defect_type, @non_conformity_reported, @reject_reason, @expected_date_close, @save_status, @modified_by, @last_modified, @pending_action, @scar_request_method)", con);

                        DateTime currentDateTime = DateTime.Now;

                        addSite.Parameters.AddWithValue("@scar_stage", "New SCAR");
                        addSite.Parameters.AddWithValue("@scar_type", "SCAR Type 2");
                        addSite.Parameters.AddWithValue("@scar_status", "Pending");
                        addSite.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
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
                        addSite.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);                        
                        addSite.Parameters.AddWithValue("@last_modified", currentDateTime);
                        addSite.Parameters.AddWithValue("@pending_action", "Awaiting SCAR Response Submission");
                        addSite.Parameters.AddWithValue("@scar_request_method", "manual");
                        addSite.ExecuteNonQuery();

                        string message = "SCAR Request for : " + scar_details.Car_no + " is successful!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                    }
                    catch (Exception err)
                    {
                        string message = "SCAR Request for : " + scar_details.Car_no + " is not successful! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else 
                {
                    // If there is duplicate records
                    try
                    {
                        SqlCommand select = new SqlCommand("SELECT scar_no, car_revision, issued_date, save_status FROM dbo.SCAR_Request", con);
                        SqlDataReader reader;
                        bool process_submit = false;
                        reader = select.ExecuteReader();
                        while (reader.Read())
                        {
                            if (scar_details.Car_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "save")
                            {
                                SqlCommand update_data = new SqlCommand(@"UPDATE TABLE dbo.SCAR_Request SET scar_no = @scar_no, car_revision = @car_revision, 
car_type = @car_type, pre_alert = @pre_alert, related_car_no = @related_car_no, related_car_rev = @related_car_rev, originator = @originator, recurrence = @recurrence, 
supplier_contact = @supplier_contact, supplier_email = @supplier_email, issued_date = @issued_date, originator_dept = @originator_dept, originator_contact = @originator_contact, 
part_no = @part_no, part_description = @part_description, business_unit = @business_unit, dept_pl = @dept_pl, commodity = @commodity, defect_quantity = @defect_quantity, 
defect_type = @defect_type, non_conformity_reported = @non_conformity_reported, reject_reason = @reject_reason, expected_date_close = @expected_date_close, 
save_status = @save_status, modified_by = @modified_by, last_modified = @last_modified, pending_action = @pending_action", con);

                                DateTime currentDateTime = DateTime.Now;
                                update_data.Parameters.AddWithValue("@scar_no", scar_details.Car_no);
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
                                update_data.Parameters.AddWithValue("@pending_action", "Awaiting SCAR Response Submission");
                                update_data.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                                update_data.Parameters.AddWithValue("@last_modified", currentDateTime);
                                update_data.ExecuteNonQuery();

                                string message = "SCAR Request for : " + scar_details.Car_no + " is successful!";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                                process_submit = true;
                            }
                        }
                        if (!process_submit)
                        {
                            string message = "SCAR Request is not successful! " + scar_details.Car_no + " already exists!";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
                        }
                    }
                    catch (Exception err)
                    {
                        string message = "SCAR Request for : " + scar_details.Car_no + " is not successful! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_details.Car_no + "', '" + message + "')", true);
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
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();
        SqlCommand select = new SqlCommand("SELECT scar_no, car_revision, issued_date, save_status FROM dbo.SCAR_Request", con);
        SqlDataReader reader;
        bool compare_data = true;
        reader = select.ExecuteReader();
        while (reader.Read())
        {
            if (scar_details.Car_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "save")
            {
                compare_data = false;
            }
            else if (scar_details.Car_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0 && scar_details.Car_revision.CompareTo(Convert.ToString(reader["car_revision"])) == 0 && scar_details.Issued_date.CompareTo(Convert.ToString(reader["issued_date"])) == 0 && Convert.ToString(reader["save_status"]) == "submit")
            {
                compare_data = false;
            } 
        }
        return compare_data;
    }
    /* End of Section 1 */

    /* SCAR Response Section */

    // SCAR Response Form Save button
    protected void Save_Response(object sender, EventArgs e)
    {
        int save_response_button_click = 0;
        Read_From_Response_Form(save_response_button_click); 
    }

    // SCAR Response Form Submit button
    protected void Submit_Response(object sender, EventArgs e)
    {
        int submit_response_button_click = 1;
        Read_From_Response_Form(submit_response_button_click);
    }

    protected bool Validate_Response_Form()
    {
        string scar_no = Request.QueryString["scar_no"];
        //Read_Existing_Response_Records(scar_id);
        SCAR_Response scar_response_details = new SCAR_Response();
        bool checkEmptyFields = true;

        /* Validation on text fields */
        if (!string.IsNullOrEmpty(lstRootCause.Text)) // Root Cause
        {
            scar_response_details.Root_cause_option = lstRootCause.Text;
        }
        else
        {
            lblRootCause.Text += "You must select a Root Cause Option!";
            lblRootCause.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtOverallSummary.Text)) // Overall Summary
        {
            scar_response_details.Overall_summary = txtOverallSummary.Text;
        }
        else
        {
            lblOverallSummary.Text += "You must enter the Overall Summary or N/A if none!";
            lblOverallSummary.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtProbVerification.Text)) // Problem Verification
        {
            scar_response_details.Problem_verification = txtProbVerification.Text;
        }
        else
        {
            lblProbVerification.Text += "You must enter the Problem Verification or N/A if none!";
            lblProbVerification.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(rdbProbVerificationStatus.Text)) // Problem Verification Status
        {
            scar_response_details.Problem_verification_status = rdbProbVerificationStatus.Text;
        }
        else
        {
            lblProbVerificationStatus.Text += "You must select the Problem Verification Status or N/A if none!";
            lblProbVerificationStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }

        /* Section 2 */
        if (!string.IsNullOrEmpty(txtContainmentAction.Text)) // Containment Action
        {
            scar_response_details.S21_containment_action = txtContainmentAction.Text;
        }
        else
        {
            lblContainmentAction.Text += "You must enter the Containment Action or N/A if none!";
            lblContainmentAction.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS2ImplementationDate.Text)) // Containment Action Implementation Date
        {
            scar_response_details.S22_implementation_date = txtS2ImplementationDate.Text;
        }
        else
        {
            lblS2ImplementationDate.Text += "You must select the Implementation Date!";
            lblS2ImplementationDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS2ResponsiblePerson.Text)) // Containment Action Responsible Person
        {
            scar_response_details.S23_responsible_person = txtS2ResponsiblePerson.Text;
        }
        else
        {
            lblS2ResponsiblePerson.Text += "You must enter the Responsible Person or N/A if none!";
            lblS2ResponsiblePerson.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtContainmentResult.Text)) // Containment Action Result
        {
            scar_response_details.S24_containment_result = txtContainmentResult.Text;
        }
        else
        {
            lblContainmentResult.Text += "You must enter the Containment Result or N/A if none!";
            lblContainmentResult.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(lstScreeningArea.Text)) // Screening Area
        {
            int size = lstScreeningArea.GetSelectedIndices().Count();
            string[] screening_area = new string[size];
            int count = 0;
            foreach (int i in lstScreeningArea.GetSelectedIndices())
            {
                screening_area[count] = Convert.ToString(lstScreeningArea.Items[i]);
                scar_response_details.Screening_area += screening_area[count];
                count++;
            }
        }
        else
        {
            lblScreeningArea.Text += "You must select the Screening Area or N/A if none!";
            lblScreeningArea.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
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
            lblFailureAnalysis.Text += "You must enter the Failure Analysis or N/A if none!";
            lblFailureAnalysis.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtFailureResult.Text)) // Failure Analysis Result
        {
            scar_response_details.S32_failure_analysis_results = txtFailureResult.Text;
        }
        else
        {
            lblFailureResult.Text += "You must select the Failure Analysis Result!";
            lblFailureResult.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
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
            lblMan.Text += "You must enter the Root Cause (Man) or N/A if none!";
            lblMan.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtMachine.Text)) // Machine
        {
            scar_response_details.Machine = txtMachine.Text;
        }
        else
        {
            lblMachine.Text += "You must enter the Root Cause (Machine) or N/A if none!";
            lblMachine.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtMethod.Text)) // Method
        {
            scar_response_details.Method = txtMethod.Text;
        }
        else
        {
            lblMethod.Text += "You must enter the Root Cause (Method) or N/A if none!";
            lblMethod.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtMaterial.Text)) // Material
        {
            scar_response_details.Material = txtMaterial.Text;
        }
        else
        {
            lblMaterial.Text += "You must enter the Root Cause (Material) or N/A if none!";
            lblMaterial.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
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
            lblCorrectiveAction.Text += "You must enter the Corrective Action or N/A if none!";
            lblCorrectiveAction.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS5ImplementationDate.Text)) // Corrective Action Implementation Date
        {
            scar_response_details.S52_implementation_date = txtS5ImplementationDate.Text;
        }
        else
        {
            lblS5ImplementationDate.Text += "You must select the Implementation Date!";
            lblS5ImplementationDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS5ResponsiblePerson.Text)) // Corrective Action Responsible Person
        {
            scar_response_details.S53_responsible_person = txtS5ResponsiblePerson.Text;
        }
        else
        {
            lblS5ResponsiblePerson.Text += "You must enter the Overall Summary or N/A if none!";
            lblS5ResponsiblePerson.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
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
            lblPermanentCA.Text += "You must enter the Permanent Corrective Action or N/A if none!";
            lblPermanentCA.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS6ImplementationDate.Text)) // Permanent Corrective Action Implementation Date
        {
            scar_response_details.S62_implementation_date = txtS6ImplementationDate.Text;
        }
        else
        {
            lblS6ImplementationDate.Text += "You must select the Implementation Date!";
            lblS6ImplementationDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS6ResponsiblePerson.Text)) // Permanent Corrective Action Responsible Person
        {
            scar_response_details.S63_responsible_person = txtS6ResponsiblePerson.Text;
        }
        else
        {
            lblS6ResponsiblePerson.Text += "You must enter the Responsible Person or N/A if none!";
            lblS6ResponsiblePerson.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
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
            lblVerifyCA.Text += "You must enter the Verify Effectiveness of Corrective Actions or N/A if none!";
            lblVerifyCA.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS7ImplementationDate.Text)) // Verify Effectiveness of Corrective Action Implementation Date
        {
            scar_response_details.S72_implementation_date = txtS7ImplementationDate.Text;
        }
        else
        {
            lblS7ImplementationDate.Text += "You must select the Implementation Date!";
            lblS7ImplementationDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtS7ResponsiblePerson.Text)) // Verify Effectiveness of Corrective Action Responsible Person
        {
            scar_response_details.S73_responsible_person = txtS7ResponsiblePerson.Text;
        }
        else
        {
            lblS7ResponsiblePerson.Text += "You must enter the Responsible Person or N/A if none!";
            lblS7ResponsiblePerson.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtVerifier.Text)) // Verify Effectiveness of Corrective Action Verifier
        {
            scar_response_details.S74_verifier = txtVerifier.Text;
        }
        else
        {
            lblVerifier.Text += "You must enter the Verifier or N/A if none!";
            lblVerifier.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }
        if (!string.IsNullOrEmpty(txtVerifierEmail.Text)) // Verify Effectiveness of Corrective Action Verifier Email
        {
            scar_response_details.S75_verifier_email = txtVerifierEmail.Text;
        }
        else
        {
            lblVerifierEmail.Text += "You must enter the Verifier Email or N/A if none!";
            lblVerifierEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }

        if(!String.IsNullOrEmpty(scar_no))
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand("SELECT scar_status FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("@scar_no", scar_no);
                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["scar_status"]).Equals("SCAR Type 2 Accepted"))
                    {
                        if (!string.IsNullOrEmpty(txtVerifyCAResult.Text)) // Verify Effectiveness of Corrective Action Result
                        {
                            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = txtVerifyCAResult.Text;
                        }
                        else
                        {
                            lblVerifyCAResult.Text += "You must enter the Verify Effectiveness of Corrective Actions Results or N/A if none!";
                            lblVerifyCAResult.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                            checkEmptyFields = false;
                        }
                    }
                    else
                    {
                        scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = "N/A";
                    }
                }
            }

        }

        /* End of Section 7 */

        if (!string.IsNullOrEmpty(lstDefectMode.Text)) // Defect Mode
        {
            scar_response_details.Defect_mode = lstDefectMode.Text;
        }
        else
        {
            lblDefectMode.Text += "You must select the Defect Mode!";
            lblDefectMode.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            checkEmptyFields = false;
        }

        //scar_response_details.Require_8D_approval = chk8Dapproval.Checked; // Require 8D Approval
        scar_response_details.MOR_Calculated = chkMOR.Checked; // MOR Calculated

        if (checkEmptyFields)
        {
            return true;
        }
        else
        {
            ProcessedMessage.Text += "Please fill in the Required Fields!";
            ProcessedMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            return false;
        }
    }

    // Read data from Response Form 
    protected void Read_From_Response_Form(int response_clicked_button)
    {
        SCAR_Response scar_response_details = new SCAR_Response();
        string scar_no = Request.QueryString["scar_no"];
        if (!string.IsNullOrEmpty(lstRootCause.Text)) // Root Cause
        {
            scar_response_details.Root_cause_option = lstRootCause.Text;
        }
        else
        {
            scar_response_details.Root_cause_option = "Please Select Root Cause";
        }
        if (!string.IsNullOrEmpty(txtOverallSummary.Text)) // Overall Summary
        {
            scar_response_details.Overall_summary = txtOverallSummary.Text;
        }
        else
        {
            scar_response_details.Overall_summary = "N/A";
        }
        if (!string.IsNullOrEmpty(txtProbVerification.Text)) // Problem Verification
        {
            scar_response_details.Problem_verification = txtProbVerification.Text;
        }
        else
        {
            scar_response_details.Problem_verification = "N/A";
        }
        if (!string.IsNullOrEmpty(rdbProbVerificationStatus.Text)) // Problem Verification Status
        {
            scar_response_details.Problem_verification_status = rdbProbVerificationStatus.Text;
        }
        else
        {
            scar_response_details.Problem_verification_status ="N/A";
        }

        /* Section 2 */
        if (!string.IsNullOrEmpty(txtContainmentAction.Text)) // Containment Action
        {
            scar_response_details.S21_containment_action = txtContainmentAction.Text;
        }
        else
        {
            scar_response_details.S21_containment_action = "N/A";
        }
        if (!string.IsNullOrEmpty(txtS2ImplementationDate.Text)) // Containment Action Implementation Date
        {
            scar_response_details.S22_implementation_date = txtS2ImplementationDate.Text;
        }
        else
        {
            scar_response_details.S22_implementation_date = Convert.ToString(DBNull.Value);
        }
        if (!string.IsNullOrEmpty(txtS2ResponsiblePerson.Text)) // Containment Action Responsible Person
        {
            scar_response_details.S23_responsible_person = txtS2ResponsiblePerson.Text;
        }
        else
        {
            scar_response_details.S23_responsible_person = "N/A";
        }
        if (!string.IsNullOrEmpty(txtContainmentResult.Text)) // Containment Action Result
        {
            scar_response_details.S24_containment_result = txtContainmentResult.Text;
        }
        else
        {
            scar_response_details.S24_containment_result = "N/A";
        }
        if (!string.IsNullOrEmpty(lstScreeningArea.Text)) // Screening Area
        {
            int size = lstScreeningArea.GetSelectedIndices().Count();
            string[] screening_area = new string[size];
            int count = 0;
            foreach (int i in lstScreeningArea.GetSelectedIndices())
            {
                screening_area[count] = Convert.ToString(lstScreeningArea.Items[i]);
                scar_response_details.Screening_area += screening_area[count];
                count++;
            }
        }
        else
        {
            scar_response_details.Screening_area = "N/A";
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
            scar_response_details.S31_failure_analysis = "N/A";
        }
        if (!string.IsNullOrEmpty(txtFailureResult.Text)) // Failure Analysis Result
        {
            scar_response_details.S32_failure_analysis_results = txtFailureResult.Text;
        }
        else
        {
            scar_response_details.S32_failure_analysis_results = "N/A";
        }
        /* End of Section 3 */

        /* Section 4 */

        if (!string.IsNullOrEmpty(txtMan.Text)) // Man
        {
            scar_response_details.Man = txtMan.Text;
        }
        else
        {
            scar_response_details.Man = "N/A";
        }
        if (!string.IsNullOrEmpty(txtMachine.Text)) // Machine
        {
            scar_response_details.Machine = txtMachine.Text;
        }
        else
        {
            scar_response_details.Machine = "N/A";
        }
        if (!string.IsNullOrEmpty(txtMethod.Text)) // Method
        {
            scar_response_details.Method = txtMethod.Text;
        }
        else
        {
            scar_response_details.Method = "N/A";
        }
        if (!string.IsNullOrEmpty(txtMaterial.Text)) // Material
        {
            scar_response_details.Material = txtMaterial.Text;
        }
        else
        {
            scar_response_details.Material = "N/A";
        }
        /* End of Section 4 */

        /* Section 5 */

        if (!string.IsNullOrEmpty(txtCorrectiveAction.Text)) // Corrective Action
        {
            scar_response_details.S51_corrective_action = txtCorrectiveAction.Text;
        }
        else
        {
            scar_response_details.S51_corrective_action = "N/A";
        }
        if (!string.IsNullOrEmpty(txtS5ImplementationDate.Text)) // Corrective Action Implementation Date
        {
            scar_response_details.S52_implementation_date = txtS5ImplementationDate.Text;
        }
        else
        {
            scar_response_details.S52_implementation_date = Convert.ToString(DBNull.Value);
        }
        if (!string.IsNullOrEmpty(txtS5ResponsiblePerson.Text)) // Corrective Action Responsible Person
        {
            scar_response_details.S53_responsible_person = txtS5ResponsiblePerson.Text;
        }
        else
        {
            scar_response_details.S53_responsible_person = "N/A";
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
            scar_response_details.S61_permanent_corrective_action = "N/A";
        }
        if (!string.IsNullOrEmpty(txtS6ImplementationDate.Text)) // Permanent Corrective Action Implementation Date
        {
            scar_response_details.S62_implementation_date = txtS6ImplementationDate.Text;
        }
        else
        {
            scar_response_details.S62_implementation_date = Convert.ToString(DBNull.Value);
        }
        if (!string.IsNullOrEmpty(txtS6ResponsiblePerson.Text)) // Permanent Corrective Action Responsible Person
        {
            scar_response_details.S63_responsible_person = txtS6ResponsiblePerson.Text;
        }
        else
        {
            scar_response_details.S63_responsible_person = "N/A";
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
            scar_response_details.S71_verify_effectiveness_of_corrective_actions = "N/A";
        }
        if (!string.IsNullOrEmpty(txtS7ImplementationDate.Text)) // Verify Effectiveness of Corrective Action Implementation Date
        {
            scar_response_details.S72_implementation_date = txtS7ImplementationDate.Text;
        }
        else
        {
            scar_response_details.S72_implementation_date = Convert.ToString(DBNull.Value);
        }
        if (!string.IsNullOrEmpty(txtS7ResponsiblePerson.Text)) // Verify Effectiveness of Corrective Action Responsible Person
        {
            scar_response_details.S73_responsible_person = txtS7ResponsiblePerson.Text;
        }
        else
        {
            scar_response_details.S73_responsible_person = "N/A";
        }
        if (!string.IsNullOrEmpty(txtVerifier.Text)) // Verify Effectiveness of Corrective Action Verifier
        {
            scar_response_details.S74_verifier = txtVerifier.Text;
        }
        else
        {
            scar_response_details.S74_verifier = "N/A";
        }
        if (!string.IsNullOrEmpty(txtVerifierEmail.Text)) // Verify Effectiveness of Corrective Action Verifier Email
        {
            scar_response_details.S75_verifier_email = txtVerifierEmail.Text;
        }
        else
        {
            scar_response_details.S75_verifier_email = "N/A";
        }

        if (!String.IsNullOrEmpty(scar_no))
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand("SELECT scar_status FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("@scar_no", scar_no);
                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["scar_status"]).Equals("SCAR Type 2 Accepted"))
                    {
                        if (!string.IsNullOrEmpty(txtVerifyCAResult.Text)) // Verify Effectiveness of Corrective Action Result
                        {
                            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = txtVerifyCAResult.Text;
                        }
                        else
                        {
                            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = "N/A";
                        }
                    }
                    else
                    {
                        scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = "N/A";
                    }
                }
            }

        }
        else
        {
            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = "N/A"; 
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
        if(!String.IsNullOrEmpty(scar_no))
        {
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand("SELECT scar_status FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("@scar_no", scar_no);
                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToString(reader["scar_status"]).Equals("SCAR Type 2 Accepted"))
                    {
                        if (!string.IsNullOrEmpty(txtVerifyCAResult.Text)) // Verify Effectiveness of Corrective Action Result
                        {
                            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = txtVerifyCAResult.Text;
                        }
                    }
                    else
                    {
                        scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = "N/A";
                    }
                }
            }
        }
        else
        {
            scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = "N/A";
        }

        /* End of Section 7 */
        scar_response_details.Defect_mode = lstDefectMode.Text;
        //scar_response_details.Require_8D_approval = chk8Dapproval.Checked; // Require 8D Approval
        scar_response_details.MOR_Calculated = chkMOR.Checked; // MOR Calculated

        if (response_clicked_button == 1)
        {
            bool checkValidation = Validate_Response_Form();
            if (checkValidation)
            {
                Insert_Into_Response_Database(scar_response_details, response_clicked_button);
            }
        }
        else if (response_clicked_button == 0)
        {
            Insert_Into_Response_Database(scar_response_details, response_clicked_button);
        }    
    }

    // Upload attachments
    protected void Upload_Files()
    {
        if(uploadFile.HasFile)
        {
            string scar_no = Request.QueryString["scar_no"];
            try
            {
                foreach (HttpPostedFile postedFile in uploadFile.PostedFiles)
                {
                    var disallowedExtensions = new[] { ".txt", ".msi" };
                    var extension = Path.GetExtension(postedFile.FileName);
                    string filename = Path.GetFileName(postedFile.FileName);
                    string filename_withoutextension = Path.GetFileNameWithoutExtension(postedFile.FileName);
                    string contentType = postedFile.ContentType;
                    
                    if(!filename.Contains(scar_no))
                    {
                        filename = filename_withoutextension + "_" + scar_no + extension;
                    }

                    if (!disallowedExtensions.Contains(extension))
                    {
                        using (Stream fs = postedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                uploadFile.PostedFile.SaveAs(Server.MapPath(@"~\Attachments\" + filename.Trim()));
                                string path = @"~\Attachments\" + filename.Trim();
                                //byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                string constr = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
                                using (SqlConnection con = new SqlConnection(constr))
                                {
                                    con.Open();
                                    SqlCommand insert = new SqlCommand(@"INSERT INTO SCAR_attachments (file_name, file_type, file_path, scar_no) VALUES 
(@Name, @ContentType, @File_path, @id)", con);
                                    insert.Parameters.AddWithValue("@Name", filename);
                                    insert.Parameters.AddWithValue("@ContentType", contentType);
                                    insert.Parameters.AddWithValue("@File_path", path);
                                    insert.Parameters.AddWithValue("@id", scar_no);
                                    insert.ExecuteNonQuery();
                                    string message = "Your files have been uploaded succesfully!";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                                    con.Close();

                                }
                            }
                        }
                    }
                    else
                    {
                        string message = ".exe and .msi files are not allowed! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);

                    }
                }

            }
            catch (Exception err)
            {
                string message = "Unable to upload files! Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
            }
            finally
            {

            }
        }
        
    }

    // Insert data from Response form into database
    protected void Insert_Into_Response_Database(SCAR_Response scar_response_details, int response_clicked_button)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        if(response_clicked_button == 0)
        {
            if(Check_Duplicate_Response_Data(scar_response_details) == true)
            {
                string scar_no = Request.QueryString["scar_no"];
                try
                {
                    // SQL command to insert data into database
                    SqlCommand addResponse = new SqlCommand(@"INSERT INTO dbo.SCAR_Response (root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, 
s21_containment_action, s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, 
s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, 
s61_permanent_corrective_action, s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, 
s72_implementation_date, s73_responsible_person, s74_verifier, s75_verifier_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, status, scar_no) 
VALUES (@root_cause_option, @overall_summary, @problem_verification, @problem_verification_status, @s21_containment_action, @s22_implementation_date, @s23_responsible_person, 
@s24_containment_result, @screening_area, @track_containment_action, @s31_failure_analysis, @s32_failure_analysis_results, @s4_man, @s4_method, @s4_material, @s4_machine, 
@s51_corrective_action, @s52_implementation_date, @s53_responsible_person, @track_corrective_action, @s61_permanent_corrective_action, @s62_implementation_date, 
@s63_responsible_person, @track_permanent_corrective_action, @s71_verify_corrective_action_effectiveness, @s72_implementation_date, @s73_responsible_person, @s74_verifier,
@s75_verifier_email, @s76_verify_corrective_action_result_effectiveness, @defect_modes, @mor_calculated, @status, @scar_no)", con);

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
                    addResponse.Parameters.AddWithValue("@scar_no", scar_no);

                    addResponse.ExecuteNonQuery();

                    try
                    {
                        SqlCommand update_request = new SqlCommand(@"UPDATE dbo.SCAR_Request SET scar_stage = @scar_stage, modified_by = @modified_by, last_modified = @last_modified, 
pending_action = @pending_action WHERE scar_no = @scar_no", con);

                        update_request.Parameters.AddWithValue("@scar_no", scar_no);
                        update_request.Parameters.AddWithValue("@scar_stage", "Pending SCAR");
                        update_request.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                        DateTime currentDateTime = DateTime.Now;
                        update_request.Parameters.AddWithValue("@last_modified", currentDateTime);
                        update_request.Parameters.AddWithValue("@pending_action", "Awaiting SCAR Response Submission");

                        update_request.ExecuteNonQuery();

                        string message = "SCAR Response for : " + scar_no + " has been saved!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                    }
                    catch(Exception er)
                    {
                        
                    }
                }
                catch (Exception err)
                {
                    string message = "SCAR Response for : " + scar_no + " cannot be saved! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                }
                finally
                {
                    con.Close();
                    Upload_Files();
                    Request_Approval();         
                }
            }
            else
            {
                string scar_no = Request.QueryString["scar_no"];
                    try
                    {
                        
                        bool exist_data = false;
                        SqlCommand select = new SqlCommand("SELECT scar_no, status FROM dbo.SCAR_Response", con);
                        SqlDataReader reader;
                        reader = select.ExecuteReader();
                        while (reader.Read())
                        {
                            if (scar_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0)
                            {
                                exist_data = true;
                            }
                        }
                        reader.Close();
                        if (exist_data)
                        {
                            SqlCommand update_response = new SqlCommand(@"UPDATE dbo.SCAR_Response SET root_cause_option = @root_cause_option, 
s0_overall_summary = @overall_summary, s1_problem_verification = @problem_verification, problem_verification_status = @problem_verification_status,
s21_containment_action = @s21_containment_action, s22_implementation_date = @s22_implementation_date, s23_responsible_person = @s23_responsible_person, 
s24_containment_result = @s24_containment_result, screening_area = @screening_area, track_containment_action = @track_containment_action, 
s31_failure_analysis = @s31_failure_analysis, s32_failure_analysis_results = @s32_failure_analysis_results, s4_man = @s4_man, s4_method = @s4_method, 
s4_material = @s4_material, s4_machine = @s4_machine, s51_corrective_action = @s51_corrective_action, s52_implementation_date = @s52_implementation_date,
s53_responsible_person = @s53_responsible_person, track_corrective_action = @track_corrective_action, s61_permanent_corrective_action = @s61_permanent_corrective_action, 
s62_implementation_date = @s62_implementation_date, s63_responsible_person = @s63_responsible_person, track_permanent_corrective_action = @track_permanent_corrective_action, 
s71_verify_corrective_action_effectiveness = @s71_verify_corrective_action_effectiveness, s72_implementation_date = @s72_implementation_date,
s73_responsible_person = @s73_responsible_person, s74_verifier = @s74_verifier, s75_verifier_email = @s75_verifier_email, 
s76_verify_corrective_action_result_effectiveness = @s76_verify_corrective_action_result_effectiveness, defect_modes = @defect_modes, 
mor_calculated = @mor_calculated WHERE scar_no = @scar_no", con);

                            update_response.Parameters.AddWithValue("@scar_no", scar_no);
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

                            try
                            {
                                SqlCommand update_request = new SqlCommand(@"UPDATE dbo.SCAR_Request SET modified_by = @modified_by, last_modified = @last_modified, pending_action = @pending_action
WHERE scar_no = @scar_no", con);

                                update_request.Parameters.AddWithValue("@scar_no", scar_no);
                                update_request.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                                DateTime currentDateTime = DateTime.Now;
                                update_request.Parameters.AddWithValue("@last_modified", currentDateTime);
                                update_request.Parameters.AddWithValue("@pending_action", "Awaiting SCAR Response Submission");

                                update_request.ExecuteNonQuery();
                            }
                            catch (Exception er)
                            {

                            }

                            string message = "SCAR Response for : " + scar_no + " has been updated!";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                        }
                    }
                    catch (Exception err)
                    {
                        string message = "SCAR Response for : " + scar_no + " has NOT been updated! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                    }
                    finally
                    {
                        con.Close();
                        Upload_Files();
                        Request_Approval();         
                    }  
                }
            
        }
        else if (response_clicked_button == 1)
        {
            string scar_no = Request.QueryString["scar_no"];
            Parse_Data_Into_Notepad(scar_no);
        }
    }

    // Check for existing SCAR Response records
    protected bool Check_Duplicate_Response_Data(SCAR_Response scar_response_details)
    {
        SqlConnection con;
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        con.Open();

        string scar_no = Request.QueryString["scar_no"];
        SqlCommand select = new SqlCommand("SELECT scar_no, status FROM dbo.SCAR_Response", con);
        SqlDataReader reader;
        bool compare_data = true;
        reader = select.ExecuteReader();
        while (reader.Read())
        {
            if (scar_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0 && Convert.ToString(reader["status"]).Equals("save"))
            {
                compare_data = false;
            }
            else if(scar_no.CompareTo(Convert.ToString(reader["scar_no"])) == 0 && Convert.ToString(reader["status"]).Equals("submit"))
            {
                compare_data = false;
            }
            else
            {
                compare_data = true;
            }
        }
        return compare_data;
    }

    // Request 8D Approval from Managers
    protected void Request_Approval()
    {
        string scar_no = Request.QueryString["scar_no"];
        if(chk8Dapproval.Checked)
        {
            // Checks if both dropdown list has been selected
            if (lstWCM.SelectedItem.Text.Equals(Convert.ToString("Please Select WCM")) || lstQM.SelectedItem.Text.Equals(Convert.ToString("Please Select QM")))
            {
                string message = "Please Select Respective QM / WCM"; ;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
            }
            else if (lstWCM.SelectedItem.Value != Convert.ToString(0) && lstQM.SelectedItem.Value != Convert.ToString(0))
            {
                // Establish Connection to Database
                SqlConnection con;
                con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
                con.Open();

                Employee WCM_details = new Employee();
                Employee QM_details = new Employee();
                EmailContent email_details = new EmailContent();

                WCM_details.Employee_name = lstWCM.SelectedItem.Text;
                WCM_details.Employee_ID = lstWCM.SelectedItem.Value;
                QM_details.Employee_name = lstQM.SelectedItem.Text;
                QM_details.Employee_ID = lstQM.SelectedItem.Value;

                SqlCommand select = new SqlCommand("SELECT employee_ID, employee_name, employee_email, employee_position FROM dbo.Employee", con);
                SqlDataReader reader;
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    // Gets WCM data
                    if (!WCM_details.Employee_name.Equals("N/A"))
                    {
                        if (WCM_details.Employee_name.CompareTo(reader["employee_name"]) == 0 && WCM_details.Employee_ID.CompareTo(reader["employee_ID"]) == 0)
                        {
                            WCM_details.Employee_email = Convert.ToString(reader["employee_email"]);
                        }
                        else
                        {
                            WCM_details.Employee_email = "N/A";
                        }
                    }

                    // Gets QM data
                    if (!QM_details.Employee_name.Equals("N/A"))
                    {
                        if (QM_details.Employee_name.CompareTo(reader["employee_name"]) == 0 && QM_details.Employee_ID.CompareTo(reader["employee_ID"]) == 0)
                        {
                            QM_details.Employee_email = Convert.ToString(reader["employee_email"]);
                        }
                        else
                        {
                            QM_details.Employee_email = "N/A";
                        }
                    }
                }
                reader.Close();

                try
                {
                    // Stores notice in database
                    string currentDateTime = DateTime.Now.ToString();
                    string noticeBody = "You have a pending 8D Approval Request - " + scar_no + " by " + JabilSession.Current.employee_name + ". Click link to view SCAR!<br/> <a href='8DApproval.aspx?scar_no=" + scar_no + "'>View SCAR</a> ";
                    SqlCommand addNoticeWCM = new SqlCommand(@"INSERT INTO dbo.Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) 
VALUES (@hash, @Notice_From, @Notice_To, @Notice_Subject, @Notice_Body, @Notice_Timestamp, @Read_Status)", con);
                    string hashWCM = WCM_details.Employee_name + scar_no + noticeBody;
                    hashWCM = Encryptor.MD5HASH(hashWCM);
                    addNoticeWCM.Parameters.AddWithValue("@hash", hashWCM);
                    addNoticeWCM.Parameters.AddWithValue("@Notice_From", JabilSession.Current.employee_name);
                    addNoticeWCM.Parameters.AddWithValue("@Notice_To", WCM_details.Employee_name);
                    addNoticeWCM.Parameters.AddWithValue("@Notice_Subject", "8D Approval Request");
                    addNoticeWCM.Parameters.AddWithValue("@Notice_Body", noticeBody);
                    addNoticeWCM.Parameters.AddWithValue("@Notice_TimeStamp",currentDateTime);
                    addNoticeWCM.Parameters.AddWithValue("@Read_Status", "False");
                    addNoticeWCM.ExecuteNonQuery();

                    SqlCommand addNoticeQM = new SqlCommand(@"INSERT INTO dbo.Notice (hash, Notice_From, Notice_To, Notice_Subject, Notice_Body, Notice_Timestamp, Read_Status) 
VALUES (@hash, @Notice_From, @Notice_To, @Notice_Subject, @Notice_Body, @Notice_Timestamp, @Read_Status)", con);
                    string hashQM = QM_details.Employee_name + scar_no + noticeBody;
                    hashQM = Encryptor.MD5HASH(hashQM);
                    addNoticeQM.Parameters.AddWithValue("@hash", hashQM);
                    addNoticeQM.Parameters.AddWithValue("@Notice_From", JabilSession.Current.employee_name);
                    addNoticeQM.Parameters.AddWithValue("@Notice_To", QM_details.Employee_name);
                    addNoticeQM.Parameters.AddWithValue("@Notice_Subject", "8D Approval Request");
                    addNoticeQM.Parameters.AddWithValue("@Notice_Body", noticeBody);
                    addNoticeQM.Parameters.AddWithValue("@Notice_TimeStamp", currentDateTime);
                    addNoticeQM.Parameters.AddWithValue("@Read_Status", "False");
                    addNoticeQM.ExecuteNonQuery();

                    // SQL command to insert data into database
                    /*SqlCommand addWCM = new SqlCommand(@"INSERT INTO dbo.email (recipient_email_address, recipient_name, email_subject, email_content)
    VALUES (@recipient_email_address, @recipient_name, @email_subject, @email_content)", con);

                    addWCM.Parameters.AddWithValue("@recipient_email_address", WCM_details.Employee_email);
                    addWCM.Parameters.AddWithValue("@recipient_name", WCM_details.Employee_name);
                    addWCM.Parameters.AddWithValue("@email_subject", email_details.Email_header);
                    addWCM.Parameters.AddWithValue("@email_content", email_details.Email_content);

                    addWCM.ExecuteNonQuery();

                    SqlCommand addQM = new SqlCommand(@"INSERT INTO dbo.email (recipient_email_address, recipient_name, email_subject, email_content)
    VALUES (@recipient_email_address, @recipient_name, @email_subject, @email_content)", con);

                    addQM.Parameters.AddWithValue("@recipient_email_address", QM_details.Employee_email);
                    addQM.Parameters.AddWithValue("@recipient_name", QM_details.Employee_name);
                    addQM.Parameters.AddWithValue("@email_subject", email_details.Email_header);
                    addQM.Parameters.AddWithValue("@email_content", email_details.Email_content);

                    addQM.ExecuteNonQuery();*/
                    
                    // Insert approval request into database
                    SqlCommand addApproval = new SqlCommand(@"INSERT INTO Approval_8D (name_WCM, name_QM, approval_status_WCM, approval_status_QM, comment_WCM, comment_QM, sent_date, sent_time, scar_no)
VALUES (@name_WCM, @name_QM, @approval_status_WCM, @approval_status_QM, @comment_WCM, @comment_QM, @sent_date, @sent_time, @scar_no)", con);

                    string currentTime = System.DateTime.Now.ToShortTimeString();
                    string currentDate = System.DateTime.Now.ToShortDateString();
                    DateTime tempCurrentDate = Convert.ToDateTime(currentDate);

                    addApproval.Parameters.AddWithValue("@name_WCM", WCM_details.Employee_name);
                    addApproval.Parameters.AddWithValue("@name_QM", QM_details.Employee_name);
                    if (WCM_details.Employee_name.Equals("N/A"))
                    {
                        addApproval.Parameters.AddWithValue("@approval_status_WCM", "N/A");
                    }
                    else
                    {
                        addApproval.Parameters.AddWithValue("@approval_status_WCM", "pending");
                    }
                    if (QM_details.Employee_name.Equals("N/A"))
                    {
                        addApproval.Parameters.AddWithValue("@approval_status_QM", "N/A");
                    }
                    else
                    {
                        addApproval.Parameters.AddWithValue("@approval_status_QM", "pending");
                    }
                    addApproval.Parameters.AddWithValue("@comment_WCM", "N/A");
                    addApproval.Parameters.AddWithValue("@comment_QM", "N/A");
                    addApproval.Parameters.AddWithValue("@sent_date", tempCurrentDate);
                    addApproval.Parameters.AddWithValue("@sent_time", currentTime);
                    addApproval.Parameters.AddWithValue("@scar_no", scar_no);

                    addApproval.ExecuteNonQuery();
                    string message = "8D Approval Request for: " + scar_no + " has been successfully sent!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                }
                catch (Exception err)
                {
                    string message = "8D Approval Request for: " + scar_no + " cannot be sent! Please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        
    }
  

    // Delete Attachments from Server File Manager
    protected void AttachmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TableCell cell = AttachmentsGridView.Rows[e.RowIndex].Cells[1];
        string scar_no = Request.QueryString["scar_no"];
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand delete = new SqlCommand("Delete from dbo.SCAR_attachments where scar_no = @scar_no AND file_name = @file_name", conn);
            delete.Parameters.AddWithValue("@scar_no", scar_no);
            delete.Parameters.AddWithValue("@file_name", cell.Text);
            delete.ExecuteNonQuery();
        }
        
        string FileToDelete = Server.MapPath(@"~\Attachments\" + cell.Text);
        File.Delete(FileToDelete);
        string message = cell.Text + " has been deleted!";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
    }


    // Parse Data into Notepad
    protected void Parse_Data_Into_Notepad(string scar_no)
    {
        string scar_type = null;
        string filename = null;
        SCAR scar_details = new SCAR();
        SCAR_Response scar_response_details = new SCAR_Response();
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand selectRequest = new SqlCommand(@"SELECT scar_type, scar_no, car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, 
recurrence, supplier_contact,supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, 
defect_quantity, defect_type, non_conformity_reported, reject_reason, expected_date_close, file_name FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
            selectRequest.Parameters.AddWithValue("scar_no", scar_no);
            SqlDataReader reader;
            reader = selectRequest.ExecuteReader();

            while (reader.Read())
            {
                scar_details.Car_no = Convert.ToString(reader["scar_no"]);
                scar_details.Car_revision = Convert.ToString(reader["car_revision"]);
                scar_details.Car_type = Convert.ToString(reader["car_type"]);
                scar_details.Pre_alert = Convert.ToString(reader["pre_alert"]);
                scar_details.Related_car_no = Convert.ToString(reader["related_car_no"]);
                scar_details.Related_car_rev = Convert.ToString(reader["related_car_ref"]);
                scar_details.Originator = Convert.ToString(reader["originator"]);
                scar_details.Recurrence = Convert.ToString(reader["recurrence"]);
                scar_details.Supplier_contact = Convert.ToString(reader["supplier_contact"]);
                scar_details.Supplier_email = Convert.ToString(reader["supplier_email"]);
                scar_details.Issued_date = Convert.ToDateTime(reader["issued_date"]).ToString("yyyy-MM-dd");
                scar_details.Originator_department = Convert.ToString(reader["originator_dept"]);
                scar_details.Originator_contact = Convert.ToString(reader["originator_contact"]);
                scar_details.Part_no = Convert.ToString(reader["part_no"]);
                scar_details.Part_description = Convert.ToString(reader["part_description"]);
                scar_details.Business_unit = Convert.ToString(reader["business_unit"]);
                scar_details.Dept_pl = Convert.ToString(reader["dept_pl"]);
                scar_details.Commodity = Convert.ToString(reader["commodity"]);
                scar_details.Defect_quantity = Convert.ToInt16(reader["defect_quantity"]);
                scar_details.Defect_type = Convert.ToString(reader["defect_type"]);
                scar_details.Non_conformity_reported= Convert.ToString(reader["non_conformity_reported"]);
                scar_details.Reject_reason = Convert.ToString(reader["reject_reason"]);
                scar_details.Expected_date_close = Convert.ToDateTime(reader["expected_date_close"]).ToString("yyyy-MM-dd");
                scar_type = Convert.ToString(reader["scar_type"]);
                filename = Convert.ToString(reader["file_name"]);
            }
            reader.Close();

            SqlCommand selectResponse = new SqlCommand(@"SELECT root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, 
s21_containment_action, s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, 
s32_failure_analysis_results, s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, 
s61_permanent_corrective_action, s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, 
s72_implementation_date, s73_responsible_person, s74_verifier, s75_verifier_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, 
status, scar_no FROM dbo.SCAR_Response WHERE scar_no = @scar_no", conn);
            selectResponse.Parameters.AddWithValue("scar_no", scar_no);
            reader = selectResponse.ExecuteReader();

            while (reader.Read())
            {
                scar_response_details.Root_cause_option = Convert.ToString(reader["root_cause_option"]);
                scar_response_details.Overall_summary = Convert.ToString(reader["s0_overall_summary"]);
                scar_response_details.Problem_verification = Convert.ToString(reader["s1_problem_verification"]);
                scar_response_details.Problem_verification_status = Convert.ToString(reader["problem_verification_status"]);
                scar_response_details.S21_containment_action = Convert.ToString(reader["s21_containment_action"]);
                scar_response_details.S22_implementation_date = Convert.ToDateTime(reader["s22_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S23_responsible_person = Convert.ToString(reader["s23_responsible_person"]);
                scar_response_details.S24_containment_result = Convert.ToString(reader["s24_containment_result"]);
                scar_response_details.Screening_area = Convert.ToString(reader["screening_area"]);
                scar_response_details.S31_failure_analysis = Convert.ToString(reader["s31_failure_analysis"]);
                scar_response_details.S32_failure_analysis_results = Convert.ToString(reader["s32_failure_analysis_results"]);
                scar_response_details.Man = Convert.ToString(reader["s4_man"]);
                scar_response_details.Method = Convert.ToString(reader["s4_method"]);
                scar_response_details.Material = Convert.ToString(reader["s4_material"]);
                scar_response_details.Machine = Convert.ToString(reader["s4_machine"]);
                scar_response_details.S51_corrective_action = Convert.ToString(reader["s51_corrective_action"]);
                scar_response_details.S52_implementation_date = Convert.ToDateTime(reader["s52_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S53_responsible_person = Convert.ToString(reader["s53_responsible_person"]);
                scar_response_details.S61_permanent_corrective_action = Convert.ToString("s61_permanent_corrective_action");
                scar_response_details.S62_implementation_date = Convert.ToDateTime(reader["s62_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S63_responsible_person = Convert.ToString(reader["s63_responsible_person"]);
                scar_response_details.S71_verify_effectiveness_of_corrective_actions = Convert.ToString(reader["s71_verify_corrective_action_effectiveness"]);
                scar_response_details.S72_implementation_date = Convert.ToDateTime(reader["s72_implementation_date"]).ToString("yyyy-MM-dd");
                scar_response_details.S73_responsible_person = Convert.ToString(reader["s73_responsible_person"]);
                scar_response_details.S74_verifier = Convert.ToString(reader["s74_verifier"]);
                scar_response_details.S75_verifier_email = Convert.ToString(reader["s75_verifier_email"]);

                if (scar_type.CompareTo("SCAR Type 4")==0)
                {
                    scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results = Convert.ToString(reader["s76_verify_corrective_action_result_effectiveness"]);
                } 
            }
            conn.Close();
        }

        try
        {
            string folderName = null;
            if (scar_type.CompareTo("SCAR Type 4")==0)
            {
                folderName = "Type-4";
            }
            else
            {
                folderName = "Type-2";
            }
            string path = Server.MapPath(@"~\Text_Files\" + folderName + "\\" + filename);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.WriteLine("------------------------------------------------------------------");
                if (scar_type.CompareTo("SCAR Type 4") == 0)
                {
                    file.WriteLine("EMG CARE Supplier Corrective Action Request (SCAR) for Type-4");
                }
                else
                {
                    file.WriteLine("EMG CARE Supplier Corrective Action Request (SCAR)");
                }
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("Section1: (For Reference Only)");
                file.WriteLine("==================================================================");
                file.WriteLine("Car No: " + scar_details.Car_no);
                file.WriteLine("Car Revision: " + scar_details.Car_revision);
                file.WriteLine("Car Type: " + scar_details.Car_type);
                file.WriteLine("Pre Alert: " + scar_details.Pre_alert);
                file.WriteLine("Related CAR No: " + scar_details.Related_car_no);
                file.WriteLine("Related CAR Rev: " + scar_details.Related_car_rev);
                file.WriteLine("Originator: " + scar_details.Originator);
                file.WriteLine("Recurrence (Ref.No): " + scar_details.Recurrence);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("Supplier Contact: " + scar_details.Supplier_contact);
                file.WriteLine("Supplier Email: " + scar_details.Supplier_email);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("Issued Date: " + scar_details.Issued_date);
                file.WriteLine("Originator Department: " + scar_details.Originator_department);
                file.WriteLine("Originator Contact: " + scar_details.Originator_contact);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("Part No: " + scar_details.Part_no);
                file.WriteLine("Part Description: " + scar_details.Part_description);
                file.WriteLine("Business Unit: " + scar_details.Business_unit);
                file.WriteLine("Dept/PL: " + scar_details.Dept_pl);
                file.WriteLine("Commodity: " + scar_details.Commodity);
                file.WriteLine("Defect Quantity: " + scar_details.Defect_quantity);
                file.WriteLine("Defect Type: " + scar_details.Defect_type);
                file.WriteLine("Non-Conformity Reported: " + scar_details.Non_conformity_reported);
                file.WriteLine("");
                file.WriteLine("Reject Reason for Previous Revision: " + scar_details.Reject_reason);
                file.WriteLine("");
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("Expected Date Close: " + scar_details.Expected_date_close);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("Section2");
                file.WriteLine("==================================================================");
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("=========================");
                file.WriteLine("==*Root Cause Category*==");
                file.WriteLine("=========================");
                file.WriteLine(scar_response_details.Root_cause_option);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("====================");
                file.WriteLine("*S0-Overall Summary*");
                file.WriteLine("====================");
                file.WriteLine("**S0-Overall Summary = " + scar_response_details.Overall_summary);
                file.WriteLine("");
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("=========================");
                file.WriteLine("*S1-Problem Verification*");
                file.WriteLine("=========================");
                file.WriteLine("**S1-Problem Verification = " + scar_response_details.Problem_verification);
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("==*Status*==");
                file.WriteLine(scar_response_details.Problem_verification_status);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("=======================");
                file.WriteLine("*S2-Containment Action*");
                file.WriteLine("=======================");
                file.WriteLine("**S21-Containment Action = " + scar_response_details.S21_containment_action);
                file.WriteLine("");
                file.WriteLine("**S22-Implementation Date = " + scar_response_details.S22_implementation_date);
                file.WriteLine("");
                file.WriteLine("**S23-Responsible Person = " + scar_response_details.S23_responsible_person);
                file.WriteLine("");
                file.WriteLine("**S24-Containment Result = " + scar_response_details.S24_containment_result);
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("==*Screening Area*==");
                file.WriteLine(scar_response_details.Screening_area);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("=====================");
                file.WriteLine("*S3-Failure Analysis*");
                file.WriteLine("=====================");
                file.WriteLine("**S31-Failure Analysis = " + scar_response_details.S31_failure_analysis);
                file.WriteLine("");
                file.WriteLine("**S32-Failure Analysis Results = " + scar_response_details.S32_failure_analysis_results);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("===============");
                file.WriteLine("*S4-Root Cause*");
                file.WriteLine("===============");
                file.WriteLine("**S4 =");
                file.WriteLine("Man = " + scar_response_details.Man);
                file.WriteLine("");
                file.WriteLine("Method = " + scar_response_details.Method);
                file.WriteLine("");
                file.WriteLine("Material = " + scar_response_details.Material);
                file.WriteLine("");
                file.WriteLine("Machine = " + scar_response_details.Machine);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("======================");
                file.WriteLine("*S5-Corrective Action*");
                file.WriteLine("======================");
                file.WriteLine("**S51-Corrective Action = " + scar_response_details.S51_corrective_action);
                file.WriteLine("");
                file.WriteLine("**S52-Implementation Date = " + scar_response_details.S52_implementation_date);
                file.WriteLine("");
                file.WriteLine("**S53-Responsible Person = " + scar_response_details.S53_responsible_person);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("================================");
                file.WriteLine("*S6-Permanent Corrective Action*");
                file.WriteLine("================================");
                file.WriteLine("**S61-Permanent Corrective Action = " + scar_response_details.S61_permanent_corrective_action);
                file.WriteLine("");
                file.WriteLine("**S62-Implementation Date = " + scar_response_details.S62_implementation_date);
                file.WriteLine("");
                file.WriteLine("**S63-Responsible Person = " + scar_response_details.S63_responsible_person);
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("===============================================");
                file.WriteLine("*S7-Verify Effectiveness of Corrective Actions*");
                file.WriteLine("===============================================");
                file.WriteLine("**S71-Verify Effectiveness of Corrective Actions = " + scar_response_details.S71_verify_effectiveness_of_corrective_actions);
                file.WriteLine("");
                file.WriteLine("**S72-Implementation Date(Start of Monitoring) = " + scar_response_details.S72_implementation_date);
                file.WriteLine("");
                file.WriteLine("**S73-Responsible Person = " + scar_response_details.S73_responsible_person);
                file.WriteLine("");
                file.WriteLine("**S74-Verifier = " + scar_response_details.S74_verifier);
                file.WriteLine("");
                file.WriteLine("**S75-Verifier Email = " + scar_response_details.S75_verifier_email);
                if (scar_type.CompareTo("SCAR Type 4") == 0)
                {
                    file.WriteLine("");
                    file.WriteLine("**S76-Verify Effectiveness of Corrective Actions Result = " + scar_response_details.S76_verifiy_effectiveness_of_corrective_actions_results);
                }
                file.WriteLine("------------------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("==================================================================");
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand update = new SqlCommand("UPDATE dbo.SCAR_Response SET status = @status WHERE scar_no = @scar_no", conn);
                    update.Parameters.AddWithValue("@scar_no", scar_no);
                    update.Parameters.AddWithValue("@status", "submit");
                    update.ExecuteNonQuery();

                    SqlCommand update_request = new SqlCommand(@"UPDATE dbo.SCAR_Request SET modified_by = @modified_by, last_modified = @last_modified, 
pending_action = @pending_action WHERE scar_no = @scar_no", conn);

                    update_request.Parameters.AddWithValue("@scar_no", scar_no);
                    update_request.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                    DateTime currentDateTime = DateTime.Now;
                    update_request.Parameters.AddWithValue("@last_modified", currentDateTime);
                    update_request.Parameters.AddWithValue("@pending_action", "Awaiting Client Response");

                    update_request.ExecuteNonQuery();

                }

                string message = "SCAR Response for : " + scar_no + "  has been successfully sent!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
            }
        }
        catch (Exception err)
        {
            string message = "SCAR Response for : " + scar_no + "  cannot be sent! Please Try Again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
        }

    }

    // Change SCAR Status
    protected void Change_SCAR_Status(object sender, EventArgs e)
    {
        string scar_no = Request.QueryString["scar_no"];
        if(!String.IsNullOrEmpty(scar_no))
        {
            string SCAR_Status = lstCurrentStatus.SelectedItem.Value;
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                try
                {
                    conn.Open();
                    SqlCommand update = new SqlCommand(@"UPDATE dbo.SCAR_Request SET scar_status = @scar_status, modified_by = @modified_by, last_modified = @last_modified WHERE scar_no = @scar_no", conn);
                    update.Parameters.AddWithValue("@scar_no", scar_no);
                    update.Parameters.AddWithValue("@scar_status", SCAR_Status);
                    update.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                    DateTime currentDateTime = DateTime.Now;
                    update.Parameters.AddWithValue("@last_modified", currentDateTime);
                    update.ExecuteNonQuery();
                    if(SCAR_Status.Equals("SCAR Type 4 Accepted"))
                    {
                        Move_Data_To_History(scar_no, SCAR_Status, "SCAR Type 4");
                        Close_SCAR_Issue(scar_no);
                    }
                    else if (SCAR_Status.Equals("SCAR Type 4 Rejected"))
                    {
                        Move_Data_To_History(scar_no, SCAR_Status, "SCAR Type 4");
                        Close_SCAR_Issue(scar_no);
                    }
                    else if (SCAR_Status.Equals("SCAR Type 2 Rejected"))
                    {
                        Move_Data_To_History(scar_no, SCAR_Status, "SCAR Type 2");
                        Close_SCAR_Issue(scar_no);
                    }
                    else
                    {
                        string message = "SCAR Status for : " + scar_no + "  has been updated to " + SCAR_Status;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                    }  
                }
                catch (Exception err)
                {
                    string message = "SCAR Status for : " + scar_no + "  cannot be changed! Please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                } 
            }
        }
        
    }

    // Display Attachments related to SCAR
    protected void Display_Attachments_Grid_View(string scar_no)
    {
        if (!IsPostBack)
        {
            SqlDataSource AttachmentsDataSource = new SqlDataSource();
            AttachmentsDataSource.ID = "AttachmentsDataSource";
            this.Page.Controls.Add(AttachmentsDataSource);
            AttachmentsDataSource.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            AttachmentsDataSource.SelectCommand = "SELECT scar_no, file_name FROM dbo.SCAR_attachments WHERE scar_no = @scar_no";


            AttachmentsDataSource.SelectParameters.Add(new Parameter("scar_no", System.TypeCode.String, scar_no));
            AttachmentsGridView.DataSource = AttachmentsDataSource;
            AttachmentsGridView.DataBind();

           
        }

    }
    
    // Sorts Attachment Grid View
    protected void AttachmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        string scar_no = Request.QueryString["scar_no"];
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        SqlConnection conn = new SqlConnection(connect);
        string query = "SELECT scar_no, file_name FROM dbo.SCAR_attachments";

        DataTable DT = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter(query, conn);
        DA.Fill(DT);

        AttachmentsGridView.DataSource = DT;
        AttachmentsGridView.DataBind();

        if (DT != null)
        {
            DataView dataView = new DataView(DT);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            AttachmentsGridView.DataSource = dataView;
            AttachmentsGridView.DataBind();
        }
    }

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }

        return GridViewSortDirection;
    }

    protected void SetSortDirection(string sortDirection)
    {
        if (sortDirection == "ASC")
        {
            sortDirection = "DESC";
        }
        else
        {
            sortDirection = "ASC";
        }
    } 

    // Display Approval Status
    protected void Display_Approval_GridView()
    {
        string scar_no = Request.QueryString["scar_no"];

        if(!String.IsNullOrEmpty(scar_no))
        {
            SqlDataReader rdr;

            DataTable dt = new DataTable();

            dt.Columns.Add("WCM Name");
            dt.Columns.Add("QM Name");
            dt.Columns.Add("WCM Approval Status");
            dt.Columns.Add("WCM Comment");
            dt.Columns.Add("QM Approval Status");
            dt.Columns.Add("QM Comment");

            DataRow dr;

            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand select = new SqlCommand(@"SELECT name_WCM, name_QM, approval_status_WCM, approval_status_QM, comment_WCM, comment_QM 
FROM dbo.Approval_8D WHERE scar_no = @scar_no", conn);
                select.Parameters.AddWithValue("@scar_no", scar_no);
                rdr = select.ExecuteReader();
                while (rdr.Read())
                {
                    dr = dt.NewRow();

                    dr["WCM Name"] = rdr["name_WCM"].ToString();
                    dr["QM Name"] = rdr["name_QM"].ToString();
                    dr["WCM Approval Status"] = rdr["approval_status_WCM"].ToString();
                    dr["QM Approval Status"] = rdr["approval_status_QM"].ToString();
                    dr["WCM Comment"] = rdr["comment_WCM"].ToString();
                    dr["QM Comment"] = rdr["comment_QM"].ToString();

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            }
            ApprovalGridView.DataSource = dt;
            ApprovalGridView.DataBind();
        }
        
    }

    // Closes the SCAR 
    protected void Close_SCAR_Issue(string scar_no)
    {
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connect))
        {
            try
            {
                conn.Open();
                SqlCommand update = new SqlCommand(@"UPDATE dbo.SCAR_Request SET scar_status = @scar_status, modified_by = @modified_by, last_modified = @last_modified WHERE scar_no = @scar_no", conn);
                update.Parameters.AddWithValue("@scar_no", scar_no);
                update.Parameters.AddWithValue("@scar_status", "Closed SCAR");
                update.Parameters.AddWithValue("@modified_by", JabilSession.Current.employee_name);
                DateTime currentDateTime = DateTime.Now;
                update.Parameters.AddWithValue("@last_modified", currentDateTime);
                update.ExecuteNonQuery();
                string message = scar_no + " has been closed!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
                lstCurrentStatus.Enabled = false;
            }
            catch (Exception err)
            {
                string message = scar_no + " cannot be closed! Please try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + scar_no + "', '" + message + "')", true);
            }
        }
    }


    // Check if the approval checkbox is checked or unchecked
    protected void Approval_CheckedChanged(object sender, EventArgs e)
    {
        if (chk8Dapproval.Checked)
        {
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
                lstWCM.Items.Insert(0, new ListItem("Please Select WCM", "0"));
                lstWCM.Items.Insert(1, new ListItem("N/A", "N/A"));

                conn.Close();
            }

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand selectQM = new SqlCommand("SELECT employee_ID, employee_name, employee_position FROM dbo.Employee WHERE employee_position = @employee_position", conn);
                conn.Open();
                selectQM.Parameters.AddWithValue("employee_position", "Quality Manager");

                lstQM.DataSource = selectQM.ExecuteReader();
                lstQM.DataTextField = "employee_name";
                lstQM.DataValueField = "employee_ID";
                lstQM.DataBind();
                lstQM.Items.Insert(0, new ListItem("Please Select QM", "0"));
                lstQM.Items.Insert(1, new ListItem("N/A", "N/A"));
            }

            lstWCM.Visible = true;
            lstQM.Visible = true;
            lblWCM.Visible = true;
            lblQM.Visible = true;
        }
        else
        {
            lblWCM.Visible = false;
            lstWCM.Visible = false;
            lblQM.Visible = false;
            lstQM.Visible = false;
        }    
    }
}

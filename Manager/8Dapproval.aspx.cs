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
using System.IO;
using Jabil_Session;
public partial class Manager_8Dapproval : System.Web.UI.Page
{
    string DatabaseName = "JabilDatabase";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
        string scar_no = Request.QueryString["scar_no"];
        if (!String.IsNullOrEmpty(scar_no))
        {
            Read_Request(connect, scar_no);
            Read_Response(connect, scar_no);
            Display_Attachments_Grid_View(scar_no);
        }
        
    }

    protected void Upload_Files(object sender, EventArgs e)
    {
        if (uploadFile.HasFile)
        {
            string scar_no = Request.QueryString["scar_no"];
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
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                                    con.Close();

                                }
                            }
                        }
                    }
                    else
                    {
                        string message = ".exe and .msi files are not allowed! Please Try Again!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);

                    }
                }

            }
            catch (Exception err)
            {
                string message = "Unable to upload files! Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
            }
            finally
            {

            }
        }

    }
    protected void Read_Request(string connect, string scar_no)
    {
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT scar_no, car_revision, car_type, pre_alert, related_car_no, related_car_ref, originator, recurrence, 
supplier_contact,supplier_email, issued_date, originator_dept, originator_contact, part_no, part_description, business_unit, dept_pl, commodity, defect_quantity, 
defect_type, non_conformity_reported, reject_reason, expected_date_close FROM dbo.SCAR_Request WHERE scar_no = @scar_no", conn);
            select.Parameters.AddWithValue("scar_no", scar_no);
            SqlDataReader reader;
            reader = select.ExecuteReader();

            while (reader.Read())
            {
                lblCarNo.Text = Convert.ToString(reader["scar_no"]);
                lblCarRev.Text = Convert.ToString(reader["car_revision"]);
                lblCarType.Text = Convert.ToString(reader["car_type"]);
                lblPreAlert.Text = Convert.ToString(reader["pre_alert"]);
                lblRelatedCarNo.Text = Convert.ToString(reader["related_car_no"]);
                lblRelatedCarRev.Text = Convert.ToString(reader["related_car_ref"]);
                lblOriginator.Text = Convert.ToString(reader["originator"]);
                lblRecurrence.Text = Convert.ToString(reader["recurrence"]);
                lblSupplierContact.Text = Convert.ToString(reader["supplier_contact"]);
                lblSupplierEmail.Text = Convert.ToString(reader["supplier_email"]);
                lblIssuedDate.Text = Convert.ToDateTime(reader["issued_date"]).ToString("yyyy-MM-dd");
                lblOriginatorDept.Text = Convert.ToString(reader["originator_dept"]);
                lblOriginatorContact.Text = Convert.ToString(reader["originator_contact"]);
                lblPartNo.Text = Convert.ToString(reader["part_no"]);
                lblPartDescription.Text = Convert.ToString(reader["part_description"]);
                lblBusinessUnit.Text = Convert.ToString(reader["business_unit"]);
                lblDeptPL.Text = Convert.ToString(reader["dept_pl"]);
                lblCommodity.Text = Convert.ToString(reader["commodity"]);
                lblDefectQuantity.Text = Convert.ToString(reader["defect_quantity"]);
                lblDefectType.Text = Convert.ToString(reader["defect_type"]);
                lblNonConformityReported.Text += Convert.ToString(reader["non_conformity_reported"]);
                lblRejectReason.Text = Convert.ToString(reader["reject_reason"]);
                lblExpectedDateClose.Text = Convert.ToDateTime(reader["expected_date_close"]).ToString("yyyy-MM-dd");

            }
        }
    }

    protected void Read_Response(string connect, string scar_no)
    {
        using (SqlConnection conn = new SqlConnection(connect))
        {
            conn.Open();
            SqlCommand select = new SqlCommand(@"SELECT root_cause_option, s0_overall_summary, s1_problem_verification, problem_verification_status, s21_containment_action,
s22_implementation_date, s23_responsible_person, s24_containment_result, screening_area, track_containment_action, s31_failure_analysis, s32_failure_analysis_results, 
s4_man, s4_method, s4_material, s4_machine, s51_corrective_action, s52_implementation_date, s53_responsible_person, track_corrective_action, s61_permanent_corrective_action, 
s62_implementation_date, s63_responsible_person, track_permanent_corrective_action, s71_verify_corrective_action_effectiveness, s72_implementation_date, 
s73_responsible_person, s74_verifier, s75_verifier_email, s76_verify_corrective_action_result_effectiveness, defect_modes, mor_calculated, status, 
scar_no FROM dbo.SCAR_Response WHERE scar_no = @scar_no", conn);
            select.Parameters.AddWithValue("scar_no", scar_no);
            SqlDataReader reader;
            reader = select.ExecuteReader();

            while (reader.Read())
            {
                lblRootCause.Text = Convert.ToString(reader["root_cause_option"]);
                lblOverallSummary.Text = Convert.ToString(reader["s0_overall_summary"]);
                lblProbVerification.Text = Convert.ToString(reader["s1_problem_verification"]);
                lblProbVerificationStatus.Text = Convert.ToString(reader["problem_verification_status"]);
                lblContainmentAction.Text = Convert.ToString(reader["s21_containment_action"]);
                lblS2ImplementationDate.Text = Convert.ToDateTime(reader["s22_implementation_date"]).ToString("yyyy-MM-dd");
                lblS2ResponsiblePerson.Text = Convert.ToString(reader["s23_responsible_person"]);
                lblContainmentResult.Text = Convert.ToString(reader["s24_containment_result"]);

                string tempScreeningArea = Convert.ToString(reader["screening_area"]);
                if (tempScreeningArea.Contains("Production"))
                {
                    chkProduction.Checked = true;
                }
                if (tempScreeningArea.Contains("FGI"))
                {
                    chkFGI.Checked = true;
                }
                if (tempScreeningArea.Contains("Remaining units with customers"))
                {
                    chkRemainingUnits.Checked = true;
                }
                if (tempScreeningArea.Contains("N/A"))
                {
                    chkNA.Checked = true;
                }
                if (tempScreeningArea.Contains("Units in Field (with other customers)"))
                {
                    chkUnitInField.Checked = true;
                }

                if (Convert.ToInt16(reader["track_containment_action"]) == 1)
                {
                    chkS2TrackActionItem.Checked = true;
                }
                else
                {
                    chkS2TrackActionItem.Checked = false;
                }

                lblFailureAnalysis.Text = Convert.ToString(reader["s31_failure_analysis"]);
                lblFailureResult.Text = Convert.ToString(reader["s32_failure_analysis_results"]);
                lblMan.Text = Convert.ToString(reader["s4_man"]);
                lblMethod.Text = Convert.ToString(reader["s4_method"]);
                lblMaterial.Text = Convert.ToString(reader["s4_material"]);
                lblMachine.Text = Convert.ToString(reader["s4_machine"]);
                lblCorrectiveAction.Text = Convert.ToString(reader["s51_corrective_action"]);
                lblS5ImplementationDate.Text = Convert.ToDateTime(reader["s52_implementation_date"]).ToString("yyyy-MM-dd");
                lblS5ResponsiblePerson.Text = Convert.ToString(reader["s53_responsible_person"]);

                if (Convert.ToInt16(reader["track_corrective_action"]) == 1)
                {
                    chkS5TrackActionItem.Checked = true;
                }
                else
                {
                    chkS5TrackActionItem.Checked = false;
                }

                lblPermanentCA.Text = Convert.ToString(reader["s61_permanent_corrective_action"]);
                lblS6ImplementationDate.Text = Convert.ToDateTime(reader["s62_implementation_date"]).ToString("yyyy-MM-dd");
                lblS6ResponsiblePerson.Text = Convert.ToString(reader["s63_responsible_person"]);

                if (Convert.ToInt16(reader["track_permanent_corrective_action"]) == 1)
                {
                    chkS6TrackActionItem.Checked = true;
                }
                else
                {
                    chkS6TrackActionItem.Checked = false;
                }

                lblVerifyCA.Text = Convert.ToString(reader["s71_verify_corrective_action_effectiveness"]);
                lblS7ImplementationDate.Text = Convert.ToDateTime(reader["s72_implementation_date"]).ToString("yyyy-MM-dd");
                lblS7ResponsiblePerson.Text = Convert.ToString(reader["s73_responsible_person"]);
                lblVerifier.Text = Convert.ToString(reader["s74_verifier"]);
                lblVerifierEmail.Text = Convert.ToString(reader["s75_verifier_email"]);
                lblVerifyCAResult.Text = Convert.ToString(reader["s76_verify_corrective_action_result_effectiveness"]);
                lblDefectMode.Text = Convert.ToString(reader["defect_modes"]);

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
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
    }

    protected void DownloadFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }

    protected void Display_Attachments_Grid_View(string scar_no)
    {
        if (!IsPostBack)
        {
            SqlDataSource AttachmentsDataSource = new SqlDataSource();
            AttachmentsDataSource.ID = "AttachmentsDataSource";
            this.Page.Controls.Add(AttachmentsDataSource);
            AttachmentsDataSource.ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            AttachmentsDataSource.SelectCommand = "SELECT scar_no, file_name, file_path FROM dbo.SCAR_attachments WHERE scar_no = @scar_no";


            AttachmentsDataSource.SelectParameters.Add(new Parameter("scar_no", System.TypeCode.String, scar_no));
            AttachmentsGridView.DataSource = AttachmentsDataSource;
            AttachmentsGridView.DataBind();


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
                string scar_no = Request.QueryString["scar_no"];

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
                                string query = "insert into dbo.SCAR_attachments (file_name, file_type, file_path, scar_no)values (@Name, @ContentType, @File_path, @scar_no)";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {
                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Name", filename);
                                    cmd.Parameters.AddWithValue("@ContentType", contentType);
                                    cmd.Parameters.AddWithValue("@File_path", path);
                                    cmd.Parameters.AddWithValue("@scar_no", scar_no);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    string message = "Your files have been uploaded succesfully!";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                                    con.Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    string message = ".exe and .msi files are not allowed! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
            }

        }
        catch (Exception err)
        {
            string message = "Unable to upload files! Please Try Again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
        }
        finally
        {

        }
    }

    protected void Submit_Approval_Form(object sender, EventArgs e)
    {
        string scar_no = Request.QueryString["scar_no"];
        if (!String.IsNullOrEmpty(scar_no))
        {
            string approvalStatus = rdbApproval.SelectedItem.Value;
            string comment = txtComment.Text;
            
            string connect = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            int tempRejectCountWCM = 0;

            string position = JabilSession.Current.employee_position;

            if(approvalStatus.Equals("Approve"))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connect))
                    {
                        conn.Open();
                        if(position.Equals("Work Cell Manager"))
                        {
                            SqlCommand update = new SqlCommand(@"UPDATE dbo.Approval_8D SET approval_status_WCM = @approval_status_WCM, comment_WCM = @comment_WCM WHERE scar_no = @scar_no", conn);
                            update.Parameters.AddWithValue("@scar_no", scar_no);
                            update.Parameters.AddWithValue("@approval_status_WCM", approvalStatus);
                            update.Parameters.AddWithValue("@comment_WCM", comment);
                            update.ExecuteNonQuery();
                        }
                        else if(position.Equals("Quality Manager"))
                        {
                            SqlCommand update = new SqlCommand(@"UPDATE dbo.Approval_8D SET approval_status_QM = @approval_status_QM, comment_QM = @comment_QM WHERE scar_no = @scar_no", conn);
                            update.Parameters.AddWithValue("@scar_no", scar_no);
                            update.Parameters.AddWithValue("@approval_status_QM", approvalStatus);
                            update.Parameters.AddWithValue("@comment_QM", comment);
                            update.ExecuteNonQuery();
                        }
                        string message = "8D Approval Submitted!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                }
                catch(Exception err)
                {
                    string message = "Unable to submit 8D Approval! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
            }
            else if(approvalStatus.Equals("Reject"))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connect))
                    {
                        conn.Open();
                        if(position.Equals("Work Cell Manager"))
                        {
                            bool records_exist = false;
                            SqlCommand select = new SqlCommand(@"SELECT reject_count_WCM FROM dbo.Approval_8D_Reject_Count WHERE scar_no = @scar_no", conn);
                            select.Parameters.AddWithValue("@scar_no", scar_no);
                            SqlDataReader reader = select.ExecuteReader();
                            if(reader.HasRows)
                            {
                                records_exist = true;
                            }

                            if(records_exist)
                            {
                                while (reader.Read())
                                {
                                    tempRejectCountWCM = Convert.ToInt16(reader["reject_count_WCM"]);
                                }
                                reader.Close();
                                SqlCommand updateCount = new SqlCommand(@"UPDATE dbo.Approval_8D_Reject_Count SET reject_count_WCM = @reject_count_WCM WHERE scar_no = @scar_no", conn);
                                updateCount.Parameters.AddWithValue("@scar_no", scar_no);
                                updateCount.Parameters.AddWithValue("@reject_count_WCM", tempRejectCountWCM += 1);
                                updateCount.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                                SqlCommand insertCount = new SqlCommand(@"INSERT INTO dbo.Approval_8D_Reject_Count (reject_count_WCM, scar_no) VALUES (@reject_count_WCM, @scar_no)", conn);
                                insertCount.Parameters.AddWithValue("@scar_no", scar_no);
                                insertCount.Parameters.AddWithValue("@reject_count_WCM", 1);
                                insertCount.ExecuteNonQuery();
                            }
                            SqlCommand updateStatus = new SqlCommand(@"UPDATE dbo.Approval_8D SET approval_status_WCM = @approval_status_WCM, comment_WCM = @comment_WCM WHERE scar_no = @scar_no", conn);
                            updateStatus.Parameters.AddWithValue("@scar_no", scar_no);
                            updateStatus.Parameters.AddWithValue("@approval_status_WCM", approvalStatus);
                            updateStatus.Parameters.AddWithValue("@comment_WCM", comment);
                            updateStatus.ExecuteNonQuery();
                            
                        }
                        else if(position.Equals("Quality Manager"))
                        {
                            bool records_exist = false;
                            SqlCommand select = new SqlCommand(@"SELECT reject_count_QM FROM dbo.Approval_8D_Reject_Count WHERE scar_no = @scar_no", conn);
                            select.Parameters.AddWithValue("@scar_no", scar_no);
                            SqlDataReader reader = select.ExecuteReader();
                            if (reader.HasRows)
                            {
                                records_exist = true;
                            }
                            if (records_exist)
                            {
                                while (reader.Read())
                                {
                                    tempRejectCountWCM = Convert.ToInt16(reader["reject_count_QM"]);
                                }
                                reader.Close();

                                SqlCommand updateCount = new SqlCommand(@"UPDATE dbo.Approval_8D_Reject_Count SET reject_count_QM = @reject_count_QM WHERE scar_no = @scar_no", conn);
                                updateCount.Parameters.AddWithValue("@scar_no", scar_no);
                                updateCount.Parameters.AddWithValue("@reject_count_QM", tempRejectCountWCM += 1);
                                updateCount.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();

                                SqlCommand insertCount = new SqlCommand(@"INSERT INTO dbo.Approval_8D_Reject_Count (reject_count_QM, scar_no) VALUES (@reject_count_QM, @scar_no)", conn);
                                insertCount.Parameters.AddWithValue("@scar_no", scar_no);
                                insertCount.Parameters.AddWithValue("@reject_count_QM", 1);
                                insertCount.ExecuteNonQuery();
                            }
                            SqlCommand updateStatus = new SqlCommand(@"UPDATE dbo.Approval_8D SET approval_status_QM = @approval_status_QM, comment_QM = @comment_QM WHERE scar_no = @scar_no", conn);
                            updateStatus.Parameters.AddWithValue("@scar_no", scar_no);
                            updateStatus.Parameters.AddWithValue("@approval_status_QM", approvalStatus);
                            updateStatus.Parameters.AddWithValue("@comment_QM", comment);
                            updateStatus.ExecuteNonQuery();
                        }
                        string message = "8D Approval Submitted!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                    }
                }
                catch (Exception err)
                {
                    string message = "Unable to submit 8D Approval! Please Try Again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "messageBox('" + message + "')", true);
                }
            }
        }
    }
}
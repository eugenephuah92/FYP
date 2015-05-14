<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_reports_export_SCAR" CodeBehind="~/Admin/reports_export_SCAR.aspx.cs" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>

    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Report - Export SCAR Data Table
                    </div>
                    <div class="panel-body">
                        <div style="overflow: scroll; height: 500px; width: 100%">
                            <asp:GridView ID="GridViewSCAR" CssClass="table" runat="server" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="100%" BorderColor="#cccccc">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="scar_stage" HeaderText="SCAR Stage" SortExpression="scar_stage" />
                                    <asp:BoundField DataField="scar_type" HeaderText="SCAR Type" SortExpression="scar_type" />
                                    <asp:BoundField DataField="scar_status" HeaderText="SCAR Status" SortExpression="scar_status" />
                                    <asp:BoundField DataField="car_no" HeaderText="CAR No." SortExpression="car_no" />
                                    <asp:BoundField DataField="car_revision" HeaderText="CAR Revision" SortExpression="car_revision" />
                                    <asp:BoundField DataField="car_type" HeaderText="CAR Type" SortExpression="car_type" />
                                    <asp:BoundField DataField="pre_alert" HeaderText="Pre Alert" SortExpression="pre_alert" />
                                    <asp:BoundField DataField="related_car_no" HeaderText="Related CAR No." SortExpression="related_car_no" />
                                    <asp:BoundField DataField="related_car_ref" HeaderText="Related CAR Rev." SortExpression="related_car_ref" />
                                    <asp:BoundField DataField="originator" HeaderText="Originator" SortExpression="originator" />
                                    <asp:BoundField DataField="recurrence" HeaderText="Recurrence (Ref.No.)" SortExpression="recurrence" />
                                    <asp:BoundField DataField="supplier_contact" HeaderText="Supplier Contact" SortExpression="supplier_contact" />
                                    <asp:BoundField DataField="supplier_email" HeaderText="Supplier Email" SortExpression="supplier_email" />
                                    <asp:BoundField DataField="issued_date" HeaderText="Issued Date" SortExpression="issued_date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="originator_dept" HeaderText="Originator Department" SortExpression="originator_dept" />
                                    <asp:BoundField DataField="originator_contact" HeaderText="Originator Contact" SortExpression="originator_contact" />
                                    <asp:BoundField DataField="part_no" HeaderText="Part No." SortExpression="part_no" />
                                    <asp:BoundField DataField="part_description" HeaderText="Part Description" SortExpression="part_description" />
                                    <asp:BoundField DataField="business_unit" HeaderText="Business Unit" SortExpression="business_unit" />
                                    <asp:BoundField DataField="dept_pl" HeaderText="Dept/PL" SortExpression="dept_pl" />
                                    <asp:BoundField DataField="commodity" HeaderText="Commodity" SortExpression="commodity" />
                                    <asp:BoundField DataField="defect_quantity" HeaderText="Defect Quantity" SortExpression="defect_quantity" />
                                    <asp:BoundField DataField="defect_type" HeaderText="Defect Type" SortExpression="defect_type" />
                                    <asp:BoundField DataField="non_conformity_reported" HeaderText="Non-Conformity Reported" SortExpression="non_conformity_reported" />
                                    <asp:BoundField DataField="reject_reason" HeaderText="Reject Reason for Previous Revision" SortExpression="reject_reason" />
                                    <asp:BoundField DataField="expected_date_close" HeaderText="Expected Date Close" SortExpression="expected_date_close" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="save_status" HeaderText="Save Status" SortExpression="save_status" />
                                    <asp:BoundField DataField="root_cause_option" HeaderText="Root Cause Option" SortExpression="root_cause_option" />
                                    <asp:BoundField DataField="s0_overall_summary" HeaderText="S0-Overall Summary" SortExpression="s0_overall_summary" />
                                    <asp:BoundField DataField="s1_problem_verification" HeaderText="S1-Problem Verification" SortExpression="s1_problem_verification" />
                                    <asp:BoundField DataField="problem_verification_status" HeaderText="Problem Verification Status" SortExpression="problem_verification_status" />
                                    <asp:BoundField DataField="s21_containment_action" HeaderText="S21-Containment Action" SortExpression="s21_containment_action" />
                                    <asp:BoundField DataField="s22_implementation_date" HeaderText="S22-Implementation Date" SortExpression="s22_implementation_date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="s23_responsible_person" HeaderText="S23-Responsible Person" SortExpression="s23_responsible_person" />
                                    <asp:BoundField DataField="s24_containment_result" HeaderText="S24-Containment Result" SortExpression="s24_containment_result" />
                                    <asp:BoundField DataField="screening_area" HeaderText="Screening Area" SortExpression="screening_area" />
                                    <asp:BoundField DataField="track_containment_action" HeaderText="Track Containment Action" SortExpression="track_containment_action" />
                                    <asp:BoundField DataField="s31_failure_analysis" HeaderText="S31-Failure Analysis" SortExpression="s31_failure_analysis" />
                                    <asp:BoundField DataField="s32_failure_analysis_results" HeaderText="S32-Failure Analysis Results" SortExpression="s32_failure_analysis_results" />
                                    <asp:BoundField DataField="s4_man" HeaderText="S4-Man" SortExpression="s4_man" />
                                    <asp:BoundField DataField="s4_method" HeaderText="S4-Method" SortExpression="s4_method" />
                                    <asp:BoundField DataField="s4_material" HeaderText="S4-Material" SortExpression="s4_material" />
                                    <asp:BoundField DataField="s4_machine" HeaderText="S4-Machine" SortExpression="s4_machine" />
                                    <asp:BoundField DataField="s51_corrective_action" HeaderText="S51-Corrective Action" SortExpression="s51_corrective_action" />
                                    <asp:BoundField DataField="s52_implementation_date" HeaderText="S52-Implementation Date" SortExpression="s52_implementation_date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="s53_responsible_person" HeaderText="S53-Responsible Person" SortExpression="s53_responsible_person" />
                                    <asp:BoundField DataField="track_corrective_action" HeaderText="Track Corrective Action" SortExpression="track_corrective_action" />
                                    <asp:BoundField DataField="s61_permanent_corrective_action" HeaderText="S61-Permanent Corrective Action" SortExpression="s61_permanent_corrective_action" />
                                    <asp:BoundField DataField="s62_implementation_date" HeaderText="S62-Implementation Date" SortExpression="s62_implementation_date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="s63_responsible_person" HeaderText="S63-Responsible Person" SortExpression="s63_responsible_person" />
                                    <asp:BoundField DataField="track_permanent_corrective_action" HeaderText="Track Permanent Corrective Action" SortExpression="track_permanent_corrective_action" />
                                    <asp:BoundField DataField="s71_verify_corrective_action_effectiveness" HeaderText="S71-Verify Effectiveness of Corrective Actions" SortExpression="s71_verify_corrective_action_effectiveness" />
                                    <asp:BoundField DataField="s72_implementation_date" HeaderText="S72-Implementation Date (Start of Monitoring Date)" SortExpression="s72_implementation_date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="s73_responsible_person" HeaderText="S73-Responsible Person" SortExpression="s73_responsible_person" />
                                    <asp:BoundField DataField="s74_verifier" HeaderText="S74-Verifier" SortExpression="s74_verifier" />
                                    <asp:BoundField DataField="s75_verifier_email" HeaderText="S75-Verifier Email" SortExpression="s75_verifier_email" />
                                    <asp:BoundField DataField="s76_verify_corrective_action_result_effectiveness" HeaderText="S76-Verify Effectiveness of Corrective Actions Result" SortExpression="s76_verify_corrective_action_result_effectiveness" />
                                    <asp:BoundField DataField="defect_modes" HeaderText="Defect Modes" SortExpression="defect_modes" />
                                    <asp:BoundField DataField="mor_calculated" HeaderText="MOR Calculated" SortExpression="mor_calculated" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="AliceBlue" Font-Bold="True" ForeColor="Black" />
                                <PagerStyle CssClass="cssPager" BackColor="AliceBlue" HorizontalAlign="Left" Font-Size="Medium" />
                                <RowStyle ForeColor="#333333" BackColor="White" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>"
                            SelectCommand="SELECT * FROM [SCAR_Request], [SCAR_Response] WHERE SCAR_Request.id = SCAR_Response.id">
                        </asp:SqlDataSource>
                        <br />
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button ID="btnExport" CssClass="btn btn-success" Text="Export to Excel" runat="server" OnClick="btnExport_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

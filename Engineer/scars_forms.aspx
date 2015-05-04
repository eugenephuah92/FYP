<%@ Page Title="Auto SCAR &amp; TAT - SCAR Forms" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_scars_forms" Codebehind="~/Engineer/scars_forms.aspx.cs"  EnableEventValidation="false"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <form class="form-horizontal pad10" action="#" method="post" enctype="multipart/form-data">
            <h4>SCAR Request Form </h4><asp:Label runat="server" ID="ProcessedMessage"/>
            <div class="panel-group" id="accordion1">
                <!--Section 1-->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion1" href="#collapse1">
                                Section 1
                            </a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse in">
                        <div class="panel-body" style="padding-top:10pt">
                            
                                <div class="form-group">
                                    <label for="txtCarNo" class="col-lg-3 control-label">Car No</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtCarNo" placeholder="Car No" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldCarNo" ErrorMessage="You must enter the Car Number or N/A if none" runat="server" ControlToValidate="txtCarNo" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtCarRev" class="col-lg-3 control-label">Car Revision</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtCarRev" placeholder="Car Revision" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldCarRev" ErrorMessage="You must enter the Car Revision or N/A if none" runat="server" ControlToValidate="txtCarRev" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtCarType" class="col-lg-3 control-label">Car Type</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtCarType" placeholder="Car Type" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldCarType" ErrorMessage="You must enter the Car Type or N/A if none" runat="server" ControlToValidate="txtCarType" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="rdbPreAlert" class="col-lg-3 control-label">Pre Alert</label>
                                    <div class="col-lg-8">
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButtonList ID="rdbPreAlert" runat="server">  
                                                    <asp:ListItem Value ="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value ="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="vldPreAlert" ErrorMessage="You must select the Pre-Alert" runat="server" ControlToValidate="rdbPreAlert" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                            </label>
                                        </div>

                                    </div>
                                    <br /><br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtRelatedCarNo" class="col-lg-3 control-label">Related Car No</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRelatedCarNo" placeholder="Related Car No" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldRelatedCarNo" ErrorMessage="You must enter the Related Car Number or N/A if none" runat="server" ControlToValidate="txtRelatedCarNo" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtRelatedCarRev" class="col-lg-3 control-label">Related Car Rev</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRelatedCarRev" placeholder="Related Car Rev" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldRelatedCarRev" ErrorMessage="You must enter the Related Car Revision or N/A if none" runat="server" ControlToValidate="txtCarType" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtOriginator" class="col-lg-3 control-label">Originator</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtOriginator" placeholder="Originator" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldOriginator" ErrorMessage="You must enter the Originator or N/A if none" runat="server" ControlToValidate="txtOriginator" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtRecurrence" class="col-lg-3 control-label">Recurrence (Ref.No.)</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRecurrence" placeholder="Recurrence (Ref.No.)" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldRecurrence" ErrorMessage="You must enter the Recurrence (Ref.No.) or N/A if none" runat="server" ControlToValidate="txtRecurrence" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtSupplierContact" class="col-lg-3 control-label">Supplier Contact</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtSupplierContact" placeholder="SupplierContact" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldSupplierContact" ErrorMessage="You must enter the Supplier Contact or N/A if none" runat="server" ControlToValidate="txtSupplierContact" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtSupplierEmail" class="col-lg-3 control-label">Supplier Email</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtSupplierEmail" placeholder="Supplier Email" runat="server" />
                                        <asp:RegularExpressionValidator ID="vldSupplierEmail" ErrorMessage="This email is missing the @ symbol" runat="server" ValidationExpression=".+@.+" ControlToValidate="txtSupplierEmail" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="cldIssuedDate" class="col-lg-3 control-label">Issued Date</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtIssuedDate" TextMode="Date" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldcldIssuedDate" ErrorMessage="You must select the Issued Date" runat="server" ControlToValidate="txtIssuedDate" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtOriginatorDept" class="col-lg-3 control-label">Originator Department</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtOriginatorDept" placeholder="Originator Department" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldOriginatorDept" ErrorMessage="You must enter the Originator Department or N/A if none" runat="server" ControlToValidate="txtOriginatorDept" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtOriginatorContact" class="col-lg-3 control-label">Originator Contact</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtOriginatorContact" placeholder="Originator Contact" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldOriginatorContact" ErrorMessage="You must enter the Originator Contact or N/A if none" runat="server" ControlToValidate="txtOriginatorContact" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtPartNo" class="col-lg-3 control-label">Part No</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtPartNo" placeholder="Part No." runat="server" />
                                        <asp:RequiredFieldValidator ID="vldPartNo" ErrorMessage="You must enter the Part Number or N/A if none" runat="server" ControlToValidate="txtPartNo" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtPartDesc" class="col-lg-3 control-label">Part Description</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtPartDesc" placeholder="Part Description" runat="server" /> 
                                        <asp:RequiredFieldValidator ID="vldPartDesc" ErrorMessage="You must enter the Part Description or N/A if none" runat="server" ControlToValidate="txtPartDesc" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtBusinessUnit" class="col-lg-3 control-label">Business Unit</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtBusinessUnit" placeholder="Business Unit" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldBusinessUnit" ErrorMessage="You must enter the Business Unit or N/A if none" runat="server" ControlToValidate="txtBusinessUnit" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtDeptPL" class="col-lg-3 control-label">Dept / PL</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtDeptPL" placeholder="Dept / PL" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldDeptPL" ErrorMessage="You must enter the Dept/PL or N/A if none" runat="server" ControlToValidate="txtDeptPL" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtCommodity" class="col-lg-3 control-label">Commodity</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtCommodity" placeholder="Commodity" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldCommodity" ErrorMessage="You must enter the Commodity or N/A if none" runat="server" ControlToValidate="txtCommodity" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtDefectQty" class="col-lg-3 control-label">Defect Quantity</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtDefectQty" placeholder="Defect Quantity" runat="server" TextMode="Number"/>
                                        <asp:RequiredFieldValidator ID="vldDefectQty" ErrorMessage="You must enter the Defect Quantity" runat="server" ControlToValidate="txtDefectQty" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="lstDefectType" class="col-lg-3 control-label">Defect Type</label>
                                    <div class="col-lg-8">
                                        <asp:DropDownList CssClass="form-control" ID="lstDefectType" runat="server">
                                            <asp:ListItem>Please Select Defect Type</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="vldDefectType" ErrorMessage="You must select the Defect Type" runat="server" ControlToValidate="lstDefectType" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtNonConformity" class="col-lg-3 control-label">Non-Conformity Reported</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtNonConformity" placeholder="Non-Conformity Reported" TextMode="MultiLine" Rows="2" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldNonConformity" ErrorMessage="You must enter the Non-Conformity Reported or N/A if none" runat="server" ControlToValidate="txtNonConformity" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtRejectReason" class="col-lg-3 control-label">Reject Reason for Previous Revision</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtRejectReason" placeholder="Reject Reason for Previous Revision" TextMode="MultiLine" Rows="2" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldRejectReason" ErrorMessage="You must enter the Reject Reason or N/A if none" runat="server" ControlToValidate="txtRejectReason" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                    </div>
                                    <br /><br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="cldDateClose" class="col-lg-3 control-label">Expected Date Close</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="txtDateClose" TextMode="Date" runat="server" />
                                        <asp:RequiredFieldValidator ID="vldDateClose" ErrorMessage="You must select the Expected Date Close" runat="server" ControlToValidate="txtDateClose" ValidationGroup="SCAR_Request" ForeColor="red"/>
                                        <br />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8 col-lg-offset-3">
                                        <asp:Button CssClass="btn btn-primary" ID="btnSaveSec1" onClick="Save_Request" ValidationGroup="SCAR_Request" runat="server" Text="Save" />
                                        <asp:Button CssClass="btn btn-success" ID="btnSubmitSec1" onClick="Submit_Request" ValidationGroup="SCAR_Request" runat="server" Text="Submit" />
                                    </div>
                                </div>
                            
                        </div>
                    </div>
                </div><!--End of Section 1-->
            </div>
                <br />
                <h4>SCAR Response Form</h4>
                <!-- GET BACK TO THIS LATER 
                <asp:LinkButton CssClass="btn btn-default" ID="btnExpand" Text="Expand all" runat="server" />
                <asp:LinkButton CssClass="btn btn-default" ID="btnCollapse" Text="Collapse all" runat="server" />
                              
                <script type="text/javascript">
                    $('.closeall').click(function () {
                        $('.panel-collapse.in')
                          .collapse('hide');
                    });
                    $('.openall').click(function () {
                        $('.panel-collapse:not(".in")')
                          .collapse('show');
                    });
                </script>
 
                <br /><br />
                -->
                <!--Section 2-->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion1" href="#collapse2">
                                Section 2
                            </a>
                        </h4>
                    </div>
                    
                    <div id="collapse2" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion2">
                                    <div class="form-group">
                                        <label for="lstRootCause" class="col-lg-3 control-label">Root Cause Option</label>
                                        <div class="col-lg-8">
                                            <asp:DropDownList CssClass="form-control" ID="lstRootCause" runat="server">

                                            </asp:DropDownList>
                                            <asp:Label ID="lblRootCause" runat="server" />
                                        </div>
                                        <br /><br />
                                    </div>
                                <!--S0-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse3">
                                                S0 - Overall Summary (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse3" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtOverallSummary" class="col-lg-3 control-label">S0 - Overall Summary</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterOverallSummary">
                                                        </div>
                                                       <asp:TextBox CssClass="form-control" ID="txtOverallSummary" placeholder="Overall Summary"  TextMode="MultiLine" Rows="3" runat="server"/>
                                                        <asp:Label ID="lblOverallSummary" runat="server" />
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S0-->
                                
                                <!--S1-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse4">
                                                S1 - Problem Verification (Max 1000 characters)
                                            </a>
                                                <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse4" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtProbVerification" class="col-lg-3 control-label">S1 - Problem Verification</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterProbVerification">
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtProbVerification" placeholder="Problem Verification" TextMode="MultiLine" Rows="3" runat="server" />
                                                        <asp:Label ID="lblProbVerification" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="rdbPreAlert" class="col-lg-3 control-label">Status</label>
                                                    <div class="col-lg-8">
                                                        <div class="radio">
                                                            <label>
                                                                <asp:RadioButtonList ID="rdbProbVerificationStatus" runat="server">  
                                                                    <asp:ListItem Value ="Valid">Valid</asp:ListItem>
                                                                    <asp:ListItem Value ="Invalid">Invalid</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:Label ID="lblProbVerificationStatus" runat="server" />
                                                            </label>
                                                            </div>
                                                        
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                   
                                </div><!--End of S1-->
                                <!--S2-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse5">
                                                S2 - Containment Action (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse5" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtContainmentAction" class="col-lg-3 control-label">S21 - Containment Action</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterContainmentAction">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtContainmentAction" name="testGroup" placeholder="Containment Action" runat="server" />
                                                        <asp:Label ID="lblContainmentAction" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="cldS2ImplementationDate" class="col-lg-3 control-label">S22 - Implementation Date</label>
                                                    <div class="col-lg-8">
                                                        <asp:TextBox CssClass="form-control" ID="txtS2ImplementationDate" TextMode="Date" runat="server" />
                                                        <asp:Label ID="lblS2ImplementationDate" runat="server" />
                                                    <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtS2ResponsiblePerson" class="col-lg-3 control-label">S23 - Responsible Person</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterS2ResponsiblePerson">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtS2ResponsiblePerson" placeholder="Responsible Person" runat="server" />
                                                        <asp:Label ID="lblS2ResponsiblePerson" runat="server" />
                                                       <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtContainmentResult" class="col-lg-3 control-label">S24 - Containment Result</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterContainmentResult">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtContainmentResult" placeholder="Containment Result" runat="server" />
                                                        <asp:Label ID="lblContainmentResult" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="lstScreeningArea" class="col-lg-3 control-label">Screening Area</label>
                                                    <div class="col-lg-8">
                                                        <asp:ListBox CssClass="form-control" ID="lstScreeningArea" SelectionMode="Multiple" runat="server">
                                                            <asp:ListItem>Production</asp:ListItem>
                                                            <asp:ListItem>FGI</asp:ListItem>
                                                            <asp:ListItem>Remaining units with customers</asp:ListItem>
                                                            <asp:ListItem>N/A</asp:ListItem>
                                                            <asp:ListItem>Units in Field (with other customers)</asp:ListItem>
                                                        </asp:ListBox>
                                                        <asp:Label ID="lblScreeningArea" runat="server" />
                                                        <span class="help-block">Hold <em>shift</em> to select more than one option if necessary</span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="chkS2TrackActionItem" class="col-lg-3 control-label">Track Action Item?</label>
                                                    <div class="col-lg-8">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkS2TrackActionItem" runat="server" /> 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S2-->
                                <!--S3-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse6">
                                                S3 - Failure Analysis (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse6" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="lstRootCause" class="col-lg-3 control-label">S31 - Failure Analysis</label>
                                                    <div class="col-lg-8">
                                                        <asp:DropDownList CssClass="form-control" ID="lstFailureAnalysis" runat="server">

                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblFailureAnalysis" runat="server" />
                                                       <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtFailureResult" class="col-lg-3 control-label">S32 - Failure Analysis Results</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterFailureAnalysisResult">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtFailureResult" placeholder="Failure Analysis Results" TextMode="MultiLine" Rows="3" runat="server" />
                                                        <asp:Label ID="lblFailureResult" runat="server" />
                                                        
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S3-->
                                <!--S4-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse7">
                                                S4 - Root Cause (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse7" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtMan" class="col-lg-3 control-label">Man</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterMan">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtMan" placeholder="Man" runat="server" />
                                                        <asp:Label ID="lblMan" runat="server" />
                                                       <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtMethod" class="col-lg-3 control-label">Method</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterMethod">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtMethod" placeholder="Method" runat="server" />
                                                        <asp:Label ID="lblMethod" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtMaterial" class="col-lg-3 control-label">Material</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterMaterial">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtMaterial" placeholder="Material" runat="server" />
                                                        <asp:Label ID="lblMaterial" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtMachine" class="col-lg-3 control-label">Machine</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterMachine">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtMachine" placeholder="Machine" runat="server" />
                                                        <asp:Label ID="lblMachine" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S4-->
                                <!--S5-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse8">
                                                S5 - Corrective Action (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse8" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtCorrectiveAction" class="col-lg-3 control-label">S51 - Corrective Action</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterCorrectiveAction">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtCorrectiveAction" placeholder="Corrective Action" TextMode="MultiLine" Rows="3" runat="server" />
                                                        <asp:Label ID="lblCorrectiveAction" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="cldS5ImplementationDate" class="col-lg-3 control-label">S52 - Implementation Date</label>
                                                    <div class="col-lg-8">
                                                        <asp:TextBox CssClass="form-control" ID="txtS5ImplementationDate" TextMode="Date" runat="server" />
                                                        <asp:Label ID="lblS5ImplementationDate" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtS5ResponsiblePerson" class="col-lg-3 control-label">S53 - Responsible Person</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterS5ResponsiblePerson">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtS5ResponsiblePerson" placeholder="Responsible Person" runat="server" />
                                                        <asp:Label ID="lblS5ResponsiblePerson" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="chkS5TrackActionItem" class="col-lg-3 control-label">Track Action Item?</label>
                                                    <div class="col-lg-8">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkS5TrackActionItem" runat="server" /> 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S5-->
                                <!--S6-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse9">
                                                S6 - Permanent Corrective Action (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse9" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtPermanentCA" class="col-lg-3 control-label">S61 - Permanent Corrective Action</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterPermanentCA">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtPermanentCA" placeholder="Permanent Corrective Action" TextMode="MultiLine" Rows="3" runat="server" />
                                                       <asp:Label ID="lblPermanentCA" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="cldS6ImplementationDate" class="col-lg-3 control-label">S62 - Implementation Date</label>
                                                    <div class="col-lg-8">
                                                        <asp:TextBox CssClass="form-control" ID="txtS6ImplementationDate" TextMode="Date" runat="server" />
                                                        <asp:Label ID="lblS6ImplementationDate" runat="server" />
                                                        <br />
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtS6ResponsiblePerson" class="col-lg-3 control-label">S63 - Responsible Person</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterS6ResponsiblePerson">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtS6ResponsiblePerson" placeholder="Responsible Person" runat="server" />
                                                        <asp:Label ID="lblS6ResponsiblePerson" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="chkS6TrackActionItem" class="col-lg-3 control-label">Track Action Item?</label>
                                                    <div class="col-lg-8">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkS6TrackActionItem" runat="server" /> 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S6-->
                                <!--S7-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse10">
                                                S7 - Verify Effectiveness of Corrective Actions Results (Max 1000 characters)
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse10" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="txtVerifyCA" class="col-lg-3 control-label">S71 - Verify Effectiveness of Corrective Actions</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterVerifyCA">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtVerifyCA" placeholder="Verify Effectiveness of Corrective Actions" TextMode="MultiLine" Rows="3" runat="server" />
                                                        <asp:Label ID="lblVerifyCA" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="cldS7ImplementationDate" class="col-lg-3 control-label">S72 - Implementation Date (Start of Monitoring)</label>
                                                    <div class="col-lg-8">
                                                        <asp:TextBox CssClass="form-control" ID="txtS7ImplementationDate" TextMode="Date" runat="server" />
                                                        <asp:Label ID="lblS7ImplementationDate" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtS7ResponsiblePerson" class="col-lg-3 control-label">S73 - Responsible Person</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterS7ResponsiblePerson">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtS7ResponsiblePerson" placeholder="Responsible Person" runat="server" />
                                                        <asp:Label ID="lblS7ResponsiblePerson" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtVerifier" class="col-lg-3 control-label">S74 - Verifier</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterVerifier">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtVerifier" placeholder="Verifier" runat="server" />
                                                         <asp:Label ID="lblVerifier" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtVerifierEmail" class="col-lg-3 control-label">S75 - Verifier Email</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterVerifierEmail">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtVerifierEmail" placeholder="Verifier Email" runat="server" />
                                                         <asp:Label ID="lblVerifierEmail" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label id="lblfortxtVerifyCAResults" runat="server" for="txtVerifyCAresults" class="col-lg-3 control-label">S76 - Verify Effectiveness of Corrective Actions Result</label>
                                                    <div class="col-lg-8">
                                                        <div id="counterVerifyCAResult">
                                                            
                                                        </div>
                                                        <asp:TextBox CssClass="form-control" ID="txtVerifyCAResult" placeholder="Verify Effectiveness of Corrective Actions Result" TextMode="MultiLine" Rows="3" runat="server" />
                                                         <asp:Label ID="lblVerifyCAResult" runat="server" />
                                                        <br />
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div><!--End of S7-->

                                <!-- 8D Approval -->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse11">
                                               8D Approval Attachments
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse11" class="panel-collapse collapse in">
                                        <div class="panel-body">
                                        <div class="form-group">
                                        <label for="uploadFile" class="col-lg-3 control-label">Upload Attachment(s)</label>
                                        <div class="col-lg-8">
                                            <asp:FileUpload ID="uploadFile" AllowMultiple="true" runat="server" onchange="showFiles()" />
                                            <span class="help-block">Maximum file size: 15MB / 5 file(s)</span>
                                            <asp:Label ID="showFileNames" runat="server"/>
                                            <asp:Button ID="btnUpload" CssClass="btn btn-primary" OnClick="Upload_Files" Text="Upload Files" runat="server" />
                                            
                                        </div>
                                            
                                    </div>
                                        
                                <div class="form-group">
                                    <asp:GridView CssClass="table table-condensed" ID="AttachmentsGridView" runat="server" 
                                        DataSourceID="AttachmentsSqlDataSource" 
                                        AutoGenerateColumns="False"
                                        AutoGenerateDeleteButton="True" 
                                        OnRowDeleting="AttachmentsGridView_RowDeleting"
                                        DataKeyNames="scar_no, file_name" BorderColor="#CCCCCC" Width="100%"
            BorderStyle="Solid" BorderWidth="1px">
                                        <HeaderStyle Height="30px" BackColor="#01385B" ForeColor="White" Font-Size="15px" BorderColor="#CCCCCC"
                BorderStyle="Solid" BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="file_name" 
                                                HeaderText="File Name" SortExpression="FileName" />
                                            
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="AttachmentsSqlDataSource" runat="server"
                                        SelectCommand="SELECT scar_no, file_name
                                            FROM dbo.SCAR_attachments "
                                            
                                        DeleteCommand="Delete from dbo.SCAR_attachments where scar_no = 
                                            @scar_no AND file_name = @file_name"
                                        ConnectionString="<%$ ConnectionStrings:JabilDatabase %>">
                                        <DeleteParameters>
                                            <asp:Parameter Name="scar_no" />
                                            
                                        </DeleteParameters>
                                    </asp:SqlDataSource>
                                </div>
                                    <div class="form-group">
                                        <label for="chk8Dapproval" class="col-lg-3 control-label">Require 8D Approval?</label>
                                        <div class="col-lg-8">
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chk8Dapproval" data-toggle="modal" data-target="#8Dapproval" runat="server" />
                                                </label>
                                                <!-- Modal -->
                                                <div class="modal fade" id="8Dapproval" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title">Select Respective WCM and QM</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="form-group">
                                                                    <label for="txtWCM" class="col-lg-4 control-label"><strong>Work Cell Manager</strong></label>
                                                                    <div class="col-lg-7">
                                                                        <asp:DropDownList ID="lstWCM" CssClass="form-control" runat="server">
                                                                           
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="txtQM" class="col-lg-4 control-label"><strong>Quality Manager</strong></label>
                                                                    <div class="col-lg-7">
                                                                        <asp:DropDownList ID="lstQM" CssClass="form-control" runat="server">
                                                                            
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <br />
                                                            </div>
                                                            <div class="modal-footer">
                                                                <asp:Button ID="btnRequestApproval" CssClass="btn btn-primary" OnClick="Click_Request_Approval" Text="Request Approval" runat="server" />
                                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div><!--End of modal-->
                                            </div>
                                        </div>

                                        <!-- 8D Approval Count -->
                                        <div class="form-group">
                                    <asp:GridView CssClass="table table-condensed" ID="ApprovalGridView" runat="server"  
                                        AutoGenerateColumns="False"
                                         BorderColor="#CCCCCC" Width="100%" BorderStyle="Solid" BorderWidth="1px">
                                        <HeaderStyle Height="30px" BackColor="#01385B" ForeColor="White" Font-Size="15px" BorderColor="#CCCCCC"
                BorderStyle="Solid" BorderWidth="1px" />
                                        <Columns>
                                            <asp:BoundField DataField="WCM Approval Status" HeaderText="WCM Approval Status" />
                                            <asp:BoundField DataField="WCM Comment" HeaderText="WCM Comment" />
                                            <asp:BoundField DataField="QM Approval Status" HeaderText="QM Approval Status" />
                                            <asp:BoundField DataField="QM Comment" HeaderText="QM Comment" />
                                        </Columns>
                                    </asp:GridView>
                                </div><!-- End of 8D Approval Count -->


                                    </div>
                                    </div>
                                  </div>
                                </div><!--End of 8D Approval-->

                                <br />
                                    <div class="form-group">
                                        <label for="lstDefectMode" class="col-lg-3 control-label">Defect Mode</label>
                                        <div class="col-lg-8">
                                            <asp:DropDownList CssClass="form-control" ID="lstDefectMode" runat="server">
                                                <asp:ListItem>Please Select Defect Mode</asp:ListItem>
                                                <asp:ListItem Value="Spoil">Spoil</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblDefectMode" runat="server" />
                                        </div>
                                    </div>
                                <br /><br />

                                    
                                    <div class="form-group">
                                        <label for="chkMOR" class="col-lg-3 control-label">MOR Calculated?</label>
                                        <div class="col-lg-8">
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chkMOR" runat="server" /> 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                <div class="form-group">
                                        <label for="lstCurrentStatus" class="col-lg-3 control-label">SCAR Status</label>
                                        <div class="col-lg-4">
                                            <asp:DropDownList CssClass="form-control" ID="lstCurrentStatus" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4">
                                                <asp:Button CssClass="btn btn-default" ID="btnChangeStatus" OnClick="Change_SCAR_Status" runat="server" Text="Change Status" />
                                            <br /><br />
                                        </div>
                                    </div>
                                
                                    <div class="form-group">
                                        <div class="col-lg-8 col-lg-offset-3">
                                            <asp:Button CssClass="btn btn-primary" ID="btnSave2" OnClientClick="Validate()" ValidationGroup="SCAR_Response" OnClick="Save_Response" runat="server" Text="Save to Database" />
                                            <asp:Button CssClass="btn btn-success" ID="btnSubmit" runat="server" OnClientClick="Validate()" ValidationGroup="SCAR_Response" OnClick="Submit_Response" Text="Send to Client" />
                                        </div>
                                    </div>
                            </div>
                            
                        </div>
                    </div>
                </div><!--End of Section 2-->
           
            </form>
        </div><!--/.col-md-12-->
    </div>
</div>

 <!-- Characters count function -->
<script type="text/javascript">
    $(function () {
        //Specifying the Character Count control explicitly
        
        $("[id*=txtOverallSummary]").MaxLength(
        {
            MaxLength: 1000,
            CharacterCountControl: $('#counterOverallSummary')
        });

        $("[id*=txtProbVerification]").MaxLength(
        {
            MaxLength: 1000,
            CharacterCountControl: $('#counterProbVerification')
        });

        $("[id*=txtContainmentAction]").MaxLength(
        {
            
            MaxLength: 600,
            CharacterCountControl: $('#counterContainmentAction')
        });

        $("[id*=txtS2ResponsiblePerson]").MaxLength(
        {

            MaxLength: 100,
            CharacterCountControl: $('#counterS2ResponsiblePerson')
        });

        $("[id*=txtContainmentResult]").MaxLength(
        {

            MaxLength: 300,
            CharacterCountControl: $('#counterContainmentResult')
        });
        
        $("[id*=txtFailureResult]").MaxLength(
        {

            MaxLength: 1000,
            CharacterCountControl: $('#counterFailureAnalysisResult')
        });

        $("[id*=txtMan]").MaxLength(
        {

            MaxLength: 250,
            CharacterCountControl: $('#counterMan')
        });

        $("[id*=txtMethod]").MaxLength(
        {

            MaxLength: 250,
            CharacterCountControl: $('#counterMethod')
        });

        $("[id*=txtMaterial]").MaxLength(
        {

            MaxLength: 250,
            CharacterCountControl: $('#counterMaterial')
        });

        $("[id*=txtMachine]").MaxLength(
        {

            MaxLength: 250,
            CharacterCountControl: $('#counterMachine')
        });

        $("[id*=txtCorrectiveAction]").MaxLength(
        {

            MaxLength: 900,
            CharacterCountControl: $('#counterCorrectiveAction')
        });

        $("[id*=txtS5ResponsiblePerson]").MaxLength(
        {

            MaxLength: 100,
            CharacterCountControl: $('#counterS5ResponsiblePerson')
        });

        $("[id*=txtPermanentCA]").MaxLength(
        {

            MaxLength: 900,
            CharacterCountControl: $('#counterPermanentCA')
        });

        $("[id*=txtS6ResponsiblePerson]").MaxLength(
       {

           MaxLength: 100,
           CharacterCountControl: $('#counterS6ResponsiblePerson')
       });

        $("[id*=txtVerifyCA]").MaxLength(
       {

           MaxLength: 450,
           CharacterCountControl: $('#counterVerifyCA')
       });
        $("[id*=txtS7ResponsiblePerson]").MaxLength(
       {

           MaxLength: 100,
           CharacterCountControl: $('#counterS7ResponsiblePerson')
       });
        $("[id*=txtVerifier]").MaxLength(
       {

           MaxLength: 100,
           CharacterCountControl: $('#counterVerifier')
       });
        $("[id*=txtVerifierEmail]").MaxLength(
      {

          MaxLength: 50,
          CharacterCountControl: $('#counterVerifierEmail')
      });
        $("[id*=txtVerifyCAResult]").MaxLength(
      {

          MaxLength: 300,
          CharacterCountControl: $('#counterVerifyCAResult')
      });
    });

</script>

<script type="text/javascript" >
    function Validate() {

        var msg = "";
        var bIsValid = true;
        var uploadedFile = document.getElementById("<%=uploadFile.ClientID %>");
       
        var totalFileSize = 0;
        for (var ii = 0; ii < uploadedFile.files.length; ii++)
        {
            totalFileSize = totalFileSize + uploadedFile.files[ii].size;
        }
        if (totalFileSize > 15000000)
        {
            msg += "File Size is limited to 15 MB!";
            bIsValid = false;
        }
        
        if (!bIsValid) {
            alert(msg);
            return false;
        }
        //On Success
        return true;
    }
    </script>
 

    <script type="text/javascript">
        function showFiles() {
            var x = document.getElementById("<%=uploadFile.ClientID%>");
         var txt = "";
         if ('files' in x) {
             if (x.files.length == 0) {
                 txt = "Select one or more files.";
             } else {
                 for (var i = 0; i < x.files.length; i++) {
                     txt += "<strong>" + (i + 1) + " .</strong>";
                     var file = x.files[i];
                     if ('name' in file) {
                         txt += file.name + "<br>";
                     }
                 }
             }
         }
         else {
             if (x.value == "") {
                 txt += "Select one or more files.";
             } else {
                 txt += "The files property is not supported by your browser!";
                 txt += "<br>The path of the selected file: " + x.value; // If the browser does not support the files property, it will return the path of the selected file instead. 
             }
         }
         document.getElementById("<%=showFileNames.ClientID %>").innerHTML = txt;
     }


        function ShowMessage(scar_no, message) {
            alert(message);
            if (scar_no != 0)
            {
                window.location.href = 'scars_forms.aspx?scar_no=' + scar_no;
            }
        }
</script>

</asp:Content>
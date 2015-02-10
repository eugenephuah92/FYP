<%@ Page Title="Auto SCAR &amp; TAT - Home" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/scars_forms.aspx.cs" Inherits="Engineer_scars_forms" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <h4>SCAR Request Form</h4>
            <div class="panel-group" id="accordion1">
                <!--Section 1-->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion1" href="#collapse1">
                                <span class="glyphicon glyphicon-plus"></span>
                                <strong>Section 1</strong>
                            </a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="carNo" class="col-lg-3 control-label">Car No:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="carNo" placeholder="Car No" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="carRev" class="col-lg-3 control-label">Car Revision:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="carRev" placeholder="Car Revision" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="carType" class="col-lg-3 control-label">Car Type:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="carType" placeholder="Car Type" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="preAlert" class="col-lg-3 control-label">Pre Alert:</label>
                                    <div class="col-lg-8">
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButton ID="preAlertYes" Text="Yes" GroupName="AlertRadio" runat="server" />
                                                
                                            </label>
                                            </div>
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButton ID="preAlertNo" Text="No" GroupName="AlertRadio" runat="server" />
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="relatedCarNo" class="col-lg-3 control-label">Related Car No:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="relatedCarNo" placeholder="Related Car No" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="relatedCarRev" class="col-lg-3 control-label">Related Car Rev:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="relatedCarRev" placeholder="Related Car Rev" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="originator" class="col-lg-3 control-label">Originator:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="originator" placeholder="Originator" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="recurrence" class="col-lg-3 control-label">Recurrence (Ref.No.):</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="recurrence" placeholder="Recurrence (Ref.No.)" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="supplierContact" class="col-lg-3 control-label">Supplier Contact:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox CssClass="form-control" ID="supplierContact" placeholder="SupplierContact" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="supplierEmail" class="col-lg-3 control-label">Supplier Email:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="supplierEmail" placeholder="Supplier Email">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="issuedDate" class="col-lg-3 control-label">Issued Date:</label>
                                    <div class="col-lg-8">
				                        <input type="text" class="form-control" id="issuedDate" placeholder="Issued Date">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="originatorDept" class="col-lg-3 control-label">Originator Department:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="originatorDept" placeholder="Originator Department">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="originatorContact" class="col-lg-3 control-label">Originator Contact:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="originatorContact" placeholder="Originator Contact">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="partNo" class="col-lg-3 control-label">Part No:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="partNo" placeholder="Part No.">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="partDesc" class="col-lg-3 control-label">Part Description:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="partDesc" placeholder="Part Description">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="businessUnit" class="col-lg-3 control-label">Business Unit:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="businessUnit" placeholder="Business Unit">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="deptPL" class="col-lg-3 control-label">Dept / PL:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="deptPL" placeholder="Dept / PL">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="commodity" class="col-lg-3 control-label">Commodity:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="commodity" placeholder="Commodity">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="defectQty" class="col-lg-3 control-label">Defect Quantity:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="defectQty" placeholder="Defect Quantity">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="defectType" class="col-lg-3 control-label">Defect Type:</label>
                                    <div class="col-lg-8">
                                        <select class="form-control" id="defectType">
                                            <option selected>Please select defect type</option>
                                            <option>Non-Performance</option>
                                            <option>Performance</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="nonConformity" class="col-lg-3 control-label">Non-Conformity Reported:</label>
                                    <div class="col-lg-8">
                                        <textarea class="form-control" rows="2" id="nonConformity" placeholder="Non-Conformity Reported"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="rejectReason" class="col-lg-3 control-label">Reject Reason for Previous Revision:</label>
                                    <div class="col-lg-8">
                                        <textarea class="form-control" rows="2" id="rejectReason" placeholder="Reject Reason for Previous Revision"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="dateClose" class="col-lg-3 control-label">Expected Date Close:</label>
                                    <div class="col-lg-8">
                                        <input type="text" class="form-control" id="dateClose" placeholder="Expected Date Close">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8 col-lg-offset-3">
                                        <button class="btn btn-primary">Save</button>
                                        <button type="submit" class="btn btn-success">Submit</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div><!--End of Section 1-->
                <br />
                <h4>SCAR Response Form</h4>
                <!--Section 2-->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion1" href="#collapse2">
                                <span class="glyphicon glyphicon-minus"></span>
                                <strong>Section 2</strong>
                            </a>
                        </h4>
                    </div>
                    <div id="collapse2" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion2">
                                <form class="form-horizontal pad10" action="#" method="post">
                                    <div class="form-group">
                                        <label for="rootCause" class="col-lg-3 control-label">Root Cause Option:</label>
                                        <div class="col-lg-8">
                                            <select class="form-control" id="rootCause">
                                                <option selected>Please select root cause</option>
                                                <option>Production - Assembly</option>
                                                <option>Production - Machine</option>
                                                <option>Production - Micro</option>
                                                <option>Production - Micro (CM)</option>
                                                <option>Production - MTA</option>
                                                <option>Production - MTA (CM)</option>
                                                <option>Production - Planning</option>
                                                <option>Production - Process</option>
                                                <option>Production - Test</option>
                                            </select>
                                        </div>
                                    </div>
                                </form>
                                <!--S0-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse3">
                                                <strong>S0 - Overall Summary</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse3" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="overallSummary" class="col-lg-3 control-label">S0 - Overall Summary:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="3" id="overallSummary" placeholder="Overall Summary"></textarea>
                                                        <span class="help-block">Max 1000 characters</span>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S0-->
                                <!--S1-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse4">
                                                <strong>S1 - Problem Verification</strong>
                                            </a>
                                                <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse4" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="probVerification" class="col-lg-3 control-label">S1 - Problem Verification:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="3" id="probVerification" placeholder="Problem Verification"></textarea>
                                                        <span class="help-block">Max 1000 characters</span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="preAlert" class="col-lg-3 control-label">Status:</label>
                                                    <div class="col-lg-8">
                                                        <div class="radio">
                                                            <label>
                                                                <input type="radio" name="optionsRadios" id="status1" value="valid" checked=""> Valid
                                                            </label>
                                                            </div>
                                                        <div class="radio">
                                                            <label>
                                                                <input type="radio" name="optionsRadios" id="status2" value="invalid"> Invalid 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S1-->
                                <!--S2-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse5">
                                                <strong>S2 - Containment Action</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse5" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="containmentAction" class="col-lg-3 control-label">S21 - Containment Action:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="containmentAction" placeholder="Containment Action">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="implementationDate" class="col-lg-3 control-label">S22 - Implementation Date:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="S2implementationDate" placeholder="Implementation Date">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="responsiblePerson" class="col-lg-3 control-label">S23 - Responsible Person:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="responsiblePerson" placeholder="Responsible Person">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="containmentResult" class="col-lg-3 control-label">S24 - Containment Result:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="containmentResult" placeholder="Containment Result">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="screeningArea" class="col-lg-3 control-label">Screening Area:</label>
                                                    <div class="col-lg-8">
                                                        <select multiple class="form-control" id="screeningArea">
                                                            <option>Production</option>
                                                            <option>FGI</option>
                                                            <option>Remaining units with customers</option>
                                                            <option>N/A</option>
                                                            <option>Units in Field (with other customers)</option>
                                                        </select>
                                                        <span class="help-block">Hold <em>shift</em> to select more than one option if necessary</span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="S2TrackActionItem" class="col-lg-3 control-label">Track Action Item?</label>
                                                    <div class="col-lg-8">
                                                        <div class="checkbox">
                                                            <label>
                                                                <input type="checkbox" id="S2TrackActionItem"> 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S2-->
                                <!--S3-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse6">
                                                <strong>S3 - Failure Analysis</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse6" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="rootCause" class="col-lg-3 control-label">S31 - Failure Analysis:</label>
                                                    <div class="col-lg-8">
                                                        <select class="form-control" id="failureAnalysis">
                                                            <option selected>Please select failure analysis</option>
                                                            <option>Visual</option>
                                                            <option>Electrical</option>
                                                            <option>Physical</option>
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="failureResult" class="col-lg-3 control-label">S32 - Failure Analysis Results:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="3" id="failureResult" placeholder="Failure Analysis Results"></textarea>
                                                        <span class="help-block">Max 1000 characters</span>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S3-->
                                <!--S4-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse7">
                                                <strong>S4 - Root Cause</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse7" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="man" class="col-lg-3 control-label">Man:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="man" placeholder="Man">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="method" class="col-lg-3 control-label">Method:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="method" placeholder="Method">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="material" class="col-lg-3 control-label">Material:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="material" placeholder="Material">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="machine" class="col-lg-3 control-label">Machine:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="machine" placeholder="Machine">
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S4-->
                                <!--S5-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse8">
                                                <strong>S5 - Corrective Action</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse8" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="correctiveAction" class="col-lg-3 control-label">S51 - Corrective Action:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="2" id="correctiveAction" placeholder="Corrective Action"></textarea>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="implementationDate" class="col-lg-3 control-label">S52 - Implementation Date:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="S5implementationDate" placeholder="Implementation Date">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="responsiblePerson" class="col-lg-3 control-label">S53 - Responsible Person:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="responsiblePerson2" placeholder="Responsible Person">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="S5TrackActionItem" class="col-lg-3 control-label">Track Action Item?</label>
                                                    <div class="col-lg-8">
                                                        <div class="checkbox">
                                                            <label>
                                                                <input type="checkbox" id="S5TrackActionItem"> 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S5-->
                                <!--S6-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse9">
                                                <strong>S6 - Permanent Corrective Action</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse9" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="permanentCA" class="col-lg-3 control-label">S61 - Permanent Corrective Action:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="2" id="permanentCA" placeholder="Permanent Corrective Action"></textarea>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="implementationDate" class="col-lg-3 control-label">S62 - Implementation Date:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="S6implementationDate" placeholder="Implementation Date">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="responsiblePerson" class="col-lg-3 control-label">S63 - Responsible Person:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="responsiblePerson3" placeholder="Responsible Person">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="S6TrackActionItem" class="col-lg-3 control-label">Track Action Item?</label>
                                                    <div class="col-lg-8">
                                                        <div class="checkbox">
                                                            <label>
                                                                <input type="checkbox" id="S6TrackActionItem"> 
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S6-->
                                <!--S7-->
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapse10">
                                                <strong>S7 - Verify Effectiveness of Corrective Actions Results</strong>
                                            </a>
                                            <i class="indicator glyphicon glyphicon-chevron-down pull-right"></i>
                                        </h4>
                                    </div>
                                    <div id="collapse10" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <form class="form-horizontal pad10" action="#" method="post">
                                                <div class="form-group">
                                                    <label for="verifyCA" class="col-lg-3 control-label">S71 - Verify Effectiveness of Corrective Actions:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="2" id="verifyCA" placeholder="Verify Effectiveness of Corrective Actions"></textarea>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="implementationDate" class="col-lg-3 control-label">S72 - Implementation Date (Start of Monitoring):</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="S7implementationDate" placeholder="Implementation Date">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="responsiblePerson" class="col-lg-3 control-label">S73 - Responsible Person:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="responsiblePerson4" placeholder="Responsible Person">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="verifier" class="col-lg-3 control-label">S74 - Verifier:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="verifier" placeholder="Verifier">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="verifierEmail" class="col-lg-3 control-label">S75 - Verifier Email:</label>
                                                    <div class="col-lg-8">
                                                        <input type="text" class="form-control" id="verifierEmail" placeholder="Verifier Email">
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="verifyCAresults" class="col-lg-3 control-label">S76 - Verify Effectiveness of Corrective Actions Result:</label>
                                                    <div class="col-lg-8">
                                                        <textarea class="form-control" rows="2" id="verifyCAresult" placeholder="Verify Effectiveness of Corrective Actions Result"></textarea>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div><!--End of S7-->

                                <form class="form-horizontal pad10" action="#" method="post">
                                    <div class="form-group">
                                        <label for="uploadFile" class="col-lg-3 control-label">Upload Attachment(s):</label>
                                        <div class="col-lg-8">
                                            <input type="file" class="filestyle" data-icon="false">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="8Dapproval" class="col-lg-3 control-label">Require 8D Approval?</label>
                                        <div class="col-lg-8">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" data-toggle="modal" data-target="#8Dapproval">
                                                </label>
                                                <!-- Modal -->
                                                <div class="modal fade" id="8Dapproval" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel">Select Respective WCM and QM</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="form-group">
                                                                    <label for="WCM" class="col-lg-4 control-label"><strong>Work Cell Manager:</strong></label>
                                                                    <div class="col-lg-7">
                                                                        <select class="form-control" id="WCM">
                                                                            <option selected>Please select respective WCM</option>
                                                                            <option>Eugene Phuah</option>
                                                                            <option>Lee Boon Chung</option>
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="QM" class="col-lg-4 control-label"><strong>Quality Manager:</strong></label>
                                                                    <div class="col-lg-7">
                                                                        <select class="form-control" id="QM">
                                                                            <option selected>Please select respective QM</option>
                                                                            <option>Wee Ai Leng</option>
                                                                            <option>Evon Tan</option>
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-success">Submit</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div><!--End of modal-->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="MOR" class="col-lg-3 control-label">MOR Calculated?</label>
                                        <div class="col-lg-8">
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" id="MOR"> 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-8 col-lg-offset-3">
                                            <button class="btn btn-primary">Save</button>
                                            <button type="submit" class="btn btn-success">Submit</button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div><!--End of Section 2-->
            </div>
        </div><!--/.col-md-12-->


    </div>
</div>
</asp:Content>
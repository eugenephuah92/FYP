<%@ Page Title="Auto SCAR &amp; TAT - 8D Approval" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" CodeFile="~/Manager/8DApproval.aspx.cs" Inherits="Manager_8Dapproval" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<!-- 8D Approval Page for managers: Allow Managers to view SCAR record, download attachments, approve or reject requests -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
                <!--Section 1-->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SCAR Details for #100001
                    </div>
                        <div class="panel-body">
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">Section 1</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Car No:</th>
                                        <td>P-SOQAP-133772</td>
                                    </tr>
                                    <tr>
                                        <th>Car Revision:</th>
                                        <td>C</td>
                                    </tr>
                                    <tr>
                                        <th>Car Type:</th>
                                        <td>OQA</td>
                                    </tr>
                                    <tr>
                                        <th>Pre Alert:</th>
                                        <td>Yes</td>
                                    </tr>
                                    <tr>
                                        <th>Related Car No:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Related Car No:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Related Car Rev:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Originator:</th>
                                        <td>Hairul Azam bin Hassan</td>
                                    </tr>
                                    <tr>
                                        <th>Recurrence (Ref.No.):</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th>Supplier Contact:</th>
                                        <td>SharmilaDevi Marimuthu</td>
                                    </tr>
                                    <tr>
                                        <th>Supplier Email:</th>
                                        <td>sharmiladevi_marimuthu@jabil.com</td>
                                    </tr>
                                    <tr>
                                        <th>Issued Date:</th>
                                        <td>04/10/2013</td>
                                    </tr>
                                    <tr>
                                        <th>Originator Department:</th>
                                        <td>WBU-CTD</td>
                                    </tr>
                                    <tr>
                                        <th>Originator Contact:</th>
                                        <td>604-6807891</td>
                                    </tr>
                                    <tr>
                                        <th>Part No:</th>
                                        <td>E5072A</td>
                                    </tr>
                                    <tr>
                                        <th>Part Description:</th>
                                        <td>Athena</td>
                                    </tr>
                                    <tr>
                                        <th>Business Unit:</th>
                                        <td>CTD</td>
                                    </tr>
                                    <tr>
                                        <th>Dept / PL:</th>
                                        <td>PLWN-DTA</td>
                                    </tr>
                                    <tr>
                                        <th>Commodity:</th>
                                        <td>Box Build</td>
                                    </tr>
                                    <tr>
                                        <th>Defect Quantity:</th>
                                        <td>1</td>
                                    </tr>
                                    <tr>
                                        <th>Defect Type:</th>
                                        <td>Performance</td>
                                    </tr>
                                    <tr>
                                        <th>Non-Conformity Reported:</th>
                                        <td>Touch panel mal-function. Unit serial# MY51200563. 5x5 serial# E05072-60101-021-79-1247-00007.</td>
                                    </tr>
                                    <tr>
                                        <th>Reject Reason for Previous Revision:</th>
                                        <td>Returned FA unit found similar issue.</td>
                                    </tr>
                                    <tr>
                                        <th>Expected Date Close:</th>
                                        <td>01/09/2014</td>
                                    </tr>
                                </tbody>
                            </table> 
                            <br />
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">Section 2</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">Root Cause Option:</th>
                                        <td>Production - Process</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S0 - Overall Summary</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S0 - Overall Summary:</th>
                                        <td>Touch panel malfunction.</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S1 - Problem Verification</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S1 - Problem Verification:</th>
                                        <td>Touch panel mal-function.<br />
                                            Conclusion given by Supplier after the complete Failure Analysis is the problem arise due to the Chemical Penetration.
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Status:</th>
                                        <td>Valid</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S2 - Containment Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S21 - Containment Action:</th>
                                        <td>Rescreen the remaining unit for the similar defect.</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S22 - Implementation Date:</th>
                                        <td>10/04/2013</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S23 - Responsible Person</th>
                                        <td>Wai Moh</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S24 - Containment Result:</th>
                                        <td>NDF</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Screening Area:</th>
                                        <td>Production</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Track Action Item:</th>
                                        <td><span class="glyphicon glyphicon-ok"></span></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S3 - Failure Analysis</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S31 - Failure Analysis:</th>
                                        <td>Electrical</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S32 - Failure Analysis Results:</th>
                                        <td>N/A</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S4 - Root Cause</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">Man:</th>
                                        <td>Conclusion given by Supplier after the complete Failure Analysis is the problem arise due to the Chemical Penetration.<br />
                                            This penetration may have been induced by a liquid saturation thru the substrate edges.
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Method:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Material:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Machine:</th>
                                        <td>N/A</td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S5 - Corrective Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S51 - Corrective Action:</th>
                                        <td>This is the isolated case. To further monitor.</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S52 - Implementation Date:</th>
                                        <td>05/12/2014</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S53 - Responsible Person</th>
                                        <td>Wai Moh / Kin Tat</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Track Action Item:</th>
                                        <td><span class="glyphicon glyphicon-ok"></span></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S6 - Permanent Corrective Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S61 - Permanent Corrective Action:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S62 - Implementation Date:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S63 - Responsible Person</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Track Action Item:</th>
                                        <td><span class="glyphicon glyphicon-ok"></span></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-condensed">
                                <thead style="background-color:antiquewhite">
                                    <tr>
                                        <th colspan="2">S7 - Verify Effectiveness of Corrective Actions Results</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="tablestyle1">S71 - Verify Effectiveness of Corrective Actions:</th>
                                        <td>To further monitor for next 3 months.</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S72 - Implementation Date (Start of Monitoring):</th>
                                        <td>05/12/2014</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S73 - Responsible Person:</th>
                                        <td>Agilent - Wai Moh / Kin Tat</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S74 - Verifier:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S75 - Verifier Email:</th>
                                        <td>N/A</td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S76 - Verify Effectiveness of Corrective Actions Result:</th>
                                        <td>No similar issue encountered during monitoring period.</td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="uploadFile" class="col-lg-3 control-label">Attachments:</label>
                                    <a class="btn btn-link" href="#" data-toggle="modal" data-target=".bs-example-modal-lg" aria-labelledby="myModalLabelName" aria-hidden="true">8D.pptx</a>
                                    <!--Large Modal-->
                                    <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                        <div class="modal-dialog modal-lg">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title">Preview of 8D.pptx</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group">
                                                        <asp:Image runat="server" ImageUrl="../images/ppt.jpg"/>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="btnDownloadAttachment" CssClass="btn btn-success" runat="server" Text="Download"/>
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div><!--End of Modal-->
                                    <div class="col-lg-8 col-lg-offset-3">
                                        <asp:Button ID="btnRemoveAttachment" CssClass="btn btn-danger" runat="server" Text="Remove File"/>
                                        <asp:Button ID="btnUploadAttachment" CssClass="btn btn-primary" runat="server" Text="Upload File"/>
                                    </div> 
                                </div>
                                <div class="form-group">
                                    <label for="approval" class="col-lg-3 control-label">8D Approval: </label>
                                    <div class="col-lg-8">
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButton ID="rdbApprovalRadio" runat="server" Text="Approve" GroupName="approvalRequest" />
                                            </label>
                                        </div>
                                        <div class="radio">
                                            <label>
                                               <asp:RadioButton ID="rdbRejectRadio" runat="server" Text="Reject" GroupName="approvalRequest" />
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtComment" class="col-lg-3 control-label">Comment:</label>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtComment" CssClass="form-control" Rows="3" TextMode="MultiLine" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8 col-lg-offset-3">
                                        <br />
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" Text="Submit" runat="server" />
                                    </div>
                                </div>
                            </form>   
                        </div>
                    </div>
        </div>
    </div><!--/.col-md-12-->
</div>
</asp:Content>
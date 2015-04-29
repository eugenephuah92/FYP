<%@ Page Title="Auto SCAR &amp; TAT - 8D Approval" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" Inherits="Manager_8Dapproval" Codebehind="~/Manager/8DApproval.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<!-- 8D Approval Page for managers: Allow Managers to view SCAR record, download attachments, approve or reject requests -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
                <!--Section 1-->
            <h4>8D Approval</h4><asp:Label runat="server" ID="ProcessedMessage"/>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SCAR Details
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
                                        <td><asp:Label ID="lblCarNo" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Car Revision:</th>
                                        <td><asp:Label ID="lblCarRev" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Car Type:</th>
                                        <td><asp:Label ID="lblCarType" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Pre Alert:</th>
                                        <td><asp:Label ID="lblPreAlert" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Related Car No:</th>
                                        <td><asp:Label ID="lblRelatedCarNo" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Related Car Rev:</th>
                                        <td><asp:Label ID="lblRelatedCarRev" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Originator:</th>
                                        <td><asp:Label ID="lblOriginator" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Recurrence (Ref.No.):</th>
                                        <td><asp:Label ID="lblRecurrence" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Supplier Contact:</th>
                                        <td><asp:Label ID="lblSupplierContact" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Supplier Email:</th>
                                        <td><asp:Label ID="lblSupplierEmail" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Issued Date:</th>
                                        <td><asp:Label ID="lblIssuedDate" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Originator Department:</th>
                                        <td><asp:Label ID="lblOriginatorDept" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Originator Contact:</th>
                                        <td><asp:Label ID="lblOriginatorContact" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Part No:</th>
                                        <td><asp:Label ID="lblPartNo" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Part Description:</th>
                                        <td><asp:Label ID="lblPartDescription" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Business Unit:</th>
                                        <td><asp:Label ID="lblBusinessUnit" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Dept / PL:</th>
                                        <td><asp:Label ID="lblDeptPL" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Commodity:</th>
                                        <td><asp:Label ID="lblCommodity" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Defect Quantity:</th>
                                        <td><asp:Label ID="lblDefectQuantity" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Defect Type:</th>
                                        <td><asp:Label ID="lblDefectType" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Non-Conformity Reported:</th>
                                        <td><asp:Label ID="lblNonConformityReported" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Reject Reason for Previous Revision:</th>
                                        <td><asp:Label ID="lblRejectReason" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th>Expected Date Close:</th>
                                        <td><asp:Label ID="lblExpectedDateClose" runat="server" /></td>
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
                                        <td><asp:Label ID="lblRootCause" runat="server" /></td>
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
                                        <td><asp:Label ID="lblOverallSummary" runat="server" /></td>
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
                                        <td><asp:Label ID="lblProbVerification" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Status:</th>
                                        <td><asp:Label ID="lblProbVerificationStatus" runat="server" /></td>
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
                                        <td><asp:Label ID="lblContainmentAction" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S22 - Implementation Date:</th>
                                        <td><asp:Label ID="lblS2ImplementationDate" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S23 - Responsible Person</th>
                                        <td><asp:Label ID="lblS2ResponsiblePerson" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S24 - Containment Result:</th>
                                        <td><asp:Label ID="lblContainmentResult" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Screening Area:</th>
                                        <td>
                                            <asp:CheckBox ID="chkProduction" runat="server" Text ="Production" Enabled="false"/>
                                            <br />
                                            <asp:CheckBox ID="chkFGI" runat="server" Text ="FGI" Enabled="false"/>
                                            <br />
                                            <asp:CheckBox ID="chkRemainingUnits" runat="server" Text ="Remaining units with customers" Enabled="false"/>
                                            <br />
                                            <asp:CheckBox ID="chkNA" runat="server" Text ="N/A" Enabled="false"/>
                                            <br />
                                            <asp:CheckBox ID="chkUnitInField" runat="server" Text ="Units in Field (with other customers)" Enabled="false"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Track Containment Action Item:</th>
                                        <td><asp:CheckBox ID="chkS2TrackActionItem" runat="server" Enabled="false"/></td>
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
                                        <td><asp:Label ID="lblFailureAnalysis" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S32 - Failure Analysis Results:</th>
                                        <td><asp:Label ID="lblFailureResult" runat="server" /></td>
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
                                        <td><asp:Label ID="lblMan" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Method:</th>
                                        <td><asp:Label ID="lblMethod" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Material:</th>
                                        <td><asp:Label ID="lblMaterial" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Machine:</th>
                                        <td><asp:Label ID="lblMachine" runat="server" /></td>
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
                                        <td><asp:Label ID="lblCorrectiveAction" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S52 - Implementation Date:</th>
                                        <td><asp:Label ID="lblS5ImplementationDate" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S53 - Responsible Person</th>
                                        <td><asp:Label ID="lblS5ResponsiblePerson" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Track Action Item:</th>
                                        <td><asp:CheckBox ID="chkS5TrackActionItem" runat="server" Enabled="false"/></td>
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
                                        <td><asp:Label ID="lblPermanentCA" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S62 - Implementation Date:</th>
                                        <td><asp:Label ID="lblS6ImplementationDate" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S63 - Responsible Person</th>
                                        <td><asp:Label ID="lblS6ResponsiblePerson" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">Track Action Item:</th>
                                        <td><asp:CheckBox ID="chkS6TrackActionItem" runat="server" Enabled="false"/></td>
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
                                        <td><asp:Label ID="lblVerifyCA" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S72 - Implementation Date (Start of Monitoring):</th>
                                        <td><asp:Label ID="lblS7ImplementationDate" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S73 - Responsible Person:</th>
                                        <td><asp:Label ID="lblS7ResponsiblePerson" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S74 - Verifier:</th>
                                        <td><asp:Label ID="lblVerifier" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S75 - Verifier Email:</th>
                                        <td><asp:Label ID="lblVerifierEmail" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <th class="tablestyle1">S76 - Verify Effectiveness of Corrective Actions Result:</th>
                                        <td><asp:Label ID="lblVerifyCAResult" runat="server" /></td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                                <div class="form-group">
                                        <label for="uploadFile" class="col-lg-3 control-label">Upload Attachment(s)</label>
                                        <div class="col-lg-8">
                                            <asp:FileUpload ID="uploadFile" AllowMultiple="true" runat="server" />
                                            <span class="help-block">Maximum file size: 15MB / 5 file(s)</span>
                                        </div>
                                    </div>
                                <div class="form-group" style="padding-left:10px;">
                                    <asp:GridView CssClass="table table-condensed" ID="AttachmentsGridView" runat="server" 
                                        DataSourceID="AttachmentsSqlDataSource" 
                                        AutoGenerateColumns="False"
                                        AutoGenerateDeleteButton="True" 
                                        OnRowDeleting="AttachmentsGridView_RowDeleting"
                                        DataKeyNames="id" BorderColor="#CCCCCC" Width="100%"
            BorderStyle="Solid" BorderWidth="1px">
                                        <HeaderStyle Height="30px" BackColor="AntiqueWhite" Font-Size="15px" BorderColor="#CCCCCC"
                BorderStyle="Solid" BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="file_name" 
                                                HeaderText="File Name" SortExpression="FileName" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("file_path") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="AttachmentsSqlDataSource" runat="server"
                                        SelectCommand="SELECT id, file_name, file_path
                                            FROM dbo.SCAR_Request "
                                            
                                        DeleteCommand="Delete from dbo.SCAR_Request where id = 
                                            @id" 
                                        ConnectionString="<%$ ConnectionStrings:JabilDatabase %>">
                                        <DeleteParameters>
                                            <asp:Parameter Name="scar_id" />
                                            
                                        </DeleteParameters>
                                    </asp:SqlDataSource>
                                        </div>      
                                <div class="form-group">
                                    <label for="approval" class="col-lg-3 control-label">8D Approval: </label>
                                    <div class="col-lg-8">
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButtonList ID="rdbApproval" runat="server">
                                                    <asp:ListItem Value="Approve">Approve</asp:ListItem>
                                                    <asp:ListItem Value="Reject">Reject</asp:ListItem>
                                                </asp:RadioButtonList>
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
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-success" OnClick="Submit_Approval_Form" Text="Submit" runat="server" />
                                    </div>
                                </div>   
                        </div>
                    </div>
        </div>
    </div><!--/.col-md-12-->
</div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - Add New Defect Modes" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Codebehind="~/Admin/add_new_defect_modes.aspx.cs" Inherits="Admin_add_new_defect_modes" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Defect Mode Page for admin: Allows Admin to add new defect modes -->
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Add New Defect Modes
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <form class="form-horizontal pad10" action="#" method="post" >
                            <div class="form-group">
                                <label for="txtNewDefectCode" class="col-lg-2 control-label">New Defect Code</label>
                                <div class="col-lg-10">
                                    <asp:TextBox CssClass="form-control" ID="txtNewDefectCode" runat="server" placeholder="New Defect Code" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCode" runat="server"
                                        ErrorMessage="* Defect Code is a required field" ForeColor="Red" ControlToValidate="txtNewDefectCode" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidatorDefectCode" runat="server" Operator="DataTypeCheck" Type="Integer" 
                                        ErrorMessage="* Defect Code ONLY accept whole numbers (0 - 9)" ForeColor="Red" ControlToValidate="txtNewDefectCode" Display="Dynamic"></asp:CompareValidator>
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="txtNewIPCCode" class="col-lg-2 control-label">New IPC Code</label>
                                <div class="col-lg-10">
                                    <asp:TextBox CssClass="form-control" ID="txtNewIPCCode" runat="server" placeholder="New IPC Code" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorIPCCode" runat="server" 
                                        ErrorMessage="* IPC Code ONLY accept numbering format (Eg: 1.1)" ForeColor="Red" ControlToValidate="txtNewIPCCode" ValidationExpression="^[0-9]+(\.[0-9]{1,2})+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="txtNewDefectName" class="col-lg-2 control-label">New Defect Name</label>
                                <div class="col-lg-10">
                                    <asp:TextBox CssClass="form-control" ID="txtNewDefectName" runat="server" placeholder="New Defect Name" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectName" runat="server"
                                        ErrorMessage="* Defect Name is a required field" ForeColor="Red" ControlToValidate="txtNewDefectName" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>     
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="lstNewDefectGroup" class="col-lg-2 control-label">New Defect Group</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList CssClass="form-control" ID="lstNewDefectGroup" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectGroup" runat="server"
                                        ErrorMessage="* Defect Group is a required field" ForeColor="Red" ControlToValidate="lstNewDefectGroup" InitialValue="0"></asp:RequiredFieldValidator>
                                </div> 
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="lstNewDefectCategory" class="col-lg-2 control-label">New Defect Category</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList CssClass="form-control" ID="lstNewDefectCategory" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCategory" runat="server"
                                        ErrorMessage="* Defect Category is a required field" ForeColor="Red" ControlToValidate="lstNewDefectCategory" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="txtNewDefectDescription" class="col-lg-2 control-label">New Defect Description</label>
                                <div class="col-lg-10">
                                    <asp:TextBox CssClass="form-control" ID="txtNewDefectDescription" runat="server" placeholder="New Defect Description" TextMode="MultiLine" Rows="5" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectDesc" runat="server"
                                        ErrorMessage="* Defect Description is a required field" ForeColor="Red" ControlToValidate="txtNewDefectDescription"></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button CssClass="btn btn-success" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

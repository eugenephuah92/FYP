<%@ Page Title="Auto SCAR &amp; TAT - Add New Defect Modes" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_add_new_defect_modes" CodeBehind="~/Admin/add_new_defect_modes.aspx.cs" %>
<%@ Import Namespace="System.IO" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Defect Mode Page for admin: Allows Admin to add new defect modes -->
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <!-- Add New Defect Modes panel -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Add New Defect Modes
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <asp:Label ID="txtCheck" runat="server" ForeColor="Red" style="padding-left: 5pt" />

                        <div class="form-group">
                            <label for="txtNewDefectCode" class="col-lg-2 control-label">New Defect Code</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtNewDefectCode" runat="server" placeholder="New Defect Code" AutoPostBack="true" OnTextChanged="txtNewDefectCode_TextChanged" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCode" runat="server" ErrorMessage="* Defect Code is a required field" 
                                    ForeColor="Red" ControlToValidate="txtNewDefectCode" ValidationGroup="DFM"></asp:RequiredFieldValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <label for="txtNewIPCCode" class="col-lg-2 control-label">New IPC Code</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtNewIPCCode" runat="server" placeholder="New IPC Code (Can leave it blank if none)" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorIPCCode" runat="server" ErrorMessage="* IPC Code ONLY accept numbering format (Eg: 1.1.1)" 
                                    ForeColor="Red" ControlToValidate="txtNewIPCCode" ValidationExpression="^[0-9]+(\.[0-9]{1,2})+(\.[0-9]{1,2})?$" Display="Dynamic" ValidationGroup="DFM"></asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="CustomValidatorIPCCode" runat="server" ErrorMessage="* IPC Code entered is already existed in the database" 
                                    ForeColor="Red" ControlToValidate="txtNewIPCCode" OnServerValidate="CustomValidatorIPCCode_ServerValidate" Display="Dynamic" ValidationGroup="DFM"></asp:CustomValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <label for="txtNewDefectName" class="col-lg-2 control-label">New Defect Name</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtNewDefectName" runat="server" placeholder="New Defect Name" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectName" runat="server" ErrorMessage="* Defect Name is a required field" 
                                    ForeColor="Red" ControlToValidate="txtNewDefectName" Display="Dynamic" ValidationGroup="DFM"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidatorDefectName" runat="server" ErrorMessage="* Defect Name entered is already existed in the database" 
                                    ForeColor="Red" ControlToValidate="txtNewDefectName" OnServerValidate="CustomValidatorDefectName_ServerValidate" Display="Dynamic" ValidationGroup="DFM"></asp:CustomValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <label for="lstNewDefectGroup" class="col-lg-2 control-label">New Defect Group</label>
                            <div class="col-lg-10">
                                <asp:DropDownList CssClass="form-control" ID="lstNewDefectGroup" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectGroup" runat="server" ErrorMessage="* Please select Defect Group" 
                                    ForeColor="Red" ControlToValidate="lstNewDefectGroup" InitialValue="0" ValidationGroup="DFM"></asp:RequiredFieldValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <label for="lstNewDefectCategory" class="col-lg-2 control-label">New Defect Category</label>
                            <div class="col-lg-10">
                                <asp:DropDownList CssClass="form-control" ID="lstNewDefectCategory" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCategory" runat="server" ErrorMessage="* Please select Defect Category" 
                                    ForeColor="Red" ControlToValidate="lstNewDefectCategory" InitialValue="0" ValidationGroup="DFM"></asp:RequiredFieldValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <label for="txtNewDefectDescription" class="col-lg-2 control-label">New Defect Description</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtNewDefectDescription" runat="server" placeholder="New Defect Description" TextMode="MultiLine" Rows="5" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectDesc" runat="server" ErrorMessage="* Defect Description is a required field" 
                                    ForeColor="Red" ControlToValidate="txtNewDefectDescription" ValidationGroup="DFM"></asp:RequiredFieldValidator>
                            </div>
                            <br /><br />
                        </div>                
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button CssClass="btn btn-success" ID="btnSubmitDFM" runat="server" Text="Submit" OnClick="btnSubmitDFM_Click" ValidationGroup="DFM" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Add New IPC Code panel -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Add New IPC Code (To Existing Defect Code)
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <div class="form-group">
                            <label for="lstDefectCode" class="col-lg-2 control-label">Defect Code</label>
                            <div class="col-lg-10">
                                <asp:DropDownList CssClass="form-control" ID="lstDefectCode" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDC" runat="server" ErrorMessage="* Please select Defect Code" 
                                    ForeColor="Red" ControlToValidate="lstDefectCode" InitialValue="0" ValidationGroup="IPC"></asp:RequiredFieldValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <label for="txtIPCCode" class="col-lg-2 control-label">New IPC Code</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtIPCCode" runat="server" placeholder="New IPC Code" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorIPC" runat="server" ErrorMessage="* New IPC Code is a required field" 
                                    ForeColor="Red" ControlToValidate="txtIPCCode" Display="Dynamic" ValidationGroup="IPC"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorIPC" runat="server" ErrorMessage="* IPC Code ONLY accept numbering format (Eg: 1.1.1)" 
                                    ForeColor="Red" ControlToValidate="txtIPCCode" ValidationExpression="^[0-9]+(\.[0-9]{1,2})+(\.[0-9]{1,2})?$" Display="Dynamic" ValidationGroup="IPC"></asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="CustomValidatorIPC" runat="server" ErrorMessage="* IPC Code entered is already existed in the database" 
                                    ForeColor="Red" ControlToValidate="txtIPCCode" OnServerValidate="CustomValidatorIPCCode_ServerValidate" Display="Dynamic" ValidationGroup="IPC"></asp:CustomValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button CssClass="btn btn-success" ID="btnSubmitIPC" runat="server" Text="Submit" OnClick="btnSubmitIPC_Click" ValidationGroup="IPC" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="messageBox" title="jQuery MessageBox In Asp.net" style="display: none;">
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>

    <script type="text/javascript">
        //Alert box
        function messageBox(message) {
            $("#messageBox").dialog({
                modal: true,
                height: 300,
                width: 520,
                title: "Save Status",
                open: function () {
                    var markup = message;
                    $(this).html(markup);
                },
                buttons: {
                    OK: function () {
                        $(this).dialog("close");
                        window.location = "add_new_defect_modes.aspx";
                    }
                },
            });
            return false;
        }
    </script>
</asp:Content>

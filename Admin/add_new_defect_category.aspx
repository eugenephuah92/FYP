<%@ Page Title="Auto SCAR &amp; TAT - Add New Defect Category / Defect Group" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_add_new_defect_category" CodeBehind="~/Admin/add_new_defect_category.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Defect Category Page for admin: Allows Admin to add new defect category -->
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <!-- Add New Defect Category panel -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Add New Defect Category 
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <div class="form-group">
                            <label for="txtNewDefectCategory" class="col-lg-2 control-label">New Defect Category</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtNewDefectCategory" runat="server" placeholder="New Defect Category" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCategory" runat="server"
                                    ErrorMessage="* Defect Category is a required field" ForeColor="Red" ControlToValidate="txtNewDefectCategory" ValidationGroup="DC" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorDefectCategory" runat="server" 
                                    ErrorMessage="* Defect Category ONLY accept alphabets (letters)" ForeColor="Red" ControlToValidate="txtNewDefectCategory" ValidationExpression="^[a-zA-Z ]+$" ValidationGroup="DC" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="CustomValidatorDefectCategory" runat="server" 
                                    ErrorMessage="* Defect Category entered is already existed in the database" ForeColor="Red" ControlToValidate="txtNewDefectCategory" OnServerValidate="ValidateDefectCategory" ValidationGroup="DC" Display="Dynamic"></asp:CustomValidator>
                            </div>
                            <br /><br />
                        </div>                     
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button CssClass="btn btn-success" ID="btnSubmitDC" runat="server" Text="Submit" OnClick="btnSubmitDC_Click" ValidationGroup="DC" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Add New Defect Group panel -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Add New Defect Group
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <div class="form-group">
                            <label for="txtNewDefectGroup" class="col-lg-2 control-label">New Defect Group</label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtNewDefectGroup" runat="server" placeholder="New Defect Group" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectGroup" runat="server"
                                    ErrorMessage="* Defect Group is a required field" ForeColor="Red" ControlToValidate="txtNewDefectGroup" ValidationGroup="DG" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidatorDefectGroup" runat="server" 
                                    ErrorMessage="* Defect Group entered is already existed in the database" ForeColor="Red" ControlToValidate="txtNewDefectGroup" OnServerValidate="ValidateDefectGroup" ValidationGroup="DG" Display="Dynamic"></asp:CustomValidator>
                            </div>
                            <br /><br />
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button CssClass="btn btn-success" ID="btnSubmitDG" runat="server" Text="Submit" OnClick="btnSubmitDG_Click" ValidationGroup="DG" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="messageBox" title="jQuery MessageBox In Asp.net" style="display: none;">
                </div>
            </div>
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
                    }
                },

            });
            return false;
        }
    </script>
</asp:Content>

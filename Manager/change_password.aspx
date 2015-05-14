<%@ Page Title="Auto SCAR &amp; TAT - Change Password" Language="C#" MasterPageFile="~/Manager.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Manager_change_password" Codebehind="~/Manager/change_password.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Change Password for engineer: Allows manager to own change account password -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Change Password
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" method="post">
                                        <div class="form-group">
                                            <label for="txtOldPassword" class="col-lg-2 control-label">Old Password</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox CssClass="form-control" ID="txtOldPassword" runat="server" placeholder="Old Password" TextMode="Password" />
                                                <asp:RequiredFieldValidator ID="vldOldPassword" runat="server" ControlToValidate="txtOldPassword" ValidationGroup="Password" ForeColor="Red" ErrorMessage="Please enter the old password!" />
                                            </div>
                                            <br /><br />
                                        </div>
                                        <div class="form-group">
                                            <label for="txtNewPassword" class="col-lg-2 control-label">New Password</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox CssClass="form-control" ID="txtNewPassword" runat="server" placeholder="New Password" TextMode="Password" />
                                                <asp:RequiredFieldValidator ID="vldNewPassword" runat="server" ControlToValidate="txtNewPassword" ValidationGroup="Password" ForeColor="Red" ErrorMessage="Please enter the new password!" />
                                            </div>
                                            <br /><br />
                                        </div>
                                        <div class="form-group">
                                            <label for="txtConfirmNewPassword" class="col-lg-2 control-label">Confirm New Password</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox CssClass="form-control" ID="txtConfirmNewPassword" runat="server" placeholder="Confirm New Password" TextMode="Password" />
                                                <asp:CompareValidator ID="vldComparePassword" runat="server" ControlToCompare="txtNewPassword" ValidationGroup="Password" ControlToValidate="txtConfirmNewPassword" ErrorMessage="Passwords do not match!" ForeColor="Red" />
                                            </div>
                                            <br /><br />
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-10 col-lg-offset-2">
                                                <asp:Button CssClass="btn btn-success" ID="btnChangePassword" ValidationGroup="Password" runat="server" OnClick="Click_Change_Password" Text="Change Password" />
                                            </div>
                                        </div>
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>

<script type="text/javascript">
    function ShowMessage(message) {
        alert(message);
    }
</script>
</asp:Content>
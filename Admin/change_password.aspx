<%@ Page Title="Auto SCAR &amp; TAT - Change Password" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/change_password.aspx.cs" Inherits="Admin_change_password" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Change Password for admin: Allows Admin to own change account password -->
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
                                    <label for="txtEmail" class="col-lg-2 control-label">Email Address</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Email Address"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtOldPassword" class="col-lg-2 control-label">Old Password</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNewDefectCode" runat="server" placeholder="Old Password" TextMode="Password" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtNewPassword" class="col-lg-2 control-label">New Password</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNewPassword" runat="server" placeholder="New Password" TextMode="Password" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtConfirmNewPassword" class="col-lg-2 control-label">Confirm New Password</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtConfirmNewPassword" runat="server" placeholder="Confirm New Password" TextMode="Password" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <asp:Button CssClass="btn btn-success" ID="btnChangePassword" runat="server" Text="Change Password" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>
</asp:Content>
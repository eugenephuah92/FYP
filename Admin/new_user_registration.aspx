<%@ Page Title="Auto SCAR &amp; TAT - New User Registration" Language="C#" MasterPageFile="~/Admin.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Admin_new_user_registration" Codebehind="~/Admin/new_user_registration.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- New User Registration for admin: Allows Admin to create new users -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            New User Registration
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="txtEmployeeName" class="col-lg-2 control-label">Employee Name</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmployeeName" runat="server" placeholder="Employee Name"/>
                                        <asp:RequiredFieldValidator ID="vldEmployeeName" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Please Enter the Employee Name!" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeeID" class="col-lg-2 control-label">Employee ID</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmployeeID" runat="server" placeholder="Employee ID"/>
                                        <asp:RequiredFieldValidator ID="vldEmployeeID" runat="server" ControlToValidate="txtEmployeeID" ErrorMessage="Please Enter the Employee ID!" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeeEmail" class="col-lg-2 control-label">Employee Email</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmployeeEmail" TextMode="Email" runat="server" placeholder="Employee Email"/>
                                        <asp:RequiredFieldValidator ID="vldEmployeeEmail" runat="server" ControlToValidate="txtEmployeeEmail" ErrorMessage="Please Enter the Employee Email!" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeePosition" class="col-lg-2 control-label">Employee Position</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmployeePosition" runat="server" placeholder="Employee Position"/>
                                        <asp:RequiredFieldValidator ID="vldEmployeePosition" runat="server" ControlToValidate="txtEmployeePosition" ErrorMessage="Please Enter the Employee Position!" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="lstPrivilege" class="col-lg-2 control-label">User Privilege</label>
                                    <div class="col-lg-10">
                                        <asp:DropDownList ID="lstPrivilege" runat="server" CssClass="form-control">
                                            <asp:ListItem>Please Select Privilege</asp:ListItem>
                                            <asp:ListItem Value="Admin">Administrator</asp:ListItem>
                                            <asp:ListItem Value="Manager">Manager</asp:ListItem>
                                            <asp:ListItem Value="Engineer">Engineer</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="vldPrivilege" runat="server" ControlToValidate="lstPrivilege" ErrorMessage="Please Select the User Privilege!" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <asp:Button CssClass="btn btn-success" ID="btnCreateNewUser" runat="server" Text="Create New User" OnClick="Create_New_User"/>
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
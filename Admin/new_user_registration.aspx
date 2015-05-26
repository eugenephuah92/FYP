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
                                    <div id="messageBox" title="jQuery MessageBox In Asp.net" style="display: none;">
                                    
                                    </div>
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
        // For Confirmation
        $(function () {

            $("#<%=btnCreateNewUser.ClientID%>").on("click", function (event) {
             event.preventDefault();
             $("#messageBox").dialog({
                 resizable: false,
                 title: "Create New User Confirmation",
                 open: function () {
                     var markup = "Are you sure you want to create a new user?";
                     $(this).html(markup);
                 },
                 height: 200,

                 modal: true,
                 buttons: {
                     Ok: function () {
                         $(this).dialog("close");
                         __doPostBack($('#<%= btnCreateNewUser.ClientID %>').attr('name'), '');
                         },
                         Cancel: function () {
                             $(this).dialog("close");

                         }
                     }
                 });
         });
     });


         // For Alert
         function messageBox(message) {
             $("#messageBox").dialog({
                 modal: true,
                 height: 300,
                 width: 500,
                 title: "Create New User Status",
                 open: function () {
                     var markup = message;
                     $(this).html(markup);
                 },
                 buttons: {
                     Close: function () {
                         $(this).dialog("close");
                     }
                 },

             });
             return false;
         }
    </script>
</asp:Content>
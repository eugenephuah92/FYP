<%@ Page Title="Auto SCAR &amp; TAT - New User Registration" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/new_user_registration.aspx.cs" Inherits="Admin_new_user_registration" %>

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
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeeEmail" class="col-lg-2 control-label">Employee Email</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmployeeEmail" runat="server" placeholder="Employee Email"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeePosition" class="col-lg-2 control-label">Employee Position</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmployeePosition" runat="server" placeholder="Employee Position"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <asp:Button CssClass="btn btn-success" ID="btnCreateNewUser" runat="server" Text="Create New User" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>
</asp:Content>
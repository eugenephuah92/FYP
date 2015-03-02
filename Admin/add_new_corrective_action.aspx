<%@ Page Title="Auto SCAR &amp; TAT - Add New Corrective Action" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/add_new_corrective_action.aspx.cs" Inherits="Admin_add_new_corrective_action" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Corrective Action Page for admin: Allows Admin to add new corrective action -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Add New Corrective Action / Preventive Action
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="txtNewCorrectiveAction" class="col-lg-2 control-label">New Corrective / Preventive Action</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNewCorrectiveAction" runat="server" placeholder="New Corrective / Preventive Action" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="cldSCARReqDate" class="col-lg-2 control-label">SCAR Request Date</label>
                                    <div class="col-lg-10">
                                        <input type="date" class="form-control" id="cldSCARReqDate" runat="server" />
                                        <br />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="cldSCARCompDate" class="col-lg-2 control-label">SCAR Completion Date</label>
                                    <div class="col-lg-10">
                                        <input type="date" class="form-control" id="cldSCARCompDate" runat="server" />
                                        <br />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtSearchCarNo" class="col-lg-2 control-label">CAR Number</label>
                                    <div class="col-lg-10">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtSearchCarNo" placeholder="Search For CAR Number" runat="server" />
                                            <span class="input-group-btn">
                                                <asp:LinkButton CssClass="btn btn-default" ID="btnSearch" runat="server">
                                                       <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="lstAssignedQE" class="col-lg-2 control-label">Assigned Quality Engineer</label>
                                    <div class="col-lg-10">
                                        <asp:DropDownList CssClass="form-control" ID="lstAssignedQE" runat="server">
                                            <asp:ListItem>Please Select QE</asp:ListItem>
                                            <asp:ListItem>James Tomkins</asp:ListItem>
                                            <asp:ListItem>Alan Hudson</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <asp:Button CssClass="btn btn-success" ID="btnSubmit" runat="server" Text="Submit" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>
</asp:Content>
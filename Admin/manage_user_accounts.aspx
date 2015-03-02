<%@ Page Title="Auto SCAR &amp; TAT - Manage User Account" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/manage_user_accounts.aspx.cs" Inherits="Admin_manage_user_accounts" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Manage User Account
                </div>
                <div class="panel-body">
                	<div class="col-md-6">
                	    <p style="padding-top:10pt"> | <asp:HyperLink runat="server" ID="show10records" Text="Show 10 records" Target="_self" NavigateUrl="#" /> | <asp:HyperLink runat="server" ID="HyperLink1" Text="Show 50 records" Target="_self" NavigateUrl="#" /> | 
                    </div>
                            <div class="row">
                                <div class="col-md-3"  style="padding-top:10pt">
                                    <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server">  
                                        <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                    </asp:DropDownList>
                            	</div>
                                <div class="col-md-3"  style="padding-top:10pt">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="searchTxt" runat="server" placeholder="Search For..." />
                                        <span class="input-group-btn">
                                            <asp:LinkButton CssClass="btn btn-default" ID="btnSearch" runat="server">
                                                <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                                <!-- Advanced Search -->
                                <div class="panel-group" id="accordion" role="tablist">
                                    <div class="col-md-6 pull-right">
                                        <div class="panel-heading" role="tab" id="headingOne">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne" style="text-decoration:none">
                                                + Advanced Search
                                            </a>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse out" role="tabpanel" aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-6"  style="padding-top:10pt">
                                                        <asp:DropDownList CssClass="form-control" ID="test" runat="server">  
                                                            <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                                        </asp:DropDownList>
                            	                    </div>
                                                    <div class="col-md-6"  style="padding-top:10pt">
                                                        <div class="input-group">
                                                            <asp:TextBox CssClass="form-control" ID="searchTxt2" runat="server" placeholder="Search for..." />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton CssClass="btn btn-default" ID="btnSearch2" runat="server">
                                                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                                </asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6"  style="padding-top:10pt">
                                                        <asp:DropDownList CssClass="form-control" ID="lstFilter3" runat="server">  
                                                            <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                                        </asp:DropDownList>
                            	                    </div>
                                                    <div class="col-md-6"  style="padding-top:10pt">
                                                        <div class="input-group">
                                                            <asp:TextBox CssClass="form-control" ID="searchTxt3" runat="server" placeholder="Search for..." />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton CssClass="btn btn-default" ID="btnSearch3" runat="server">
                                                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                                </asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </p>
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">
                                    	<thead>
                                        	<tr>
                                                <th>Employee Name</th>
                                                <th>Employee Email</th>
                                                <th>Employee Position</th>
                                                <th>Actions</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td>John Watson</td>
                                                <td>watson.john@jabil.com</td>
                                                <td>Quality Manager</td>
                                                <td>
                                                    <a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true" class="btn btn-primary">Edit</a>
                                                    <asp:Button CssClass="btn btn-danger" runat="server" ID="btnRemove" Text="Remove" />
                                                </td>
                                          	</tr>
                                        </tbody>
  									</table>
                                </div>
                            </div>  
                        <nav style="padding-right:30pt">
                                <ul class="pagination pull-right">
                                    <li>
                                        <a href="#" aria-label="Previous">
                                            <span aria-hidden="true">&laquo;</span>
                                        </a>
                                    </li>
                                    <li><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li>
                                        <a href="#" aria-label="Next">
                                            <span aria-hidden="true">&raquo;</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>                                 
                        <!-- Modal -->
                        <div class="modal fade" id="myModalName" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:100pt">
                            <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title">User Information</h4>
                                </div>
                                <div class="modal-body" style="padding-top:30pt">
                                    <div class="form-group">
                                        <label for="txtEmployeeName" class="col-lg-4 control-label">Employee Name</label>
                                        <div class="row">
                                            <div class="col-lg-7">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtEmployeeName" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>                                       
                                        </div>
                                        <label for="txtEmployeeEmail" class="col-lg-4 control-label">Employee Email</label>
                                        <div class="row">
                                            <div class="col-lg-7">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtEmployeeEmail" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <label for="txtEmployeePosition" class="col-lg-4 control-label">Employee Position</label>
                                        <div class="row">
                                            <div class="col-lg-7">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtEmployeePosition" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <label for="txtEmployeePassword" class="col-lg-4 control-label">Employee Password</label>
                                        <div class="row">
                                            <div class="col-lg-7">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtEmployeePassword" CssClass="form-control" runat="server" TextMode="Password"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSave" CssClass="btn btn-primary" Text="Save" runat="server" />
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - Manual Escalation" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/manual_escalation.aspx.cs" Inherits="Admin_manual_escalation" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Manual Escalation Page for admin: Allows admin to manually escalate a particular SCAR issue -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Manual Escalation
                </div>
                <div class="panel-body">
                	<div class="col-md-6">
                	    <p style="padding-top:10pt"> | <a href="#">Show 10 records</a> | <a href="#">Show 50 records</a> | 
                    </div>
                    	<form action="#" method="post">
                            <div class="row">
                                <div class="col-md-3" style="padding-top:10pt"> 
                                    <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server">
                                        <asp:ListItem>Please Select Filter</asp:ListItem>
                                    </asp:DropDownList> 
                            	</div>
                                <div class="col-md-3" style="padding-top:10pt">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtSearch" placeholder="Search For" runat="server" />
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
                        </form>
                        </p>
                    
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">
                                    	<thead>
                                        	<tr>
                                                <th style="padding-left:30pt">CAR Number</th>
                                                <th style="padding-left:30pt">Assigned QE Name</th>
                                                <th style="padding-left:30pt">Level of Escalation</th>
                                                <th style="padding-left:30pt">Days Till Next Escalation</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td style="padding-left:30pt">P-SOQANP-140916</td>
                                                <td style="padding-left:30pt">
                                                	<a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true">Doe</a>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="myModalName" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:100pt">
                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    <h4 class="modal-title">Assign New Quality Engineer</h4>
                                                                </div>
                                                                <div class="modal-body" style="padding-top:30pt">
                                                                    <div class="form-group">
                                                                        <label for="lstQE" class="col-lg-4 control-label">New Quality Engineer</label>
                                                                        <div class="col-lg-7">
                                                                            <asp:DropDownList ID="lstQE" runat="server" CssClass="form-control">
                                                                                <asp:ListItem>Please Select QE</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <asp:Button ID="btnChangeQE" CssClass="btn btn-primary" Text="Save Change" runat="server" />
                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="padding-left:30pt">
                                                	<button type="button" class="btn btn-xs" data-toggle="modal" data-target="#myModal" aria-labelledby="myModalLabel" aria-hidden="true">1</button>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:100pt">
                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                          	        <h4 class="modal-title">New Escalation Level</h4>                        
                                                                </div>
                                                                <div class="modal-body" style="padding-top:30pt">
                                                                    <div class="form-group">                                                            
                                                                        <label for="lstEscalationLevel" class="col-lg-4 control-label">New Escalation Level</label>
                                                                        <div class="col-lg-7">
                                                                            <asp:DropDownList ID="lstEscalationLevel" runat="server" CssClass="form-control">
                                                                                <asp:ListItem>Please Select Escalation Level</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                          	        </div>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <asp:button ID="btnChangeEscLevel" CssClass="btn btn-primary" Text="Save Change" runat="server" /> 
                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="padding-left:30pt">4</td>
                                          	</tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>                      	
                    </form>
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
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
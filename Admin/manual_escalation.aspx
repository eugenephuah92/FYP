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
                                <div class="col-md-3"  style="padding-top:10pt"> 
                                    <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server">
                                        <asp:ListItem>Please Select Filter</asp:ListItem>
                                    </asp:DropDownList> 
                            	</div>
                                <div class="col-md-3"  style="padding-top:10pt">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtSearch" placeholder="Search For" runat="server" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton CssClass="btn btn-default" ID="btnSearch" runat="server">
                                                   <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </p>
                    
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table">
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
                                                	<a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true" style="text-decoration:none; color:#000;">Doe</a>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="myModalName" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:100pt">
                                                      <div class="modal-dialog">
                                                        <div class="modal-content">
                                                          <div class="modal-header" style="padding-top:15pt">
                                                          	<strong>Assign New Quality Engineer</strong>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br>
                                                          </div>
                                                          <div class="modal-body" style="padding-top:30pt">
                                                            <div class="form-group">
                                                                
                                                                <label for="lstQE" class="col-lg-4 control-label" style="padding-top:20pt">New QE</label>
                                                                <div class="col-lg-6" style="padding-top:15pt">
                                                                    <asp:DropDownList ID="lstQE" runat="server" CssClass="form-control">
                                                                        <asp:ListItem>Please Select QE</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                          	</div>
                                                          </div>
                                                          <div class="modal-footer">
                                                              <asp:button ID="btnChangeQE" CssClass="btn btn-success" Text="Change QE" runat="server" /> 
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
                                                          <div class="modal-header" style="padding-top:15pt">
                                                          	<strong>Set New Escalation Level</strong>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br>
                                                          </div>
                                                          <div class="modal-body" style="padding-top:30pt">
                                                            <div class="form-group">
                                                                
                                                                <label for="lstEscalationLevel" class="col-lg-4 control-label" style="padding-top:20pt">Next Escalation Level</label>
                                                                <div class="col-lg-6" style="padding-top:15pt">
                                                                    <asp:DropDownList ID="lstEscalationLevel" runat="server" CssClass="form-control">
                                                                        <asp:ListItem>Please Select Escalation Level</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                          	</div>
                                                          </div>
                                                          <div class="modal-footer">
                                                            <asp:button ID="btnChangeEscLevel" CssClass="btn btn-success" Text="Change Escalation Level" runat="server" /> 
                                                          </div>
                                                        </div>
                                                      </div>
                                                    </div>
                                                </td>
                                                <td style="padding-left:30pt">4</td>
                                          	</tr>
                                          	
                    </form>
                </div>

            </div>

        </div><!--/.col-md-12-->


    </div>
</div>
</asp:Content>
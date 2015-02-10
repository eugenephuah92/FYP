﻿<%@ Page Title="Auto SCAR &amp; TAT - View Corrective Actions" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/view_corrective_action.aspx.cs" Inherits="Engineer_view_corrective_actions" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">

            <div class="panel panel-info">
                <div class="panel-heading">
                    Total SCAR
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
                            </div>
                    </p>
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table">
                                    	<thead>
                                        	<tr>
                                                <th>Corrective Actions / Preventive Actions</th>
                                                <th>SCAR Request Date</th>
                                                <th>SCAR Completion Date</th>
                                                <th>CAR No</th>
                                                <th>Assigned Quality Engineer</th>
                                                <th>Actions</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td>ABC</td>
                                                <td>11.1.2015</td>
                                                <td>13.1.2015</td>
                                                <td>ABC</td>
                                                <td>John Doe</td>
                                                <td>
                                                    <a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true" class="btn btn-primary">Edit</a>
                                                    <asp:Button CssClass="btn btn-danger" runat="server" ID="btnRemove" Text="Remove" />
                                                </td>
                                          	</tr>

                                        </tbody>
  									</table>
                                </div>
                            </div>                          
                        <!-- Modal -->
                        <div class="modal fade" id="myModalName" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:100pt">
                            <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="padding-top:15pt">
                                <strong>Edit Defect Mode</strong>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br>
                                </div>
                                <div class="modal-body" style="padding-top:30pt">
                                <div class="form-group">
                                    <label for="txtNewCorrectiveAction" class="col-lg-4 control-label">New Corrective / Preventive Action</label>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="txtNewCorrectiveAction" runat="server" placeholder="New Corrective / Preventive Action" />
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <br />
                                    <label for="cldSCARReqDate" class="col-lg-4 control-label">SCAR Request Date</label>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <asp:Calendar  ID="cldSCARReqDate" runat="server"/>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <label for="cldSCARCompDate" class="col-lg-4 control-label">SCAR Completion Date</label>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <asp:Calendar  ID="cldSCARCompDate" runat="server"/>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <label for="txtSearchCarNo" class="col-lg-4 control-label">CAR Number</label>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="txtSearchCarNo" placeholder="Search For CAR Number" runat="server" />
                                                <span class="input-group-btn">
                                                    <asp:LinkButton CssClass="btn btn-default" ID="btnSearchCarNo" runat="server">
                                                           <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                    </asp:LinkButton>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <label for="lstAssignedQE" class="col-lg-4 control-label">Assigned Quality Engineer</label>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <asp:DropDownList CssClass="form-control" ID="lstAssignedQE" runat="server">
                                                    <asp:ListItem>Please Select QE</asp:ListItem>
                                                    <asp:ListItem>James Tomkins</asp:ListItem>
                                                    <asp:ListItem>Alan Hudson</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSave" CssClass="btn btn-primary" Text="Save" runat="server" />
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
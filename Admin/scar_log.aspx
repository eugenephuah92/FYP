<%@ Page Title="Auto SCAR &amp; TAT - SCAR Log" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/scar_log.aspx.cs" Inherits="Admin_scar_log" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    SCAR Log
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
                                        <asp:TextBox CssClass="form-control" ID="searchTxt" runat="server" placeholder="Search for..." />
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
                                <div class="col-lg-12" style="padding-left:25pt; padding-right:30pt; padding-top:15pt; padding-bottom:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">
                                    	<thead>
                                        	<tr>
                                                <th>CAR Number</th>
                                                <th style="padding-left:30pt">Stage</th>
                                                <th style="padding-left:30pt">Disapprove Frequency</th>
                                                <th style="padding-left:30pt">Creation Date</th>
                                                <th style="padding-left:30pt">Completion Date</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td>P-SOQANP-140916</td>
                                                <td style="padding-left:30pt">SCAR Type 4 Pending Approval</td>
                                                <td style="padding-left:30pt">
                                                    <a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true">0</a>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="myModalName" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:100pt">
                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                          	        <h4 class="modal-title">Disapprove Frequency</h4>                                                                  
                                                                </div>
                                                                <div class="modal-body" style="padding-top:30pt">
                                                                    <div class="form-group">
                                                                        <table class="table">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th>Manager</th>
                                                                                    <th>Status</th>
                                                                                    <th>Comments</th>
                                                                                    <th>Date</th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>Alan (QM)</td>
                                                                                    <td>Disapprove</td>
                                                                                    <td>Incomplete data</td>
                                                                                    <td>22/11/2014</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>George (WCM)</td>
                                                                                    <td>Approve</td>
                                                                                    <td>-</td>
                                                                                    <td>22/11/2014</td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                          	        </div>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <asp:button ID="btnChangeQE" CssClass="btn btn-primary" Text="Save Change" runat="server" />
                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> 
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="padding-left:30pt">22/10/2014</td>
                                                <td style="padding-left:30pt">Ongoing</td>
                                          	</tr>
                                          	<tr>
                                            	<td>P-SOBDP-142945</td>
                                                <td style="padding-left:30pt">SCAR Issue Completed</td>
                                                <td style="padding-left:30pt">2</td>
                                                <td style="padding-left:30pt">22/10/2014</td>
                                                <td style="padding-left:30pt">25/10/2014</td>
                                          	</tr>
                                          	<tr>
                                            	<td>Q-COBDP-142633</td>
                                                <td style="padding-left:30pt">SCAR Type 2 Pending Approval</td>
                                                <td style="padding-left:30pt">1</td>
                                                <td style="padding-left:30pt">24/10/2014</td>
                                                <td style="padding-left:30pt">Ongoing</td>
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
        </div> <!--/.col-md-12-->
    </div>
</div>
</asp:Content>
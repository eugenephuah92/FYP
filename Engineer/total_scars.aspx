<%@ Page Title="Auto SCAR &amp; TAT - Total SCARS" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/total_scars.aspx.cs" Inherits="Engineer_total_scars" %>

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
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt; padding-bottom:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">
                                    	<thead>
                                        	<tr>
                                                <th>CAR Number</th>
                                                <th style="padding-left:30pt">Defect Name</th>
                                                <th style="padding-left:30pt">Description</th>
                                                <th style="padding-left:30pt">Creation Date</th>
                                                <th style="padding-left:30pt">SCAR Type</th>
                                                <th style="padding-left:30pt">Level of Escalation</th>
                                                <th style="padding-left:30pt">Days Till Next Escalation</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td>P-SOQANP-140916</td>
                                                <td style="padding-left:30pt">INSUFF SOLDER</td>
                                                <td style="padding-left:30pt">Insufficient amount of solder on a lead, pad or terminal</td>
                                                <td style="padding-left:30pt">22/10/2014</td>
                                                <td style="padding-left:30pt">2</td>
                                                <td style="padding-left:30pt">1</td>
                                                <td style="padding-left:30pt">4</td>
                                          	</tr>
                                          	<tr>
                                            	<td>P-SOBDP-142945</td>
                                                <td style="padding-left:30pt">SKEWED</td>
                                                <td style="padding-left:30pt">Component with rotational misalignment / misregistration of terminals</td>
                                                <td style="padding-left:30pt">22/10/2014</td>
                                                <td style="padding-left:30pt">4</td>
                                            	<td style="padding-left:30pt">2</td>
                                                <td style="padding-left:30pt">5</td>
                                          	</tr>
                                          	<tr>
                                            	<td>Q-COBDP-142633</td>
                                                <td style="padding-left:30pt">FRACTURED SOLDER</td>
                                                <td style="padding-left:30pt">Stressed solder torn away through the PCB</td>
                                                <td style="padding-left:30pt">24/10/2014</td>
                                                <td style="padding-left:30pt">2</td>
                                            	<td style="padding-left:30pt">1</td>
                                                <td style="padding-left:30pt">6</td>
                                          	</tr>      
                                            <tr>
                                            	<td>S-ABCDE-181988</td>
                                                <td style="padding-left:30pt">BURNED</td>
                                                <td style="padding-left:30pt">Damaged caused to board or part due to excessive heat</td>
                                                <td style="padding-left:30pt">25/10/2014</td>
                                                <td style="padding-left:30pt">4</td>
                                            	<td style="padding-left:30pt">2</td>
                                                <td style="padding-left:30pt">8</td>
                                          	</tr>   
                                            <tr>
                                            	<td>R-COPAB-123456</td>
                                                <td style="padding-left:30pt">ARROWS ON PCB</td>
                                                <td style="padding-left:30pt">Inspection arrows left on the board</td>
                                                <td style="padding-left:30pt">05/11/2014</td>
                                                <td style="padding-left:30pt">2</td>
                                            	<td style="padding-left:30pt">1</td>
                                                <td style="padding-left:30pt">7</td>
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
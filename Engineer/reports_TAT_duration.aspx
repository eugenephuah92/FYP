<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/reports_TAT_duration.aspx.cs" Inherits="Engineer_reports_TAT_duration" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">

            <div class="panel panel-info">
                <div class="panel-heading">
                    Duration Needed to close SCAR
                </div>
                <div class="panel-body">
                	<div class="col-md-6">
                	<p style="padding-top:10pt"> | <a href="#">Show 10 records</a> | <a href="#">Show 50 records</a> | 
                    </div>
                    	
                            <div class="row">
                                <div class="form-group" style="padding-top:10px;">
                                    <label for="txtCarRev" class="col-md-1 control-label">Number of Days:</label>
                                    <div class="col-md-2">
                                        <asp:TextBox CssClass="form-control" ID="txtCarRev" placeholder="Enter Number of Days" runat="server" />
                                    </div>
                                    <div class="col-md-1">
                                       <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" />
                                    </div>
                                    <br /><br />
                                </div>
                            </div>
                            
                    
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<div class="row">
                                        <div class="col-md-2" style="padding-top:10pt">
                                            <b>Duration: 3 days</b>
                                        </div>
                                        <div class="col-md-2"  style="padding-top:10pt">
                                            <b>Number of Cases: 2</b>
                                        </div>
                                    </div>
                                    <br />
                                    <!-- Table -->
  									<table class="table">
                                    	<thead>
                                        	<tr>
                                                <th>CAR No</th>
                                                <th>Assigned Quality Engineer</th>
                                                <th>Start Date</th>
                                                <th>Completion Date</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td>P123</td>
                                                <td>Tony Tan</td>
                                                <td>1.1.2015</td>
                                                <td>3.1.2015</td>
                                        	</tr> 
                                            <tr>
                                                <td>P201</td>
                                                <td>Marcus Lim</td>
                                                <td>3.1.2015</td>
                                                <td>5.1.2015</td>
                                        	</tr>                   
                                        </tbody>
  									</table>
                                </div>
                            </div>                          
                            <div class="form-group">
                                <div class="col-lg-10">
                                    <asp:button ID="btnExport" CssClass="btn btn-success" Text="Export" runat="server" />
                                    <asp:button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" />
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
                </div>

            </div>

        </div><!--/.col-md-12-->
        </div>
        </div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_TAT" Codebehind="~/Admin/TAT.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Report - Duration Needed to Close SCAR
                </div>
                <div class="panel-body">
                	<div class="col-md-5">
                	    <p style="padding-top:10pt"> | <a href="#">Show 10 records</a> | <a href="#">Show 50 records</a> | 
                    </div>                   	
                            <div class="row">
                                <div class="col-md-4" style="padding-top:10pt">
                                    <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server" >
                                        <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1" style="padding-top:10pt">
                                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Search" runat="server" />
                            	</div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="SCAR_ID" HeaderText=""/>
                                            <asp:BoundField DataField="employee_ID" HeaderText="Jan'14"/>
                                            <asp:BoundField DataField="issued_date" HeaderText="First Name"/>
                                            <asp:BoundField DataField="escalation_level" HeaderText="Hire Date"/>
                                            <asp:BoundField DataField="trigger_date" HeaderText="City"/>
                                            <asp:BoundField DataField="escalation_count" HeaderText="Country"/>
                                        </Columns>
                                    </asp:GridView>
                                    
                                    <!-- Table -->
  									<table class="table">
                                    	<thead>
                                        	<tr>
                                                <th>Duration</th>
                                                <th>Number of Cases</th>
                                                <th>CAR Number</th>
                                                <th>Assigned Quality Engineer</th>
                                                <th>Start Date</th>
                                                <th>Completion Date</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td>3</td>
                                                <td>2</td>
                                                <td>P-SOQANP-140916</td>
                                                <td>Tony Tan</td>
                                                <td>01/11/2014</td>
                                                <td>03/11/2014</td>
                                        	</tr>                   
                                        </tbody>
  									</table>
                                </div>
                            </div>                          
                            <div class="form-group">
                                <div class="col-lg-10" style="text-align:center">
                                    <asp:button ID="btnExport" CssClass="btn btn-success" Text="Export" runat="server" />
                                    <asp:button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" />
                                </div>
                            </div>
                        </p>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/reports_Q3.aspx.cs" Inherits="Engineer_reports_Q3" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Report - 3rd Quadrant (Q3)
                </div>
                    <div class="panel-body">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:10pt">
                                    <!-- Table -->
  									<table class="table">
                                    	<thead>
                                        	<tr>
                                                <th>Working Week</th>
                                                <th>Defect</th>
                                                <th>Corrective / Preventive Action</th>
                                                <th>PIC</th>
                                                <th>Due Date</th>
                                                <th>Status</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td><asp:TextBox ID="txtWorkingWeek1" runat="server" CssClass="form-control" Text="WW32" /></td>
                                                <td><asp:TextBox ID="txtDefect1" runat="server" CssClass="form-control" Text="Overall 8D Log" /></td>
                                                <td><asp:TextBox ID="txtCAPA1" runat="server" CssClass="form-control" /></td>
                                                <td><asp:TextBox ID="txtPIC1" runat="server" CssClass="form-control" Text="QE"/></td>
                                                <td><asp:TextBox ID="txtDueDate1" runat="server" CssClass="form-control" Text="Ongoing" /></td>
                                                <td><asp:TextBox ID="txtStatus1" runat="server" CssClass="form-control" Text="On-Track" /></td>
                                        	</tr>
                                            <tr>
                                                <td><asp:TextBox ID="txtWorkingWeek2" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtDefect2" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtCAPA2" runat="server" CssClass="form-control" /></td>
                                                <td><asp:TextBox ID="txtPIC2" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtDueDate2" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtStatus2" runat="server" CssClass="form-control"/></td>
                                        	</tr>   
                                            <tr>
                                                <td><asp:TextBox ID="txtWorkingWeek3" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtDefect3" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtCAPA3" runat="server" CssClass="form-control" /></td>
                                                <td><asp:TextBox ID="txtPIC3" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtDueDate3" runat="server" CssClass="form-control"/></td>
                                                <td><asp:TextBox ID="txtStatus3" runat="server" CssClass="form-control"/></td>
                                        	</tr>                          
                                        </tbody>
  									</table>
                                </div>
                            </div>                          
                            <div class="form-group">
                                <div class="col-lg-10" style="text-align:center">
                                    <asp:button ID="btnAddRow" CssClass="btn btn-primary" Text="Add New Row" runat="server" />
                                    <asp:button ID="btnExport" CssClass="btn btn-success" Text="Export" runat="server" />
                                    <asp:button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" />
                                </div>
                            </div>
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
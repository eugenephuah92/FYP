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
                                            <asp:BoundField DataField="SCAR_ID" HeaderText="SCAR_ID"/>
                                            <asp:BoundField DataField="employee_ID" HeaderText="employee_ID"/>
                                            <asp:BoundField DataField="issued_date" HeaderText="issued_date"/>
                                            <asp:BoundField DataField="escalation_level" HeaderText="escalation_level"/>
                                            <asp:BoundField DataField="trigger_date" HeaderText="trigger_date"/>
                                            <asp:BoundField DataField="escalation_count" HeaderText="escalation_count"/>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>                          
                            <div class="form-group">
                                <div class="col-lg-10" style="text-align:center">
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
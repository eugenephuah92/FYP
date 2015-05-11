<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_reports_TAT_frequency" Codebehind="~/Engineer/reports_TAT_frequency.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Report - Frequency of Cases of TAT Triggering
                </div>
                <div class="panel-body">
                	<div class="col-md-5">
                	    <p style="padding-top:10pt"> | <a href="#">Show 10 records</a> | <a href="#">Show 50 records</a> | 
                    </div>                   	
                            <div class="row">
                                <div class="col-md-4" style="padding-top:10pt">
                                    <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server" >
                                        <asp:ListItem Selected="True">Please Select Month</asp:ListItem>
                                        <asp:ListItem Value ="1" Text="January">January</asp:ListItem>
                                        <asp:ListItem Value ="2">February</asp:ListItem>
                                        <asp:ListItem Value ="3">March</asp:ListItem>
                                        <asp:ListItem Value ="4">April</asp:ListItem>
                                        <asp:ListItem Value ="5">May</asp:ListItem>
                                        <asp:ListItem Value ="6">June</asp:ListItem>
                                        <asp:ListItem Value ="7">July</asp:ListItem>
                                        <asp:ListItem Value ="8">August</asp:ListItem>
                                        <asp:ListItem Value ="9">September</asp:ListItem>
                                        <asp:ListItem Value ="10">October</asp:ListItem>
                                        <asp:ListItem Value ="11">November</asp:ListItem>
                                        <asp:ListItem Value ="12">December</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1" style="padding-top:10pt">
                                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Search" runat="server" OnClick="btnSearch_Click"/>
                            	</div>
                            </div>
                                                
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
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
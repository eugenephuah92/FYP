<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_reports_TAT_frequency" CodeBehind="~/Admin/reports_TAT_frequency.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Report - Frequency of Cases of TAT Triggering
                    </div>
                    <div class="panel-body">
                        <div class="row" style="padding-left: 15pt">
                            <div class="col-md-2" style="padding-top: 10pt">                             
                                <asp:DropDownList CssClass="form-control" ID="lstYear" runat="server">
                                    <asp:ListItem Selected="True">Select year</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="2001">2001</asp:ListItem>
                                    <asp:ListItem Value="2002">2002</asp:ListItem>
                                    <asp:ListItem Value="2003">2003</asp:ListItem>
                                    <asp:ListItem Value="2004">2004</asp:ListItem>
                                    <asp:ListItem Value="2005">2005</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Search" runat="server" OnClick="btnSearch_Click" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-12" style="align-content:center; padding-top: 20pt">
                                <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button ID="btnExport" CssClass="btn btn-success" Text="Export to Excel" runat="server" Visible="false" />
                                <asp:Button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

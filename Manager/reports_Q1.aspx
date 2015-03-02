<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" CodeFile="~/Manager/reports_Q1.aspx.cs" Inherits="Manager_reports_Q1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Report - 1st Quadrant (Q1)
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt; padding-bottom:10pt">
                        	<img src="../Images/Q1.jpg" alt="Q1 Report"/>
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
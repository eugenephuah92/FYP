<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/reports.aspx.cs" Inherits="Engineer_reports" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Reports
                </div>
                <div class="panel-body">
                	<div class="col-md-4">
                	    <p style="padding-top:10pt"> | <a href="#">Show 10 records</a> | <a href="#">Show 50 records</a> | 
                    </div>                  	
                            <div class="row">
                                <div class="col-md-3" style="padding-top:10pt">
                                    <asp:DropDownList CssClass="form-control" ID="lstReport" runat="server" >
                                        <asp:ListItem Selected="True">Please Select Report Type</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1" style="padding-top:10pt">
                                    <asp:Button ID="btnGenerateReport" CssClass="btn btn-primary" Text="Generate" OnClick="onClick_btnGenerate" runat="server" />                    
                            	</div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table">
                                    	<thead>
                                        	<tr>

                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td></td>
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

                </div>

            </div>

        </div><!--/.col-md-12-->
        </div>
        </div>
</asp:Content>
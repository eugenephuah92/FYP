<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_reports_Q4" Codebehind="~/Engineer/reports_Q4.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Report - 4th Quadrant (Q4)
                    </div>
                    <div class="panel-body" style="padding-top:10pt">
                        <!-- Start date -->
                        <asp:Label ID="lblStartDate" runat="server" Font-Bold="true" CssClass="col-md-1 control-label">Start Date</asp:Label>
                        <div class="col-md-3">
                            <input type="date" class="form-control" id="cldStartDate1" runat="server" />
                        </div>
                        <!-- Generate chart button -->
                        <div class="col-md-2">
                            <asp:Button ID="btnGenerateQ4" CssClass="btn btn-success" Text="Generate" runat="server" OnClick="btnGenerateQ4_Click" />
                        </div>

                        <br /><br /><br />

                        <div style="text-align:center">
                            <asp:Chart ID="Chart_Q4" runat="server" Width="800px" Height="500 px">
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

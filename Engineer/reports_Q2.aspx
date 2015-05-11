<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_reports_Q2" Codebehind="~/Engineer/reports_Q2.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- JavaScript for printing charts -->
    <script type="text/javascript">
        function print() {
            var printContent = document.getElementById("columnChart");
            var printWindow = window.open('', '', 'left=100,top=100,width=0,height=0,resizable=1');

            printWindow.document.write(printContent.outerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Report - 2nd Quadrant (Q2)
                </div>
                <div class="panel-body" style="padding-top:20px">
                    <!-- Start date -->
                    <asp:Label ID="lblStartDate" runat="server" Font-Bold="true" CssClass="col-md-1 control-label"><p>Start Date</p></asp:Label>
                    <div class="col-md-2">
				        <input type="date" class="form-control" ID="cldStartDate1" runat="server" />
                    </div>
                    <!-- Generate chart button -->
                    <div class="col-md-2">
                        <asp:button ID="btnGenerateQ2" CssClass="btn btn-success" Text="Generate" runat="server" OnClick="btnGenerateQ2_Click" />
                    </div>

                    <br /><br /><br />

                    <div class="form-group" style="text-align:center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Chart ID="Chart_Q2" runat="server" Height="400px" Width="600px">
                                    <Series>
                                        <asp:series Name="Categories" XValueMember="Categories"></asp:series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>         
                    
                    
                                    
                    <div class="form-group" style="padding-bottom:35px">
                        <div class="col-lg-10">
                            <asp:button ID="btnExport_Q2" CssClass="btn btn-success" Text="Export" runat="server" OnClick="btnExport_Q2_Click" />
                            <asp:button ID="btnPrint_Q2" CssClass="btn btn-success" Text="Print" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_reports_Q1" Codebehind="~/Engineer/reports_Q1.aspx.cs" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    

    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        1st Quadrant (1Q) - Report
                    </div>
                    <div class="panel-body" style="padding-top:20px">
                        <asp:Label ID="lblGenerateOptions" runat="server" Font-Bold="true" CssClass="pull-left col-md-2">Option to generate graph</asp:Label>
                        <div class="col-md-2" style="padding-top:4px">
                            <asp:DropDownList CssClass="form-control" ID="lstGenerateOptions" runat="server" AutopostBack="true">  
                                <asp:ListItem Selected="True">Choose an option</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- Start of year option -->
                        <asp:Label ID="lblYearOptions" runat="server" Font-Bold="true" CssClass="pull-left col-md-1"><p style="padding-left:25px;">From Year</p></asp:Label>
                        <div class="col-md-2" style="padding-top:4px">
                            <asp:DropDownList CssClass="form-control" ID="lstYearOptions" runat="server">  
                                <asp:ListItem Selected="True">Choose year</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!-- Generate chart button -->
                        <div class="col-md-2" style="padding-top:4px; padding-left:20px">
                            <asp:Button ID="btnGenerateYear" CssClass="btn btn-success" runat="server" Text="Generate" OnClick="btnGenerateYear_Click"/>
                        </div>
                        <!-- End of year option -->
                        
                        <br /><br />

                        <!-- Start of month option -->
                        <!-- Start month -->
                        <asp:Label ID="lblMonthOptions1" runat="server" Font-Bold="true" CssClass="pull-left col-md-1"><p style="padding-top:10px;">From Month</p></asp:Label>
                        <div class="col-md-2" style="padding-top:4px;">
                            <asp:DropDownList CssClass="form-control" ID="lstMonthOptions1" runat="server">  
                                <asp:ListItem Selected="True">Choose month</asp:ListItem>
                                <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                <asp:ListItem Value="12" Text="December"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- End month -->
                        <asp:Label ID="lblMonthOptions2" runat="server" Font-Bold="true" CssClass="pull-left col-md-1"><p style="padding-top:10px;">To Month</p></asp:Label>
                        <div class="col-md-2" style="padding-top:4px;">
                            <asp:DropDownList CssClass="form-control" ID="lstMonthOptions2" runat="server">  
                                <asp:ListItem Selected="True">Choose month</asp:ListItem>
                                <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                <asp:ListItem Value="12" Text="December"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- Choose year -->
                        <asp:Label ID="lblMonthYear" runat="server" Font-Bold="true" CssClass="pull-left col-md-1"><p style="padding-top:10px;">Year</p></asp:Label>
                        <div class="col-md-2" style="padding-top:4px;">
                            <asp:DropDownList CssClass="form-control" ID="lstMonthYear" runat="server">  
                                <asp:ListItem Selected="True">Choose year</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!-- Generate chart button -->
                        <div class="col-md-2" style="padding-top:4px; padding-left:20px;">
                            <asp:Button ID="btnGenerateMonth" CssClass="btn btn-success" runat="server" Text="Generate" OnClick="btnGenerateMonth_Click"/>
                        </div>
                        <!-- End of month option -->

                        <br /><br /><br />

                        <!-- Start of work week option -->
                        <!-- Start date -->
                        <asp:Label ID="lblStartDate" runat="server" Font-Bold="true" CssClass="col-md-1 control-label"><p>Start Date</p></asp:Label>
                        <div class="col-md-2">
				            <input type="date" class="form-control" ID="cldStartDate" runat="server" />
                        </div>
                        <!-- Generate chart button -->
                        <div class="col-md-2">
                            <asp:button ID="btnGenerateWW" CssClass="btn btn-success" Text="Generate" runat="server" OnClick="btnGenerateWW_Click" />
                        </div>
                        <!-- End of work week option -->

                        <br /><br /><br /><br />
                        
                        <div id="columnChart" class="form-group" style="padding-left:100px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Chart ID="Chart_Q1" runat="server" Height="400px" Width="800px">
                                        <Series>
                                            <asp:series Name="Open" XValueMember="Open"></asp:series>
                                        </Series>
                                        <Series>
                                            <asp:series Name="Closed" XValueMember="Closed"></asp:series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="Q1">
                                                <AxisX Title="Category"></AxisX>
                                                <AxisY Title="Quantity"></AxisY>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- Append the HTML string to Placeholder. -->
                            <asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div> 

                        <div class="form-group" style="text-align:center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Chart ID="Chart_Q2" runat="server" Height="400px" Width="600px">
                                        <Series>
                                            <asp:series Name="Categories" XValueMember="Categories"></asp:series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="Q2"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="form-group" style="text-align:center">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Chart ID="Chart_Q4" runat="server" Width="800px" Height="500 px">
                                        <ChartAreas>
                                            <asp:ChartArea Name="Q4"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <br /><br />
                                         
                        <div class="form-group" style="padding-bottom:35px">
                            <div class="col-lg-10">
                                <asp:button ID="btnExport_Q1" CssClass="btn btn-success" Text="Export" runat="server" OnClick="btnExport_Q1_Click" />
                                <asp:button ID="btnPrint_Q1" CssClass="btn btn-success" Text="Print" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div><!--/.col-md-12-->
        </div>
    </div>

    <script>
        var currentYear = (new Date).getFullYear();

        $("#<%= cldStartDate.ClientID %>").datepicker({
            showWeek: true,
            firstDay: 1,
            minDate: new Date((currentYear - 1), 12, 1),
            maxDate: new Date(currentYear, 11, 31),
            onSelect: function (dateText, inst) {
                $(this).val($.datepicker.iso8601Week(new Date(dateText)));
            }
        });

       
    </script>
</asp:Content>
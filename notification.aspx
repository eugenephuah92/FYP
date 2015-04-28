<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Site.Master" CodeBehind="notification.aspx.cs" Inherits="FYP_WebApp.Notification" %>

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
                                	<!--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Date" SortExpression="NoticeTimestamp">
                                                <ItemTemplate>
                                                    <div style="width: auto; overflow: hidden; white-space: nowrap; text-overflow: ellipsis">
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("NoticeTimestamp") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NoticeFrom" HeaderText="From" />
                                            <asp:TemplateField HeaderText="NoticeSubject" SortExpression="NoticeSubject">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"
                                                        Text='<%# Bind("NoticeSubject") %>'></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label2" runat="server"
                                                        Text='<%# Bind("NoticeBody") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" SortExpression="">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnRead" Text="I have read the notice" runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>-->
                                    
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
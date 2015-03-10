<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Admin.Site.master" AutoEventWireup="true" CodeFile="email_tracker.aspx.cs" Inherits="email_tracker" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Email Tracker
                </div>
                    <div class="panel-body">	
                        <div class="form-group">
                            <div class="col-lg-11">
                                 <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="10000" />
                                    <asp:Label ID="test" runat="server"/>
                                    <asp:Label ID="anotherLabel" runat="server"/>
                                    <asp:GridView ID="gvEmails" runat="server" OnRowDataBound="OnRowDataBound" DataKeyNames="MessageNumber"
                                    AutoGenerateColumns="false" CssClass="table-hover">
                                   <Columns>
                                        <asp:BoundField HeaderText="From" DataField="From" HtmlEncode="false" />
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkView" runat="server" Text='<%# Eval("Subject") %>' />
                                                <span class="body" style="display: none">
                                                    <%# Eval("Body") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Date" DataField="DateSent" />
                                        <asp:TemplateField ItemStyle-CssClass="Attachments">
                                            <ItemTemplate>
                                                <asp:Repeater ID="rptAttachments" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkAttachment" runat="server"  Text='<%# Eval("FileName") %>' />
                                                    </ItemTemplate>
                                                    <SeparatorTemplate>
                                                        <br>
                                                    </SeparatorTemplate>
                                                </asp:Repeater>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div> 
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
    
</asp:Content>

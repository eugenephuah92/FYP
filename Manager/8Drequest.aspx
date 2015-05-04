<%@ Page Title="Auto SCAR &amp; TAT - 8D Approval Request" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" Inherits="Manager_8Drequest" Codebehind="~/Manager/8Drequest.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<!-- 8D Request Page for managers: Displays existing 8D requests from Engineers-->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    8D Approval Requests
                </div>
                    <div class="panel-body" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                        <asp:Label ID="lblNoRows" runat="server" CssClass="col-lg-12 col-md-offset-3" />
                        <asp:GridView ID="display8DRequests" BorderWidth="2" AlternatingRowStyle-BorderWidth="2" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover">
                                       <Columns>
                                           <asp:BoundField HeaderText="SCAR ID" DataField="CAR Number"  />
                                           <asp:BoundField HeaderText="Assigned QE (Sender)" DataField="Assigned QE"  />
                                           <asp:TemplateField HeaderText="Sent Date">
                                            <ItemTemplate>
                                               <asp:Label runat="server" ID="lblSentDate" Text='<%#Eval("Sent Date")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lblSentTime" Text='<%#Eval("Sent Time")%>'/>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="linkSCAR" runat="server" Text="View SCAR" NavigateUrl='<%# String.Format("8Dapproval.aspx?scar_id={0}", Eval("CAR Number")) %>' />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                       </Columns>
                                   
                      </asp:GridView>  
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
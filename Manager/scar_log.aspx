<%@ Page Title="Auto SCAR &amp; TAT - SCAR Log" Language="C#" MasterPageFile="~/Manager.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Manager_scar_log" Codebehind="~/Manager/scar_log.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    SCAR Log
                </div>
                <div class="panel-body">
                	<!-- Record per page -->
                        <div class="col-md-5" style="padding-top: 10pt">
                            Records per page :
                                <asp:DropDownList ID="lstPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSizeChanged" Font-Size="Medium">
                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                    <asp:ListItem Text="20" Value="20" />
                                    <asp:ListItem Text="50" Value="50" />
                                </asp:DropDownList>
                        </div>
                        <!-- Search -->
                        <div class="row">
                            <div class="col-md-2" style="padding-top: 10pt">
                                <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server">
                                    <asp:ListItem Selected="True">Select filter</asp:ListItem>
                                    <asp:ListItem Value="Car No">Car No.</asp:ListItem>

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFilter" runat="server" ErrorMessage="* No filter is selected" ForeColor="Red" ControlToValidate="lstFilter" InitialValue="Select filter" Display="Dynamic" ValidationGroup="Search"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2" style="padding-top: 10pt">
                                <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter keyword" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSearch" runat="server" ErrorMessage="* Keyword is required" ForeColor="Red" ControlToValidate="txtSearch" Display="Dynamic" ValidationGroup="Search"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button CssClass="btn btn-primary" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" ValidationGroup="Search" />
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button CssClass="btn btn-danger" ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" />
                            </div> 

                        </div> 
                        <br />
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:25pt; padding-right:30pt; padding-top:15pt; padding-bottom:15pt">
                                	<!-- Table -->
                                    <asp:UpdatePanel ID="updatePanelSCARLog" runat="server" UpdateMode="Always">
                                     <ContentTemplate>
                                   <asp:GridView ID="displaySCARLog" AllowSorting="true" OnSorting="SCARLogGridView_Sorting" AlternatingRowStyle-BorderWidth="2" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table">
                                       <Columns>
                                           <asp:TemplateField HeaderText="CAR Number" SortExpression="CAR Number">
                                            <ItemTemplate>
                                           <asp:HyperLink ID="link" runat="server" Text='<%#Eval("CAR Number") %>' NavigateUrl='<%# String.Format("view_scar_record.aspx?scar_no={0}", Eval("CAR Number")) %>'></asp:HyperLink>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status"/>
                                           <asp:BoundField HeaderText="Disapprove Frequency" DataField="Disapprove Frequency" SortExpression="Disapprove Frequency"/>
                                           <asp:BoundField HeaderText="Creation Date" DataField="Creation Date"/>
                                           <asp:BoundField HeaderText="Expected Date Close" DataField="Expected Date Close"/>
                                       </Columns>
                                       <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <EmptyDataTemplate>
                                            <label style="color: Red; font-weight: bold">No records found for SCARS !</label>
                                        </EmptyDataTemplate>  
                                       </asp:GridView>
                                    </ContentTemplate>
  								</asp:UpdatePanel>	
  									
                                </div>
                            </div> 
                    </form>
                </div>
            </div>
        </div> <!--/.col-md-12-->
    </div>
</div>
</asp:Content>
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
                                    <asp:ListItem Value="CAR No">CAR No.</asp:ListItem>
                                    <asp:ListItem Value="Assigned QE">Assigned QE</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFilter" runat="server" ErrorMessage="* No filter is selected" ForeColor="Red" ControlToValidate="lstFilter" InitialValue="Select filter" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2" style="padding-top: 10pt">
                                <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter keyword" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSearch" runat="server" ErrorMessage="* Keyword is required" ForeColor="Red" ControlToValidate="txtSearch" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button CssClass="btn btn-primary" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button CssClass="btn btn-danger" ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" />
                            </div>

                            <!-- Advanced Search -->
                            <div class="panel-group" id="accordion" role="tablist">
                                <div class="col-md-7 pull-right">
                                    <div class="panel-heading" role="tab" id="headingOne">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne" style="text-decoration: none">+ Advanced Search
                                        </a>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse out" role="tabpanel" aria-labelledby="headingOne">
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-4" style="padding-top: 10pt">
                                                    <asp:DropDownList CssClass="form-control" ID="lstFilter1" runat="server">
                                                        <asp:ListItem Selected="True">Select filter</asp:ListItem>
                                                        <asp:ListItem Value="CAR No">CAR No.</asp:ListItem>
                                                        <asp:ListItem Value="Assigned QE">Assigned QE</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-6" style="padding-top: 10pt">
                                                    <div class="input-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtSearch1" runat="server" placeholder="Enter keyword" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4" style="padding-top: 10pt">
                                                    <asp:DropDownList CssClass="form-control" ID="lstFilter2" runat="server">
                                                        <asp:ListItem Selected="True">Select filter</asp:ListItem>
                                                        <asp:ListItem Value="CAR No">CAR No.</asp:ListItem>
                                                        <asp:ListItem Value="Assigned QE">Assigned QE</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-6" style="padding-top: 10pt">
                                                    <div class="input-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtSearch2" runat="server" placeholder="Enter keyword" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="display8DRequests" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table">
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
                                    <asp:HyperLink ID="linkSCAR" runat="server" Text="View SCAR" NavigateUrl='<%# String.Format("8Dapproval.aspx?scar_no={0}", Eval("CAR Number")) %>' />
                                </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                            <RowStyle BackColor="#E3EAEB" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                <label style="color: Red; font-weight: bold">No records found for Pending Requests!</label>
                            </EmptyDataTemplate>
                      </asp:GridView>  
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - View Defect Modes" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_view_defect_modes" Codebehind="~/Engineer/view_defect_modes.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Defect Modes
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
                                    <asp:ListItem Value="Defect Code">Defect Code</asp:ListItem>
                                    <asp:ListItem Value="IPC Code">IPC Code</asp:ListItem>
                                    <asp:ListItem Value="Defect Name">Defect Name</asp:ListItem>
                                    <asp:ListItem Value="Defect Group">Defect Group</asp:ListItem>
                                    <asp:ListItem Value="Defect Category">Defect Category</asp:ListItem>
                                    <asp:ListItem Value="Defect Description">Defect Description</asp:ListItem>
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
                                                        <asp:ListItem Value="Defect Code">Defect Code</asp:ListItem>
                                                        <asp:ListItem Value="IPC Code">IPC Code</asp:ListItem>
                                                        <asp:ListItem Value="Defect Name">Defect Name</asp:ListItem>
                                                        <asp:ListItem Value="Defect Group">Defect Group</asp:ListItem>
                                                        <asp:ListItem Value="Defect Category">Defect Category</asp:ListItem>
                                                        <asp:ListItem Value="Defect Description">Defect Description</asp:ListItem>
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
                                                        <asp:ListItem Value="Defect Code">Defect Code</asp:ListItem>
                                                        <asp:ListItem Value="IPC Code">IPC Code</asp:ListItem>
                                                        <asp:ListItem Value="Defect Name">Defect Name</asp:ListItem>
                                                        <asp:ListItem Value="Defect Group">Defect Group</asp:ListItem>
                                                        <asp:ListItem Value="Defect Category">Defect Category</asp:ListItem>
                                                        <asp:ListItem Value="Defect Description">Defect Description</asp:ListItem>
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

                        <!-- Defect Modes Gridview -->
                        <asp:GridView ID="GridViewDFM" CssClass="table" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridViewDFM_PageIndexChanging" CellPadding="4" ForeColor="#333333" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="defect_code" HeaderText="Defect Code" SortExpression="defect_code" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="IPC_code" HeaderText="IPC Code" SortExpression="IPC_code" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="defect_name" HeaderText="Defect Name" SortExpression="defect_name" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="defect_group" HeaderText="Defect Group" SortExpression="defect_group" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="defect_category" HeaderText="Defect Category" SortExpression="s51_corrective_action" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="defect_description" HeaderText="Defect Description" SortExpression="defect_description" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="modified_by" HeaderText="Modified By" SortExpression="modified_by" ControlStyle-Width="100%" />
                                <asp:BoundField DataField="last_modified" HeaderText="Last Modified" SortExpression="last_modified" ControlStyle-Width="100%" />
                            </Columns>
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                            <RowStyle BackColor="#E3EAEB" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                <label style="color: Red; font-weight: bold">No record found !</label>
                            </EmptyDataTemplate>
                        </asp:GridView>                        
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>

    <!-- Gridview paging -->
    <style type="text/css">
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }

        .cssPager span {
            font-weight: bold;
            text-decoration: underline;
        }
    </style>
</asp:Content>
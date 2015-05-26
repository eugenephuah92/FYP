<%@ Page Title="Auto SCAR &amp; Report - Corrective Action / Preventive Action" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_reports_CAPA" CodeBehind="~/Admin/reports_CAPA.aspx.cs" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Report - Corrective Action / Preventive Action
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
                                    <asp:ListItem Value="CAR No">CAR No.</asp:ListItem>
                                    <asp:ListItem Value="Part No">Part No.</asp:ListItem>
                                    <asp:ListItem Value="Part Desc">Part Description</asp:ListItem>
                                    <asp:ListItem Value="Business Unit">Business Unit</asp:ListItem>
                                    <asp:ListItem Value="CAPA">Corrective Action / Preventive Action</asp:ListItem>
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
                                                        <asp:ListItem Value="Part No">Part No.</asp:ListItem>
                                                        <asp:ListItem Value="Part Desc">Part Description</asp:ListItem>
                                                        <asp:ListItem Value="Business Unit">Business Unit</asp:ListItem>
                                                        <asp:ListItem Value="CAPA">Corrective Action / Preventive Action</asp:ListItem>
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
                                                        <asp:ListItem Value="Part No">Part No.</asp:ListItem>
                                                        <asp:ListItem Value="Part Desc">Part Description</asp:ListItem>
                                                        <asp:ListItem Value="Business Unit">Business Unit</asp:ListItem>
                                                        <asp:ListItem Value="CAPA">Corrective Action / Preventive Action</asp:ListItem>
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

                        <!-- CAPA Gridview -->
                        <asp:GridView ID="GridViewCAPA" CssClass="table" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridViewCAPA_PageIndexChanging" OnDataBound="GridViewCAPA_DataBound" CellPadding="4" ForeColor="#333333" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="scar_no" HeaderText="CAR No." SortExpression="scar_no" />
                                <asp:BoundField DataField="part_no" HeaderText="Part No." SortExpression="part_no" />
                                <asp:BoundField DataField="part_description" HeaderText="Part Description" SortExpression="part_description" />
                                <asp:BoundField DataField="business_unit" HeaderText="Business Unit" SortExpression="business_unit" />
                                <asp:BoundField DataField="s51_corrective_action" HeaderText="Corrective Action / Preventive Action" SortExpression="s51_corrective_action" ItemStyle-Wrap="true" />
                                <asp:BoundField DataField="modified_by" HeaderText="Modified By" SortExpression="modified_by" />
                                <asp:BoundField DataField="last_modified" HeaderText="Last Modified" SortExpression="last_modified" />
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

                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button ID="btnExport" CssClass="btn btn-success" Text="Export to Excel" runat="server" OnClick="btnExport_Click" />
                                <asp:Button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" OnClick="btnPrint_Click" />
                            </div>
                        </div>
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

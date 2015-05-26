<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" Inherits="Manager_reports_TAT_duration" CodeBehind="~/Manager/reports_TAT_duration.aspx.cs" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Report - Duration Needed to Close SCAR
                    </div>
                    <div class="panel-body">
                        <!-- Record per page -->
                        <div class="col-md-6" style="padding-top: 10pt">
                            Records per page :
                                <asp:DropDownList ID="lstPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSizeChanged" Font-Size="Medium">
                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                    <asp:ListItem Text="20" Value="20" />
                                    <asp:ListItem Text="50" Value="50" />
                                </asp:DropDownList>
                        </div>
                        <!-- Search -->
                        <div class="row">
                            <div class="col-md-1" style="padding-top: 10pt">
                                <label for="txtDuration">Duration: (days)</label>
                            </div>
                            <div class="col-md-2" style="padding-top: 10pt">
                                <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server" placeholder="Enter duration" ToolTip="Duration needed to close SCAR (Eg: 3)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSearch" runat="server" ErrorMessage="* Duration is required" ForeColor="Red" ControlToValidate="txtDuration" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidatorSearch" runat="server" Operator="DataTypeCheck" Type="Integer" ErrorMessage="* ONLY numbers is allowed" ForeColor="Red" ControlToValidate="txtDuration" Display="Dynamic"></asp:CompareValidator>
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Search" runat="server" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-md-1" style="padding-top: 10pt">
                                <asp:Button ID="btnClear" CssClass="btn btn-danger" Text="Clear" runat="server" OnClick="btnClear_Click" />
                            </div>
                        </div>
                        <br />

                        <!-- Total number of SCAR cases -->
                        <label for="txtNumOfCases">Total Number of Cases : </label>
                        <asp:Label ID="txtRowCount" runat="server" Font-Bold="true" />

                        <!-- TAT Duration Gridview -->
                        <asp:GridView ID="GridViewTAT_Duration" CssClass="table" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridViewTAT_Duration_PageIndexChanging" OnDataBound="GridViewTAT_Duration_DataBound" CellPadding="4" ForeColor="#333333">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="scar_no" HeaderText="CAR No." SortExpression="scar_no" />
                                <asp:BoundField DataField="supplier_contact" HeaderText="Assigned Quality Engineer" SortExpression="supplier_contact" />
                                <asp:BoundField DataField="issued_date" HeaderText="Start Date" SortExpression="issued_date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="expected_date_close" HeaderText="Completion Date" SortExpression="expected_date_close" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:TemplateField HeaderText="Duration">
                                    <ItemTemplate>
                                        <asp:Label ID="txtDuration" Text='<%# CalculateDuration(DataBinder.Eval(Container.DataItem,"issued_date").ToString(), DataBinder.Eval(Container.DataItem,"expected_date_close").ToString()) %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="modified_by" HeaderText="Modified By" SortExpression="modified_by" />
                                <asp:BoundField DataField="last_modified" HeaderText="Last Modified" SortExpression="last_modified" />
                            </Columns>
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                            <RowStyle BackColor="#E3EAEB" />
                            <AlternatingRowStyle BackColor="White" />
                            <EmptyDataTemplate>
                                <label style="color:Red; font-weight:bold">No record found !</label>
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

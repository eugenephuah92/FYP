<%@ Page Title="Auto SCAR &amp; TAT - View Defect Modes" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_view_defect_modes" CodeBehind="~/Admin/view_defect_modes.aspx.cs" %>

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
                        <asp:GridView ID="GridViewDFM" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="defect_code" OnRowDataBound="GridViewDFM_RowDataBound" OnRowEditing="GridViewDFM_RowEditing" OnRowCancelingEdit="GridViewDFM_RowCancelingEdit" OnRowUpdating="GridViewDFM_RowUpdating" OnRowDeleting="GridViewDFM_RowDeleting" AllowPaging="True" OnPageIndexChanging="GridViewDFM_PageIndexChanging" CellPadding="4" ForeColor="#333333" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Defect Code" SortExpression="defect_code" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectCode" CssClass="form-control" runat="server" Text='<%# Bind("defect_code") %>' ReadOnly="true"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectCode" runat="server" Text='<%# Bind("defect_code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IPC Code" SortExpression="IPC_code" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtIPCcode" CssClass="form-control" runat="server" Text='<%# Bind("IPC_code") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorIPCCode" runat="server" ErrorMessage="* IPC Code ONLY accept numbering format (Eg: 1.1.1)"
                                            ForeColor="Red" ControlToValidate="txtIPCcode" ValidationExpression="^[0-9]+(\.[0-9]{1,2})+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtIPCcode" runat="server" Text='<%# Bind("IPC_code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Name" SortExpression="defect_name" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectName" CssClass="form-control" runat="server" Text='<%# Bind("defect_name") %>' ReadOnly="true"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectName" runat="server" Text='<%# Bind("defect_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Group" SortExpression="defect_group" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="lstDefectGroup" CssClass="form-control" runat="server" SelectedValue='<%# Bind("defect_group") %>' DataSourceID="SqlDataSource2" DataTextField="defect_group"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>"
                                            SelectCommand="SELECT [defect_group_ID], [defect_group] FROM [Defect_Group]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectGroup" runat="server"
                                            ErrorMessage="* Defect Group is a required field" ForeColor="Red" ControlToValidate="lstDefectGroup"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectGroup" runat="server" Text='<%# Bind("defect_group") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Category" SortExpression="defect_category" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="lstDefectCategory" CssClass="form-control" runat="server" SelectedValue='<%# Bind("defect_category") %>' DataSourceID="SqlDataSource3" DataTextField="defect_category"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>"
                                            SelectCommand="SELECT [defect_category_ID], [defect_category] FROM [Defect_Category]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCategory" runat="server"
                                            ErrorMessage="* Defect Category is a required field" ForeColor="Red" ControlToValidate="lstDefectCategory"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectCategory" runat="server" Text='<%# Bind("defect_category") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Description" SortExpression="defect_description" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectDesc" CssClass="form-control" runat="server" Text='<%# Bind("defect_description") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectDesc" runat="server"
                                            ErrorMessage="* Defect Description is a required field" ForeColor="Red" ControlToValidate="txtDefectDesc"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectDesc" runat="server" Text='<%# Bind("defect_description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="modified_by" HeaderText="Modified By" SortExpression="modified_by" ReadOnly="true" />
                                <asp:BoundField DataField="last_modified" HeaderText="Last Modified" SortExpression="last_modified" ReadOnly="true" />
                                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-primary" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-danger" />
                                </asp:CommandField>
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

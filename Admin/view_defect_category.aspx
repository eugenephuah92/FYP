<%@ Page Title="Auto SCAR &amp; TAT - View Defect Category / Defect Group" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_view_defect_category" CodeBehind="view_defect_category.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Defect Category
                    </div>
                    <!-- Defect Category Gridview -->
                    <div class="panel-body" style="padding-top: 10pt">                        
                        <asp:GridView ID="GridViewDFC" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="defect_category_ID" OnRowEditing="GridViewDFC_RowEditing" OnRowCancelingEdit="GridViewDFC_RowCancelingEdit" OnRowUpdating="GridViewDFC_RowUpdating" AllowPaging="True" OnPageIndexChanging="GridViewDFC_PageIndexChanging" CellPadding="4" ForeColor="#333333">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Category" SortExpression="defect_category">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectCategory" CssClass="form-control" runat="server" Text='<%# Bind("defect_category") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCategory" runat="server"
                                            ErrorMessage="* Defect Category is a required field" ForeColor="Red" ControlToValidate="txtDefectCategory" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDefectCategory" runat="server" 
                                            ErrorMessage="* Defect Category ONLY accept alphabets (letters)" ForeColor="Red" ControlToValidate="txtDefectCategory" ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:CustomValidator ID="CustomValidatorDefectCategory" runat="server" 
                                            ErrorMessage="* Defect Category is already existed" ForeColor="Red" ControlToValidate="txtDefectCategory" OnServerValidate="ValidateDefectCategory" Display="Dynamic"></asp:CustomValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectCategory" runat="server" Text='<%# Bind("defect_category") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="modified_by" HeaderText="Modified By" SortExpression="modified_by" ReadOnly="true" />
                                <asp:BoundField DataField="last_modified" HeaderText="Last Modified" SortExpression="last_modified" ReadOnly="true" />
                                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-primary" />
                                    <ItemStyle Wrap="false" />
                                </asp:CommandField>                            
                            </Columns>
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                            <RowStyle BackColor="#E3EAEB" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                <!-- Defect Group Gridview -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Defect Group
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <asp:GridView ID="GridViewDFG" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="defect_group_ID" OnRowEditing="GridViewDFG_RowEditing" OnRowCancelingEdit="GridViewDFG_RowCancelingEdit" OnRowUpdating="GridViewDFG_RowUpdating" OnRowDeleting="GridViewDFG_RowDeleting" OnRowDataBound="GridViewDFG_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridViewDFG_PageIndexChanging" CellPadding="4" ForeColor="#333333">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Group" SortExpression="defect_group" ItemStyle-Wrap="true">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectGroup" CssClass="form-control" runat="server" Text='<%# Bind("defect_group") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectGroup" runat="server"
                                            ErrorMessage="* Defect Group is a required field" ForeColor="Red" ControlToValidate="txtDefectGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidatorDefectGroup" runat="server" 
                                            ErrorMessage="* Defect Group is already existed" ForeColor="Red" ControlToValidate="txtDefectGroup" OnServerValidate="ValidateDefectGroup" Display="Dynamic"></asp:CustomValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectGroup" runat="server" Text='<%# Bind("defect_group") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="modified_by" HeaderText="Modified By" SortExpression="modified_by" ReadOnly="true" />
                                <asp:BoundField DataField="last_modified" HeaderText="Last Modified" SortExpression="last_modified" ReadOnly="true" />
                                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-primary" />
                                    <ItemStyle Wrap="false" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-danger" />
                                    <ItemStyle Wrap="false" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                            <RowStyle BackColor="#E3EAEB" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                <!--/.col-md-12-->
            </div>
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

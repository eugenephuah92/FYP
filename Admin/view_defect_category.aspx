<%@ Page Title="Auto SCAR &amp; TAT - View Defect Category / Defect Group" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_view_defect_category" CodeBehind="view_defect_category.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>

    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Defect Category
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <!-- Defect Category Gridview -->
                        <asp:GridView ID="GridViewDFC" CssClass="table" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="defect_category_ID" OnRowDataBound="GridViewDFC_DeleteConfirm" OnRowUpdating="GridViewDFC_RowUpdating" AllowPaging="True" BorderColor="#cccccc">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Category" SortExpression="defect_category" ControlStyle-Width="100%">
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
                                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-primary" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-danger" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="AliceBlue" Font-Bold="True" ForeColor="Black" />
                            <PagerStyle CssClass="cssPager" BackColor="AliceBlue" HorizontalAlign="Center" Font-Size="Medium" />
                            <RowStyle ForeColor="#333333" BackColor="White" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>"
                            SelectCommand="SELECT [defect_category_ID], [defect_category] FROM [Defect_Category]"
                            DeleteCommand="DELETE FROM [Defect_Category] WHERE [defect_category_ID] = @defect_category_ID"
                            UpdateCommand="UPDATE [Defect_Category] SET [defect_category] = @defect_category WHERE [defect_category_ID] = @defect_category_ID">
                            <DeleteParameters>
                                <asp:Parameter Name="defect_category_ID" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="defect_category" Type="String" />
                                <asp:Parameter Name="defect_category_ID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <!-- Defect Group Gridview -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Defect Group
                    </div>
                    <div class="panel-body" style="padding-top: 10pt">
                        <asp:GridView ID="GridViewDFG" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="defect_group_ID" DataSourceID="SqlDataSource2" OnRowDataBound="GridViewDFG_DeleteConfirm" OnRowUpdating="GridViewDFG_RowUpdating" AllowPaging="True" BorderColor="#cccccc">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Group" SortExpression="defect_group">
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
                                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-primary" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-danger" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="AliceBlue" Font-Bold="True" ForeColor="Black" />
                            <PagerStyle CssClass="cssPager" BackColor="AliceBlue" HorizontalAlign="Center" Font-Size="Medium" />
                            <RowStyle ForeColor="#333333" BackColor="White" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>" 
                            SelectCommand="SELECT [defect_group_ID], [defect_group] FROM [Defect_Group]" 
                            DeleteCommand="DELETE FROM [Defect_Group] WHERE [defect_group_ID] = @defect_group_ID" 
                            UpdateCommand="UPDATE [Defect_Group] SET [defect_group] = @defect_group WHERE [defect_group_ID] = @defect_group_ID">
                            <DeleteParameters>
                                <asp:Parameter Name="defect_group_ID" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="defect_group" Type="String" />
                                <asp:Parameter Name="defect_group_ID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <!--/.col-md-12-->
            </div>
        </div>
    </div>
</asp:Content>

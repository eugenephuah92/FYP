<%@ Page Title="Auto SCAR &amp; TAT - View Defect Modes" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_view_defect_modes" CodeBehind="~/Admin/view_defect_modes.aspx.cs" %>

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
                        Defect Modes
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
                        <div class="row">
                            <div class="col-md-3" style="padding-top: 10pt">
                                <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server">
                                    <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3" style="padding-top: 10pt">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="searchTxt" runat="server" placeholder="Search For..." />
                                    <span class="input-group-btn">
                                        <asp:LinkButton CssClass="btn btn-default" ID="btnSearch" runat="server">
                                                <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                            <!-- Advanced Search -->
                            <div class="panel-group" id="accordion" role="tablist">
                                <div class="col-md-6 pull-right">
                                    <div class="panel-heading" role="tab" id="headingOne">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne" style="text-decoration: none">+ Advanced Search
                                        </a>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse out" role="tabpanel" aria-labelledby="headingOne">
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-6" style="padding-top: 10pt">
                                                    <asp:DropDownList CssClass="form-control" ID="test" runat="server">
                                                        <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-6" style="padding-top: 10pt">
                                                    <div class="input-group">
                                                        <asp:TextBox CssClass="form-control" ID="searchTxt2" runat="server" placeholder="Search for..." />
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton CssClass="btn btn-default" ID="btnSearch2" runat="server">
                                                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6" style="padding-top: 10pt">
                                                    <asp:DropDownList CssClass="form-control" ID="lstFilter3" runat="server">
                                                        <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-6" style="padding-top: 10pt">
                                                    <div class="input-group">
                                                        <asp:TextBox CssClass="form-control" ID="searchTxt3" runat="server" placeholder="Search for..." />
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton CssClass="btn btn-default" ID="btnSearch3" runat="server">
                                                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                        </span>
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
                        <asp:GridView ID="GridViewDFM" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="defect_ID" DataSourceID="SqlDataSource1" OnRowDataBound="GridviewDFM_DeleteConfirm" OnRowUpdating="GridViewDFM_RowUpdating" AllowPaging="True" BorderColor="#cccccc">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRowNum" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Code" SortExpression="defect_code" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectCode" CssClass="form-control" runat="server" Text='<%# Bind("defect_code") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCode" runat="server"
                                            ErrorMessage="* Defect Code is a required field" ForeColor="Red" ControlToValidate="txtDefectCode" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidatorDefectCode" runat="server" Operator="DataTypeCheck" Type="Integer"
                                            ErrorMessage="* Defect Code ONLY accept whole numbers (0 - 9)" ForeColor="Red" ControlToValidate="txtDefectCode" Display="Dynamic"></asp:CompareValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectCode" runat="server" Text='<%# Bind("defect_code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IPC Code" SortExpression="IPC_code" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtIPCcode" CssClass="form-control" runat="server" Text='<%# Bind("IPC_code") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorIPCCode" runat="server"
                                            ErrorMessage="* IPC Code ONLY accept numbering format (Eg: 1.1.1)" ForeColor="Red" ControlToValidate="txtIPCcode" ValidationExpression="^[0-9]+(\.[0-9]{1,2})+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtIPCcode" runat="server" Text='<%# Bind("IPC_code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Name" SortExpression="defect_name" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectName" CssClass="form-control" runat="server" Text='<%# Bind("defect_name") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectName" runat="server"
                                            ErrorMessage="* Defect Name is a required field" ForeColor="Red" ControlToValidate="txtDefectName"></asp:RequiredFieldValidator>
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
                            SelectCommand="SELECT [defect_ID], [defect_code], [IPC_code], [defect_name], [defect_group], [defect_category], [defect_description] FROM [Defect_Modes] ORDER BY [defect_code]"
                            DeleteCommand="DELETE FROM [Defect_Modes] WHERE [defect_ID] = @defect_ID"
                            UpdateCommand="UPDATE [Defect_Modes] SET [defect_code] = @defect_code, [IPC_code] = @IPC_code, [defect_name] = @defect_name, [defect_group] = @defect_group, [defect_category] = @defect_category, [defect_description] = @defect_description WHERE [defect_ID] = @defect_ID">
                            <DeleteParameters>
                                <asp:Parameter Name="defect_ID" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="defect_code" Type="Decimal" />
                                <asp:Parameter Name="IPC_code" Type="String" />
                                <asp:Parameter Name="defect_name" Type="String" />
                                <asp:Parameter Name="defect_group" Type="String" />
                                <asp:Parameter Name="defect_category" Type="String" />
                                <asp:Parameter Name="defect_description" Type="String" />
                                <asp:Parameter Name="defect_ID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

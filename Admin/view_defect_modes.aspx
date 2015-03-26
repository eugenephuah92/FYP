<%@ Page Title="Auto SCAR &amp; TAT - View Defect Modes" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/view_defect_modes.aspx.cs" Inherits="Admin_view_defect_modes" %>

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
                        <div class="col-md-6">
                            <p style="padding-top: 10pt">
                                Records per page :
                                <asp:DropDownList ID="lstPageSize" Font-Size="Medium" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSizeChanged">
                                    <asp:ListItem Text="5" Value="5" />
                                    <asp:ListItem Text="10" Value="10" Selected="True" />
                                    <asp:ListItem Text="15" Value="15" />
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
                        <!-- Defect Modes Gridview -->
                        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="defectID" DataSourceID="SqlDataSource1" OnRowDataBound="Gridview1_DeleteConfirm" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" BackColor="White" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Defect Code" SortExpression="defectCode" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectCode" runat="server" Text='<%# Bind("defectCode") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCode" runat="server"
                                            ErrorMessage="* Defect Code is a required field" ForeColor="Red" ControlToValidate="txtDefectCode" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidatorDefectCode" runat="server" Operator="DataTypeCheck" Type="Integer" 
                                            ErrorMessage="* Defect Code ONLY accept whole numbers (0 - 9)" ForeColor="Red" ControlToValidate="txtDefectCode" Display="Dynamic"></asp:CompareValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectCode" runat="server" Text='<%# Bind("defectCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IPC Code" SortExpression="ipcCode" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtIPCcode" runat="server" Text='<%# Bind("ipcCode") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorIPCCode" runat="server" 
                                            ErrorMessage="* IPC Code ONLY accept numbering format (Eg: 1.1)" ForeColor="Red" ControlToValidate="txtIPCcode" ValidationExpression="^[0-9]+(\.[0-9]{1,2})+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>                       
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtIPCcode" runat="server" Text='<%# Bind("ipcCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Name" SortExpression="defectName" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectName" runat="server" Text='<%# Bind("defectName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectName" runat="server"
                                            ErrorMessage="* Defect Name is a required field" ForeColor="Red" ControlToValidate="txtDefectName"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectName" runat="server" Text='<%# Bind("defectName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Group" SortExpression="defectGroup" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="lstDefectGroup" runat="server" SelectedValue='<%# Bind("defectGroup") %>' DataSourceID="SqlDataSource2" DataTextField="defectGroup"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>" 
                                            SelectCommand="SELECT [defectGroupID], [defectGroup] FROM [DefectGroup]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectGroup" runat="server"
                                            ErrorMessage="* Defect Group is a required field" ForeColor="Red" ControlToValidate="lstDefectGroup"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectGroup" runat="server" Text='<%# Bind("defectGroup") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Category" SortExpression="defectCategory" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="lstDefectCategory" runat="server" SelectedValue='<%# Bind("defectCategory") %>' DataSourceID="SqlDataSource3" DataTextField="defectCategory"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:JabilDatabase %>" 
                                            SelectCommand="SELECT [defectCategoryID], [defectCategory] FROM [DefectCategory]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectCategory" runat="server"
                                            ErrorMessage="* Defect Category is a required field" ForeColor="Red" ControlToValidate="lstDefectCategory"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectCategory" runat="server" Text='<%# Bind("defectCategory") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defect Description" SortExpression="defectDescription" ControlStyle-Width="100%">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDefectDesc" runat="server" Text='<%# Bind("defectDescription") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDefectDesc" runat="server"
                                            ErrorMessage="* Defect Description is a required field" ForeColor="Red" ControlToValidate="txtDefectDesc"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="txtDefectDesc" runat="server" Text='<%# Bind("defectDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="Action" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-primary" />
                                    <ItemStyle Wrap="False" />
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
                            SelectCommand="SELECT [defectID], [defectCode], [ipcCode], [defectName], [defectGroup], [defectCategory], [defectDescription] FROM [DefectModes] ORDER BY [defectCode]"
                            DeleteCommand="DELETE FROM [DefectModes] WHERE [defectID] = @defectID"
                            UpdateCommand="UPDATE [DefectModes] SET [defectCode] = @defectCode, [ipcCode] = @ipcCode, [defectName] = @defectName, [defectGroup] = @defectGroup, [defectCategory] = @defectCategory, [defectDescription] = @defectDescription WHERE [defectID] = @defectID">
                            <DeleteParameters>
                                <asp:Parameter Name="defectID" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="defectCode" Type="Decimal" />
                                <asp:Parameter Name="ipcCode" Type="String" />
                                <asp:Parameter Name="defectName" Type="String" />
                                <asp:Parameter Name="defectGroup" Type="String" />
                                <asp:Parameter Name="defectCategory" Type="String" />
                                <asp:Parameter Name="defectDescription" Type="String" />
                                <asp:Parameter Name="defectID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                           
                        <style type="text/css">
                            .cssPager td {
                                padding-left: 4px;
                                padding-right: 4px;
                            }
                        </style>

                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

<%@ Page Title="Auto SCAR &amp; TAT - Manage User Account" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" EnableEventValidation="false" Inherits="Admin_manage_user_accounts" Codebehind="~/Admin/manage_user_accounts.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Manage User Account
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
                                    <asp:ListItem Value="Employee Name">Employee Name</asp:ListItem>
                                    <asp:ListItem Value="Employee ID">Employee ID</asp:ListItem>
                                    <asp:ListItem Value="Employee Email">Employee Email</asp:ListItem>
                                    <asp:ListItem Value="Employee Position">Employee Position</asp:ListItem>
                                    <asp:ListItem Value="Privilege">Privilege</asp:ListItem>
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
                                                        <asp:ListItem Value="Employee Name">Employee Name</asp:ListItem>
                                                        <asp:ListItem Value="Employee ID">Employee ID</asp:ListItem>
                                                        <asp:ListItem Value="Employee Email">Employee Email</asp:ListItem>
                                                        <asp:ListItem Value="Employee Position">Employee Position</asp:ListItem>
                                                        <asp:ListItem Value="Privilege">Privilege</asp:ListItem>
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
                                                        <asp:ListItem Value="Employee Name">Employee Name</asp:ListItem>
                                                        <asp:ListItem Value="Employee ID">Employee ID</asp:ListItem>
                                                        <asp:ListItem Value="Employee Email">Employee Email</asp:ListItem>
                                                        <asp:ListItem Value="Employee Position">Employee Position</asp:ListItem>
                                                        <asp:ListItem Value="Privilege">Privilege</asp:ListItem>
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
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
                                   <asp:GridView ID="displayUsers" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" OnRowDeleting="UsersGridView_RowDeleting" OnRowEditing="UsersGridView_RowEditing" OnRowCancelingEdit="UsersGridView_RowCancelingEdit" 
                                        OnRowUpdating="UsersGridView_RowUpdating"
                                       DataKeyNames="id"  runat="server" OnPageIndexChanging="OnPageIndexChanging" 
                                       AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table">
                                       <Columns>
                                           <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="getID" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField HeaderText="Employee ID" DataField="Employee ID"/>
                                           <asp:BoundField HeaderText="Employee Name" DataField="Employee Name"/>
                                           <asp:BoundField HeaderText="Employee Email" DataField="Employee Email" />
                                           <asp:BoundField HeaderText="Employee Position" DataField="Employee Position" />
                                           <asp:BoundField HeaderText="Privilege" DataField="Privilege"/>
                                       </Columns>
                                         <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <EmptyDataTemplate>
                                            <label style="color: Red; font-weight: bold">No records found for Users !</label>
                                        </EmptyDataTemplate>
                                       </asp:GridView>
  									<div id="messageBox" title="jQuery MessageBox In Asp.net" style="display: none;">
                                    
                                    </div>
                                </div>
                            </div>  
                    </form>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
    <script type="text/javascript">

         // For Alert
         function messageBox(message) {
             $("#messageBox").dialog({
                 modal: true,
                 height: 300,
                 width: 500,
                 title: "Manage User Account Status",
                 open: function () {
                     var markup = message;
                     $(this).html(markup);
                 },
                 buttons: {
                     Close: function () {
                         $(this).dialog("close");
                     }
                 },

             });
             return false;
         }
</script>
</asp:Content>
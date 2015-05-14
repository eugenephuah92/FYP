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
                	<div class="col-md-6">
                	    <p style="padding-top:10pt"> | <asp:LinkButton ID="display10records" runat="server" Text="Show 10 Records" OnClick="Show_10_Records"/> | <asp:LinkButton ID="display50records" runat="server" Text="Show 50 Records" OnClick="Show_50_Records"/> |
                    </div>
                            <div class="row">
                                <div class="col-md-3"  style="padding-top:10pt">
                                    <asp:DropDownList CssClass="form-control" ID="lstFilter" runat="server">  
                                        <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                    </asp:DropDownList>
                            	</div>
                                <div class="col-md-3"  style="padding-top:10pt">
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
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne" style="text-decoration:none">
                                                + Advanced Search
                                            </a>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse out" role="tabpanel" aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-6"  style="padding-top:10pt">
                                                        <asp:DropDownList CssClass="form-control" ID="test" runat="server">  
                                                            <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                                        </asp:DropDownList>
                            	                    </div>
                                                    <div class="col-md-6"  style="padding-top:10pt">
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
                                                    <div class="col-md-6"  style="padding-top:10pt">
                                                        <asp:DropDownList CssClass="form-control" ID="lstFilter3" runat="server">  
                                                            <asp:ListItem Selected="True">Please Select Filter</asp:ListItem>
                                                        </asp:DropDownList>
                            	                    </div>
                                                    <div class="col-md-6"  style="padding-top:10pt">
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
                        </p>
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
                                    
                                    <asp:Label ID="lblNoRows" runat="server" CssClass="col-lg-12 col-md-offset-3" />
                                   <asp:GridView ID="displayUsers" BorderWidth="2" AlternatingRowStyle-BorderWidth="2" 
                                       AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" OnRowDeleting="UsersGridView_RowDeleting" OnRowEditing="UsersGridView_RowEditing" OnRowCancelingEdit="UsersGridView_RowCancelingEdit" 
        OnRowUpdating="UsersGridView_RowUpdating"
                                       AllowSorting="true" DataKeyNames="id" OnSorting="UsersGridView_Sorting" runat="server" OnPageIndexChanging="OnPageIndexChanging" 
                                       AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover">
                                       <Columns>
                                           <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="getID" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField HeaderText="Employee ID" DataField="Employee ID" SortExpression="Employee ID"/>
                                           <asp:BoundField HeaderText="Employee Name" DataField="Employee Name" SortExpression="Employee Name"/>
                                           <asp:BoundField HeaderText="Employee Email" DataField="Employee Email" SortExpression="Employee Email"/>
                                           <asp:BoundField HeaderText="Employee Position" DataField="Employee Position" SortExpression="Employee Position"/>
                                           <asp:BoundField HeaderText="Privilege" DataField="Privilege" SortExpression="Privilege"/>
                                       </Columns>
                                   
                                       </asp:GridView>
  									
                                </div>
                            </div>  
                    </form>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
    <script type="text/javascript">
    function ShowMessage(message) {
        alert(message);
        window.location("manage_user_accounts.aspx");
        }
</script>
</asp:Content>
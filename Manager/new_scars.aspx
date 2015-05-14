<%@ Page Title="Auto SCAR &amp; TAT - New SCARS" EnableEventValidation="false" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" Inherits="Manager_new_scars" Codebehind="~/Manager/new_scars.aspx.cs"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    New SCAR
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
                            </div>
                    </p>
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:25pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
                                   <asp:Label ID="lblNoRows" runat="server" CssClass="col-lg-12 col-md-offset-3" />
                                   <asp:GridView ID="displayNewSCAR" BorderWidth="2" AlternatingRowStyle-BorderWidth="2" AllowSorting="true" OnSorting="SCARGridView_Sorting" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover">
                                       <Columns>
                                           <asp:TemplateField HeaderText="CAR Number" SortExpression="CAR Number">
                                            <ItemTemplate>
                                           <asp:HyperLink ID="link" runat="server" Text='<%#Eval("CAR Number") %>' NavigateUrl='<%# Eval("CAR Number","view_scar_record.aspx?scar_no={0}") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField HeaderText="Defect Mode" DataField="Defect Mode" SortExpression="Defect Mode"/>
                                           <asp:BoundField HeaderText="SCAR Type" DataField="SCAR Type" SortExpression="SCAR Type"/>
                                           <asp:BoundField HeaderText="Creation Date" DataField="Creation Date"/>
                                           <asp:BoundField HeaderText="Level of Escalation" DataField="Level of Escalation"/>
                                           <asp:BoundField HeaderText="Days Till Next Escalation" DataField="Days Till Next Escalation"/>
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
</asp:Content>

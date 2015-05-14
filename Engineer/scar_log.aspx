<%@ Page Title="Auto SCAR &amp; TAT - SCAR Log" Language="C#" MasterPageFile="~/Engineer.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Engineer_scar_log" Codebehind="~/Engineer/scar_log.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    SCAR Log
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
                                        <asp:TextBox CssClass="form-control" ID="searchTxt" runat="server" placeholder="Search for..." />
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
                                <div class="col-lg-12" style="padding-left:25pt; padding-right:30pt; padding-top:15pt; padding-bottom:15pt">
                                	<!-- Table -->
                                    <asp:UpdatePanel ID="updatePanelSCARLog" runat="server" UpdateMode="Always">
                                     <ContentTemplate>
                                   <asp:Label ID="lblNoRows" runat="server" CssClass="col-lg-12 col-md-offset-3" />
                                   <asp:GridView ID="displaySCARLog" BorderWidth="2" HeaderStyle-ForeColor="Black" AllowSorting="true" OnSorting="SCARLogGridView_Sorting" AlternatingRowStyle-BorderWidth="2" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered table-hover">
                                       <Columns>
                                           <asp:TemplateField HeaderText="CAR Number" SortExpression="CAR Number">
                                            <ItemTemplate>
                                           <asp:HyperLink ID="link" runat="server" Text='<%#Eval("CAR Number") %>' NavigateUrl='<%# String.Format("scars_forms.aspx?scar_no={0}", Eval("CAR Number")) %>'></asp:HyperLink>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status"/>
                                           <asp:BoundField HeaderText="Disapprove Frequency" DataField="Disapprove Frequency" SortExpression="Disapprove Frequency"/>
                                           <asp:BoundField HeaderText="Creation Date" DataField="Creation Date"/>
                                           <asp:BoundField HeaderText="Completion Date" DataField="Completion Date"/>
                                       </Columns>
                                         
                                       </asp:GridView>
                                    </ContentTemplate>
  								</asp:UpdatePanel>	
  									
                                </div>
                            </div> 
                    </form>
                </div>
            </div>
        </div> <!--/.col-md-12-->
    </div>
</div>
</asp:Content>
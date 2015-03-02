<%@ Page Title="Auto SCAR &amp; TAT - Add New Defect Modes" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/add_new_defect_modes.aspx.cs" Inherits="Admin_add_new_defect_modes" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Defect Mode Page for admin: Allows Admin to add new defect modes -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Add New Defect Modes
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="txtNewDefectName" class="col-lg-2 control-label">New Defect Name</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNewDefectName" runat="server" placeholder="New Defect Modes" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtNewDefectCode" class="col-lg-2 control-label">New Defect Code</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNewDefectCode" runat="server" placeholder="New Defect Code" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtNewIPCCode" class="col-lg-2 control-label">New IPC Code</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNewIPCCode" runat="server" placeholder="New IPC Code" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="lstNewDefectType" class="col-lg-2 control-label">New Defect Type</label>
                                    <div class="col-lg-10">
                                        <asp:DropDownList CssClass="form-control" ID="lstNewDefectType" runat="server">
                                            <asp:ListItem>Please Select Defect Type</asp:ListItem>
                                            <asp:ListItem>Performance</asp:ListItem>
                                            <asp:ListItem>Non-Performance</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="lstNewDefectCategory" class="col-lg-2 control-label">New Defect Category</label>
                                    <div class="col-lg-10">
                                        <asp:DropDownList CssClass="form-control" ID="lstNewDefectCategory" runat="server">
                                            <asp:ListItem>Please Select Defect Category</asp:ListItem>
                                            <asp:ListItem>Category A</asp:ListItem>
                                            <asp:ListItem>Category B</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtNewDefectDescription" class="col-lg-2 control-label">New Defect Description</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="New Defect Description" TextMode="MultiLine" Rows="5"/>
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <br />
                                        <asp:Button CssClass="btn btn-success" ID="btnSubmit" runat="server" Text="Submit" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>
</asp:Content>
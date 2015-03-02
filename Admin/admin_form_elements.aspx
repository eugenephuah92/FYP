<%@ Page Title="Auto SCAR &amp; TAT - Manage Form Elements" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/admin_form_elements.aspx.cs" Inherits="Admin_admin_form_elements" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Manage Form Elements Page for admin: Allows Admin to edit/add/remove form element values -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                   Modify Form Elements
                </div>
                <div class="panel-body" style="padding-top:10pt">
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <label for="formElements" class="col-lg-2 control-label">Form Elements</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="lstElements" runat="server" CssClass="form-control">
                                        <asp:ListItem>Please Select Form Elements</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br /><br />
                            <div class="form-group">
                                <label for="rootCause" class="col-lg-2 control-label">Root Cause Options</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="lstRootCause" runat="server" CssClass="form-control">
                                        <asp:ListItem>Please Select Root Cause Option</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br /><br />
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <button type="submit" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-lg-add">Add New Element</button>
                                    <button type="submit" class="btn btn-success" data-toggle="modal" data-target=".bs-example-modal-lg-modify">Modify</button>
                                    <asp:Button ID="btnRemove" CssClass="btn btn-danger" runat="server" Text="Remove"/>
                                </div>
                            </div>

							<div class="modal fade bs-example-modal-lg-add" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title">Add Root Cause Option</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">
                                                <label for="txtAddRootCause" class="col-lg-4 control-label">Root Cause Option</label>
                                            <div class="col-lg-7">
                                                <asp:TextBox ID="txtAddRootCause" CssClass="form-control" runat="server" placeholder="Root Cause Option" />
                                            </div>
                                            <br />
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnSaveAdd" CssClass="btn btn-primary" runat="server" Text="Save Change" />
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="modal fade bs-example-modal-lg-modify" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title">Modify Root Cause Option</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">
                                                <label for="txtModifyRootCause" class="col-lg-4 control-label">Root Cause Option</label>
                                            <div class="col-lg-7">
                                                <asp:TextBox ID="txtModifyRootCause" CssClass="form-control" runat="server" placeholder="Root Cause Option" Text="1. Agilent and CM joint issue - Material" />
                                            </div>
                                            <br />
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                  	        <asp:Button ID="btnSaveModify" CssClass="btn btn-primary" runat="server" Text="Save Change" />
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </form>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
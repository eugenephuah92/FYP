<%@ Page Title="Auto SCAR &amp; TAT - Admin Form Elements" Language="C#" MasterPageFile="~/Admin.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Admin_admin_form_elements" Codebehind="~/Admin/admin_form_elements.aspx.cs" %>

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
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br /><br />
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnAddNewElement" CssClass="btn btn-primary" Text="Add New Element" OnClick="Click_Add" runat="server" />
                                    <asp:Button ID="btnModifyElement" CssClass="btn btn-success" Text="Modify Existing Element" OnClick="Click_Modify" runat="server" />
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
                 title: "Form Elements Status",
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
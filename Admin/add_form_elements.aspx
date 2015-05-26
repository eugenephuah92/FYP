<%@ Page Title="Auto SCAR &amp; TAT - Add Form Elements" Language="C#" MasterPageFile="~/Admin.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Admin_add_form_elements" Codebehind="add_form_elements.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Manage Form Elements Page for admin: Allows Admin to edit/add/remove form element values -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                   Add Form Elements  
                </div>
                <div class="panel-body" style="padding-top:10pt">
                    <form class="form-horizontal pad10" action="#" method="post">
                            <div class="form-group">
                                <asp:Label ID="formElements" Font-Bold="true" CssClass="col-lg-2 control-label" runat="server" />
                                <div class="col-lg-10">
                                <asp:TextBox ID="txtAddElement" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <br /><br />
                        <div id="messageBox" title="jQuery MessageBox In Asp.net" style="display: none;">
                                    
                                </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button CssClass="btn btn-primary" ID="btnAdd" runat="server" Text="Add Element" OnClick="Click_Add" />
                                </div>
                            </div>

							
                    </form>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
    <script type="text/javascript">
        // For Confirmation
        $(function () {

            $("#<%=btnAdd.ClientID%>").on("click", function (event) {
             event.preventDefault();
             $("#messageBox").dialog({
                 resizable: false,
                 title: "Add Element Confirmation",
                 open: function () {
                     var markup = "Are you sure you want to add this element?";
                     $(this).html(markup);
                 },
                 height: 200,

                 modal: true,
                 buttons: {
                     Ok: function () {
                         $(this).dialog("close");
                         __doPostBack($('#<%= btnAdd.ClientID %>').attr('name'), '');
                         },
                         Cancel: function () {
                             $(this).dialog("close");

                         }
                     }
                 });
         });
     });


         // For Alert
         function messageBox(message) {
             $("#messageBox").dialog({
                 modal: true,
                 height: 300,
                 width: 500,
                 title: "Add Element Status",
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
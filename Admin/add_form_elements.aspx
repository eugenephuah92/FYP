<%@ Page Title="Auto SCAR &amp; TAT - Add Form Elements" Language="C#" MasterPageFile="~/Admin.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Admin_add_form_elements" Codebehind="add_form_elements.aspx.cs" %>

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
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add Element" OnClick="Click_Add" OnClientClick="if ( ! AddConfirmation()) return false;"/>
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
        }

        function AddConfirmation() {
            return confirm("Are you sure you want to add this element?");
        }
    </script>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - Add New Escalation / Reminder" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="True" Inherits="Admin_add_new_escalation_reminder" Codebehind="~/Admin/add_new_escalation_reminder.aspx.cs" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Escalation / Reminder Page for admin: Allows admin to create a new escalation level and reminder -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            TAT - Add New Escalation / Reminder
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="txtNELN" class="col-lg-2 control-label">New Escalation Level Name</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtNELN" runat="server" placeholder="New Escalation Level Name" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group" style="padding-top:10pt">
                                    <label for="chkbUsersInvolved" class="col-lg-2 control-label">Users Involved (Position)</label>
                                    <div class="col-lg-8" style="margin-right:10pt; padding-top:5pt; padding-bottom:5pt;">
                                        <asp:CheckBoxList ID="chkbUsersInvolved" runat="server">
                                            <asp:ListItem Value="QEL">Quality Engineer Lead</asp:ListItem> 
                                            <asp:ListItem Value="QM">Quality Manager</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <br /><br />
                                </div>

                                <div class="form-group" style="padding-top:10pt">
                                    <label for="txtDuration" class="col-lg-2 control-label">Duration Till Next Escalation</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtDuration" runat="server" placeholder="Duration Till Next Escalation (Days)" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group" style="padding-top:10pt">
                                    <label for="lblEscalationLvl" class="col-lg-2 control-label">Escalation Level</label>
                                    <asp:UpdatePanel ID="updatepanel" runat="server">
                                        <ContentTemplate>
                                            <div class="col-lg-10" >                                        
                                                <asp:Label CssClass="form-control" ID="lblEscalationLvl" runat="server"></asp:Label>
                                            </div>
                                            <br /><br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group" style="padding-top:10pt">
                                    <label for="txtEmail" class="col-lg-2 control-label">Email Content</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" placeholder="Message in the Email" TextMode="MultiLine" Rows="2" runat="server" />
                                    </div>
                                    <br /><br />
                                </div>
                                <div class="form-group" style="padding-top:10pt">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <asp:Button CssClass="btn btn-success" ID="btnSubmitNEL" onClick="Submit_NEL" runat="server" Text="Submit" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>
</asp:Content>
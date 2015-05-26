<%@ Page Title="Auto SCAR &amp; TAT - Pending Open Items" Language="C#" MasterPageFile="~/Manager.Site.Master" EnableEventValidation="false" AutoEventWireup="true" Inherits="Manager_pending_open_items" Codebehind="~/Manager/pending_open_items.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Pending Open Items Page for managers: Displays the pending open items for tracking -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Pending Open Action Items
                </div>
                    <div class="panel-body" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                        <asp:Label ID="lblNoRows" runat="server" CssClass="col-lg-12 col-md-offset-3" />
                        <asp:GridView ID="displayPendingOpenItems" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" CssClass="table">
                                       <Columns>
                                           <asp:BoundField HeaderText="CAR Number" DataField="CAR Number"  />
                                           <asp:TemplateField HeaderText="S2 - Containment Action">
                                            <ItemTemplate>
                                               <asp:CheckBox runat="server" Enabled="false" ID="chkTrackContainmentAction" Text="Track Item" Checked='<%#Convert.ToBoolean(Eval("S2 Track Containment Action"))%>' />
                                               <br />
                                               <asp:Label runat="server" ID="lbls21ContainmentAction" Text='<%#Eval("S21 Containment Action")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lbls22ImplementationDate" Text='<%#Eval("S22 Implementation Date")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lbls23ResponsiblePerson" Text='<%#Eval("S23 Responsible Person")%>'/>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S5 - Corrective Action">
                                            <ItemTemplate>
                                               <asp:CheckBox runat="server" Enabled="false" ID="chkTrackCorrectiveAction" Text="Track Item" Checked='<%#Convert.ToBoolean(Eval("S5 Track Corrective Action"))%>' />
                                               <br />
                                               <asp:Label runat="server" ID="lbls51CorrectiveAction" Text='<%#Eval("S51 Corrective Action")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lbls52ImplementationDate" Text='<%#Eval("S52 Implementation Date")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lbls53ResponsiblePerson" Text='<%#Eval("S53 Responsible Person")%>'/>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="S6 - Permanent Corrective Action">
                                            <ItemTemplate>
                                               <asp:CheckBox runat="server" Enabled="false" ID="chkTrackPermanentCorrectiveAction" Text="Track Item" Checked='<%#Convert.ToBoolean(Eval("S6 Track Permanent Corrective Action"))%>' />
                                               <br />
                                               <asp:Label runat="server" ID="lbls61PermanentCorrectiveAction" Text='<%#Eval("S61 Permanent Corrective Action")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lbls62ImplementationDate" Text='<%#Eval("S62 Implementation Date")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lbls63ResponsiblePerson" Text='<%#Eval("S63 Responsible Person")%>'/>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                       </Columns>
                                   <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle CssClass="cssPager" BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <EmptyDataTemplate>
                                            <label style="color: Red; font-weight: bold">No records found for Pending Open Items !</label>
                                        </EmptyDataTemplate>
                                       </asp:GridView>
                        
                        <div class="form-group" style="text-align:center">
                            <div>
                                <asp:Button CssClass="btn btn-success" Text="Export" runat="server" OnClick="Export_Items"/>
                                <asp:Button CssClass="btn btn-primary" Text="Print" OnClientClick="print()" runat="server" />
                            </div>
                        </div>
                             
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
    <!-- Print gridview -->
    <script type="text/javascript">
        function print() {
            var prtContent = document.getElementById('<%= displayPendingOpenItems.ClientID %>');
            var printWindow = window.open('', '', 'left=100,top=100,width=0,height=0,resizable=1');
            printWindow.document.write(prtContent.outerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
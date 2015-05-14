<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" Inherits="Admin_reports_Q3" CodeBehind="~/Admin/reports_Q3.aspx.cs" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Print gridview -->
    <script type="text/javascript">
        function print() {
            var prtContent = document.getElementById('<%= GridViewQ3.ClientID %>');
            var printWindow = window.open('', '', 'left=100,top=100,width=0,height=0,resizable=1');
            printWindow.document.write(prtContent.outerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>

    <div class="right-panel">
        <div class="right-panel-inner">
            <div class="col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Report - 3rd Quadrant (Q3)
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="col-lg-12" style="padding-top: 10pt">
                                <span class="help-block" style="color:red;font-size:small" >* Please double check all the data entered as they CANNOT be edited once you click on <b>Add Record</b>.</span>
                                <!-- Table -->
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>WW</th>
                                            <th>Defect</th>
                                            <th>Corrective / Preventive Action</th>
                                            <th>PIC</th>
                                            <th>Due Date</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtWW" CssClass="form-control" runat="server" placeholder="Enter WW" Width="100%" />
                                                <asp:CustomValidator ID="CustomValidatorCheckEmpty" runat="server"
                                                    ErrorMessage="* Please fill in at least ONE field" ForeColor="Red" ControlToValidate="txtWW" OnServerValidate="CheckEmptyField" ValidateEmptyText="true"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDefect" CssClass="form-control" runat="server" placeholder="Enter Defect" Width="100%" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCAPA" CssClass="form-control" runat="server" placeholder="Enter CAPA" TextMode="MultiLine" Width="100%" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPIC" CssClass="form-control" runat="server" placeholder="Enter PIC" Width="100%" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDueDate" CssClass="form-control" runat="server" TextMode="Date" Width="100%" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStatus" CssClass="form-control" runat="server" placeholder="Enter Status" Width="100%" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="col-lg-12" style="text-align:center">
                                <asp:Button ID="btnAddRecord" CssClass="btn btn-primary" Text="Add Record" runat="server" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnClear" CssClass="btn btn-danger" Text="Clear" runat="server" OnClick="btnClear_Click" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-12">
                                <br />
                                <asp:Label ID="lblInfo" runat="server" ForeColor="Red" Font-Size="Small" Text="* All records saved in the table will be <u>deleted</u> if the page is refreshed / redirected." Visible="false" />

                                <!-- Q3 Report Gridview -->
                                <asp:GridView ID="GridViewQ3" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridViewQ3_RowDataBound" BorderColor="#cccccc" Width="100%">
                                    <Columns>
                                        <asp:BoundField HeaderText="WW" DataField="WW" />
                                        <asp:BoundField HeaderText="Defect" DataField="Defect" />
                                        <asp:BoundField HeaderText="Corrective / Preventive Action" DataField="CAPA" ItemStyle-Wrap="true" ControlStyle-Width="100%" />
                                        <asp:BoundField HeaderText="PIC" DataField="PIC" />
                                        <asp:BoundField HeaderText="Due Date" DataField="DueDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="Black" />
                                    <HeaderStyle BackColor="AliceBlue" Font-Bold="True" ForeColor="Black" />
                                    <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
                                    <RowStyle ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button ID="btnExport" CssClass="btn btn-success" Text="Export to Excel" runat="server" OnClick="btnExport_Click" Visible="false" />
                                <asp:Button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" OnClientClick="print()" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/.col-md-12-->
        </div>
    </div>
</asp:Content>

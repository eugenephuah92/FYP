<%@ Control Language="C#" AutoEventWireup="true" Inherits="navbar" Codebehind="navbar.ascx.cs" %>

<!-- Top Navigational Bar -->    
    <nav class="navbar navbar-default" role="navigation">
        <div class="container-fluid">

            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle visible-sm visible-xs closed" id="menu-toggle">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    Auto SCAR & TAT Monitoring and Triggering System
                </a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                         
                <ul class="nav navbar-nav navbar-right">

                    <li class="navaccount clearfix">
                        <asp:LinkButton runat="server" ID="btnModal" OnClick="changeStatus"> <i class="fa fa-globe"></i>&nbsp;
                            <span id="notification" runat="server" class="badge-active">
                                        <asp:Label ID="lblNotification" runat="server"/>
                                        
                            </span>

                        </asp:LinkButton>
                       

                        <!-- Modal -->
                        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                    <ContentTemplate>
                                    <div class="modal-content">
                                        <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" id="myModalLabel" style="color:black;"> Notifications </h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lblNoRows" runat="server" />
                                            <asp:GridView CssClass="table table-condensed" ID="displayNotifications" runat="server" 
                                         AutoGenerateColumns="false" PageSize="15"
                                         BorderColor="#CCCCCC" Width="100%" RowStyle-ForeColor="Black"
            BorderStyle="Solid" BorderWidth="1px">
                                        <HeaderStyle Height="30px" BackColor="#01385B" ForeColor="White" Font-Size="15px" BorderColor="#CCCCCC"
                BorderStyle="Solid" BorderWidth="1px" />
                                       <Columns>
                                           <asp:BoundField HeaderText="From" DataField="Notice From"/>
                                           <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                               <asp:Label runat="server" ID="lblNoticeSubject" Text='<%#Eval("Notice Subject")%>'/>
                                               <br />
                                               <asp:Label runat="server" ID="lblNoticeBody" Text='<%#Eval("Notice Body")%>'/>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:BoundField HeaderText="Date / Time" DataField="Notice Timestamp"/>
                                       </Columns>
                                   
                                       </asp:GridView>
                                        </div>
                                        <div class="modal-footer">
                                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                        </div>
                                    </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>



                    </li>
                    <li class="navaccount clearfix">
                        <a href="#">Hi, <asp:Label ID="lbl_employee_name" runat="server"/></a>
                    </li>


                    <li>
                        <div class="form-group navform">
                            <a href="../Logout.aspx" class="btn btn-default"><i class="fa fa-sign-out"></i>&nbsp;Log Out</a>
                        </div>
                    </li>

                </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>

<script type="text/javascript">
    $('#myModal').on('hidden.bs.modal', function (e) {
        document.getElementById("<%=lblNotification.ClientID%>").innerText = "0";
    })
    
</script>




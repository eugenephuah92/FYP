<%@ Page Title="Auto SCAR &amp; TAT - Pending Open Items" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" CodeFile="~/Manager/pending_open_items.aspx.cs" Inherits="Manager_pending_open_items" %>

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
                        <table class="table">
                            <thead>
                            <tr>
                                <th>SCAR ID</th>
                                <th>S2 - Containment Action</th>
                                <th>S5 - Corrective Action</th>
                                <th>S6 - Permanent Corrective Action</th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <td>100001</td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>10/04/2013</div>
                                    <div><strong>Responsible Person: </strong>Wai Moh</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>05/12/2014</div>
                                    <div><strong>Responsible Person: </strong>Wai Moh</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-remove"></span></div>
                                    <div><strong>Implementation Date: </strong>N/A</div>
                                    <div><strong>Responsible Person: </strong>N/A</div>
                                </td>
                            </tr>
                            <tr>
                                <td>100002</td>
                                <td>
                                    <div><span class="glyphicon glyphicon-remove"></span></div>
                                    <div><strong>Implementation Date: </strong>N/A</div>
                                    <div><strong>Responsible Person: </strong>N/A</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>13/01/2014</div>
                                    <div><strong>Responsible Person: </strong>Kin Tat</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>28/09/2014</div>
                                    <div><strong>Responsible Person: </strong>Kin Tat</div>
                                </td>
                            </tr>
                            <tr>
                                <td>100003</td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>22/06/2013</div>
                                    <div><strong>Responsible Person: </strong>Wei Keong</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>12/02/2014</div>
                                    <div><strong>Responsible Person: </strong>Wei Keong</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>01/12/2014</div>
                                    <div><strong>Responsible Person: </strong>Wei Keong</div>
                                </td>
                            </tr>
                            <tr>
                                <td>100004</td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>04/03/2013</div>
                                    <div><strong>Responsible Person: </strong>Azlan</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-remove"></span></div>
                                    <div><strong>Implementation Date: </strong>N/A</div>
                                    <div><strong>Responsible Person: </strong>N/A</div>
                                </td>
                                <td>
                                    <div><span class="glyphicon glyphicon-ok"></span></div>
                                    <div><strong>Implementation Date: </strong>05/04/2014</div>
                                    <div><strong>Responsible Person: </strong>Azlan</div>
                                </td>
                            </tr>
                            </tbody>
                        </table>
                        <div class="form-group" style="text-align:center">
                            <div>
                                <asp:Button CssClass="btn btn-success" Text="Export" runat="server" />
                                <asp:Button CssClass="btn btn-success" Text="Print" runat="server" />
                            </div>
                        </div>
                        <nav style="padding-right:30pt">
                                <ul class="pagination pull-right">
                                    <li>
                                        <a href="#" aria-label="Previous">
                                            <span aria-hidden="true">&laquo;</span>
                                        </a>
                                    </li>
                                    <li><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li>
                                        <a href="#" aria-label="Next">
                                            <span aria-hidden="true">&raquo;</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>         
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
<%@ Page Title="Auto SCAR &amp; TAT - 8D Approval Request" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" CodeFile="~/Manager/8Drequest.aspx.cs" Inherits="Manager_8Drequest" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<!-- 8D Request Page for managers: Displays existing 8D requests from Engineers-->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    8D Approval Requests
                </div>
                    <div class="panel-body" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                        <table class="table table-hover">
                            <thead>
                            <tr>
                                <th>SCAR ID</th>
                                <th>QE Name (Sender)</th>
                                <th>Sent Date</th>
                                <th></th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <td>100001</td>
                                <td>Shazmeen Zainudin</td>
                                <td>
                                    <div><strong>Date: </strong>23/02/2014</div>
                                    <div><strong>Time: </strong>12.06pm</div>
                                </td>
                                <td><a class="btn btn-success" href="8Dapproval.aspx">View SCAR</a></td>
                            </tr>
                            <tr>
                                <td>100002</td>
                                <td>Hairul Azam</td>
                                <td>
                                    <div><strong>Date: </strong>12/06/2014</div>
                                    <div><strong>Time: </strong>9.10am</div>
                                </td>
                                <td><a class="btn btn-success" href="8Dapproval.aspx">View SCAR</a></td>
                            </tr>
                            <tr>
                                <td>100003</td>
                                <td>SharmilaDevi Marimuthu</td>
                                <td>
                                    <div><strong>Date: </strong>10/11/2014</div>
                                    <div><strong>Time: </strong>10.50am</div>
                                </td>
                                <td><a class="btn btn-success" href="8Dapproval.aspx">View SCAR</a></td>
                            </tr>
                            </tbody>
                        </table>
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
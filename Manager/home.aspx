﻿<%@ Page Title="Auto SCAR &amp; TAT - Home" Language="C#" MasterPageFile="~/Manager.Site.Master" AutoEventWireup="true" CodeFile="~/Manager/home.aspx.cs" Inherits="Manager_home" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Home Page for managers: Displays summary -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">

            <div class="panel panel-info">
                <div class="panel-heading">
                    8D Approval Requests
                </div>
                    <div class="panel-body">
                            <div class="form-group">
                                <div class="col-lg-11" style="padding-left:100pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">                                    	
    									<tbody>
                                          	<tr>
                                            	<td style="padding-left:45pt"><a href="scar_record.aspx" style="text-decoration:none">View Total SCARS</a></td>
                                                <td><span class="badge">5</span></td>
                                          	</tr>   
                                            <tr>
                                            	<td style="padding-left:45pt"><a href="8Drequest.aspx" style="text-decoration:none">Pending 8D Approval Requests</a></td>
                                                <td><span class="badge">2</span></td>
                                          	</tr>                                   
                                        </tbody>
  									</table>
                                </div>
                            </div> 
                    </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
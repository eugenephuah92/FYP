<%@ Page Title="Auto SCAR &amp; TAT - Home" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/home.aspx.cs" Inherits="Admin_home" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Home Page for admin: Displays summary -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">

            <div class="panel panel-info">
                <div class="panel-heading">
                    Summary
                </div>
                    <div class="panel-body">	
                            <div class="form-group">
                                <div class="col-lg-11" style="padding-left:100pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">                                    	
    									<tbody>
                                        	
                                          	<tr>
                                            	<td style="padding-left:45pt"><a href="total_scars.html" style="text-decoration:none">Total SCAR</a></td>
                                                <td><span class="badge">5</span></td>
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
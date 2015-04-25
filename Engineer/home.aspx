<%@ Page Title="Auto SCAR &amp; TAT - Home" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_home" Codebehind="~/Engineer/home.aspx.cs" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Home Page for engineers: Displays summary -->
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
                                                <td style="padding-left:45pt"><a href="new_scars.aspx" style="text-decoration:none">New SCAR</a></td>
                                                <td><span class="badge"><asp:Label ID="lblNewSCAR" runat="server"/></span></td>
                                       	    </tr>
                                            <tr>
                                                <td style="padding-left:45pt"><a href="pending_scars.aspx" style="text-decoration:none">Pending SCAR</a></td>
                                                <td><span class="badge"><asp:Label ID="lblPendingSCAR" runat="server"/></span></td>
                                            </tr>                  
                                            <tr>
                                                <td style="padding-left:45pt"><a href="closed_scars.aspx" style="text-decoration:none">Closed SCAR</a></td>
                                                <td><span class="badge"><asp:Label ID="lblClosedSCAR" runat="server"/></span></td>
                                            </tr>    
                                            <tr>
                                                <td style="padding-left:45pt"><a href="total_scars.aspx" style="text-decoration:none">Total SCAR</a></td>
                                                <td><span class="badge"><asp:Label ID="lblTotalSCAR" runat="server"/></span></td>
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
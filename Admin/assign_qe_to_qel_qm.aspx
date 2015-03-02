<%@ Page Title="Auto SCAR &amp; TAT - Assign QE to QEL / QM" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/assign_qe_to_qel_qm.aspx.cs" Inherits="Admin_assign_qe_to_qel_qm" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Home Page for admin: Displays summary -->
<div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Assign QE to QEL, QM
                </div>
                <div class="panel-body">
                    <form class="form-horizontal pad10" action="#" method="post">
                    	<div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table table-hover">
                                    	<thead>
                                        	<tr>
                                                <th style="padding-left:30pt">Quality Engineer (QE)</th>
                                                <th style="padding-left:30pt">Quality Engineer Lead (QEL)</th>
                                                <th style="padding-left:30pt">Quality Manager (QM)</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td style="padding-left:30pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QE1">
                                                        	<option selected>QE</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                                <td style="padding-left:40pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QEL1">
                                                        	<option selected>QEL</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                                <td style="padding-left:30pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QM1">
                                                        	<option selected>QM</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                          	</tr>
                                          	<tr>
                                            	<td style="padding-left:30pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QE2">
                                                        	<option selected>QE</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                            	<td style="padding-left:40pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QEL2">
                                                        	<option selected>QEL</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                            	<td style="padding-left:30pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QM2">
                                                        	<option selected>QM</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                          	</tr>
                                          	<tr>
                                            	<td style="padding-left:30pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QE3">
                                                        	<option selected>QE</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                            	<td style="padding-left:40pt">
                                                	<div class="col-lg-7" style="padding-top:8pt; padding-bottom:8pt">
                                                    	<select class="form-control" id="QEL3">
                                                        	<option selected>QEL</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                            	<td style="padding-left:30pt">
                                                	<div class="col-lg-7" style="padding-top:8pt;; padding-bottom:8pt">
                                                    	<select class="form-control" id="QM3">
                                                        	<option selected>QM</option>
                                                            <option>Gorilla</option>
                                                            <option>Tony Hudson</option>
                                                            <option>Jeff Long</option>
                                                            <option>Blake Shelton</option>
                                                        </select>
                                                   </div>
                                                </td>
                                          	</tr>                                         
                                        </tbody>
  									</table>
                                </div>
                            </div>                          
                            <div class="form-group">
                                <div class="col-lg-10" style="text-align:center">
                                    <button class="btn btn-primary">Save</button>
                                    <button type="submit" class="btn btn-success">Submit</button>
                                </div>
                            </div>
                    </form>
                </div>
            </div>
        </div><!--/.col-md-12-->
    </div>
</div>
</asp:Content>
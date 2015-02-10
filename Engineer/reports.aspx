<%@ Page Title="Auto SCAR &amp; TAT - Reports" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" CodeFile="~/Engineer/reports.aspx.cs" Inherits="Engineer_reports" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="right-panel">
    <div class="right-panel-inner">
        <div class="col-md-12">

            <div class="panel panel-info">
                <div class="panel-heading">
                    Manual Escalation
                </div>
                <div class="panel-body">
                	<div class="col-md-4">
                	<p style="padding-top:10pt"> | <a href="#">Show 10 records</a> | <a href="#">Show 50 records</a> | 
                    </div>
                    	
                            <div class="row">
                                <div class="col-md-3" style="padding-top:10pt">
                                    <asp:DropDownList CssClass="form-control" ID="lstReport" runat="server" >
                                          <asp:ListItem Selected="True">Please Select Report Type</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1" style="padding-top:10pt">
                                    <asp:Button ID="btnGenerateReport" CssClass="btn btn-primary" Text="Generate" runat="server" />
                            	</div>
                            </div>
                    
                    
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-left:30pt; padding-right:30pt; padding-top:15pt">
                                	<!-- Table -->
  									<table class="table">
                                    	<thead>
                                        	<tr>
                                                <th style="padding-left:30pt">CAR Number</th>
                                                <th style="padding-left:30pt">Assigned QE Name</th>
                                          	</tr>
                                        </thead>
    									<tbody>
                                        	<tr>
                                                <td style="padding-left:30pt">P-SOQANP-140916</td>
                                                <td style="padding-left:30pt">
                                                	<a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true" style="text-decoration:none; color:#000;">Doe</a>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="myModalName" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:100pt">
                                                      <div class="modal-dialog">
                                                        <div class="modal-content">
                                                          <div class="modal-header" style="padding-top:15pt">
                                                          	<strong>Assign New Quality Engineer</strong>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br>
                                                          </div>
                                                          <div class="modal-body" style="padding-top:30pt">
                                                            <div class="form-group">
                                                                <label for="inputCARNo" class="col-lg-4 control-label">CAR Number</label>
                                                                <div class="row">
                                                                	<div class="col-lg-6">
                                                                    	<div class="input-group">
                                                                        	<input type="text" class="form-control" placeholder="Search for...">
                                                                            <span class="input-group-btn">
                                                                                <button class="btn btn-default" type="button">
                                                                                	<span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                                                </button>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <label for="inputNewQE" class="col-lg-4 control-label" style="padding-top:20pt">New QE</label>
                                                                <div class="col-lg-6" style="padding-top:15pt">
                                                                    <select class="form-control" id="select2">
                                                                    	<option selected>Please select new QE</option>
                                                                        <option>Gorilla</option>
                                                                        <option>Tony Hudson</option>
                                                                        <option>Jeff Long</option>
                                                                        <option>Blake Shelton</option>
                                                                    </select>
                                                                </div>
                                                          	</div>
                                                          </div>
                                                          <div class="modal-footer">
                                                            <button type="submit" class="btn btn-success">Submit</button>
                                                          </div>
                                                        </div>
                                                      </div>
                                                    </div>
                                                </td>
                                          	</tr>
                                          	<tr>
                                            	<td style="padding-left:30pt">P-SOBDP-142945</td>
                                            	<td style="padding-left:30pt">
                                                	<a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true" style="text-decoration:none; color:#000;">SharmilaDevi Marimuthu</a>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="Div1" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:85pt">
                                                      <div class="modal-dialog">
                                                        <div class="modal-content">
                                                          <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br>
                                                          </div>
                                                          <div class="modal-body" style="padding-top:30pt">
                                                            <div class="form-group">
                                                                <label for="inputCARNo" class="col-lg-4 control-label">CAR Number</label>
                                                                <div class="row">
                                                                	<div class="col-lg-6">
                                                                    	<div class="input-group">
                                                                        	<input type="text" class="form-control" placeholder="Search for...">
                                                                            <span class="input-group-btn">
                                                                                <button class="btn btn-default" type="button">
                                                                                	<span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                                                </button>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <label for="inputNewQE" class="col-lg-4 control-label" style="padding-top:20pt">New QE</label>
                                                                <div class="col-lg-6" style="padding-top:15pt">
                                                                    <select class="form-control" id="select3">
                                                                    	<option selected>Please select new QE</option>
                                                                        <option>Gorilla</option>
                                                                        <option>Tony Hudson</option>
                                                                        <option>Jeff Long</option>
                                                                        <option>Blake Shelton</option>
                                                                    </select>
                                                                </div>
                                                          	</div>
                                                          </div>
                                                          <div class="modal-footer">
                                                            <button type="submit" class="btn btn-success">Submit</button>
                                                          </div>
                                                        </div>
                                                      </div>
                                                    </div>
                                                </td>
                                          	</tr>
                                          	<tr>
                                            	<td style="padding-left:30pt">Q-COBDP-142633</td>
                                            	<td style="padding-left:30pt">
                                                	<a href="#" data-toggle="modal" data-target="#myModalName" aria-labelledby="myModalLabelName" aria-hidden="true" style="text-decoration:none; color:#000;">Dooley</a>
                                                    
                                                    <!-- Modal -->
                                                    <div class="modal fade" id="Div2" tabindex="-1" role="dialog" aria-labelledby="myModalLabelName" aria-hidden="true" style="padding-top:85pt">
                                                      <div class="modal-dialog">
                                                        <div class="modal-content">
                                                          <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br>
                                                          </div>
                                                          <div class="modal-body" style="padding-top:30pt">
                                                            <div class="form-group">
                                                                <label for="inputCARNo" class="col-lg-4 control-label">CAR Number</label>
                                                                <div class="row">
                                                                	<div class="col-lg-6">
                                                                    	<div class="input-group">
                                                                        	<input type="text" class="form-control" placeholder="Search for...">
                                                                            <span class="input-group-btn">
                                                                                <button class="btn btn-default" type="button">
                                                                                	<span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                                                                </button>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <label for="inputNewQE" class="col-lg-4 control-label" style="padding-top:20pt">New QE</label>
                                                                <div class="col-lg-6" style="padding-top:15pt">
                                                                    <select class="form-control" id="select4">
                                                                    	<option selected>Please select new QE</option>
                                                                        <option>Gorilla</option>
                                                                        <option>Tony Hudson</option>
                                                                        <option>Jeff Long</option>
                                                                        <option>Blake Shelton</option>
                                                                    </select>
                                                                </div>
                                                          	</div>
                                                          </div>
                                                          <div class="modal-footer">
                                                            <button type="submit" class="btn btn-success">Submit</button>
                                                          </div>
                                                        </div>
                                                      </div>
                                                    </div>
                                                </td>
                                          	</tr>                                         
                                        </tbody>
  									</table>
                                </div>
                            </div>                          
                            <div class="form-group">
                                <div class="col-lg-10">
                                    <asp:button ID="btnExport" CssClass="btn btn-success" Text="Export" runat="server" />
                                    <asp:button ID="btnPrint" CssClass="btn btn-success" Text="Print" runat="server" />
                                </div>
                            </div>

                </div>

            </div>

        </div><!--/.col-md-12-->
        </div>
        </div>
</asp:Content>
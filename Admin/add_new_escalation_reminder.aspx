<%@ Page Title="Auto SCAR &amp; TAT - Add New Escalation / Reminder" Language="C#" MasterPageFile="~/Admin.Site.Master" AutoEventWireup="true" CodeFile="~/Admin/add_new_escalation_reminder.aspx.cs" Inherits="Admin_add_new_escalation_reminder" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Add New Escalation / Reminder Page for admin: Allows admin to create a new escalation level and reminder -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Add New Escalation / Reminder
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" method="post">
                                <div class="form-group">
                                    <label for="inputNELN" class="col-lg-2 control-label">New Escalation Level Name</label>
                                    <div class="col-lg-10">
                                        <input type="text" class="form-control" id="inputNELN" placeholder="New Escalation Level Name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputUsersInvolved" class="col-lg-2 control-label">Users Involved (Position)</label>
                                    <div class="col-lg-3" style="margin-right:10pt; padding-top:5pt">
                                        <select multiple="" class="form-control">
                                            <option>Huang Kae Jyn</option>
                                            <option>Helen Bambu</option>
                                            <option>Fang Jia Hui</option>
                                            <option>Huang Kae Shern</option>
                                            <option>Federer Lim Boon Seng</option>
                                            <option>Karimuthu Kumar</option>
                                            <option>Mary Obama</option>
                                    	</select>
                                    </div>
                                    <div style="margin-top:3pt; padding-top:5pt">
                                    	<span class="input-group-btn">
                                        	<button class="btn btn-default" type="button" id="moveRight">
                                            	<span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                            </button>
                                        </span>
                                    </div>
                                    <div style="margin-top:5pt">
                                    	<span class="input-group-btn">
                                        	<button class="btn btn-default" type="button" id="moveLeft">
                                            	<span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                            </button>
                                        </span>
                                    </div>
                                    <div class="col-lg-3" style="margin-top:-58.5pt; margin-left:41pt">
                                        <select multiple="" class="form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputDTN" class="col-lg-2 control-label">Duration Till Next Escalation</label>
                                    <div class="col-lg-10" style="padding-top:8.5pt">
                                        <input type="text" class="form-control" id="inputDTN" placeholder="Duration Till Next Escalation">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputEscalationLevelStage" class="col-lg-2 control-label">Escalation Level</label>
                                    <div class="col-lg-10" >
                                        <select class="form-control" id="select">
                                        	<option selected>Please select escalation level</option>
                                            <option>1</option>
                                            <option>2</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="textArea" class="col-lg-2 control-label">Email Content</label>
                                    <div class="col-lg-10" style="padding-top:3pt">
                                        <textarea class="form-control" rows="4" id="textArea"></textarea>
                                        <span class="help-block">A longer block of help text that breaks onto a new line and may extend beyond one line.</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
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
﻿<%@ Page Title="Auto SCAR &amp; TAT - Upload SCAR Request" EnableEventValidation="false" Language="C#" MasterPageFile="~/Engineer.Site.Master" AutoEventWireup="true" Inherits="Engineer_upload_scar_request" Codebehind="~/Engineer/upload_SCAR_request.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Change Password for engineer: Allows engineer to upload SCAR Request Attachment -->
<div class="right-panel">
            <div class="right-panel-inner">
                <div class="col-md-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Upload SCAR Request Attachment
                        </div>
                        <div class="panel-body" style="padding-top:10pt">
                            <form class="form-horizontal pad10" action="#" id="uploadSCAR" method="post">
                                    <div class="row" style="padding-left:20px;padding-top:10pt;">
                                    <div class="form-group">
                                        <label for="uploadFile" class="col-lg-3 control-label">Upload SCAR Type 2 Attachment(s)</label>
                                        <div class="col-lg-4">
                                            <asp:FileUpload ID="uploadSCARType2" AllowMultiple="true" accept=".txt" runat="server" onchange="showSCAR2()"/>
                                            <span class="help-block">Maximum file size: 15MB</span>
                                        </div>
                                        <asp:Label ID="lblSCARType2" runat="server" />
                                    </div>
                                    </div>

                                <div class="row" style="padding-left:20px;padding-top:10pt;">
                                <div class="form-group">
                                        <asp:Label ID="lblShowType2Names" runat="server" />
                                    </div>
                                </div> 

                               <div class="row" style="padding-left:20px;padding-top:10pt;">
                                <div class="form-group">
                                        <label for="uploadFile" class="col-lg-3 control-label">Upload SCAR Type 4 Attachment(s)</label>
                                        <div class="col-lg-4">
                                            <asp:FileUpload ID="uploadSCARType4" AllowMultiple="true" accept=".txt" runat="server" onchange="showSCAR4()"/>
                                            <span class="help-block">Maximum file size: 15MB</span>
                                        </div>
                                        <asp:Label ID="lblSCARType4" runat="server" />
                                    </div>
                                </div> 

                                <div class="row" style="padding-left:20px;padding-top:10pt;">
                                <div class="form-group">
                                        <asp:Label ID="lblShowType4Names" runat="server" />
                                    </div>
                                </div>   
                                <div id="messageBox" title="jQuery MessageBox In Asp.net" style="display: none;">
                                    
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8 col-lg-offset-1">
                                        <asp:Button CssClass="btn btn-success" ID="btnUpload" runat="server" OnClick="Upload_Files" Text="Upload to Server" />
                                        <asp:Button CssClass="btn btn-danger" ID="btnReset" runat="server" Text="Clear Attachments" OnClientClick="clearSCAR();" />
                                    </div>

                                </div>
                                </div>
                        
                            </form>
                        </div>
                    </div>
                </div><!--/.col-md-12-->
            </div>
</div>
 <script type="text/javascript">

     // For Confirmation
     $(function () {

         $("#<%=btnUpload.ClientID%>").on("click", function (event) {
                 event.preventDefault();
                 $("#messageBox").dialog({
                     resizable: false,
                     title: "Upload Confirmation",
                     open: function () {
                         var markup = "Are you sure you want to upload the selected file(s)?";
                         $(this).html(markup);
                     },
                     height: 200,
                     
                     modal: true,
                     buttons: {
                         Ok: function () {
                             $(this).dialog("close");
                             __doPostBack($('#<%= btnUpload.ClientID %>').attr('name'), '');
                        },
                         Cancel: function () {
                            $(this).dialog("close");
                            
                        }
                    }
                });
            });
         });


     // For Alert
     function messageBox(message) {
         $("#messageBox").dialog({
             modal: true,
             height: 300,
             width: 500,
             title: "Upload Status",
             open: function () {
                 var markup = message;
                 $(this).html(markup);
             },
             buttons: {
                 Close: function () {
                     $(this).dialog("close");
                 }
             },

         });
         return false;
     }
        
     // Clear Attachments from UploadFile 
     function clearSCAR()
     {
         document.getElementById("<%=lblShowType4Names.ClientID %>").innerHTML = "";
         document.getElementById("<%=lblShowType2Names.ClientID %>").innerHTML = "";
     }

     // Shows the file names of the files chosen in SCAR Type 4 upload
     function showSCAR4() {
         var x = document.getElementById("<%=uploadSCARType4.ClientID%>");
         var txt = "";
         if ('files' in x) {
             if (x.files.length == 0) {
                 txt = "Select one or more files.";
             } else {
                 for (var i = 0; i < x.files.length; i++) {
                     txt += "<strong>" + (i + 1) + " .</strong>";
                     var file = x.files[i];
                     if ('name' in file) {
                         txt += file.name + "<br>";
                     }
                 }
             }
         }
         else {
             if (x.value == "") {
                 txt += "Select one or more files.";
             } else {
                 txt += "The files property is not supported by your browser!";
                 txt += "<br>The path of the selected file: " + x.value; // If the browser does not support the files property, it will return the path of the selected file instead. 
             }
         }
         document.getElementById("<%=lblShowType4Names.ClientID %>").innerHTML = txt;
     }

     // Shows the file names of the files chosen in SCAR Type 2 upload
     function showSCAR2() {
         var x = document.getElementById("<%=uploadSCARType2.ClientID%>");
         var txt = "";
         if ('files' in x) {
             if (x.files.length == 0) {
                 txt = "Select one or more files.";
             } else {
                 for (var i = 0; i < x.files.length; i++) {
                     txt += "<strong>" + (i + 1) + " .</strong>";
                     var file = x.files[i];
                     if ('name' in file) {
                         txt += file.name + "<br>";
                     }
                 }
             }
         }
         else {
             if (x.value == "") {
                 txt += "Select one or more files.";
             } else {
                 txt += "The files property is not supported by your browser!";
                 txt += "<br>The path of the selected file: " + x.value; // If the browser does not support the files property, it will return the path of the selected file instead. 
             }
         }
         document.getElementById("<%=lblShowType2Names.ClientID %>").innerHTML = txt;
     }
</script>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="forgot_password" Codebehind="forgot_password.aspx.cs" %>

<!DOCTYPE html>
<html>
<head>
    <title>Auto SCAR &amp; TAT - Forgot Password</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/theme-light.css" rel="stylesheet" type="text/css">
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="css/jquery-ui.css" type="text/css" rel="stylesheet" />


    <!--[if lt IE 9]>
    <script src="js/ie/respond.min.js" cache="false"></script>
    <script src="js/ie/html5.js" cache="false"></script>
    <script src="js/ie/fix.js" cache="false"></script>
    <script src="js/ie/iewarning.js"></script>
    <![endif]-->
</head>


<body class="clearfix bg-grey">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <%--Framework scripts--%>
            <asp:ScriptReference Path="Scripts/jquery-1.11.0.min.js" />
            <asp:ScriptReference Path="Scripts/bootstrap.min.js" />
            <asp:ScriptReference Path="Scripts/app.js" />
            <asp:ScriptReference Path="Scripts/MaxLength.min.js" />
            <asp:ScriptReference Path="Scripts/select2.min.js" />
            <asp:ScriptReference Path="Scripts/jquery-ui.js" />
            <%--Site scripts--%>
            
        </Scripts>
    </asp:ScriptManager>
    <div class="col-md-4 col-md-offset-4 col-xs-12 col-xs-offset-0 col-sm-6 col-sm-offset-3 login mt50">
        <div class="logo">
            <img src="Images/jabil.jpg" class="center-block img-responsive">
        </div>
        <p class="lead text-center">
            Auto SCAR & TAT System
        <div class="form-group clearfix">
                <div class="input-group"> <span class="input-group-addon"><i class="fa fa-user"></i></span>
                    <asp:TextBox ID="txtEmail" CssClass="form-control tb" placeholder="Email Address" runat="server" TextMode="Email"/>
                    <asp:RequiredFieldValidator ID="vldEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address is Required!" />
                </div>
        </div>
        <div class="form-group clearfix">
            <p class="small text-muted pull-left"><a href="index.aspx"><i class="fa fa-lock"></i>&nbsp; Back to Login</a></p>
            <asp:Button ID="btnSubmit" CssClass="btn btn-success pull-right" OnClick="Reset_Password" Text="Submit" runat="server" /> 
        </div>

    </div><!--/.col-md-4-->
    </form>
    <footer class="login-footer">
        <div class="footer-inner text-center">
            <img src="images/jabil-small.png">
            <p class="small">&copy; 2014 Jabil | Business System Group | " One Team . One World. One Jabil "</p>
        </div>
    </footer>
</body>

<script type="text/javascript">
    // For Confirmation
    $(function () {

        $("#<%=btnSubmit.ClientID%>").on("click", function (event) {
             event.preventDefault();
             $("#messageBox").dialog({
                 resizable: false,
                 title: "Password Reset Confirmation",
                 open: function () {
                     var markup = "Are you sure you want to reset your password?";
                     $(this).html(markup);
                 },
                 height: 200,

                 modal: true,
                 buttons: {
                     Ok: function () {
                         $(this).dialog("close");
                         __doPostBack($('#<%= btnSubmit.ClientID %>').attr('name'), '');
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
                 title: "Reset Password Status",
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

</script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot_password.aspx.cs" Inherits="forgot_password" %>

<!DOCTYPE html>
<html>
<head>
    <title>Auto SCAR &amp; TAT - Forgot Password</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/theme-light.css" rel="stylesheet" type="text/css">
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">


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
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="Scripts/jquery-1.11.0.min.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="Scripts/bootstrap.min.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="Scripts/app.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="Scripts/select2.min.js" />
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
                    <asp:TextBox ID="txtEmail" CssClass="form-control tb" placeholder="Email Address" runat="server" />
                </div>
        </div>
        <div class="form-group clearfix">
            <p class="small text-muted pull-left"><a href="index.aspx"><i class="fa fa-lock"></i>&nbsp; Back to Login</a></p>
            <asp:Button ID="btnSubmit" CssClass="btn btn-success pull-right" Text="Submit" runat="server" /> 
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



<script type="text/javascript" src="js/jquery-1.11.0.min.js"></script>
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/app.js"></script>

</html>

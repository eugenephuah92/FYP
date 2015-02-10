<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navbar.ascx.cs" Inherits="navbar" %>

<!-- Top Navigational Bar -->    
    <nav class="navbar navbar-default" role="navigation">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle visible-sm visible-xs closed" id="menu-toggle">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    Auto SCAR & TAT Monitoring and Triggering System
                </a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                </ul>
                <ul class="nav navbar-nav navbar-right">

                    <li class="navaccount clearfix">
                        <a href="#">Hi, Joey</a>
                    </li>


                    <li>
                        <div class="form-group navform">
                            <a href="#" class="btn btn-default"><i class="fa fa-sign-out"></i>&nbsp;Log Out</a>
                        </div>
                    </li>

                </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>

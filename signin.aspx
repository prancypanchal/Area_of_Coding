<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Singin</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <link href="css/custom.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        body
        {
            background-color:#FFEDFA;
        }
        .BORDER
        {
            border-color:#FFB8E0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle " data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle Navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>

                        </button>
                            <a class = "navbar-brand" href="shop1.aspx" > <span><img src="icon/Pink and White Minimalist Initial Makeup Artist Logo (1).png" alt="myeshoping" height="30" /></span>Wearing-Area</a>
                    
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class ="nav navbar-nav navbar-right">
                            <li><a href="shop1.aspx">Home</a></li>
                            <li><a href="#">About</a></li>
                            <li><a href="#">Contact US</a></li>
                            <li><a href="#">Blog</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li class="dropdown-header">Woman</li>
                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Western wear</li>
                                    <li role="separator" class="divider"></li>
                                    <li> <a href="#">Dresses</a></li>
                                    <li> <a href="#">Tops</a></li>
                                    <li> <a href="#">Tshirts</a></li>
                                    <li> <a href="#">Jeans</a></li>
                                    <li> <a href="#">Trousers & Capris</a></li>
                                    <li> <a href="#">Shorts & Skirts</a></li>
                                    <li> <a href="#">Co-ords</a></li>
                                    <li> <a href="#">Jumpsuits</a></li>
                                    <li> <a href="#">Shrugs</a></li>
                                    <li> <a href="#">Sweaters & Sweatshirts</a></li>
                                    <li> <a href="#">Jackets & Coats</a></li>
                                    <li> <a href="#">Blazers & Waistcoats</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Idian & Fusion Wear</li>
                                    <li role="separator" class="divider"></li>
                                    <li> <a href="#">Kurtas & Suits</a></li>
                                    <li> <a href="#">Kurtis, Tunics & Tops</a></li>
                                    <li> <a href="#">Sarees</a></li>
                                    <li> <a href="#">Ethnic Wear</a></li>
                                    <li> <a href="#">Leggings, Salwars & Churidas</a></li>
                                    <li> <a href="#">Skirts & Palazzos</a></li>
                                    <li> <a href="#">Dress Materials</a></li>
                                    <li> <a href="#">Lehenga Cholis</a></li>
                                    <li> <a href="#">Dupattas & Shawls</a></li>
                                    <li> <a href="#">Jackets</a></li>
                                    <li> <a href="#">Topwear</a></li>
                                    <li> <a href="#">Lehengas</a></li>
                                    <li> <a href="#">Bottom wear</a></li>
                                    <li> <a href="#">Indie-fusion</a></li>
                                    <li> <a href="#">Co-ords</a></li>
                                </ul>
                            </li>
                            <li><a href="signup.aspx">SignUp</a></li>
                            <li class="active"><a href="signin.aspx">SignIn</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            </div>

            <br/>
            <br />
            <br />

        <!-- signin form start--->
        
        
            <div class="container">
                <div class="form-horizontal">
                    <h2 style="color:#EC7FA9; font-family:sans-serif;">Login </h2>
                    <hr  class="BORDER"/>
                    <div class="form-group">
                        <asp:Label ID="Label1" CssClass="col-md-2 control-label"  runat="server" Text="Username"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Txtusername" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1username" CssClass="text-danger" runat="server" ErrorMessage="Enter username" ControlToValidate="Txtusername" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Password"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Txtpass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1password" CssClass="text-danger" runat="server" ErrorMessage="Enter valid Password" ControlToValidate="Txtpass" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class ="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label3" CssClass="control-label" runat="server" Text="Remember me"></asp:Label>

                        </div>
                </div>

                     <div class="form-group">
                        <div class ="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:Button ID="btnLogin" CssClass="btn btn-success" runat="server" Text="Login&raquo;" OnClick="btnLogin_Click" /> 
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/signup.aspx">SignUp</asp:HyperLink>

                        </div>
                </div>
                    <!-- for forgot password start-->

                     <div class="form-group">
                        <div class ="col-md-2"></div>
                            <div class="col-md-6">
                                <asp:HyperLink ID="HyForgotPass" runat="server" NavigateUrl="~/forgotpassword.aspx">Forgot Password</asp:HyperLink>
                        </div>
                </div>

                    <!-- for forgot password end-->


                       <div class="form-group">
                        <div class ="col-md-2"></div>
                            <div class="col-md-6">
                           
                                <asp:Label ID="lblerror" CssClass="text-danger" runat="server"></asp:Label>
                        </div>
                </div>
            </div>
        </div>
               
         <!-- signin from end-->

           <!-- footer cintent start --->
        <hr class="BORDER" />
        <footer>
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy;wearing-area &middot; <a href="shop1.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
            </div>
        </footer>


        <!-- footer contant end -->
    </form>
</body>
</html>

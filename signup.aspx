<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
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
                                    <li> <a href="#">Trousers </a></li>
                                    <li> <a href="#">Shorts & Skirts</a></li>
                                    <li> <a href="#">Jumpsuits</a></li>
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
                            <li class="active"><a href="signup.aspx">SignUp</a></li>
                            <li><a href="signin.aspx">SignIn</a></li>
                        </ul>
                    </div>


                </div>


            </div>

        </div>

        <!-- s ighup page --->
        <div class="center-page">

            <label class="col-xs-11">UserName:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtuname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
            </div>

               <label class="col-xs-11">Your Full Name:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="TxtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
            </div>


               <label class="col-xs-11">Email:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="TxtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
            </div>

             <label class="col-xs-11">Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Password"></asp:TextBox>
            </div>


               <label class="col-xs-11">Confirm Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtcpass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm Password"></asp:TextBox>
            </div>  

               <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="txtsignup" Class="btn btn-success" runat="server" Text="SignUp" OnClick="txtsignup_Click" />
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </div>

        </div>



        <!-- signup end--->
        <!-- footer cintent start --->
        <footer class="footer-pos">
            <div class="container">
                <hr class="BORDER"/>
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy;wearing-area &middot; <a href="shop1.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
           </div>
            
      <!--  <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView> -->

        </footer>

        <!-- footer contant end -->
    </form>
</body>
</html>

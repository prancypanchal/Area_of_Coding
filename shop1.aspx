<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shop1.aspx.cs" Inherits="shop1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My E-Shopping Website</title>
  <script src="http://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc="
        crossorigin="anonymous">   </script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <link href="css/custom.css" rel="stylesheet" />
    <link href="css/demo.css" rel="stylesheet" />
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script  type="text/javascript">
        $(document).ready(function myfunction() {
            $("#btnCart").click(function myfunction() {
                window.location.href = "Cart.aspx";
            });
        });
    </script>   
    <style>
        body
        {
            background-color:#FFEDFA;
        }
        .BORDER
        {
                   border-color:#FFB8E0;

        }
        .thumbnail
          {
               display: flex;
               flex-wrap: wrap;
               justify-content: space-between;
               gap: 10px;   
               margin: 10 auto;
               max-width: 1300px;
               width: 250px; 
               height: 440px;
               border: 1px solid #ddd;
               padding: 8px;
               background-color: #fff;
               box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
               display: flex;
               flex-direction: column;
               justify-content: space-between;
          }
          .thumbnail img
          {
               width: 500px;
               height: 900px;  
               object-fit: cover;  
               max-height:fit-content;
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
                            <li><a href="About.aspx">About</a></li>
                            <li><a href="ContactUS.aspx">Contact US</a></li>
                            <li><a href="Blog.aspx">Blog</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                <li class="dropdown-header">Woman</li>
                                    <li role="separator" class="divider"></li>
                                     <li><a href="ProductsView.aspx">All Products</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Western wear</li>
                                    <li role="separator" class="divider"></li>
                                    <li> <a href="Dresses.aspx">Dresses</a></li>
                                    <li> <a href="CropTop.aspx"</a>Tops</li>
                                    <li> <a href="Tshirts.aspx">Tshirts</a></li>
                                    <li> <a href="Pants.aspx">Jeans</a></li>
                                    <li> <a href="Trousers.aspx">Trousers</a></li>
                                    <li> <a href="Shorts.aspx">Shorts</a></li>
                                    <li> <a href="JumpSuits.aspx">Jumpsuits</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Idian & Fusion Wear</li>
                                    <li role="separator" class="divider"></li>
                                     <li> <a href="KurtasnSuits.aspx">Kurtas & Suits</a></li>
                                    <li> <a href="KurtisnTunicsnTops.aspx">Kurtis, Tunics & Tops</a></li>
                                     <li> <a href="Saress.aspx">Sarees</a></li>
                                    <li> <a href="EthnicWear.aspx">Ethnic Wear</a></li>
                                    <li> <a href="LehengaCholis.aspx">Lehenga Cholis</a></li>
                                    <li> <a href="Co-ords.aspx">Co-ords</a></li> </ul>
                            </li>
                           <li>
                            <button id="btnCart" class="btn btn-primary navbar-btn " type="button">
                                Cart <span class="badge " id="pCount" runat="server"></span>
                            </button>
                        </li>
                            <li id="btnSignUp" runat="server"><a href="signup.aspx">SignUp</a></li>
                            <li id="btnSignIn" runat="server"><a href="signin.aspx">SignIn</a></li>
                                  <li>
                        <asp:Button ID="Button1" CssClass ="btn btn-link navbar-btn " runat="server" Text=""/>
                        </li>
                      
                            <li>
                                <asp:Button ID="btnlogout" CssClass="btn btn-default navbar-btn" runat="server" Text="Sign Out" OnClick="btnlogout_Click"/>

                            </li>
                        </ul>
                    </div>


                </div>


            </div>

            <!--image slider--->
            <div class="container">
  <div id="myCarousel" class="carousel slide" data-ride="carousel" border-radius="10px">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
        <img src="imageslider/hom.jpg" alt="Los Angeles" style="width:100%; height:450px;">
           <div class="carousel-caption">
               <p><a class="btn btn-lg btn-primary" href="ProductsView.aspx" role="button" style="width:120px; height:40px;">Shop Now</a></p>
        </div>
      </div>

      <div class="item">
        <img src="imageslider/2nd.jpg" alt="Chicago" style="width:100%; height:450px;">
           <div class="carousel-caption">
          <h3>Woman Shopping</h3>
          <p>Too much of anything is bad, but too many clothes? That’s a blessing.</p>
        </div>
      </div>
    
      <div class="item">
        <img src="imageslider/3rd.jpg" alt="New york" style="width:100%; height:450px;">
           <div class="carousel-caption">
          <h3>Woman Shopping</h3>
          <p>Shopping is cheaper than therapy.</p>
        </div>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
     </div>
    </div>
    <!--img slider end--->






        </div>


        <!-- middle content start -->
        <hr />
        <div class="container center">
            <div class="row">
                <div class="col-lg-6">
                  <img class="img-circle" src="imagess/Screenshot 2024-12-09 184019.png" alt="thumb" width="140" height="140"/>
                       <h2>Western Wear</h2>
                        <p>She wears her confidence <br /> like couture</p>
                        <p> <a class="btn btn-default" href="ProductsView.aspx" role="button">View More &raquo;</a></p>
                </div>


                 <div class="col-lg-6">
                    <img class="img-circle" src="imagess/Screenshot 2024-12-09 185332.png" alt="thumb" width="140" height="140" />
                       <h2>Indian Wear</h2>
                        <p>Lehenga or kurti, my style is as <br /> versatile as my dreams</p>
                        <p> <a class="btn btn-default" href="ProductsView.aspx" role="button">View More &raquo;</a></p>
                </div>
            </div>
             <%--<div class="panel panel-primary">--%>
            <%--<div class="panel-heading"> BLACK FRIDAY DEAL</div>--%>
            <div class="panel-body">
                <div class="row" style="padding-bottom:5px;">
                    
                    <asp:Repeater ID="rptrProducts" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3 col-sm-6 mb-3">

                                <a href="ViewPro.aspx?PID=<%# Eval("PID") %>" style="text-decoration: none;">
                                    <div class="thumbnail">
                                       
                                        <img src="imagess/ProductsImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>" />
                                        <div class="caption">
                                            <div class="probrand">
                                                <%# Eval ("BrandName") %>
                                            </div>
                                            <div class="proName">
                                                <%# Eval ("PName") %>
                                            </div>
                                            <div class="proPrice">
                                                <span class="proOgPrice">
                                                    <%# Eval ("PPrice","{0:0,00}") %>
                                                </span>
                                                <%# Eval ("PSelPrice","{0:c}") %>
                                                <span class="proPriceDiscount">(<%# Eval("DiscAmount","{0:0,00}") %>off) </span>
                                            </div>
                                                 
                                            </div>
                                        </div>
                                   
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <%--<div class="panel-footer"> </div>--%>
        <%--</div>--%>


        </div>



        <!-- middle end -->


        <!-- footer cintent start --->
        <hr class="BORDER" />
        <footer>
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy;wearing-area &middot; <a href="shop1.aspx">Home</a>&middot;<a href="About.aspx">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
            </div>
        </footer>


        <!-- footer contant end -->
    </form>

</body>
</html>

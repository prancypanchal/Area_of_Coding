<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ViewPro.aspx.cs" Inherits="ViewPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />

       <br /><br /><br />
    <button id="btnCart2" runat="server" class="btn btn-primary navbar-btn pull-right" onserverclick="btnCart2_ServerClick" type="button">Cart <span id="CartBadge" runat="server" class="badge">0</span>
    </button>
    <br />
<div style="padding-top:50px">
      <!--- Success Alert --->
                        <div id="divSuccess" runat="server" class="alert alert-success alert-dismissible fade in h4">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>Success! </strong>Item successfully added to cart. <a href="Cart.aspx">View Cart</a>
                        </div>
    <div class="col-md-5">
        <div class="thumbnail">
            <%-- for Proimage slider --%>
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
         <!-- Indicators -->
         <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active" ></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            <li data-target="#carousel-example-generic" data-slide-to="3"></li>
            <li data-target="#carousel-example-generic" data-slide-to="4"></li>

        </ol>

         <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <asp:Repeater ID="rptrImage" runat="server">
                <ItemTemplate>
            <div class="item <%#GetActiveImgClass(Container.ItemIndex) %>">
      <img src="imagess/ProductsImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt=" <%# Eval("Name") %>" onerror="this.src='Noimg.png'">
                   
            </div>
                    </ItemTemplate>
             </asp:Repeater>
            
        </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

            <%-- for Proimage slider ending--%>

        </div>
    </div>
    <div class="col-md-5">
        <asp:Repeater ID="rptrProductDetalis" runat="server" OnItemDataBound="rptrProductDetalis_ItemDataBound">
            <ItemTemplate>
        <div class="divDet1">
            <h1 class="proNameView"><%# Eval("PName") %></h1>
            <span class="ProOgPriceView"><%# Eval("PPrice","{0:c}") %></span><span class="ProPriceDiscountView">Off Rs.<%# string.Format("{0}",Convert.ToInt64(Eval("PPrice"))-Convert.ToInt64(Eval("PSelPrice"))) %></span>
            <p class="ProPriceView">Rs.<%# Eval("PSelPrice","{0:c}") %></p>
        </div>
        <div>
                <h5 class="">SIZE</h5>
            <div>
                <asp:RadioButtonList ID="rblSize" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="XS" Text="XS"></asp:ListItem>
                    <asp:ListItem Value="S" Text="S"></asp:ListItem>
                    <asp:ListItem Value="M" Text="M"></asp:ListItem>
                    <asp:ListItem Value="L" Text="L"></asp:ListItem>
                    <asp:ListItem Value="XL" Text="XL"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="divDet1">
            
            <asp:Button ID="btnAddtoCart" CssClass="mainButton" runat="server" Text="ADD TO CART" OnClick="btnAddtoCart_Click" />
                                <asp:Label ID="lblerror" CssClass="text-danger" runat="server"></asp:Label>
        </div>
        <div class="divDet1">
                <h5 class="h5SIZE">Description</h5>
            <p><%# Eval("PDescription") %></p>
            

                <h5 class="h5SIZE">Products Details</h5>
            <p><%# Eval("PProductDetails") %></p>

                <h5 class="h5SIZE">Material & Care</h5>
             <p><%# Eval("PMaterialCare") %></p>
        </div>
        <div>
            <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":"" %></p>
            <p><%#  ((int)Eval("30DayRet")==1)? "30 Days Returns":"" %></p>
            <p><%# ((int) Eval("COD")==1)?"Cash On Delivery":"" %></p>
        </div>

                <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("PCategoryID") %>' />
                <asp:HiddenField ID="hfSubCatID" runat="server" Value='<%# Eval("PSubCatID") %>' />
                <asp:HiddenField ID="hfBrandID" runat="server" Value='<%# Eval("PBrandID") %>' />


                
                </ItemTemplate>
            </asp:Repeater>
    </div>
</div>

</asp:Content>


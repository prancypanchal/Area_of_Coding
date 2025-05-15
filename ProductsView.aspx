<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ProductsView.aspx.cs" Inherits="ProductsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <title>Product</title>
    <%--<link href="css/addtoCart.css" rel="stylesheet" />--%>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
          body
        {
            background-color:#FFEDFA;
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
        /*  .thumbnail img
          {
               width: 500px;
               height: 1000px;  
               object-fit: cover;  
               max-height:fit-content;
          }*/
          
         
    </style>
  <br />
    <br />
    <br />
    <div class="row">
      <div class="col-md-12">
          <button id="btnCart2" runat="server" class="btn btn-primary navbar-btn pull-right" onserverclick="btnCart2_ServerClick" type="button">
                        Cart <span id="CartBadge" runat="server" class="badge"> 0 </span>
                    </button>
                    <h3>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Showing All Products"></asp:Label> </h3>
                    <hr class="BORDER" />
                    
      </div>
    </div>

    <div class="row" style="padding-top:50px">

     <asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server" 
              placeholder="Search Products...." AutoPostBack="true" 
              ontextchanged="txtFilterGrid1Record_TextChanged" ></asp:TextBox>
      <br />
      <hr />

       <asp:repeater ID="rptrProducts" runat="server">
           <ItemTemplate>
        <div class="col-md-3 col-sm-6 mb-3<%--col-sm-3 col-md-3--%>">
            <a href="ViewPro.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
          <div class="thumbnail">              
              <img src="imagess/ProductsImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>" style="object-fit:cover;"/>
              <div class="caption" style="text-align:center; margin-left:0px; margin-right:4px;"> 
                   <div class="probrand"><%# Eval ("BrandName") %>  </div>
                   <div class="proName"> <%# Eval ("PName") %> </div>
                   <div class="proPrice"> <span class="proOgPrice" > <%# Eval ("PPrice","{0:0,00}") %> </span> <%# Eval ("PSelPrice","{0:c}") %> <span class="proPriceDiscount"> (<%# Eval("DiscAmount","{0:0,00}") %> off) </span></div> 
                   
              </div>
          </div>
                </a>
        </div>
               </ItemTemplate>
       </asp:repeater>
    </div>



    <%--second product--%>


</asp:Content>


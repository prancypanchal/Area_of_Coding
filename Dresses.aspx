<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Dresses.aspx.cs" Inherits="Dresses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Dresses</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
         <br />
         <br />

         <br />
            <style>
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
        </style>
  <h2 style="color:#EC7FA9;">Dresses</h2>  
         <hr class="BORDER"/>
    <%--<div class="panel panel-primary">--%>
      <div class="panel-heading"></div>
      <div class="panel-body">
      <asp:repeater ID="rptrProducts" runat="server">
           <ItemTemplate>
        <div class="col-sm-3 col-md-3">
            <a href="ViewPro.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
          <div class="thumbnail">              
              <img src="imagess/ProductsImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>"/>
              <div class="caption" style="text-align:center; margin-left:0px; margin-right:4px;"> 
                   <div class="probrand"><%# Eval ("BrandName") %>  </div>
                   <div class="proName"> <%# Eval ("PName") %> </div>
                   <div class="proPrice"> <span class="proOgPrice" > <%# Eval ("PPrice","{0:0,00}") %> </span> <%# Eval("PSelPrice","{0:c}") %> <span class="proPriceDiscount"> (<%# Eval("DiscAmount","{0:0,00}") %> off) </span></div> 
                   
              </div>
          </div>
                </a>
        </div>
               
               </ItemTemplate>
       </asp:repeater>
      
      </div>
      <%--<div class="panel-footer"></div>--%>
    </div>
    
<%--</div>--%>

</asp:Content>


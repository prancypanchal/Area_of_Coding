<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="LehengaCholis.aspx.cs" Inherits="LehengaCholis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Lehenga Cholis</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
 <br />
         <br />
         <br />
  <h2 style="color:#EC7FA9;">Lehenga Cholis</h2>  
         <hr class="BORDER" />
    <%--<div class="panel panel-primary">--%>
      <div class="panel-heading"></div>
      <div class="panel-body">
      <asp:repeater ID="rptrProducts" runat="server">
           <ItemTemplate>
        <div class="col-sm-3 col-md-3">
            <a href="ViewPro.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
          <div class="thumbnail">              
              <img src="imagess/ProductsImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>"/>
              <div class="caption"> 
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


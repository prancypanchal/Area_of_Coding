﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>About me Page</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>--%>
  <style>
      body{background-color:#FFEDFA;}
      .container-fluid{
          background-color:#FFB8E0;
      }
     .text-center
     {
         background-color:#EC7FA9;
     }
  .jumbotron {
    background-color:#EC7FA9;
    color: #fff;
    padding: 100px 25px;
  }
  .container-fluid {
    padding: 60px 50px;
    border-radius:5px;
  }
  .bg-grey {
    background-color: #FFEDFA;
  }
  .logo-small {
    color: #FFEDFA;
    font-size: 50px;
  }
  .logo {
    color: #FFEDFA;
    font-size: 200px;
  }
  @media screen and (max-width: 768px) {
    .col-sm-4 {
      text-align: center;
      margin: 25px 0;
    }
  }
  </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[



// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" class="body"> 
    <br />

<div class="jumbotron text-center">
  <h1>Wearing-Area Website</h1> 
  <p></p> 
  <form class="form-inline">
    <div class="input-group">
      
    </div>
  </form>
</div>

<!-- Container (About Section) -->
<div class="container-fluid">
  <div class="row">
    <div class="col-sm-8">
      <h2 class="COM">About Company Page</h2>
      <h4>Developer..</h4>      
      <p>I am geek at heart that loves to learn and play with new technologies. I am grounded with solid object oriented programming principles, but spread my wings across most of the Microsoft product stack: from ASP.NET MVC, WCF, Windows forms, Silverlight, Business Intelligence, PerformancePoint Services, VSTO to SharePoint.</p>
      <%--<button  id="btn11" runat="server" onclick="btn11_onclick()">Get in Touch</button>--%>
        <asp:Button  class="btn btn-default btn-lg" ID="Button1" runat="server" Text="Back To Products" onclick="Button1_Click"/>

    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-signal logo"></span>
    </div>
  </div>
</div>

<%--<div class="container-fluid bg-grey">
  <div class="row">
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-globe logo"></span>
    </div>
    <div class="col-sm-8">
      <h2>Our Values</h2>
      <h4><strong>MISSION:</strong> Our mission lorem ipsum..</h4>      
      <p><strong>VISION:</strong> Our vision Lorem ipsum..</p>
    </div>
  </div>
</div>--%>

<!-- Container (Services Section) -->
<div class="container-fluid text-center" style="margin-top:35px;">
  <h2>SERVICES</h2>
  <h4>What we offer</h4>
  <br>
  <div class="row">
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-off logo-small"></span>
      <h4>POWER</h4>
      <p>Lorem ipsum dolor sit amet..</p>
    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-heart logo-small"></span>
      <h4>LOVE</h4>
      <p>Lorem ipsum dolor sit amet..</p>
    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-lock logo-small"></span>
      <h4>JOB DONE</h4>
      <p>Lorem ipsum dolor sit amet..</p>
    </div>
  </div>
  <br><br>
  <div class="row">
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-leaf logo-small"></span>
      <h4>GREEN</h4>
      <p>Lorem ipsum dolor sit amet..</p>
    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-certificate logo-small"></span>
      <h4>CERTIFIED</h4>
      <p>Lorem ipsum dolor sit amet..</p>
    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-wrench logo-small"></span>
      <h4 style="color:#303030;">HARD WORK</h4>
      <p>Lorem ipsum dolor sit amet..</p>
    </div>
  </div>
</div>
<%--<footer class="container-fluid text-center">
 <%-- <a href="#myPage" title="To Top">
    <span class="glyphicon glyphicon-chevron-up"></span>
  </a>--%>
  <%--<p> Made By <a href="https://www.youtube.com/coderbaba" title="Visit w3schools">MyShoppingWebsite</a></p>
</footer>--%>

</asp:Content>


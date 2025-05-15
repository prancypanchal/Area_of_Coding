<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <!DOCTYPE html>

    <title>Blog - E-Commerce Website</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%-- <form id="form1" runat="server">--%>
        <div class="container">
            <br />
            <br />
            <br />
            <h1 style="color:#EC7FA9;">Latest Blog Posts</h1>
            <hr class="BORDER" />
            <asp:Repeater ID="rptBlogPosts" runat="server">
                <ItemTemplate>
                    <div class="blog-post">
                        <h2><%# Eval("Title") %></h2>
                        <p><%# Eval("Content") %></p>
                        <p><small>Posted on <%# Eval("DatePosted", "{0:MMMM d, yyyy}") %></small></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    <%--</form>--%>


</asp:Content>


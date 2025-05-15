<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ContactUS.aspx.cs" Inherits="ContactUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!DOCTYPE html>

    <title>Contact Us - E-Commerce Website</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
    <%--<form id="form1" runat="server">--%>
        <div class="container">
            <br />
            <br />
            <br />
            <h1 style="color:#EC7FA9;">Contact Us</h1>
            <hr class="BORDER" />
            <div>
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTXTNAME" CssClass="text-danger" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
            <div>
                <br />
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtemail" CssClass="text-danger" runat="server" ErrorMessage="Enter Email" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
            <div>
                <br />
                <label for="txtMessage">Message:</label>
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtmsg" CssClass="text-danger" runat="server" ErrorMessage="Enter Your Message" ControlToValidate="txtMessage" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
            <div>
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Send Message" CssClass="btn" OnClick="btnSubmit_Click" BackColor="LightBlue" />
            </div>
        </div>
    <%--</form>--%>
</asp:Content>


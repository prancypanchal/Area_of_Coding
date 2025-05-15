<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Success" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Placed</title>
    <link href="Styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div>
            <div class="container">
                <div class="center">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                
                    <br />
                    
                    <h1 style="color:darkslategray; font-size:55px;">Congratulations.</h1>
                    <h1 style="color:darkslategray;"><br />  Your Order Successfully Placed...&nbsp;We're trying to send your Order as soon as possible!<br /> &nbsp;<br />Thank You for joining the WEARING-AREA FAMILY</h1>
                   

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" style="background-color:darkslategray" Font-Size="Large" Text="Back To Products" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

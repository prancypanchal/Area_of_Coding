<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.master" AutoEventWireup="true" CodeFile="AddSize.aspx.cs" Inherits="AddSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
                <div class="form-horizontal">
                    <br />
                    <br />
                    <br />
                    <h2>Add Size</h2>
                    <hr class="BORDER"/>

                       <div class="form-group">
                        <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Size Name"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" CssClass="text-danger" runat="server" ErrorMessage="Enter The Size Right" ControlToValidate="txtSize" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                 


                    
                     <div class="form-group">
                        <asp:Label ID="Label3" CssClass="col-md-2 control-label" runat="server" Text="Brand"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" CssClass="text-danger" runat="server" ErrorMessage="Enter The Brand" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Category"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1Category" CssClass="text-danger" runat="server" ErrorMessage="Enter The Category" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>


                     <div class="form-group">
                        <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="SubCategory"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlSubCat" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlSubCat" CssClass="text-danger" runat="server" ErrorMessage="Enter Sub-Category" ControlToValidate="ddlSubCat" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                   

                    
                     <div class="form-group">
                        <div class ="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:Button ID="btnAddSize" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddSize_Click"/> 

                        </div>
                </div>
                   


                       <div class="form-group">
                        <div class ="col-md-2"></div>
                            <div class="col-md-6">
                           
                                <asp:Label ID="lblerror" CssClass="text-danger" runat="server"></asp:Label>
                        </div>
                </div>
            </div>

             <h1>Size</h1>
        <hr class="BORDER"/>

                <div class="panel panel-default">

                    <div class="panel-heading"> All Size</div>


                    <asp:Repeater ID="rptrSize" runat="server">
                       
                            <HeaderTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Size</th>
                                            <th>Brand</th>
                                            <th>Category</th>
                                            <th>SubCategory</th>
                                            <th>Edit</th>
                                        </tr>

                                    </thead>
                                    <tbody>
                        
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th> <%# Eval("SizeID") %> </th>
                                        <td><%# Eval("SizeName")%></td>
                                        <td><%# Eval("Name")%></td>
                                        <td><%# Eval("CatName")%></td>
                                        <td><%# Eval("SubCatName")%></td>
                                        <td>Edit</td>
                                    </tr>
                           
                                </ItemTemplate>

                                <FooterTemplate>
                                    </tbody>
                                    </table>
                   
                                </FooterTemplate>
                    </asp:Repeater>

                                
            </div>


        </div>


</asp:Content>


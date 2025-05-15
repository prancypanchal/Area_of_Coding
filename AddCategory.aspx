<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="form-horizontal">
                    <br />
                    <br />
                    <br />
                    <h2>Add Category</h2>
                    <hr class="BORDER" />
            <div class="form-group">
                        <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Category Name"></asp:Label>
                   <div class="col-md-3">
                            <asp:TextBox ID="txtCat" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCatname" CssClass="text-danger" runat="server" ErrorMessage="Enter Category" ControlToValidate="txtCat" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
            </div>
                    
               <div class="form-group">
                        <div class ="col-md-2"></div>
                            <div class="col-md-6">
                                <asp:Button ID="btnAddCat" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddCat_Click" /> 
                            </div>
                </div> 
     </div>

         <h1>Category</h1>
        <hr class="BORDER"/>

                <div class="panel panel-default">

                    <div class="panel-heading"> All Categories</div>


                    <asp:Repeater ID="rptrCategory" runat="server">
                       
                            <HeaderTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Catgories</th>
                                            <th>Edit</th>
                                        </tr>

                                    </thead>
                                    <tbody>
                        
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th> <%# Eval("CatID") %> </th>
                                        <td><%# Eval("CatName")%></td>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.master" AutoEventWireup="true" CodeFile="AddSubCat.aspx.cs" Inherits="AddSubCat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
                <div class="form-horizontal">
                    <br />
                    <br />
                    <br />
                    <h2>Add Sub Category</h2>
                    <hr class="BORDER"/>


                     <div class="form-group">
                        <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Main CategoryID"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlMainCatID" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlMainCatID" CssClass="text-danger" runat="server" ErrorMessage="Enter Main CategoryId" ControlToValidate="ddlMainCatID" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                   

                    <div class="form-group">
                        <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Sub Category Name"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtSubCat" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCatname" CssClass="text-danger" runat="server" ErrorMessage="Enter Sub Category" ControlToValidate="txtSubCat" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
                     <div class="form-group">
                        <div class ="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:Button ID="btnAddSubCat" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddSubCat_Click"/> 

                        </div>
                </div>
                   


                       <div class="form-group">
                        <div class ="col-md-2"></div>
                            <div class="col-md-6">
                           
                                <asp:Label ID="lblerror" CssClass="text-danger" runat="server"></asp:Label>
                        </div>
                </div>
            </div>

        <h1>Sub-Category</h1>
        <hr class="BORDER" />

                <div class="panel panel-default">

                    <div class="panel-heading"> All Sub-Categories</div>


                    <asp:Repeater ID="rptrSubCategory" runat="server">
                       
                            <HeaderTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Sub-Category</th>
                                            <th>Main-Category </th>
                                            <th>Edit</th>
                                        </tr>

                                    </thead>
                                    <tbody>
                        
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th> <%# Eval("SubCatID") %> </th>
                                        <td><%# Eval("SubCatName")%></td>
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


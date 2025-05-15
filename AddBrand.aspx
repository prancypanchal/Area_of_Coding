<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.master" AutoEventWireup="true" CodeFile="AddBrand.aspx.cs" Inherits="AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
            <br />
            <br />
            <br />
                <div class="form-horizontal">
                      <h2>Add Brand</h2>
                        <hr class="BORDER"/>
                    <div class="form-group">
                        <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="BrandName"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="TxtBrand" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" CssClass="text-danger" runat="server" ErrorMessage="Enter BrandName" ControlToValidate="TxtBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
                     <div class="form-group">
                         <div class ="col-md-2"></div>
                            <div class="col-md-6">
                            <asp:Button ID="btnAddBrand" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddBrand_Click" /> 
                        </div>
                </div>
            </div>

           <h1>Brands</h1>
        <hr class="BORDER"/>

                <div class="panel panel-default">

                    <div class="panel-heading"> All Brands</div>


                    <asp:Repeater ID="rptrBrands" runat="server">
                       
                            <HeaderTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Brand</th>
                                            <th>Edit</th>
                                        </tr>

                                    </thead>
                                    <tbody>
                        
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <th> <%# Eval("BrandID") %> </th>
                                        <td><%# Eval("Name")%></td>
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


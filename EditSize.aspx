﻿<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.master" AutoEventWireup="true" CodeFile="EditSize.aspx.cs" Inherits="EditSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
  <h2></h2>  
  <br /><br /><br /><br />
    <%--<div class="panel panel-primary">--%>
      <%--<div class="panel-heading">Edit Size</div>--%>
      <div class="panel-body">
          <div class="row">
               <div class="col-sm-6">
                  <div class="form-group">
                       <label> Enter ID:</label>
                       <asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true"  ontextchanged="txtID_TextChanged"></asp:TextBox>
                  </div>

                  <div class="form-group">
                       <label> Enter Size (L,S,XL)</label>
                       <asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>

                  <div class="form-group">
                       <label> Select Brand</label>
                        <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                  </div>

                  <div class="form-group">
                       <label> Select Category</label>
                        <asp:DropDownList ID="ddlCategory" CssClass ="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  </div>

                  <div class="form-group">
                       <label> Sub Category</label>
                        <asp:DropDownList ID="ddlSubCategory" CssClass ="form-control" runat="server"></asp:DropDownList>
                  </div>

                  
                  <div class="form-group">
                  <asp:Button ID="btnUpdateSubCategory" CssClass="btn btn-primary" runat="server" Text="UPDATE" onclick="btnUpdateSubCategory_Click" />
                  </div>

               
               </div>

               <div class="col-sm-6">

                <div class="row">
                <div class="col-md-12">
                <h4 class="alert-info text-center" style="color:#EC7FA9; background-color:#FFEDFA;"> All Size</h4>
                <br />
                 <asp:TextBox ID="txtFilterGrid1Record" style="border:2px solid #EC7FA9;" CssClass="form-control" runat="server" placeholder="Search Category...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                <hr class="BORDER"/>
                   <div class="table table-responsive">
                       <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" EmptyDataText="Record not found...">
                       </asp:GridView>
                   </div>
                </div>
             </div>
               
               </div>
          
          </div>

      </div>
      <%--<div class="panel-footer">Panel Footer</div>--%>
    <%--</div>--%>
    
</div>




<script type="text/javascript">
    function Search_Gridview(strKey) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById("<%=GridView1.ClientID %>");
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    }  
</script>


</asp:Content>


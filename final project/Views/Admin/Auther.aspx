<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="Auther.aspx.cs" Inherits="final_project.Views.Admin.Auther" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
     <div class="container-fluid">
     <div class="row">
         <div class="col">
             <h3 class="text-center">Manage Authors</h3>
             <h5 class="text-center">User Name : <asp:Label runat="server" ID="Name" class="text-success"></asp:Label></h5>
         </div>
     </div>
     <div class="row">
         <div class="col-md-4">
             <div class="mb-3">
                 <label for="" class="form-label text-success">Author Name</label>
                 <input type="text" placeholder="Title" autocomplete="off" class="form-control" runat="server" id="ANameTb"/>
             </div>

             <div class="mb-3">
                 <label for="" class="form-label text-success">Author Gender</label>
                 <asp:DropDownList runat="server" class="form-control" id="GenCb">
                      <asp:ListItem>Male</asp:ListItem>
                      <asp:ListItem>Female</asp:ListItem>
                 </asp:DropDownList>
             </div>

             <div class="mb-3">
                 <label for="" class="form-label text-success">Country</label>
                 <asp:DropDownList ID="CountryCb" runat="server" class="form-control">
                     <asp:ListItem>JORDAN</asp:ListItem>
                     <asp:ListItem>USA</asp:ListItem>
                     <asp:ListItem>UK</asp:ListItem>
                     <asp:ListItem>SPAIN</asp:ListItem>
                     <asp:ListItem>UAE</asp:ListItem>
                     <asp:ListItem>OTHER</asp:ListItem>
                 </asp:DropDownList>
             </div>


             <div class="row">
                 <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
                 <div class="col d-grid"><asp:Button Text="Update" runat="server" id="EditBtn" class="btn-success btn-block btn" Style="background-color:hotpink" OnClick="EditBtn_Click"/></div>
                 <div class="col d-grid"><asp:Button Text="Save" runat="server" id="SaveBtn" class="btn-success btn-block btn" Style="background-color:lightpink" OnClick="SaveBtn_Click"/></div>
                 <div class="col d-grid"><asp:Button Text="Delete" runat="server" id="DeleteBtn" class="btn-success btn-block btn" Style="background-color:deeppink" OnClick="DeleteBtn_Click"/></div>
             </div>

         </div>
         <div class="col-md-8">
             <asp:GridView ID="AuthorsList" runat="server" width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged">
                 <AlternatingRowStyle BackColor="White" />
                 <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="pink" Font-Bold="false" ForeColor="White" />
                 <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                 <RowStyle BackColor="lightpink" ForeColor="#333333" />
                 <SelectedRowStyle BackColor="deeppink" Font-Bold="True" ForeColor="white" />
                 <SortedAscendingCellStyle BackColor="#FDF5AC" />
                 <SortedAscendingHeaderStyle BackColor="#4D0000" />
                 <SortedDescendingCellStyle BackColor="#FCF6C0" />
                 <SortedDescendingHeaderStyle BackColor="#820000" />
             </asp:GridView>
         </div>
     </div>
 </div>
</asp:Content>

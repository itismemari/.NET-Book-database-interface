<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="final_project.Views.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Books</h3>
                <h5 class="text-center">User Name : <asp:Label runat="server" ID="Name" class="text-success"></asp:Label></h5>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Book Title</label>
                    <input type="text" placeholder="Title" id="BookTitleTb" autocomplete="off" class="form-control" runat="server"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Book Author</label>
                    <asp:DropDownList ID="BATb" runat="server" class="form-control"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Categories</label>
                    <asp:DropDownList ID="BcatTb" runat="server" class="form-control"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Price</label>
                    <input type="text" placeholder="Price" id="priceTb" autocomplete="off" class="form-control" runat="server"/>
                </div>

                <div class="mb-3">
                    <label for="" class="form-label text-success">Quantity</label>
                    <input type="text" placeholder="Quantity" id="QuantityTb" autocomplete="off" class="form-control" runat="server"/>
                </div>

                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
                    <div class="col d-grid"><asp:Button Text="Update" runat="server" ID="EditBtn" class="btn-success btn-block btn" Style="background-color:hotpink" OnClick="EditBtn_Click"/></div>
                    <div class="col d-grid"><asp:Button Text="Save" runat="server" id="SaveBtn" class="btn-success btn-block btn" Style="background-color:lightpink" OnClick="SaveBtn_Click" /></div>
                    <div class="col d-grid"><asp:Button Text="Delete" runat="server" id="DeleteBtn" class="btn-success btn-block btn" Style="background-color:deeppink" OnClick="DeleteBtn_Click"/></div>
                </div>

            </div>
            <div class="col-md-8">
                <asp:GridView ID="BooksList" runat="server" width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BooksList_SelectedIndexChanged">
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

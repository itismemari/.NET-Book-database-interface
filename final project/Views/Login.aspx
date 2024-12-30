<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="final_project.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel ="stylesheet" href="../Assets/lip/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">

        </div>
        <div class="row">
            <div class ="col-md-4">

            </div>
            <div class ="col-md-4">
                <form id="form1" runat="server">
                   <div>
                       <div class="row">
                           <div class="col-md-4"></div>
                           <div class="col-md-8">
                               <img src="../Assets/images/5078755.png" width="100px"/>
                           </div>
                       </div>
                       
                   </div>
                   <div class="mt-3">
                       <label for="" class="form-label">User Name</label>
                       <input type="email" placeholder="Your Email" autocomplete="off" runat="server" class="form-control" id="UsernameTb"/>
                   </div>
                   <div class="mt-3">
                       <label for="" class="form-label">password</label>
                       <input type="password" placeholder="password" autocomplete="off" runat="server" class="form-control" id="PasswordTb"/>
                   </div>
                   <div class="mt-3 d-grid">
                       <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger text-center"></asp:Label>
                       <asp:Button Text="Login" runat="server" class="btn-success btn" Style="background-color:lightpink" ID="LoginBtn" OnClick="LoginBtn_Click"/>
                   </div>
                </form>
            </div>
            <div class ="col-md-4">

            </div>
        </div>
    </div>
</body>
</html>

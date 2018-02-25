<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/register.css" media="screen" type="text/css" />
    <title>Register</title>
</head>
<body>
    <div class ="login-card">
     <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="name" runat="server" placeholder="Name" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="username" runat="server" placeholder="UserName" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="password" runat="server" placeholder="Password" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="re_password" runat="server" placeholder="Re-type Password" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="role" runat="server" placeholder="Role" CssClass="input"></asp:TextBox><br />
            <asp:Button ID="register" runat="server" Text="Register" Cssclass="register" OnClick="Register"/>
            <asp:HyperLink ID="login" runat="server" NavigateUrl="/Default.aspx">Click Here To Login.</asp:HyperLink>
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
    </form>
   </div>
</body>
</html>

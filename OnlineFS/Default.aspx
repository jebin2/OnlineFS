<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label> <asp:TextBox ID="username" runat="server" TextMode="SingleLine"></asp:TextBox></br>
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label> <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></br>
            <asp:Button ID="login" runat="server" Text="Login" OnClick="Login"/>
            <asp:HyperLink ID="Register" runat="server" Visible="false" NavigateUrl="/Register.aspx">Click Here To Register</asp:HyperLink>
            <asp:HyperLink ID="PostData" runat="server" Visible="false" NavigateUrl="/PostData.aspx">Click Here To Post Data</asp:HyperLink>
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
̥

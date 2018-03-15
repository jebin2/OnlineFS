<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div class ="login-card">
            <asp:TextBox ID="name" runat="server" placeholder="Name" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="username" runat="server" placeholder="UserName" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="password" runat="server" placeholder="Password" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="re_password" runat="server" placeholder="Re-type Password" CssClass="input"></asp:TextBox><br />
            <asp:TextBox ID="role" runat="server" placeholder="Role" CssClass="input"></asp:TextBox><br />
            <asp:Button ID="register" runat="server" Text="Register" Cssclass="register" OnClick="Register"/>
            <asp:HyperLink ID="login" runat="server" NavigateUrl="/Default.aspx">Click Here To Login.</asp:HyperLink>
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>

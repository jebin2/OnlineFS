<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

         <div class ="login-card">
            <div>
            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label> <br/><br/>
            <asp:TextBox ID="username" runat="server" CssClass="input" TextMode="SingleLine"></asp:TextBox><br/><br/>
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label><br/> <br/>
            <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/><br/>
            <asp:Button ID="login" runat="server" Cssclass="register" Text="Login" OnClick="Login"/><br/>
            <asp:HyperLink ID="Register" runat="server" Visible="false" NavigateUrl="/Register.aspx">Click Here To Register</asp:HyperLink>
            <asp:HyperLink ID="PostData" runat="server" Visible="false" NavigateUrl="/PostData.aspx">Click Here To Post Data</asp:HyperLink>
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
            </div>
         </div>
 </asp:Content>

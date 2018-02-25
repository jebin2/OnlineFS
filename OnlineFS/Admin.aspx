<%@ Page Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
  
         <div class ="login-card">
        <div>
             <asp:Label ID="Label2" runat="server" Text="User Name"></asp:Label> <br/><br/>
            <asp:TextBox ID="username" runat="server" CssClass="input" TextMode="SingleLine"></asp:TextBox><br/><br/>
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label><br/> <br/>
            <asp:TextBox ID="password" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/><br/>
            <asp:Button ID="login" runat="server" Cssclass="register" Text="Login" OnClick="Adminfu"/><br/>
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
        </div>
     </asp:Content>


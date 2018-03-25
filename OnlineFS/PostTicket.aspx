<%@ Page Language="C#" MasterPageFile="~/post.master" AutoEventWireup="true" CodeFile="PostTicket.aspx.cs" Inherits="PostTicket" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="login-card">

                    <asp:Label ID="pLabel_title" runat="server" Text="Title"></asp:Label>
                    <asp:TextBox ID="pTextBox_title" runat="server" CssClass="input" TextMode="SingleLine"></asp:TextBox><br/><br/>
                    <asp:Label ID="pLabel_description" runat="server" Text="Description"></asp:Label>
                    <asp:TextBox id="pTextBox_description" TextMode="multiline" Columns="50" Rows="5" runat="server" /><br/><br/>
                    <asp:Label ID="pLabel_file" runat="server" Text="File" CssClass="Label"></asp:Label><br/>
                    <asp:FileUpload ID="pcontent" runat="server" /><br/><br/>
                    <asp:Label ID="pLabel_email" runat="server" Text="Email" CssClass="Label"></asp:Label><br/>
                    <asp:TextBox ID="pTextBox_email" runat="server" CssClass="input" TextMode="SingleLine"></asp:TextBox><br/><br/>
                    <asp:HyperLink ID="webx" runat="server" ImageUrl="image/webex.jpg" NavigateUrl="https://www.webex.co.in" Target="_blank">https://www.webex.co.in</asp:HyperLink>
        <p>
            <asp:Button ID="psubmit" runat="server" Cssclass="register" Text="Submit" OnClick="Submit"/>
            <!--<asp:Button ID="Mail" runat="server" Cssclass="register" Text="Mail" OnClick="SendMail"/><br/>-->
        </p>
            </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/post.master" AutoEventWireup="true" CodeFile="PostData.aspx.cs" Inherits="PostData" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="login-card">
                    <h2><asp:Label ID="pLabel_title12" runat="server" Text="PostData"></asp:Label></h2><br/>
                    <asp:Label ID="pLabel_title" runat="server" Text="Title"></asp:Label>
                    <asp:TextBox ID="pTextBox_title" runat="server" CssClass="input" TextMode="SingleLine"></asp:TextBox><br/><br/>
                    <asp:Label ID="pLabel_description" runat="server" Text="Description"></asp:Label>
                    <asp:TextBox id="pTextBox_description" TextMode="multiline" Columns="50" Rows="5" runat="server" /><br/><br/>
                    <!--<asp:Label ID="pLabel_file" runat="server" Text="File" CssClass="Label"></asp:Label><br/>-->
                    <!--<asp:FileUpload ID="pcontent" runat="server" /><br/><br/>-->
                    <asp:Label ID="pLabel_keyword" runat="server" Text="Keywords" CssClass="Label"></asp:Label><br/>
                    <asp:TextBox ID="pTextBox_keyword" runat="server" CssClass="input" TextMode="SingleLine"></asp:TextBox><br/><br/>
        <p>
            <asp:Button ID="psubmit" runat="server" Cssclass="register" Text="Submit" OnClick="Submit"/>
        </p>
            </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/post.master" CodeFile="PostData.aspx.cs" Inherits="PostData" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div>
            <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="row1" runat="server">
                <asp:TableCell ID="cell11" runat="server">
                    <asp:Label ID="Label_title" runat="server" Text="Title" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="cell12" runat="server">
                    <asp:TextBox ID="TextBox_title" runat="server" CssClass="Textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row2" runat="server">
                <asp:TableCell ID="cell21" runat="server">
                    <asp:Label ID="Label_description" runat="server" Text="Description" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="cell22" runat="server">
                    <asp:TextBox ID="TextBox_description" runat="server" CssClass="Textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row3" runat="server">
                <asp:TableCell ID="cell31" runat="server">
                    <asp:Label ID="Label_file" runat="server" Text="File" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="cell32" runat="server">
                    <asp:FileUpload ID="content" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row4" runat="server">
                <asp:TableCell ID="cell41" runat="server">
                    <asp:Label ID="Label_keyword" runat="server" Text="Keywords" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="cell42" runat="server">
                    <asp:TextBox ID="TextBox_keyword" runat="server" CssClass="Textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row5" runat="server">
                <asp:TableCell ID="cell51" runat="server">

                </asp:TableCell>
                <asp:TableCell ID="cell52" runat="server" style="float:right;">
                    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Submit" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Logout" Text="Logout" />
</asp:Content>

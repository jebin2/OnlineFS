<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostData.aspx.cs" Inherits="PostData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/postdata.css" media="screen" type="text/css" />
    <title>Post Data</title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>

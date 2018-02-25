<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostTicket.aspx.cs" Inherits="PostTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Post Ticket</title>
</head>
<body>
    <form id="postticket" runat="server">
        <div>
            <asp:Table ID="pTable1" runat="server">
            <asp:TableRow ID="prow1" runat="server">
                <asp:TableCell ID="pcell11" runat="server">
                    <asp:Label ID="pLabel_title" runat="server" Text="Title" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="pcell12" runat="server">
                    <asp:TextBox ID="pTextBox_title" runat="server" CssClass="Textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="prow2" runat="server">
                <asp:TableCell ID="pcell21" runat="server">
                    <asp:Label ID="pLabel_description" runat="server" Text="Description" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="pcell22" runat="server">
                    <asp:TextBox ID="pTextBox_description" runat="server" CssClass="Textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="prow3" runat="server">
                <asp:TableCell ID="pcell31" runat="server">
                    <asp:Label ID="pLabel_file" runat="server" Text="File" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="pcell32" runat="server">
                    <asp:FileUpload ID="pcontent" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="prow4" runat="server">
                <asp:TableCell ID="pcell41" runat="server">
                    <asp:Label ID="pLabel_keyword" runat="server" Text="Keywords" CssClass="Label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="pcell42" runat="server">
                    <asp:TextBox ID="pTextBox_keyword" runat="server" CssClass="Textbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="prow5" runat="server">
                <asp:TableCell ID="pcell51" runat="server">

                </asp:TableCell>
                <asp:TableCell ID="pcell52" runat="server" style="float:right;">
                    <asp:Button ID="psubmit" runat="server" Text="Submit" OnClick="Submit" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="TicketLogOut" Text="Logout" />
        </p>
    </form>
</body>
</html>

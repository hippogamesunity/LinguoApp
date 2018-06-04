<%@ Page Title="Глóвна" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinguoWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td style="text-align: left" colspan="2">
            Select language:
                <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Polish</asp:ListItem>
                <asp:ListItem>Czech</asp:ListItem>
            </asp:DropDownList>
            <tr>
            <td style="text-align: center">
                Latin</td>
            <td style="text-align: center">
                Cyrillic</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="300px" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="300px" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Width="400px" Height="40px" OnClick="Button1_Click" Text="Translate" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Width="400px" Height="40px" OnClick="Button2_Click" Text="Translate" />
            </td>
        </tr>
    </table>
</asp:Content>

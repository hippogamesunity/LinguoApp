<%@ Page Title="Глóвна" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinguoWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td style="text-align: center">
                Łacina</td>
            <td style="text-align: center">
                Цырылица</td>
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
                <asp:Button ID="Button1" runat="server" Width="400px" Height="40px" OnClick="Button1_Click" Text="Przetłumacz" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Width="400px" Height="40px" OnClick="Button2_Click" Text="Претлумачь" />
            </td>
        </tr>
    </table>
</asp:Content>

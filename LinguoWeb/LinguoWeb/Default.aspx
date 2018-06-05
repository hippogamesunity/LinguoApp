<%@ Page Title="Глóвна" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinguoWeb.Default" %>
<%@ Import Namespace="LinguoWeb" %>

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
            <td style="text-align: center"><%=Localization.Localize("Latin")%></td>
            <td style="text-align: center"><%=Localization.Localize("Cyrillic")%></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxInput" runat="server" TextMode="MultiLine" Height="300px" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxResult" runat="server" TextMode="MultiLine" Height="300px" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="TranslateButton" runat="server" Width="400px" Height="40px" OnClick="Translate" />
            </td>
            <td>
                <asp:Button ID="TranslateBackButton" runat="server" Width="400px" Height="40px" OnClick="TranslateBack" />
            </td>
        </tr>
    </table>
</asp:Content>

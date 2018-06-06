<%@ Page Title="Translator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinguoWeb.Default" %>
<%@ Import Namespace="LinguoWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
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

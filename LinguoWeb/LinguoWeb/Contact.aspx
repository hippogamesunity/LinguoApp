<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LinguoWeb.Contact" %>
<%@ Import Namespace="LinguoWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%=Localization.Localize("Contact")%></h2>
    <h3><%=Localization.Localize("Contact.Text")%></h3>
</asp:Content>

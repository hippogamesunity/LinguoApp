<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LinguoWeb.Contact" %>
<%@ Import Namespace="LinguoWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%=Localization.Localize("Contact")%></h3>
    <p><%=Localization.Localize("Contact.Text")%></p>
</asp:Content>

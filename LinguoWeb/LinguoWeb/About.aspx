<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LinguoWeb.About" %>
<%@ Import Namespace="LinguoWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h3><%=Localization.Localize("About")%></h3>
    <p><%=Localization.Localize("About.Text")%></p>
</asp:Content>

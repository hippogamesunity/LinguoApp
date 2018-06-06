<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LinguoWeb.About" %>
<%@ Import Namespace="LinguoWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%=Localization.Localize("About")%></h2>
    <h3><%=Localization.Localize("About.Text")%></h3>
</asp:Content>

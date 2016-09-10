<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Digital_School.Admin.WebForm1" %>

<%@ Register Src="~/User Control/SelectableImage.ascx" TagPrefix="uc1" TagName="SelectableImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<uc1:SelectableImage runat="server" id="SelectableImage" />
</asp:Content>

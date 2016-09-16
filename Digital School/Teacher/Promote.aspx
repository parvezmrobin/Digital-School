<%@ Page Title="Promote" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Promote.aspx.cs" Inherits="Digital_School.Teacher.Promote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2 style="text-align: center">Eligible students are promoted. Promote the rest manually.
	</h2>
	<asp:GridView runat="server" ID="gvPromote" CssClass="table table-striped table-hover"
		AutoGenerateSelectButton="true"></asp:GridView>
	<asp:Button Text="Promote" ID="btnPromote" runat="server" />
</asp:Content>

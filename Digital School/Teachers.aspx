<%@ Page Title="Teachers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="Digital_School.Teachers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="col-md-12 table-responsive">
			<h2>Teachers</h2>
			<asp:GridView AllowSorting="true" CssClass="table table-striped table-hover " ID="gvDetail"
				runat="server" GridLines="Horizontal" AutoGenerateColumns="true" BorderColor="Transparent">
			</asp:GridView>
		</div>
	</div>
</asp:Content>

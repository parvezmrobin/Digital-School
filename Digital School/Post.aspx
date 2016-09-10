<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Post.aspx.cs" Inherits="Digital_School.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style type="text/css">
		select.form-control {
			max-width: none;
		}
	</style>
	<div class="row ">
		<br />
		<h1 id="postTitle" runat="server" class="text-info" style="text-align: center" enableviewstate="true">
			Post Title</h1>
		<hr />
		<br />
		<div class="col-md-8 col-sm-7 well" id="postBody" runat="server" style="text-align: justify"
			enableviewstate="true">
		</div>
		<div class="col-sm-5 col-md-4">
			<asp:DropDownList ID="ddlCatagory" CssClass="form-control" runat="server" AutoPostBack="true"
				OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged" EnableViewState="true">
				<asp:ListItem Text="All" Value="All"></asp:ListItem>
				<asp:ListItem Text="News" Value="1"></asp:ListItem>
				<asp:ListItem Text="Notice" Value="2"></asp:ListItem>
				<asp:ListItem Text="Speech" Value="3"></asp:ListItem>
			</asp:DropDownList>
			<br />
			<div id="PostList" runat="server" class="list-group">
			</div>
		</div>
	</div>
</asp:Content>

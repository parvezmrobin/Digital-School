<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="Digital_School.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
		<div class="row ">
			<br />

			<div class="col-xs-12 btn btn-primary btn-block btn-lg text-left">
				<h1 id="postTitle" runat="server" enableviewstate="true">Post Title</h1>
			</div>
			<br />
			<div class="col-sm-9 well" id="postBody" runat="server" style="text-align: justify"
				enableviewstate="true">
			</div>
			<div class="col-sm-3">
				
				<asp:DropDownList ID="ddlCatagory" CssClass="form-control" runat="server" AutoPostBack="true"
					OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged" EnableViewState="true">
					<asp:ListItem Text="All" Value="All"></asp:ListItem>
					<asp:ListItem Text="News" Value="1"></asp:ListItem>
					<asp:ListItem Text="Notice" Value="2"></asp:ListItem>
					<asp:ListItem Text="Speech" Value="3"></asp:ListItem>
				</asp:DropDownList>
				
				<br />
				<div id="PostList" runat="server" class="list-group" style="overflow-y: scroll">
				</div>
			</div>


		</div>
	
</asp:Content>

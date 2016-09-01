<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Album.ascx.cs" Inherits="Digital_School.User_Control.Album" %>
<div class="col-lg-3 col-md-4 col-sm-6">
	<a href="~/Images.aspx?album=" id="link" runat="server" class="thumbnail">
		<h3 id="name" runat="server">
			<span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
			Album
		</h3>
		<img src="~/Albums/Album-Thumbnail.png" id="img" runat="server" />
	</a>
</div>

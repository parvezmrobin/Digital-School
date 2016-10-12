<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tile.ascx.cs" Inherits="Digital_School.User_Control.Tile" %>
<div id="divwidth" runat="server" class="col-sm-6" style="padding: 5px">
	<a runat="server" onserverclick="heading_Click" style="text-decoration: none">
	<div id="panel" runat="server" class="panel panel-primary" style="background-color: transparent;
		border: ridge"
		onmouseover="$(this).css('background-color', 'Highlight'); $(this).css('border', 'outset')"
		onmouseout="$(this).css('background-color', 'transparent'); $(this).css('border', 'ridge')">
		<p runat="server" Class="panel-heading" ID="heading" style="font-size:xx-large" ></p>
		<p style="text-align: justify; white-space: normal; height: 150px; overflow-y: auto;"
			class="panel-body" id="body" runat="server">
		</p>
		<p runat="server" id="footer"></p>
		<br />
		<asp:HiddenField ID="hfPostID" runat="server" />
		<asp:HiddenField ID="hfType" runat="server" />
	</div>
	</a>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tile.ascx.cs" Inherits="Digital_School.User_Control.Tile" %>
<div id="divwidth" runat="server" class="col-sm-6" style="padding: 5px">
	<div id="panel" runat="server" class="panel panel-primary">
		<asp:Button Text="Heading" runat="server" CssClass="panel-heading col-xs-12" Style="white-space: normal"
			OnClick="heading_Click" ID="heading" />
		<button style="text-align: justify; white-space: normal; height: 200px; overflow-y: scroll;"
			class="col-xs-12 btn btn-default"
			id="body" onserverclick="heading_Click"
			runat="server">
		</button>
		<asp:HiddenField ID="hfPostID" runat="server" />
		<asp:HiddenField ID="hfType" runat="server" />
	</div>
</div>

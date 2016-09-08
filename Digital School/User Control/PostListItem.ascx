<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostListItem.ascx.cs" Inherits="Digital_School.User_Control.PostListItem" %>
<div id="divCss" runat="server">
	<asp:Button ID="heading" CssClass="list-group-item list-group-item-heading col-xs-10 col-md-11"
		Style="white-space: normal"
		OnClick="heading_Click" runat="server">
	</asp:Button>
	<span class="badge col-xs-2 col-md-1" id="spanBadge" runat="server"></span>
	<asp:HiddenField runat="server" ID="hf" />
</div>

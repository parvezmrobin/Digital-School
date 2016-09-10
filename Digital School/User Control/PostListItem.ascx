<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostListItem.ascx.cs" Inherits="Digital_School.User_Control.PostListItem" %>
<asp:LinkButton ID="divCss" class="list-group-item" OnClick="heading_Click"
	runat="server">
	<h4 id="heading" class="list-group-item-heading"
		style="white-space: normal" runat="server">
	</h4>
	<span class="badge" id="spanBadge" runat="server"></span>	
	<p class="list-group-item-text" runat="server" id="body">
	</p>
	<asp:HiddenField runat="server" ID="hf" />
</asp:LinkButton>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Summary.ascx.cs" Inherits="Digital_School.User_Control.Summary" %>
<div id="widthdiv" runat="server" class="col-sm-6" style="padding: 7px">
	<div class="panel panel-primary">
		<button onserverclick="button_Click" class="col-xs-12 btn btn-default" style="min-height: 150px"
			runat="server">
			<h2 class="text-info" id="detail" runat="server" style="white-space: normal;"></h2>
		</button>
		<asp:Button Text="Button" CssClass="panel-heading col-xs-12" Style="white-space: normal"
			OnClick="button_Click" ID="button" runat="server" />
	</div>
</div>

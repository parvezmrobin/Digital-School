<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Summary.ascx.cs" Inherits="Digital_School.User_Control.Summary" %>
<div id="widthdiv" runat="server" class="col-sm-6">
	<a runat="server" onserverclick="button_Click"
		id="anchor">
		<div class="panel panel-primary" runat="server" id="panel" style="background-color:lavender">
			<h4 id="detail" class="panel-body" style="height: 100px;" runat="server"></h4>
			<h2 class="panel-heading" id="heading" runat="server"></h2>
		</div>
	</a>
</div>

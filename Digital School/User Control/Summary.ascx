<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Summary.ascx.cs" Inherits="Digital_School.User_Control.Summary" %>
<div id="widthdiv" runat="server" class="col-sm-6">
	<a runat="server" onserverclick="button_Click" style="text-decoration:none"
		id="anchor">
		<div class="panel panel-primary" runat="server" id="panel" style="background-color: lavender;
			border: ridge"
			onmouseover="$(this).css('background-color', 'Highlight'); $(this).css('border', 'outset')"
			onmouseout="$(this).css('background-color', 'lavender'); $(this).css('border', 'ridge')">
			<h4 id="detail" class="panel-body" style="height: 100px;" runat="server"></h4>
			<h2 class="panel-heading" id="heading" style="background-color: darkslategrey;" runat="server"></h2>
		</div>
	</a>
</div>

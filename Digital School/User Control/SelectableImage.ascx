<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectableImage.ascx.cs"
	Inherits="Digital_School.User_Control.SelectableImage" %>
<script>
	$(document).ready(function () {
		$('#link').click(function () {
			$('#cb').prop('checked', ($('#cb').checked) ? false : true);
		});
	});
</script>
<a href="#" id="link" class="thumbnail">
	<input type="checkbox" id="cb"/>
	<img src="~/Albums/Album-Thumbnail.png" id="img" runat="server" />
	<asp:HiddenField runat="server" ID="fileName" />
</a>
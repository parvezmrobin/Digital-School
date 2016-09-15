<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectableImage.ascx.cs"
	Inherits="Digital_School.User_Control.SelectableImage" %>

<div id="div" runat="server">
	<div class="thumbnail" onclick="var checkBox = $('#<%:cb.ClientID %>');
			checkBox.prop('checked', !checkBox.prop('checked'));">
	<asp:CheckBox ID="cb" runat="server"/>
	<img src="~/Albums/Album-Thumbnail.png" id="img" runat="server" />
	</div>
	<asp:HiddenField runat="server" ID="fileName" />
</div>
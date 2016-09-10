<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Settings.aspx.cs" Inherits="Digital_School.Admin.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminSettings').attr('class', 'active');
			//$('hSuccess').delay(5000).fadeOut(1000);
		});
	</script>
	<div class="row">
		<h2 class="text-info" style="text-align: center">Administrator Settings</h2>
		<hr />

		<div class="col-md-offset-2">
			<asp:UpdatePanel runat="server" ID="up">
				<ContentTemplate>
					
					<h4 runat="server" id="hSuccess" class="text-success">Changes are saved</h4>
					<asp:CheckBoxList runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value"
						ID="cbSettings"
						CellPadding="7">
					</asp:CheckBoxList>

					<br />
					<asp:Button Text="Update" CssClass="btn btn-info btn-lg" OnClick="Unnamed_Click"
						runat="server" />
				</ContentTemplate>
			</asp:UpdatePanel>
		</div>
	</div>
</asp:Content>

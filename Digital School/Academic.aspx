<%@ Page Title="Academic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Academic.aspx.cs" Inherits="Digital_School.Academic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#menuAcademic').attr('class', 'active');
		});
	</script>
	<script type="text/javascript">
		$(document).ready(function () {
			var divApp = $('#<%:Applications.ClientID %>');
			divApp.bind('resize', function (event) {
				divApp.css({ 'max-height': $(window).height() - 150 });
			});
		});
	</script>
	
	<div class="row" style="padding-left: 10px">
		<div class="panel panel-info col-md-6">
			<p class="panel-heading" style="font-size:xx-large">
				Applications
			</p>
			<div id="Applications" runat="server">

			</div>
			<br />

		</div>
		<div class="panel panel-success col-md-6">
			<p class="panel-heading" style="font-size:xx-large">
				Results
			</p>
			<div id="Results" runat="server"></div>
		</div>
	</div>
</asp:Content>

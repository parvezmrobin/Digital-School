<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Academic.aspx.cs" Inherits="Digital_School.Academic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#menuAcademic').attr('class', 'active');
		});
	</script>
	<div class="row" style="padding-left: 10px">
		<div class="well col-md-5" id="Applications" runat="server">
			<p class="btn btn-default btn-lg btn-block">
				Applications
			</p>
			<br />

		</div>
		<div class="jumbotron col-md-5 col-md-offset-2" id="Results" runat="server">
			<p class="btn btn-default btn-lg btn-block">
				Results
			</p>
		</div>
	</div>
</asp:Content>

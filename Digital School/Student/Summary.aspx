<%@ Page Title="Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Summary.aspx.cs" Inherits="Digital_School.Student.Summary" %>

<%@ Register Src="~/User Control/Summary.ascx" TagName="Summary" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		input.panel-heading {
			font-size: 24px;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#studentSummary').attr('class', 'active');
		});
	</script>
	<div class="row">
		<section>
			<h2 runat="server" class="text-info col-md-8" style="text-align: center">
				<%:new AspNet.Identity.MySQL.UserTable<Digital_School.Models.ApplicationUser>(new AspNet.Identity.MySQL.MySQLDatabase()).GetUserByName(User.Identity.Name).Select(x=> x.FullName).FirstOrDefault() %>
			</h2>
			<h4 class="text-danger text-right col-md-4" runat="server" id="pDue"></h4>
		</section>
		<hr />
		<br />
		<uc1:Summary ID="SummaryNotification" runat="server" Title="Notification"
			Detail="Check your notifications" OnClick="SummaryNotification_Click" />
		<uc1:Summary ID="SummaryBrowse" runat="server" Title="Browse" Detail="Browse your results and info"
			OnClick="SummaryBrowse_Click" />
		<uc1:Summary ID="SummaryGraphicalView" runat="server" Title="Graphical View"
			Detail="See your progress and digress in graph" OnClick="SummaryGraphicalView_Click" />
		<uc1:Summary ID="SummaryAskQuestion" runat="server" Title="Ask Question"
			Detail="Ask question to teachers" OnClick="SummaryAskQuestion_Click" />
	</div>
</asp:Content>

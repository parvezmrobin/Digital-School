<%@ Page Title="Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Summary.aspx.cs" Inherits="Digital_School.Teacher.Summary" %>

<%@ Register Src="~/User Control/Summary.ascx" TagPrefix="uc1" TagName="Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		input.panel-heading {
			font-size: 24px;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#teacherSummary').attr('class', 'active');
		});
	</script>
	<br />
	<div class="row">
		<h2 class="text-info" runat="server" style="text-align: center">
			<%:new AspNet.Identity.MySQL.UserTable<Digital_School.Models.ApplicationUser>(new AspNet.Identity.MySQL.MySQLDatabase()).GetUserByName(User.Identity.Name).Select(x=> x.FullName).FirstOrDefault() %>
		</h2>
		<hr />
		<uc1:Summary runat="server" ID="SummaryAttendance" Title="Attendance"
			Detail="Input Today's Attendances" WidthClass="col-md-4 col-sm-6" />
		<uc1:Summary runat="server" ID="SummaryNotifications" Title="Push Notification"
			Detail="Push notifications to all or specific student" WidthClass="col-md-4 col-sm-6" />
		<uc1:Summary runat="server" ID="SummaryAnswer" Title="Answer Quest"
			Detail="Answer Questions Asked by Students" WidthClass="col-md-4 col-sm-6" />
		<uc1:Summary runat="server" ID="SummaryInput" Title="Input Result"
			Detail="Input results of various exams" WidthClass="col-md-4 col-sm-6" />
		<uc1:Summary runat="server" ID="SummaryTransaction" Title="Transaction"
			Detail="Transactions options" WidthClass="col-md-4 col-sm-6" />
		<uc1:Summary runat="server" ID="SummaryMiscellaneous" Title="Miscellaneous" PanelClass="panel panel-warning" 
			Detail="Miscellaneous jobs like promotions, tabulations, mark sheet, edit student account"
			WidthClass="col-md-4 col-sm-6" />
	</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Summary.aspx.cs" Inherits="Digital_School.Student.Summary" %>

<%@ Register Src="~/User Control/Summary.ascx" TagName="Summary" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		input.panel-heading {
			font-size: 24px;
		}
	</style>
	<div class="row">
		<br />
		<h2 id="name" runat="server">Student Name</h2>
		<hr />
		<br />
		<uc1:Summary ID="SummaryNotification" runat="server" Title="Notification"
			Detail="View Notifications that are pushed by authority." OnClick="SummaryNotification_Click" />
		<uc1:Summary ID="SummaryBrowse" runat="server" Title="Browse" Detail="Browse student's results and info."
			OnClick="SummaryBrowse_Click" />
		<uc1:Summary ID="SummaryGraphicalView" runat="server" Title="Graphical View"
			Detail="View progress and digress of student in graph." OnClick="SummaryGraphicalView_Click" />
		<uc1:Summary ID="SummaryAskQuestion" runat="server" Title="Ask Question"
			Detail="Ask question to subject teachers or authority." OnClick="SummaryAskQuestion_Click" />
	</div>
	<br />
</asp:Content>

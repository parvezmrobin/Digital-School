<%@ Page Title="Summary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="Digital_School.Teacher.Summary" %>
<%@ Register Src="~/User Control/Summary.ascx" TagPrefix="uc1" TagName="Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		input.panel-heading {
			font-size: 24px;
		}
	</style>
	<br />
	<div class="row">
		<uc1:Summary runat="server" id="SummaryInput" title="Input Result"
			detail="Input results of various exams" />
		<uc1:Summary runat="server" id="SummaryNotifications" title="Push Notifications & Answer Quests"
			detail="Push notifications to all or specific student" />
		<uc1:Summary runat="server" id="SummaryTransaction" title="Transaction"
			detail="Transactions options " />
		<uc1:Summary runat="server" id="SummaryMiscellaneous" title="Miscellaneous"
			detail="Miscellaneous jobs like promotions, tabulations, mark sheet, edit student account" />
	</div>
</asp:Content>

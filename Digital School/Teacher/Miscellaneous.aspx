<%@ Page Title="Miscellaneous" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Miscellaneous.aspx.cs" Inherits="Digital_School.Teacher.Miscellaneous" %>

<%@ Register Src="~/User Control/Summary.ascx" TagPrefix="uc1" TagName="Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<br />
	<div class="row">
		<uc1:Summary Title="Promote" Detail="Promote eligible students to next class"
			runat="server" WidthClass="col-md-6 col-lg-4" ID="SummaryPromote" />
		<uc1:Summary Title="Tabulation" Detail="Create Tabulation sheet"
			runat="server" WidthClass="col-md-6 col-lg-4" ID="SummaryTabulation" />
		<uc1:Summary Title="Edit Student Account" Detail="Edit student account"
			runat="server" WidthClass="col-md-6 col-lg-4" ID="SummaryEditStudent" />
		<uc1:Summary Title="Student Group" Detail="Create,edit or delete student group"
			runat="server" WidthClass="col-md-6 col-lg-4" ID="SummaryStudentGroup" />
		<uc1:Summary Title="Student Details" Detail="View Student Detail Information"
			runat="server" WidthClass="col-md-6 col-lg-4" ID="SummaryStudentDetail" />
	</div>
</asp:Content>

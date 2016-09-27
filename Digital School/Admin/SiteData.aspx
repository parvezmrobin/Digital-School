<%@ Page Title="Site Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="SiteData.aspx.cs" Inherits="Digital_School.Admin.SiteData" %>

<%@ Register Src="~/User Control/Summary.ascx" TagPrefix="uc1" TagName="Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminSiteData').attr('class', 'active');
		});
	</script>
	<div class="row">
		<h2 class="text-info text-center">Change site related data</h2>
		<hr />
		<uc1:Summary runat="server" ID="SummarySlideShow" WidthClass="col-lg-4 col-md-6"
			Title="Slide Show" Detail="<ul><li>Select images for slide show</li></ul>" OnClick="SummarySlideShow_Click" />
		<uc1:Summary runat="server" ID="SummaryGallery" WidthClass="col-lg-4 col-md-6" Title="Gallery"
			Detail="<ul><li>Create and/or edit albums</li></ul>" OnClick="SummaryGallery_Click" />
		<uc1:Summary runat="server" ID="SummaryPost" WidthClass="col-lg-4 col-md-6" Title="Post"
			Detail="<ul><li>Create, edit and/or delete news, notice and speech</li></ul>" />
		<uc1:Summary runat="server" ID="SummaryHistoryContact" WidthClass="col-lg-4 col-md-6"
			Title="History"
			Detail="<ul><li>Edit 'History' page</li></ul>" />
		<uc1:Summary runat="server" ID="Summary1" WidthClass="col-lg-4 col-md-6"
			Title="Contact"
			Detail="<ul><li>Edit 'Contact' page</li></ul>" />
		<uc1:Summary runat="server" ID="SummaryApplication" WidthClass="col-lg-4 col-md-6"
			Title="Application" OnClick="SummaryApplication_Click"
			Detail="<ul><li>Create new application for admitting student or recruiting teacher</li></ul>" />
		
	</div>
</asp:Content>

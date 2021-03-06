﻿<%@ Page Title="Site Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
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
		
        <uc1:Summary runat="server" ID="SummaryGallery" WidthClass="col-lg-4 col-md-6" Title="Gallery"
            Detail="<ul><li>Create and/or edit albums</li></ul>" OnClick="SummaryGallery_Click" />
        <uc1:Summary runat="server" ID="SummaryPost" WidthClass="col-lg-4 col-md-6" Title="Post"
           Detail="<ul><li>Create and edit news, notice and speech</li></ul>" OnClick="SummaryPost_Click" />
        <uc1:Summary runat="server" ID="SummaryHistoryContact" WidthClass="col-lg-4 col-md-6"
			Title="History And Contacts"
			Detail="<ul><li>Edit 'History And Contact' page</li></ul>" OnClick="SummaryHistoryContact_Click" />
        <uc1:Summary runat="server" ID="SummaryApplicationResponse" WidthClass="col-lg-4 col-md-6"
            Title="Application Response"
            Detail="<ul><li>Response</li></ul>" OnClick="SummaryApplicationResponse_Click" />
        <uc1:Summary runat="server" ID="SummaryApplication" WidthClass="col-lg-4 col-md-6"
			Title="Create Application" OnClick="SummaryApplication_Click"
			Detail="<ul><li>Create new application for admitting students or recruiting teachers</li></ul>" />
         <uc1:Summary runat="server" ID="SummaryAccount" WidthClass="col-lg-4 col-md-6"
			Title="Create Account" Detail="<ul><li>Create new accounts for admitted students or recruited teachers</li></ul>" OnClick="SummaryAccount_Click" />

	</div>
</asp:Content>

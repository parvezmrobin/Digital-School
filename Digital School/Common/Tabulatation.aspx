<%@ Page Title="Tabulation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Tabulatation.aspx.cs" Inherits="Digital_School.Admin.Tabulatation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<style type="text/css">
			.absent{
				color:red;
				font-weight:bold;
			}
			.header-cell{
				border-style:solid;
				border-width:3px;
				border-color:white;
			}
		</style>
		<script type="text/javascript">
			$(document).ready(function () {
				$("td").filter(function () {
					return $(this).text() == "A";
				}).attr('class', 'absent');

				$('th').attr('class', 'header-cell');
			});
		</script>
		<h2 class="text-center text-info"><%: Page.Title %></h2>
		<hr />
		<div class="col-lg-4 col-md-6">
			<div class="form-horizontal">
				<div class="form-group">
					<asp:Label Text="Year" AssociatedControlID="ddlYear" CssClass="control-label col-md-4"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" AutoPostBack="true"
							DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="LoadDDLClass">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Class" AssociatedControlID="ddlClass" CssClass="control-label col-md-4"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlClass" CssClass="form-control" AutoPostBack="true"
							DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="LoadDDLSection">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Section" AssociatedControlID="ddlSection" CssClass="control-label col-md-4"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlSection" CssClass="form-control" AutoPostBack="true"
							DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="LoadNextOfDDLSection">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Term" AssociatedControlID="ddlTerm" CssClass="control-label col-md-4"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlTerm" CssClass="form-control" AutoPostBack="true"
							DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="LoadGV">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group" hidden="hidden">
					<asp:Label Text="Subject" AssociatedControlID="ddlSubject" CssClass="control-label col-md-4"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control" AutoPostBack="true"
							DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="LoadGV">
						</asp:DropDownList>
					</div>
				</div>
			</div>
		</div>
		<div class="col-md-12" style="overflow-x:auto">
			<asp:GridView runat="server" ID="gv" CssClass="table table-striped table-hover" HeaderStyle-CssClass="text-info" OnRowDataBound="gv_RowDataBound">
			</asp:GridView>
		</div> 
	</div>
</asp:Content>

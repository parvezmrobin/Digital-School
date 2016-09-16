<%@ Page Title="Application & Reponses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="Digital_School.Admin.Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2 class="text-info text-center"><%:Title %></h2>
	<hr />
	<div class="row">
		<div class="panel panel-info col-md-6">
			<p class="panel-heading" style="font-size:xx-large">Applications</p>
			<div class="panel-body">
				<div id="Applications" runat="server"></div>
				<br />
				<div>
					<asp:CheckBox Text="Show inactives" ToolTip="Show inactive applications as well" AutoPostBack="true" runat="server" />
					<asp:Button Text="Remove" CssClass="btn btn-danger" ID="btnRemoveApp" ToolTip="Remove selected application and all corresponding responses" style="float:right" runat="server" />
				</div>
			</div>
		</div>
		<div class="panel panel-info col-md-6">
			<p class="panel-heading" style="font-size: xx-large">Responses</p>
			<div class="panel-body">
				<div id="Responses" runat="server"></div>
				<br />
				<div>
					<asp:Button Text="Remove" CssClass="btn btn-danger" ID="btnRemoveRes" ToolTip="Remove selected responses"
						Style="float: right" runat="server" />
				</div>
			</div>
		</div>
	</div>
</asp:Content>

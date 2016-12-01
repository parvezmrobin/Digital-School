<%@ Page Title="Create Application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateApplication.aspx.cs" Inherits="Digital_School.Admin.CreateApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2 class="text-center text-info">Create A New Application</h2>
		<hr />
		<div class="form-horizontal">
			<div class="form-group">
				<asp:Label Text="Applicaiton Type" CssClass="control-label col-md-4" AssociatedControlID="ddlType" runat="server" />
				<div class="col-md-8">
					<asp:DropDownList runat="server" ID="ddlType" AutoPostBack="true" DataTextField="Text" DataValueField="Value" CssClass="form-control">
						<asp:ListItem Text="Student" Value="1" />
						<asp:ListItem Text="Teacher" Value="2" />
					</asp:DropDownList>
				</div>
			</div>
			<div class="form-group">
				<asp:Label Text="Applicaiton Title" CssClass="control-label col-md-4" AssociatedControlID="txtTitle"
					runat="server" />
				<div class="col-md-8">
					<asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" TextMode="SingleLine" />
					<asp:RequiredFieldValidator ErrorMessage="Title cannot be empty" CssClass="text-danger" ControlToValidate="txtTitle"
						runat="server" />
				</div>
			</div>
			<div class="form-group">
				<asp:Label Text="Applicaiton Summary" CssClass="control-label col-md-4" AssociatedControlID="txtSummary"
					runat="server" />
				<div class="col-md-8">
					<asp:TextBox runat="server" ID="txtSummary" CssClass="form-control" TextMode="MultiLine" />
				</div>
			</div>
			<div class="form-group">
				<asp:Label Text="Corresponding Notice URL" CssClass="control-label col-md-4" AssociatedControlID="txtNoticeURL"
					runat="server" />
				<div class="col-md-8">
					<asp:TextBox runat="server" ID="txtNoticeURL" CssClass="form-control" TextMode="SingleLine" AutoCompleteType="BusinessUrl" />
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-offset-4 col-md-8">
					<asp:Button Text="Create" CssClass="btn btn-success" OnClick="Unnamed_Click" runat="server" />
				</div>
			</div>
		</div>
	</div>
</asp:Content>

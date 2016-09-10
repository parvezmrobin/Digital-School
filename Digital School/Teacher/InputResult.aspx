<%@ Page Title="Input Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="InputResult.aspx.cs" Inherits="Digital_School.Teacher.InputResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		select.form-control {
			max-width: 280px;
		}
	</style>
	<br />
	<div class="row">
		<h2 style="text-align: center" class="text-info"><%: Title %>.</h2>
		<hr />
		<asp:UpdatePanel runat="server" ID="up">
			<ContentTemplate>

				<div class="col-md-5 col-lg-4">
					<div class="form-horizontal">
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlYear" OnSelectedIndexChanged="ReloadYCSId" CssClass="form-control"
									runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlClass" OnSelectedIndexChanged="ReloadYCSId" CssClass="form-control"
									runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
						<br />

						<div class="form-group">
							<asp:Label Text="Select Section" AssociatedControlID="ddlSection" runat="server"
								CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlSection" OnSelectedIndexChanged="ReloadYCSId" CssClass="form-control"
									runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>

						<br />
						<div class="form-group">
							<asp:Label Text="Select Subject" AssociatedControlID="ddlSubject" runat="server"
								CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlSubject" CssClass="form-control" runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Exam" AssociatedControlID="ddlTerm" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlTerm" CssClass="form-control" runat="server" AutoPostBack="true">
									<asp:ListItem Text="First Term" Value="1" />
									<asp:ListItem Text="Second Term" Value="2" />
									<asp:ListItem Text="Final Term" Value="3" />
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Student" AssociatedControlID="ddlStudent" runat="server"
								CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlStudent" CssClass="form-control" runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
					</div>

				</div>
				<div class="col-md-7 col-lg-8" style="align-items: center">
					<div class="form-horizontal">
						<div id="marks" runat="server"></div>
						<asp:Button Text="Submit All" runat="server" ID="btnSubmit" CssClass="btn btn-primary btn-lg col-md-offset-4"
							OnClick="btnSubmit_Click" />
					</div>

				</div>


			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdateProgress AssociatedUpdatePanelID="up" DisplayAfter="1" runat="server">
			<ProgressTemplate>
					<h1 class="text-info">Loading...</h1>
			</ProgressTemplate>
		</asp:UpdateProgress>
	</div>
</asp:Content>

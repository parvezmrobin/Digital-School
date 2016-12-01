<%@ Page Title="Browse Marks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="BrowseMarks.aspx.cs" Inherits="Digital_School.Student.BrowseMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style type="text/css">
		input.form-control {
			max-width: 280px;
		}
	</style>
	<div class="row">
		<h2>Browse Your Exam Marks</h2>
		<hr />
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-5 col-lg-4">
					<div class="form-horizontal">
						<div class="form-group">
							<asp:Label Text="Year" AssociatedControlID="ddlYear" runat="server" CssClass="col-md-2 control-label" />
							<div class="col-md-10">
								<asp:DropDownList ID="ddlYear" OnDataBound="LoadDDLSubject" OnSelectedIndexChanged="LoadDDLTerm" 
									CssClass="form-control" runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Term" AssociatedControlID="ddlTerm" runat="server" CssClass="col-md-2 control-label" />
							<div class="col-md-10">
								<asp:DropDownList ID="ddlTerm" CssClass="form-control" runat="server" AutoPostBack="true" 
									OnSelectedIndexChanged="LoadDDLSubject" DataTextField="Text" DataValueField="Value">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Subject" AssociatedControlID="ddlSubject" runat="server"
								CssClass="col-md-2 control-label" />
							<div class="col-md-10">
								<asp:DropDownList ID="ddlSubject" OnSelectedIndexChanged="LoadGridView" OnDataBound="LoadGridView" CssClass="form-control" runat="server" AutoPostBack="true">
									<asp:ListItem Text="All" Value="All"></asp:ListItem>
								</asp:DropDownList>
							</div>
						</div>
					</div>
				</div>

				<div class="col-md-7 col-lg-8">
					<asp:GridView CssClass="table table-striped table-hover" runat="server" ID="gvMark"
						HeaderStyle-CssClass="text-info" AutoGenerateColumns="true" BorderColor="Transparent">
					</asp:GridView>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>

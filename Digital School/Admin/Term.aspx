<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Term.aspx.cs" Inherits="Digital_School.Admin.Term" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<div class="visible-sm">
		<br />
		<br />
	</div>
	<div class="row">
		<div class="panel panel-primary col-md-6 form-horizontal" style="border: none">
			<h2 class="panel-heading text-center">Overview</h2>
			<div class="panel-body" style="border: 2px solid #428bca; border-radius: 5px">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlYear" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlClass" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Section" AssociatedControlID="ddlSection" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlSection" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control">
								</asp:DropDownList>
							</div>
						</div>
						<div class="from-group">
							<asp:Label Text="Terms" AssociatedControlID="blTerm" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8 ">
								<asp:BulletedList ID="blTerm" CssClass="text-info" 
									runat="server" DataTextField="Text"
									DataValueField="Value">
									<asp:ListItem Text="text" />
									<asp:ListItem Text="text" />
								</asp:BulletedList>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>

	</div>
</asp:Content>

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
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" runat="server" CssClass="col-md-2 control-label" />
							<div class="col-md-10">
								<asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server" AutoPostBack="true">
								</asp:DropDownList>

							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Term" AssociatedControlID="ddlTerm" runat="server" CssClass="col-md-2 control-label" />
							<div class="col-md-10">
								<asp:DropDownList ID="ddlTerm" CssClass="form-control" runat="server" AutoPostBack="true">
									<asp:ListItem Text="First Term" Value="1"></asp:ListItem>
									<asp:ListItem Text="Second Term" Value="2"></asp:ListItem>
									<asp:ListItem Text="Final Term" Value="3"></asp:ListItem>
								</asp:DropDownList>

							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Subject" AssociatedControlID="ddlSubject" runat="server"
								CssClass="col-md-2 control-label" />
							<div class="col-md-10">
								<asp:DropDownList ID="ddlSubject" CssClass="form-control" runat="server" AutoPostBack="true">
									<asp:ListItem Text="All" Value="All"></asp:ListItem>
								</asp:DropDownList>
							</div>
						</div>
					</div>
				</div>

				<div class="col-md-7 col-lg-8">
					<asp:GridView CssClass="table table-striped table-hover" runat="server" ID="gvMark"
						HeaderStyle-CssClass="text-info">
					</asp:GridView>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	
	</div>
</asp:Content>

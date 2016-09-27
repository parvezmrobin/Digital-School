<%@ Page Title="Promotion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Promote.aspx.cs" Inherits="Digital_School.Teacher.Promote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2 class="text-info" style="text-align: center"><%: Title %></h2>
		<hr />
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-6">
					<div class="form-horizontal">
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlClass" OnSelectedIndexChanged="ReloadDDLSection" CssClass="form-control"
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
					</div>
				</div>
				<div class="col-md-6">
					<asp:GridView runat="server" ID="gvPromote" CssClass="table table-striped table-hover">
					</asp:GridView>

				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>

<%@ Page Title="Promotion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Promote.aspx.cs" Inherits="Digital_School.Teacher.Promote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<style>
			.panel{
				border:none;
			}
		</style>
		<h2 class="text-info" style="text-align: center"><%: Title %></h2>
		<hr />
		<h3 class="text-success text-center" id="hPromote" runat="server">Promoted Successfully</h3>
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-6">
					<div class="panel panel-primary">
						<h2 class="panel-heading text-center">From</h2>
						<div class="form-horizontal panel-body">
							<div class="form-group">
								<asp:Label Text="Select Year" AssociatedControlID="ddlFromYear" runat="server" CssClass="col-md-4 control-label" />
								<div class="col-md-8">
									<asp:DropDownList ID="ddlFromYear" OnSelectedIndexChanged="ReloadDDLFromClass" CssClass="form-control"
										DataTextField="Text" DataValueField="Value"
										runat="server" AutoPostBack="true">
									</asp:DropDownList>
								</div>
							</div>
							<br />
							<div class="form-group">
								<asp:Label Text="Select Class" AssociatedControlID="ddlFromClass" runat="server" CssClass="col-md-4 control-label" />
								<div class="col-md-8">
									<asp:DropDownList ID="ddlFromClass" OnSelectedIndexChanged="ReloadDDLFromSection" CssClass="form-control" DataTextField="Text" DataValueField="Value"
										runat="server" AutoPostBack="true">
									</asp:DropDownList>
								</div>
							</div>
							<br />
							<div class="form-group">
								<asp:Label Text="Select Section" AssociatedControlID="ddlFromSection" runat="server"
									CssClass="col-md-4 control-label" />
								<div class="col-md-8">
									<asp:DropDownList ID="ddlFromSection" CssClass="form-control"
										runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="BindGridView">
									</asp:DropDownList>
								</div>
							</div>
						</div>
						<h2 class="panel-heading text-center">To</h2>
						<div class="form-horizontal panel-body">
							<div class="form-group">
								<asp:Label Text="Select Year" AssociatedControlID="ddlToYear" runat="server" CssClass="col-md-4 control-label" />
								<div class="col-md-8">
									<asp:DropDownList ID="ddlToYear" OnSelectedIndexChanged="ReloadDDLToClass"
										CssClass="form-control"
										DataTextField="Text" DataValueField="Value"
										runat="server" AutoPostBack="true">
									</asp:DropDownList>
								</div>
							</div>
							<br />
							<div class="form-group">
								<asp:Label Text="Select Class" AssociatedControlID="ddlToClass" runat="server"
									CssClass="col-md-4 control-label" />
								<div class="col-md-8">
									<asp:DropDownList ID="ddlToClass" OnSelectedIndexChanged="ReloadDDLToSection"
										CssClass="form-control" DataTextField="Text" DataValueField="Value"
										runat="server" AutoPostBack="true">
									</asp:DropDownList>
								</div>
							</div>
							<br />
							<div class="form-group">
								<asp:Label Text="Select Section" AssociatedControlID="ddlToSection" runat="server"
									CssClass="col-md-4 control-label" />
								<div class="col-md-8">
									<asp:DropDownList ID="ddlToSection" CssClass="form-control"
										runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value">
									</asp:DropDownList>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-6">
					<br />
					<asp:GridView runat="server" ID="gvPromote" CssClass="table table-striped table-hover" AutoGenerateColumns="false" HeaderStyle-CssClass="text-info">
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<asp:CheckBox ID="cb" runat="server" />
									<asp:HiddenField runat="server" ID="StudentId" Value='<%# Eval("Student.ID") %>' />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="First Name">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Student.FirstName") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Last Name">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Student.LastName") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Roll">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Student.Roll") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Position">
								<ItemTemplate>
									<asp:Label ID="NextRoll" Text='<%# Eval("MarkId") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>

				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:Button Text="Promote" CssClass="btn btn-success" OnClick="Unnamed_Click" runat="server" />
	</div>
</asp:Content>

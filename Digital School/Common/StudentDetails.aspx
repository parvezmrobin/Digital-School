<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="StudentDetails.aspx.cs" Inherits="Digital_School.Common.StudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2 class="text-info text-center">Student Details</h2>
		<hr />
		<div>
			<div class="form-horizontal">
				<div class="form-group">
					<asp:Label Text="Select Year" AssociatedControlID="ddlYear" runat="server"
						CssClass="col-md-4 col-sm-6 control-label" />
					<div class="col-md-8 col-sm-6">
						<asp:DropDownList ID="ddlYear" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
							CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 col-sm-6 control-label" />
					<div class="col-md-8 col-sm-6">
						<asp:DropDownList ID="ddlClass" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
							CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
							runat="server">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Section" AssociatedControlID="ddlSection" runat="server"
						CssClass="col-md-4 col-sm-6 control-label" />
					<div class="col-md-8 col-sm-6">
						<asp:DropDownList ID="ddlSection" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
							CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
						</asp:DropDownList>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="row">
		<div class="table-responsive">
			<div class="form-horizontal">
				<div class="form-group">
					<asp:GridView runat="server" ID="gvStudentDetails" BorderColor="Transparent" Caption='<span class="text-info" style="font-size:xx-large"></span>'
						AutoGenerateColumns="false" HeaderStyle-CssClass="text-info"
						CssClass="table table-striped table-hover">
						<Columns>
							<asp:TemplateField HeaderText="Roll">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Roll") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Name">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Name") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Father's Name">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("FathersName") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Mother's Name">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("MothersName") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Email">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Email") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Phone Number">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("PhoneNumber") %>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Gender">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Gender").ToString() == "0" ?"Male":"Female"%>' runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

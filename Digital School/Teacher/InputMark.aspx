<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InputMark.aspx.cs" Inherits="Digital_School.Teacher.InputMark" %>

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
		<%--<asp:UpdatePanel runat="server" ID="up">
			<ContentTemplate>--%>

				<div class="col-md-5 col-lg-4">
					<div class="form-horizontal">
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlYear" OnSelectedIndexChanged="LoadClass" CssClass="form-control"
									runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlClass" OnSelectedIndexChanged="LoadSection" CssClass="form-control"
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
								<asp:DropDownList ID="ddlSubject" OnSelectedIndexChanged="LoadStudent" CssClass="form-control" runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Term" AssociatedControlID="ddlTerm" runat="server" CssClass="col-md-4 control-label" />
							<div class="col-md-8">
								<asp:DropDownList ID="ddlTerm" CssClass="form-control" OnSelectedIndexChanged="LoadStudent" runat="server" AutoPostBack="true">
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
								<asp:DropDownList ID="ddlStudent" CssClass="form-control" OnSelectedIndexChanged="BindGridView" runat="server" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
					</div>

				</div>
				<div class="col-md-7 col-lg-8" style="align-items: center">
					<div class="form-horizontal">
						<div id="marks" class="table-responsive" runat="server" style="max-height: 600px;
							overflow-y: auto">
							<asp:GridView runat="server" ID="gvMark" CssClass="table table-striped table-hover" AutoGenerateColumns="false">
								<Columns>
									<asp:TemplateField>
										<HeaderTemplate>
											<asp:CheckBox AutoPostBack="true" ID="chkHeader" runat="server" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:CheckBox ID="chk" runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField>
										<HeaderTemplate>
											<asp:Label Text="Subject" runat="server" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:TextBox runat="server" ID="txtSubject" Text='<%# Eval("Subject") %>' Visible="false" />
											<asp:Label Text='<%# Eval("Subject") %>' ID="lblSubject" Visible="true" runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<%--<asp:BoundField DataField="Subject" HeaderText="Subject" />--%>
									<asp:TemplateField>
										<HeaderTemplate>
											<asp:Label Text="Portion Name" runat="server" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:TextBox runat="server" ID="txtPortionName" Text='<%# Eval("PortionName") %>' Visible="false" />
											<asp:Label Text='<%# Eval("PortionName") %>' ID="lblPortionName" Visible="true" runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<%--<asp:BoundField DataField="PortionName" HeaderText="Portion Name" NullDisplayText="NULL" />--%>
									<asp:TemplateField>
										<HeaderTemplate>
											<asp:Label Text="Mark Portion Id" runat="server" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:TextBox runat="server" ID="txtMarkPortionId" Text='<%# Eval("MarkPortionId") %>'
												Visible="false" />
											<asp:Label Text='<%# Eval("MarkPortionId") %>' ID="lblMarkPortionId" Visible="true"
												runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<%--<asp:BoundField DataField="MarkPortionId" HeaderText="Mark Portion Id" NullDisplayText="NULL" />--%>
									<asp:TemplateField>
										<HeaderTemplate>
											<asp:Label Text="Mark" runat="server" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:TextBox runat="server" ID="txtMark" Text='<%# Eval("Mark") %>'
												Visible="false" />
											<asp:Label Text='<%# Eval("Mark") %>' ID="lblMark" Visible="true"
												runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<%--<asp:BoundField DataField="Mark" HeaderText="Mark" NullDisplayText="NULL" />--%>
									<asp:TemplateField>
										<HeaderTemplate>
											<asp:Label Text="Mark Id" runat="server" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:TextBox runat="server" ID="txtMarkId" Text='<%# Eval("MarkId") %>'
												Visible="false" />
											<asp:Label Text='<%# Eval("MarkId") %>' ID="lblMarkId" Visible="true"
												runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<%--<asp:BoundField DataField="MarkId" HeaderText="MarkId" NullDisplayText="NULL" />--%>
								</Columns>
							</asp:GridView>
						</div>
						<asp:Button Text="Edit" OnClick="btnSubmit_Click" runat="server" ID="btnSubmit" CssClass="btn btn-primary btn-lg" />
					</div>

				</div>
				

			<%--</ContentTemplate>

		</asp:UpdatePanel>
		<asp:UpdateProgress AssociatedUpdatePanelID="up" DisplayAfter="1" runat="server">
			<ProgressTemplate>
				<h1 class="text-info">Loading...</h1>
			</ProgressTemplate>
		</asp:UpdateProgress>--%>
	</div>
</asp:Content>


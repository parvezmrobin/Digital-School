<%@ Page Title="Transaction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Transaction.aspx.cs" Inherits="Digital_School.Teacher.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {

			$('#hSuccess').delay(5000).fadeOut(1000);

		});
	</script>
	<style type="text/css">
		input.form-control {
			max-width: 280px;
		}
	</style>
	<div class="row">
		<div class="col-md-6 col-md-offset-3">
			<asp:UpdatePanel runat="server">
				<ContentTemplate>
					<div class="panel panel-primary">
						<p class="panel-heading">Payment</p>
						<div class="panel-body">
							<div class="form-horizontal">
								<br />
								<div class="form-group">
									<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-3 control-label" />
									<div class="col-md-9">
										<asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server" DataTextField="Text"
											DataValueField="Value"
											OnSelectedIndexChanged="LoadSection" AutoPostBack="true">
										</asp:DropDownList>
									</div>
								</div>
								<br />
								<div class="form-group">
									<asp:Label Text="Select Section" AssociatedControlID="ddlSection" runat="server"
										CssClass="col-md-3 control-label" />
									<div class="col-md-9">
										<asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server" DataTextField="Text"
											DataValueField="Value" OnSelectedIndexChanged="LoadStudent" AutoPostBack="true">
										</asp:DropDownList>
									</div>
								</div>
								<br />
								<div class="form-group">
									<asp:Label Text="Select Student" AssociatedControlID="ddlStudent" runat="server"
										CssClass="col-md-3 control-label" />
									<div class="col-md-9">
										<asp:DropDownList ID="ddlStudent" CssClass="form-control" runat="server" DataTextField="Text"
											DataValueField="Value" OnSelectedIndexChanged="LoadDue" AutoPostBack="true">
										</asp:DropDownList>
									</div>
								</div>
								<br />
								<div class="form-group">
									<asp:Label  AssociatedControlID="btnDue" runat="server" ID="lblDue"
										CssClass="col-md-3 control-label" />
									<div class="col-md-9">
										<asp:LinkButton ToolTip="Click here to see transaction history" id="btnDue" PostBackUrl="~/Teacher/TransactionHistory" runat="server" Width="280px" />
									</div>
								</div>


								<br />

								<div class="form-group">
									<asp:Label Text="Select Type" AssociatedControlID="ddlType" runat="server"
										CssClass="col-md-3 control-label" />
									<div class="col-md-9">
										<asp:DropDownList ID="ddlType" CssClass="form-control" runat="server" DataTextField="Text"
											DataValueField="Value">
										</asp:DropDownList>
									</div>
								</div>
								<br />
								<div class="form-group">
									<asp:Label Text="Amount" AssociatedControlID="txtAmount" runat="server" CssClass="col-md-3 control-label" />
									<div class="col-md-9">
										<asp:TextBox ID="txtAmount" CssClass="form-control" placeholder="Ammount of Payment"
											TextMode="Number" runat="server">
										</asp:TextBox>
									</div>
								</div>
								<br />
								<div class="form-group">
									<div class="col-md-offset-3 col-md-9">
										<asp:Button Text="Pay" ID="btnPay" CssClass="btn btn-primary" runat="server" OnClick="btnPay_Click" />
									</div>
								</div>
							</div>
						</div>
					</div>
				</ContentTemplate>
			</asp:UpdatePanel>
		</div>
		<%--<div class="col-md-7">
			<div class="panel panel-primary">
				<p class="panel-heading">Students With Due</p>

				<div class="panel-body">
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div class="col-md-12 col-lg-12">
								<div class="col-lg-6 col-md-12">

									<div class="from-horiontal">
										<div class="col-md-12">
											<div class="form-group">
												<label for="ddlClassDue" class="col-md-12 control-label">Class</label>
												<div class="col-md-12">
													<asp:DropDownList DataTextField="Text" DataValueField="Value" runat="server" ID="ddlClassDue"
														AutoPostBack="true" OnSelectedIndexChanged="LoadSectionDue" CssClass="form-control">
													</asp:DropDownList>
												</div>
											</div>
											<br />
											<div class="form-group">
												<label for="ddlSectionDue" class="col-md-12 control-label">Section</label>
												<div class="col-md-12">
													<asp:DropDownList DataTextField="Text" DataValueField="Value" runat="server" ID="ddlSectionDue"
														OnSelectedIndexChanged="LoadCBL" AutoPostBack="true" CssClass="form-control">
													</asp:DropDownList>
												</div>
											</div>
											<br />
											<div class="form-group">
												<div class="col-md-12">
													<asp:TextBox ID="txtDueGreaterThen" TextMode="Search" placeholder="Due greater than"
														CssClass="form-control" runat="server">
													</asp:TextBox>
												</div>
											</div>
											<div class="form-group">
												<div class="col-md-12">
													<asp:Button Text="Search" ID="btnSearch" OnClick="LoadCBL" CssClass="btn btn-primary"
														runat="server" />
												</div>
											</div>
										</div>
									</div>

								</div>
								<div class="col-lg-6 col-md-12">
									<asp:CheckBoxList runat="server" ID="cblDue" CssClass="checkbox" DataTextField="Text"
										DataValueField="Value">
									</asp:CheckBoxList>
								</div>
							</div>
						</ContentTemplate>
					</asp:UpdatePanel>
					<hr />
					<h2 class="text-info text-center" id="hSuccess" runat="server">Selected students are
						notified</h2>
					<div class="col-md-12">
						<asp:Button Text="Create Group" ID="btnCreateGroup" OnClientClick="alert('Not implemented yet')"
							CssClass="btn btn-primary" runat="server" />
						<asp:Button Text="Notify" ID="btnNotify" CssClass="btn btn-primary" runat="server"
							OnClick="btnNotify_Click" />
					</div>
				</div>

			</div>
		</div>--%>
	</div>
</asp:Content>

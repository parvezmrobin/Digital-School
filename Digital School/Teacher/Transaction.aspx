<%@ Page Title="Transaction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Transaction.aspx.cs" Inherits="Digital_School.Teacher.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="col-md-6">

			<asp:UpdatePanel runat="server">
				<ContentTemplate>
					<div class="form-horizontal">
						<br />
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-3 control-label" />
							<div class="col-md-9">
								<asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Section" AssociatedControlID="ddlSection" runat="server"
								CssClass="col-md-3 control-label" />
							<div class="col-md-9">
								<asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Student" AssociatedControlID="ddlStudent" runat="server"
								CssClass="col-md-3 control-label" />
							<div class="col-md-9">
								<asp:DropDownList ID="ddlStudent" CssClass="form-control" runat="server">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Due" AssociatedControlID="lblDue" runat="server"
								CssClass="col-md-3 control-label" />
							<div class="col-md-9">
								<asp:Label ID="lblDue" CssClass="form-control" runat="server">
								</asp:Label>
							</div>
						</div>
					</div>
				</ContentTemplate>
			</asp:UpdatePanel>
			<div class="panel panel-primary">
				<p class="panel-heading">Payment</p>
				<div class="panel-body">
					<br />
					<div class="form-horizontal">
						<div class="form-group">
							<asp:Label Text="Amount" AssociatedControlID="txtAmount" runat="server" CssClass="col-md-3 control-label" />
							<div class="col-md-9">
								<asp:TextBox ID="txtAmount" CssClass="form-control" runat="server">
								</asp:TextBox>
							</div>
						</div>
					</div>
					<asp:Button Text="Pay" ID="btnPay" CssClass="btn btn-primary" runat="server" />
				</div>
			</div>
		</div>
		<div class="col-md-6">
			<br />
			<div class="panel panel-primary">
				<p class="panel-heading">Students With Due</p>
				<div class="panel-body">
					<div class="col-lg-6 col-md-12 list-group" runat="server" id="divDueStudentName">
					</div>
					<div class="col-lg-6 col-md-12">
						<br />
						<div class="col-md-12">
							<div class="from-horiontal">
								<div class="form-group">
									<asp:Label Text="Due Greater Than" AssociatedControlID="txtDueGreaterThen" runat="server"
										CssClass="col-md-12 control-label" />
									<div class="col-md-12">
										<asp:TextBox ID="txtDueGreaterThen" TextMode="Search" CssClass="form-control" runat="server">
										</asp:TextBox>

									</div>
								</div>
							</div>
						</div>
						<div class="col-md-12">
							<asp:Button Text="Search" ID="btnSearch" CssClass="btn btn-primary" runat="server" />
						</div>
						<hr />
						<div class="col-md-12">
							<asp:Button Text="Create Group" ID="btnCreateGroup" CssClass="btn btn-primary" runat="server" />
							<asp:Button Text="Notify" ID="btnNotify" CssClass="btn btn-primary" runat="server" />
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

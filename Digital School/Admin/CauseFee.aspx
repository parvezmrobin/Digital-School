<%@ Page Title="Cause Fee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="CauseFee.aspx.cs" Inherits="Digital_School.Admin.CauseFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminCauseFee').attr('class', 'active');

			$('#<%: hSuccess.ClientID %>').delay(5000).fadeOut(1000);
		})
	</script>
	<div class="visible-sm">
		<br />
		<br />
	</div>
	<div class="row">
		<h2 class="text-success text-center" id="hSuccess" runat="server"></h2>
		<div class="panel panel-primary col-md-6 col-md-offset-3 col-sm-10 col-sm-offset-1"
			style="border-width: 2px">
			<h2 class="text-center panel-heading">Cause Fee</h2>
			<div class="panel-body form-horizontal">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" CssClass="col-sm-4 control-label"
								runat="server" />
							<div class="col-sm-8">
								<asp:DropDownList runat="server" ID="ddlClass" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadDDLSection">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label Text="Select Section" AssociatedControlID="ddlSection" CssClass="col-sm-4 control-label"
								runat="server" />
							<div class="col-sm-8">
								<asp:DropDownList runat="server" ID="ddlSection" DataTextField="Text" DataValueField="Value"
									CssClass="form-control">
								</asp:DropDownList>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Type" AssociatedControlID="ddlType" CssClass="col-sm-4 control-label"
						runat="server" />
					<div class="col-sm-8">
						<asp:DropDownList runat="server" ID="ddlType" DataTextField="Text" DataValueField="Value"
							CssClass="form-control">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Amount" AssociatedControlID="txtAmount" CssClass="col-sm-4 control-label"
						runat="server" />
					<div class="col-sm-8">
						<asp:TextBox style="max-width:280px" runat="server" ID="txtAmount" TextMode="Number" placeholder="Amount of money"
							CssClass="form-control">
						</asp:TextBox>
					</div>
				</div>
				<div class="panel-footer form-group">
					<div class="col-sm-offset-4 col-sm-8">
						<asp:Button Text="Cause" ID="btnCauseFee" CssClass="btn btn-danger" 
							runat="server" OnClick="btnCauseFee_Click" />
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

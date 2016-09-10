<%@ Page Title="Notification" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="Digital_School.Teacher.Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		input.form-control {
			max-width: none;
		}

		select.form-control {
			max-width: 280px;
		}

		textarea.form-control {
			min-height: 300px;
			max-width: none;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$("#<%:divSuccessful.ClientID%>").delay(5000).fadeOut(1000);
		});
	</script>
	<br />
	<div class="row">
		<h2 class="text-info" style="text-align: center">Push Notification</h2>
		<hr />
		<h3 runat="server" class="text-success" style="text-align: center" id="divSuccessful">
			Your notification '<span id="notificatinName" runat="server"></span>' is sent to
			members of group '<span id="groupName" runat="server"></span>'.
		</h3>

		<div class="col-md-6 panel panel-info">
			<h3 class="panel-heading">Subject and Group</h3>
			<div class="form-horizontal panel-body">
				<div class="form-group">
					<asp:Label Text="Subject" AssociatedControlID="txtSubject" runat="server" CssClass="col-md-3 control-label" />
					<div class="col-md-9">
						<asp:TextBox ID="txtSubject" CssClass="form-control" runat="server">
						</asp:TextBox>
						<asp:RequiredFieldValidator ErrorMessage="Subject cannot be empty" CssClass="text-danger"
							ControlToValidate="txtSubject"
							runat="server" />
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="To" AssociatedControlID="ddlTo" runat="server" CssClass="col-md-3 control-label" />
					<div class="col-md-9">
						<asp:DropDownList ID="ddlTo" CssClass="form-control" runat="server" DataTextField="Text"
							DataValueField="Value">
						</asp:DropDownList>
					</div>
				</div>
				<br />
			</div>
		</div>
		<div class="col-md-6 panel panel-primary">
			<h3 class="panel-heading">Notification Detail</h3>
			<div class="panel-body">
				<asp:TextBox runat="server" ID="txtDetail" CssClass="form-control" TextMode="MultiLine" />
				<br />
				<asp:Button Text="Push" CssClass="btn btn-primary" ID="btnPush" runat="server" OnClick="btnPush_Click" />
			</div>
		</div>
	</div>
</asp:Content>

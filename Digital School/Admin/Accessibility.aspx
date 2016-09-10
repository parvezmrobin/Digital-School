<%@ Page Title="Accessibility" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true"
	CodeBehind="Accessibility.aspx.cs" Inherits="Digital_School.Admin.Accessibility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminAccessibility').attr('class', 'active');
			var id = '#<%:hInfo.ClientID %>';
			$(id).delay(5000).fadeOut(1000);
		});
	</script>

	<div class="row">
		<h2 class="text-info" style="text-align: center">Transaction Accessibility</h2>
		<hr />
		<div class="panel panel-info">
			<p class="panel-heading" style="font-size: xx-large; text-align: center">
				Choose Teacher
			</p>
			<div class="panel body">
				<h3 runat="server" id="hInfo" style="text-align: center"></h3>
				<div class="form-horizontal">
					<div class="form-group">
						<asp:Label Text="Select Teacher" AssociatedControlID="ddlTeacher" runat="server"
							CssClass="col-md-4 col-sm-6 control-label" />
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlTeacher" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
								CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTeacher_SelectedIndexChanged">
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
					<br />
					<div class="form-group">
						<asp:Label Text="Can Transact" AssociatedControlID="ddlTransact" runat="server"
							CssClass="col-md-4 col-sm-6 control-label" />
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlTransact" DataTextField="Text" DataValueField="Value"
								AutoPostBack="true"
								CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlTransact_SelectedIndexChanged">
								<asp:ListItem Text="Yes" Value="1" />
								<asp:ListItem Text="No" Value="0" />
							</asp:DropDownList>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

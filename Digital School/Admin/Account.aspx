<%@ Page Title="Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Account.aspx.cs" Inherits="Digital_School.Admin.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminAccount').attr('class', 'active');
			$('.text-success').delay(5000).fadeOut(1000);
			$('.text-danger').delay(5000).fadeOut(1000);
		});
	</script>
	<style type="text/css">
		input.form-control{
			max-width:280px;
		}
	</style>
	<br />
	<div class="row">
		<div class="col-md-6 panel panel-info" style="border:none">
			<p class="panel-heading" style="font-size: xx-large">Teacher Account</p>
			<h3 class="text-success" id="success1" runat="server">Teacher designation updated successfully.
			</h3>
			<div class="panel-body">
				<div class="form-horizontal">
					<div class="form-group">
						<asp:Label Text="Select Teacher" AssociatedControlID="ddlTeacher" runat="server"
							CssClass="col-md-4 col-sm-6 control-label" />
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlTeacher" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
								CssClass="form-control" runat="server" OnSelectedIndexChanged="ChangeDDLDesignationAsDDLTeacher">
							</asp:DropDownList>
						</div>
					</div>
					<br />
					<div class="form-group">
						<asp:Label Text="Select Designation" AssociatedControlID="ddlDesignation" runat="server"
							CssClass="col-md-4 col-sm-6 control-label" />
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlDesignation" DataTextField="Text" DataValueField="Value"
								AutoPostBack="true"
								CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
							</asp:DropDownList>
						</div>
					</div>

				</div>
			</div>
		</div>
		<div class="col-md-6 panel panel-info" style="border:none">
			<p class="panel-heading" style="font-size: xx-large">Student Account</p>
			<div class="panel-body">
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
								CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" runat="server">
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
						<asp:Label Text="Select Student" AssociatedControlID="ddlStudent" runat="server"
							CssClass="col-md-4 col-sm-6 control-label" />
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlStudent" DataTextField="Text" DataValueField="Value"
								AutoPostBack="true"
								CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
							</asp:DropDownList>
						</div>
					</div>
					
					<h4 class="text-danger" runat="server" id="info">
						Inputed Class & Section must exist in running year.
					</h4>
					<h3 class="text-success" id="success2" runat="server">
						Student information updated successfully.
					</h3>
					<hr />
					<%-- Text Boxes for updating info --%>
                   
					<div class="form-group">
						<label for="ddlToClass" class="col-md-4 col-sm-6 control-label text-static">
							Class
						</label>
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlToClass" CssClass="form-control" runat="server" DataTextField="Text"
								DataValueField="Value" AutoPostBack="true" OnSelectedIndexChanged="LoadDDLToSection"></asp:DropDownList>
						</div>
					</div>
					<br />
					<div class="form-group">
						<label for="ddlSection" class="col-md-4 col-sm-6 control-label text-static">
							Section
						</label>
						<div class="col-md-8 col-sm-6">
							<asp:DropDownList ID="ddlToSection" CssClass="form-control" runat="server" DataTextField="Text"
								DataValueField="Value"></asp:DropDownList>
						</div>
					</div>
					<br />
					<div class="form-group">
						<label for="txtRoll" class="col-md-4 col-sm-6 control-label text-static">
							Roll
						</label>
						<div class="col-md-8 col-sm-6">
							<asp:TextBox ID="txtRoll" placeholder="Roll of Student" CssClass="form-control" runat="server"
								TextMode="Number" min="1"></asp:TextBox>
						</div>
					</div>
					<div class="form-group">
						<div class="col-md-offset-4 col-sm-offset-6 col-md-8 col-sm-6">
							<asp:Button Text="Apply" CssClass="btn btn-success"
								runat="server" ID="btnApply" Font-Size="Large" OnClick="btnApply_Click" />

						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
</asp:Content>

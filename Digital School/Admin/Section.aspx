<%@ Page Title="Section Management" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true"
	CodeBehind="Section.aspx.cs" Inherits="Digital_School.Admin.Section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminSection').attr('class', 'active');
		})
	</script>
	<div class="row">
		<div class="visible-sm">
			<br />
			<br />
		</div>
		<div class="panel panel-primary col-md-6 form-horizontal" style="border: none">
			<h2 class="panel-heading text-center">Overview</h2>
			<div class="panel-body">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlYear" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadDDLClass">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlClass" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadGVSection">
								</asp:DropDownList>
							</div>
						</div>
						<div class="from-group">
							<asp:GridView runat="server" ID="gvSection" CssClass="table table-striped table-hover" AutoGenerateColumns="false">
								<Columns>
									<asp:BoundField HeaderText="Level" DataField="Value" />
									<asp:BoundField HeaderText="Label" DataField="Text" />
								</Columns>
							</asp:GridView>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>
		<div class="panel panel-primary col-md-6 form-horizontal" style="border: none">
			<h2 class="text-center panel-heading">Assign Section</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:CheckBoxList runat="server" ID="cbSection" DataTextField="Text" DataValueField="Value" RepeatDirection="Horizontal" CssClass="table" RepeatColumns="5">
					</asp:CheckBoxList>
				</div>
				<div class="form-group">
					<asp:Button Text="Assign" ID="btnAssign" ToolTip="Assign selected section(s) to selected class" OnClick="btnAssign_Click"
						CssClass="btn btn-default" runat="server" OnClientClick="return confirm('Are you sure to assign selected section(s) to selected class?');" />
				</div>
			</div>
			
		</div>
	</div>
</asp:Content>

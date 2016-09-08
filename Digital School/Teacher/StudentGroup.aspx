<%@ Page Title="Student Group" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="StudentGroup.aspx.cs" Inherits="Digital_School.Teacher.StudentGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		input.form-control {
			max-width: none;
		}

		select.form-control {
			max-width: 280px;
		}
	</style>
	<br />
	<div class="row">
		<div class="form-horizontal">
			<div class="form-group">
				<label for="txtGroupName" class="col-md-4 col-sm-6 control-label text-static">
					Create New Group
				</label>
				<div class="col-md-6 col-sm-4">
					<asp:TextBox ID="txtGroupName" ToolTip="Group Name" CssClass="form-control" runat="server"
						TextMode="SingleLine"></asp:TextBox>
				</div>
				<asp:Button Text="Create" CssClass="btn btn-default col-md-2 col-sm-2"
					ID="btnCreateGroup" OnClick="btnCreateGroup_Click" runat="server" />
			</div>
		</div>
		<hr />
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="form-horizontal">
					<br />
					<div class="form-group">
						<asp:Label Text="Select Group" AssociatedControlID="ddlGroup" runat="server"
							CssClass="col-md-4 col-sm-6 control-label" />
						<div class="col-md-6 col-sm-4">
							<asp:DropDownList DataTextField="Text" DataValueField="Value" ID="ddlGroup" AutoPostBack="true"
								CssClass="form-control" OnSelectedIndexChanged="LoadCBRemove" runat="server">
							</asp:DropDownList>
						</div>
						<asp:Button Text="Remove" CssClass="btn btn-danger col-md-2 col-sm-2"
							ID="btnRemoveGroup" OnClick="btnRemoveGroup_Click" ToolTip="Remove selected group"
							runat="server" />
					</div>
					<hr />
					<br />
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-6 panel panel-danger">
					<h2 style="text-align: center" class="panel-heading">Remove Group Member</h2>
					
						<div class="form-horizontal panel-body">
							<asp:CheckBoxList ID="cbRemove" runat="server" DataTextField="Text" DataValueField="Value">
							</asp:CheckBoxList>
							<asp:Button Text="Remove" ToolTip="Romove selected students" ID="btnRemove" CssClass="btn btn-danger"
								Style="float: right" runat="server" OnClick="btnRemove_Click" />
						</div>
						
					
				</div>
				<div class="col-md-6 panel panel-success">
					<h2 style="text-align: center" class="panel-heading">Add Group Member</h2>
					<div class="panel-body">

						<div class="form-horizontal">
							<div class="form-group">
								<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 col-sm-6 control-label" />
								<div class="col-md-8 col-sm-6">
									<asp:DropDownList ID="ddlClass" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
										CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
									</asp:DropDownList>
								</div>
							</div>
							<br />
							<div class="form-group">
								<asp:Label Text="Select Section" AssociatedControlID="ddlSection" runat="server"
									CssClass="col-md-4 col-sm-6 control-label" />
								<div class="col-md-8 col-sm-6">
									<asp:DropDownList ID="ddlSection" DataTextField="Text" DataValueField="Value" AutoPostBack="true"
										CssClass="form-control" runat="server" OnSelectedIndexChanged="LoadCBAdd">
									</asp:DropDownList>
								</div>
							</div>
						</div>
						<hr />
						<div class="form-horizontal">
							<asp:CheckBoxList ID="cbAdd" runat="server" DataTextField="Text" DataValueField="Value">
							</asp:CheckBoxList>
							<asp:Button Text="Add" OnClick="btnAdd_Click" ToolTip="Add selected students" ID="btnAdd"
								CssClass="btn btn-success"
								Style="float: right" runat="server" />
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>

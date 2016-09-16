<%@ Page Title="Edit Student Account" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="Digital_School.Teacher.EditStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h1 class="text-info" style="text-align:center"><%:Title %></h1>
		<hr />
		<div class="col-md-6 panel panel-primary">
			<h2 class="panel-heading">Select Student</h2>
			<div class="form-horizontal panel-body">
				<br />
				<div class="form-group">
					<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 col-sm-6 control-label" />
					<div class="col-md-8 col-sm-6">
						<asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server" DataTextField="Text"
							DataValueField="Value" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Section" AssociatedControlID="ddlSection" runat="server"
						CssClass="col-md-4 col-sm-6 control-label" />
					<div class="col-md-8 col-sm-6">
						<asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server" DataTextField="Text"
							DataValueField="Value" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged"
							AutoPostBack="true">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Student" AssociatedControlID="ddlStudent" runat="server"
						CssClass="col-md-4 col-sm-6 control-label" />
					<div class="col-md-8 col-sm-6">
						<asp:DropDownList ID="ddlStudent" CssClass="form-control" runat="server" DataTextField="Text"
							DataValueField="Value" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"
							AutoPostBack="true">
						</asp:DropDownList>
					</div>
				</div>
				<asp:Button Text="Delete" CssClass="btn btn-danger btn-lg"
					runat="server" ID="btnDelete" Style="float: right" />
			</div>
			
		</div>
		<div class="col-md-6 panel panel-info">
			<h2 class="panel-heading">Edit Student Info</h2>
			<br />
			<h4 class="text-info" runat="server" id="info">Inputed Class & Section must exist in running year.</h4>
			<div class="form-horizontal panel-body">
				<div class="form-group">
					<label for="txtClass" class="col-md-4 col-sm-6 control-label text-static">
						Class
					</label>
					<div class="col-md-8 col-sm-6">
						<asp:TextBox ID="txtClass" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
					</div>
				</div>
				<br />
				<div class="form-group">
					<label for="txtSection" class="col-md-4 col-sm-6 control-label text-static">
						Section
					</label>
					<div class="col-md-8 col-sm-6">
						<asp:TextBox ID="txtSection" CssClass="form-control" runat="server" TextMode="Number" style="max-width:none"></asp:TextBox>
					</div>
				</div>
				<br />
				<div class="form-group">
					<label for="txtRoll" class="col-md-4 col-sm-6 control-label text-static">
						Roll
					</label>
					<div class="col-md-8 col-sm-6">
						<asp:TextBox ID="txtRoll" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
					</div>
				</div>
				<asp:Button Text="Apply" CssClass="btn btn-success btn-lg"
					runat="server" ID="btnApply" style="float:right" OnClick="btnApply_Click" />
			</div>
			
		</div>
		
	</div>
</asp:Content>

<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Attendance.aspx.cs" Inherits="Digital_School.Teacher.Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:UpdatePanel runat="server">
		<ContentTemplate>
			<div class="row">
				<div class="panel panel-info col-md-6">
					<h2 class="panel-heading">Select class and/or section</h2>
					<div class="panel-body">
						<div class="form-horizontal panel-body">
							<div class="form-group">
								<asp:Label Text="Select Class" AssociatedControlID="ddlClass" runat="server" CssClass="col-md-4 col-sm-6 control-label" />
								<div class="col-md-8 col-sm-6">
									<asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server" DataTextField="Text"
										DataValueField="Value" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
										AutoPostBack="true">
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
						</div>
					</div>
				</div>
				<div class="panel panel-primary col-md-6">
					<h2 class="panel-heading">Attendance</h2>
					<div class="panel-body">
						<asp:CheckBoxList runat="server" ID="cbAttendance" DataTextField="Text" DataValueField="Value">
						</asp:CheckBoxList>
						<asp:Button Text="Submit" ID="btnSubmint" CssClass="btn btn-lg btn-success" Style="float: right"
							OnClick="btnSubmint_Click" runat="server" />
					</div>
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>

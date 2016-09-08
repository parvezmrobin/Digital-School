<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="Digital_School.Student.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<br />
		<div class="col-xs-12 btn btn-primary btn-block btn-lg text-left">
			<h1 id="postTitle" runat="server" enableviewstate="true">No Notification Selected</h1>
		</div>
		<br />
		<div class="col-xs-12">
			<div class="col-sm-9 well" id="postBody" runat="server" style="text-align: justify"
				enableviewstate="true">
			</div>
			<div id="PostList" runat="server" class="list-group col-sm-3" style="overflow-y: scroll">
			</div>

		</div>
	</div>
</asp:Content>

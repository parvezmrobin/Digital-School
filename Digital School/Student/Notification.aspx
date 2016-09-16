<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Notification.aspx.cs" Inherits="Digital_School.Student.Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		function clientConfirm() {
			return confirm("Are sure to delete this notification?");			
		}
	</script>
	<div class="row">
		<br />
		<div class="col-xs-12 panel panel-primary">
			<h1 id="postTitle" runat="server" class="panel-heading" enableviewstate="true">No Notification Selected
			</h1>
			<h3 runat="server" id="pushedBy" class="text-info" style="text-align:right"></h3>
		</div>
		<br />
		<div class="col-xs-12">
			<div id="PostList" runat="server" class="list-group col-md-4" style="overflow-y: scroll">
			</div>		
			<div class="col-md-8">				
				<div class="well" id="postBody" runat="server" style="text-align: justify;"
					enableviewstate="true">
				</div>
				<hr />
				<asp:Button Text="Remove" ToolTip="Remove selected notification" ID="btnDelete" OnClick="Unnamed_Click"
					CssClass="btn btn-danger" OnClientClick="return clientConfirm()" style="float:right" runat="server" />
			</div>
			
		</div>
	</div>
</asp:Content>

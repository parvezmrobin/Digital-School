<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="AskQuestion.aspx.cs" Inherits="Digital_School.Student.AskQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function() {
			$("#<%:divSuccess.ClientID%>").delay(5000).fadeOut(1000);
			});
	</script>
	<div class="row">
		<br />
		<h2 class="text-primary hidden-xs" style="text-align: center">Ask question to teachers
		</h2>
		<br />
		<div style="text-align: center" runat="server" id="divSuccess">
			<h3 class="text-success">Your question '<span runat="server" id="spanQuestion"></span>'
				has asked to '<span runat="server" id="spanTo"></span>' successfully.
			</h3>
			<h4 class="text-info">You will get a notification when you are answered.</h4>
		</div>
		<div class="form-horizontal">

			<div class="form-group col-sm-8">
				<asp:Label Text="Subject" AssociatedControlID="txtSubject" runat="server" CssClass="col-md-2 col-sm-3 control-label" />
				<div class="col-md-10  col-sm-9">
					<asp:TextBox runat="server" ID="txtSubject" CssClass="form-control" TextMode="SingleLine"
						Style="max-width: none" />
					<asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Subject must not be empty."
						ControlToValidate="txtSubject"
						runat="server" />
				</div>

			</div>

			<div class="form-group col-sm-4">
				<asp:Label Text="To" AssociatedControlID="ddlTo" runat="server" CssClass="col-sm-4 control-label" />
				<div class="col-sm-8">
					<asp:DropDownList ID="ddlTo" CssClass="form-control" runat="server">
					</asp:DropDownList>
				</div>

			</div>
		</div>
		<div class="col-sm-12" style="padding: 10px">
			<asp:TextBox ID="txtQuestion" Style="min-height: 300px" CssClass="form-control" TextMode="MultiLine"
				runat="server"></asp:TextBox>
		</div>
		<br />
		<div class="col-sm-12">
			<asp:Button Text="Ask" CssClass="btn btn-primary btn-lg" Style="min-width: 100px;
				float: right"
				runat="server" OnClick="Ask_Click" />
		</div>
	</div>
</asp:Content>

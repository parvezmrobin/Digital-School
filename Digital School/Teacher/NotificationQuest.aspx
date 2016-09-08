<%@ Page Title="Notification & Quests" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true" CodeBehind="NotificationQuest.aspx.cs" Inherits="Digital_School.Teacher.NotificationQuest" %>
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
	<br />
	<div class="row">
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-6">
					<div class="form-horizontal">
						<div class="form-group">
							<asp:Label Text="Subject" AssociatedControlID="txtSubject" runat="server" CssClass="col-md-3 control-label" />
							<div class="col-md-9">
								<asp:TextBox ID="txtSubject" CssClass="form-control" runat="server">
								</asp:TextBox>
								<%--<asp:RequiredFieldValidator ErrorMessage="Subject cannot be empty" CssClass="text-danger"
									ControlToValidate="txtSubject"
									runat="server" />--%>
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
					<h3>Notification Detail</h3>
					<asp:TextBox runat="server" ID="txtDetail" CssClass="form-control" TextMode="MultiLine" />
					<br />
					<asp:Button Text="Push" CssClass="btn btn-primary" ID="btnPush" runat="server" OnClick="btnPush_Click" />
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-6">
					<div class="panel panel-primary">
						<p class="panel-heading">Questions</p>
						<div class="panel-body" runat="server" id="divQuestions"></div>
					</div>
					<textarea runat="server" id="quesBody" enableviewstate="true" class="form-control" disabled="disabled"></textarea>
					<h3>Write Answer</h3>
					<asp:TextBox runat="server" ID="txtAnswer" CssClass="form-control" TextMode="MultiLine" />
					<br />
					<asp:Button Text="Reply" CssClass="btn btn-primary" ID="btnReply"
						runat="server" OnClick="btnReply_Click" />
					<asp:HiddenField ID="hfQuesId" runat="server" EnableViewState="true" />
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>

	</div>
</asp:Content>

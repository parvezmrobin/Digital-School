<%@ Page Title="Answer Quests" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="AnswerQuests.aspx.cs" Inherits="Digital_School.Teacher.AnswerQuests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2 style="text-align: center" class="text-info"><%:Title %></h2>
		<hr />
		<asp:UpdatePanel runat="server">
			<ContentTemplate>
				<div class="col-md-6">
					<div class="panel panel-primary">
						<h3 class="panel-heading">Questions</h3>
						<div class="panel-body ">
							<div class="pre-scrollable" runat="server" id="divQuestions"></div>
							<br />
							<span runat="server" id="quesBody" style="min-height:300px" enableviewstate="true" class="form-control pre-scrollable"
								visible="false"></span>
						</div>
					</div>
					

				</div>
				<div class="col-md-6">
					<div class=" panel panel-primary">
						<h3 class="panel-heading">Write Answer</h3>
						<div class="panel-body">
							<asp:TextBox runat="server" ID="txtAnswer" Style="min-height: 300px" CssClass="form-control"
								TextMode="MultiLine" />
							<h4 id="hAnswered" class="text-info" runat="server" visible="false">This question is
								answered successfully</h4>
							<br />
							<asp:Button Text="Reply" Style="float: right" CssClass="btn btn-primary" ID="btnReply"
								runat="server" OnClick="btnReply_Click" />
							<asp:HiddenField ID="hfQuesId" runat="server" EnableViewState="true" />
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="Digital_School.Images" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="col-xs-12">
			<h2 style="text-align: center"><%:Page.Title %></h2>
		</div>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div class="col-sm-2 col-md-1 hidden-xs">
					<asp:Button OnClick="btnPrev_Click" ID="btnPrev" CssClass="btn btn-primary btn-lg "
						Text="Prev" runat="server" />
				</div>
				<div class="col-xs-12 col-sm-8 col-md-10">
					<img src="#" class="centre-block img-responsive img-thumbnail" id="image"
						runat="server" />
				</div>
				<div class="col-sm-2 col-md-1 hidden-xs">
					<asp:Button OnClick="btnNext_Click" ID="btnNext" CssClass="btn btn-primary btn-lg "
						Text="Next" Style="float: right" runat="server" />
				</div>
				<div>
					<div class="col-xs-6 visible-xs">
						<asp:Button OnClick="btnPrev_Click" ID="Button1" CssClass="btn btn-primary btn-lg "
							Text="Prev" runat="server" />
					</div>
				</div>
				<div class="col-xs-6 visible-xs">
					<asp:Button OnClick="btnNext_Click" ID="Button2" CssClass="btn btn-primary btn-lg "
						Style="float: right" Text="Next" runat="server" />
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>

</asp:Content>

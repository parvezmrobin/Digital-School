<%@ Page Title="Transaction History" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true"
	CodeBehind="TransactionHistory.aspx.cs" Inherits="Digital_School.Student.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<div class="row">
		<div class="col-md-6 panel panel-primary" style="border:none">
			<h2 class="panel-heading text-centre">Payments</h2>
			<div class="panel-body table-responsive">
				<asp:GridView ID="gvDebit" runat="server" CssClass="table table-stripe table-hover"
					Style="border-color: transparent" HeaderStyle-CssClass="text-info" RowStyle-CssClass="success"
					AutoGenerateColumns="false">
					<Columns>
						<asp:BoundField DataField="Date" HeaderText="Date" />
						<asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" />
						<asp:BoundField DataField="Amount" HeaderText="Amount" />
						<asp:BoundField DataField="DoneBy" HeaderText="Done By" />
					</Columns>
				</asp:GridView>
			</div>

		</div>
		<div class="col-md-6 panel panel-primary" style="border:none">
			<h2 class="panel-heading text-centre">Causes</h2>
			<div class="panel-body">
				<asp:GridView ID="gvCredit" runat="server" CssClass="table table-stripe table-hover"
					Style="border-color: transparent" HeaderStyle-CssClass="text-info" RowStyle-CssClass="danger" AutoGenerateColumns="false">
					<Columns>
						<asp:BoundField DataField="Date" HeaderText="Date" />
						<asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" />
						<asp:BoundField DataField="Amount" HeaderText="Amount" />
						
					</Columns>
				</asp:GridView>
			</div>

		</div>
	</div>
</asp:Content>

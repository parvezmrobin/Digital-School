<%@ Page Title="Teachers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="Digital_School.Teachers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="col-md-12">
			<h2>Teachers</h2>
			<asp:GridView AllowSorting="true" CssClass="table table-striped table-hover " ID="gvDetail"
				runat="server" GridLines="Horizontal" AutoGenerateColumns="false">
				<Columns>
					<asp:ButtonField ButtonType="Link" Text="Detail" />
					<asp:BoundField DataField="firstname" HeaderText="First Name" HeaderStyle-CssClass="text-primary" />
					<asp:BoundField DataField="lastname" HeaderText="Last Name" HeaderStyle-CssClass="text-primary" />
					<asp:BoundField DataField="subject" HeaderText="Subject" HeaderStyle-CssClass="text-primary" />
				</Columns>
			</asp:GridView>
		</div>
	</div>
</asp:Content>

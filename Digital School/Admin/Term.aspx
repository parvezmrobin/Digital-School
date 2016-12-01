<%@ Page Title="Term Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Term.aspx.cs" Inherits="Digital_School.Admin.Term" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminTerm').attr('class', 'active');
		})
	</script>
	<div class="row" style="border: 2px solid #428bca; border-radius: 5px">
		<div class="panel panel-info col-md-6 form-horizontal" style="border: none">
			<h2 class="panel-heading text-center">Overview</h2>
			<div class="panel-body">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlYear" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadDDLClass">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlClass" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlClass" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadDDLSection">
								</asp:DropDownList>
							</div>
						</div>
						<div class="form-group">
							<asp:Label Text="Select Section" AssociatedControlID="ddlSection" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlSection" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadGVTerm">
								</asp:DropDownList>
							</div>
						</div>
						<div class="from-group">
							<asp:Label Text="Terms" AssociatedControlID="gvTerm" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8 ">
								<asp:GridView runat="server" ID="gvTerm" BorderColor="Transparent" CssClass="table table-striped table-hover"
									HeaderStyle-CssClass="text-info" AutoGenerateColumns="false" OnRowDeleting="gvTerm_RowDeleting">
									<Columns>
                                        <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
										<asp:BoundField HeaderText="Term" DataField="Text" />
										<asp:BoundField HeaderText="Percentage" DataField="Value" />
                                        <asp:CommandField ShowDeleteButton="true" />
									</Columns>
								</asp:GridView>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>
		<div class="panel panel-success col-md-6 form-horizontal" style="border: none">
			<h2 class="panel-heading text-center">Add Term</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:GridView runat="server" ID="gvAddTerm" BorderColor="Transparent" CssClass="table table-striped table-hover"
						HeaderStyle-CssClass="text-info" AutoGenerateColumns="false">
						<Columns>
							<asp:TemplateField HeaderText="Select">
								<ItemTemplate>
									<asp:CheckBox id="cb" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Term">
								<ItemTemplate>
									<asp:Label Text='<%# Eval("Text") %>' ID="lbl" runat="server" />
									<asp:HiddenField Value='<%# Eval("Value") %>' ID="hf" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Percentage">
								<ItemTemplate>
									<asp:TextBox runat="server" ID="txt" TextMode="Number" CssClass="form-control" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</div>
				<div class="from-group">
                    <ul>
                    <asp:HyperLink NavigateUrl="~/Admin/NewEntry.aspx" runat="server" Text="Add New Term" />
                    </ul>
                    <br />
					<ul>
						<li class="text-danger">Clicking this button will create a new term</li>
					</ul>
				</div>
				<div class="form-group">
					<asp:Button Text="Add" ID="btnAddTerm" CssClass="btn btn-success col-sm-offset-1 col-xs-offset-2"
						ValidationGroup="AddClass" OnClick="btnAddTerm_Click" runat="server" />
				</div>
			</div>
		</div>
	</div>
</asp:Content>

<%@ Page Title="Graphical View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="GraphicalView.aspx.cs" Inherits="Digital_School.Student.GraphicalView" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(window).resize(function () {
			$('chart').height($(window).height() - 20);
		});

		$(window).trigger('resize');
	</script>
	<div class="row">
		<h2 class="text-info text-center"><%:Title %></h2>
		<hr />
		<div class="col-sm-6 col-md-5">
			<div class="form-horizontal">
				<br />
				<div class="form-group">
					<asp:Label Text="Select Year" AssociatedControlID="ddlYear" runat="server" CssClass="col-md-4 control-label" />
					<div class="col-md-8">
						<asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server" OnSelectedIndexChanged="LoadDDLTerm"
							AutoPostBack="true" DataTextField="Text" DataValueField="Value">
						</asp:DropDownList>

					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Term" AssociatedControlID="ddlTerm" runat="server"
						CssClass="col-md-4 control-label" />
					<div class="col-md-8">
						<asp:DropDownList ID="ddlTerm" CssClass="form-control" runat="server" OnSelectedIndexChanged="ReloadChart"
							AutoPostBack="true" DataTextField="Text" DataValueField="Value">
						</asp:DropDownList>

					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label Text="Select Subject" AssociatedControlID="ddlSubject"
						runat="server"
						CssClass="col-md-4 control-label" />
					<div class="col-md-8">
						<asp:DropDownList ID="ddlSubject" CssClass="form-control" OnSelectedIndexChanged="ReloadChart"
							runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value">
							
						</asp:DropDownList>
					</div>
				</div>
			</div>
		</div>

		<div id="chart" class="col-sm-6 col-md-7">

			<asp:Chart ID="Chart1" runat="server" Width="500px" Height="500px" CssClass="img img-resposive img-thumbnail">
				<ChartAreas>
					<asp:ChartArea Name="ChartArea1">
					</asp:ChartArea>
				</ChartAreas>
			</asp:Chart>
		</div>
	</div>
</asp:Content>

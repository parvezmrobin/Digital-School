<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GraphicalView.aspx.cs" Inherits="Digital_School.Student.GraphicalView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(window).resize(function () {
			$('chart').height($(window).height() - 20);
		});

		$(window).trigger('resize');
	</script>
	<br />
	<div class="row">
		<div class="col-sm-5 col-md-4">
			<div class="form-horizontal">
				<div class="form-group">
					<asp:Label Text="Select Exam" AssociatedControlID="ddlExam" runat="server" CssClass="col-sm-5 control-label" />
					<div class="col-sm-7">
						<asp:DropDownList ID="ddlExam" CssClass="form-control" runat="server">
							<asp:ListItem Text="All" Value="All"></asp:ListItem>
						</asp:DropDownList>
					</div>
				</div>
				<hr />
				<h3 class="text-static" style="text-align: center">Time Span</h3>
				<div class="form-group">
					<asp:Label Text="Select Exam" AssociatedControlID="ddlExam" runat="server" CssClass="col-sm-5 control-label" />
					<div class="col-sm-7">
						<asp:TextBox ID="txtFrom" CssClass="form-control" TextMode="Date" runat="server">
						</asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<asp:Label Text="Select Exam" AssociatedControlID="ddlExam" runat="server" CssClass="col-sm-5 control-label" />
					<div class="col-sm-7">
						<asp:TextBox ID="txtTo" CssClass="form-control" TextMode="Date"
							runat="server">
						</asp:TextBox>
					</div>
				</div>
			</div>
		</div>
		
		<div id="chart" class="col-sm-7 col-md-8">
			<%--<asp:Chart ID="Chart1" runat="server" Style="height: inherit; width: inherit">
				<Series>
					<asp:Series Name="Series1" ChartType="SplineArea" YValuesPerPoint="1">
						<Points>
							<asp:DataPoint AxisLabel="1st Term" YValues="50,0" />
							<asp:DataPoint AxisLabel="2nd Term" YValues="40,0" />
							<asp:DataPoint AxisLabel="3rd Term" YValues="80,0" />
						</Points>
					</asp:Series>
				</Series>
				<ChartAreas>
					<asp:ChartArea Name="ChartArea1"></asp:ChartArea>
				</ChartAreas>
			</asp:Chart>--%>
		</div>
	</div>
</asp:Content>

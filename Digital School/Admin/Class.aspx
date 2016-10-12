<%@ Page Title="Class Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Class.aspx.cs" Inherits="Digital_School.Admin.Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminClass').attr('class', 'active');
		})

		function emptyStringCheck(scr, e) {
			if ($(this).val() == '')
				return false;
			else
				return true;
		}

		<%--function confirmCreateClass(src, e) {
			return confirm('Are you sure to create a new class with name \'' + $('#<%: txtLabel.ClientID %>').val() + '\' and level \'' + $('#<%: txtLevel.ClientID %>').val() + '\'?');
		}--%>
	</script>
	<div class="visible-sm">
		<br />
		<br />
	</div>

	<div class="row" style="border: 2px solid skyblue; border-radius: 5px 5px">

		<%-- Year & Class --%>

		<h2 class="text-center text-info">Classes According to Year</h2>
		<div id="yealyOverview" class="panel panel-info col-md-6" style="border: none">
			<p style="font-size: xx-large" class="panel-heading">Overview</p>
			<div class="panel-body form-horizontal">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" DataTextField="Text"
									DataValueField="Value" AutoPostBack="true" OnSelectedIndexChanged="LoadGVDDLExistingClass">
								</asp:DropDownList>
							</div>
						</div>
						<br />

						<div class="form-group">
							<asp:GridView runat="server" ID="gvExistingClass" BorderColor="Transparent" Caption='<span class="text-info" style="font-size:xx-large">Classes</span>'
								AutoGenerateColumns="false" HeaderStyle-CssClass="text-info"
								CssClass="table table-striped table-hover">
								<Columns>
									<asp:BoundField HeaderText="Level" DataField="Value" />
									<asp:BoundField HeaderText="Label" DataField="Text" />
								</Columns>
							</asp:GridView>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>
		<div id="addClass" class="panel panel-primary col-md-6" style="border: none">
			<p style="font-size: xx-large" class="panel-heading">Assign Class & Section</p>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:Label Text="Select Class" AssociatedControlID="ddlClass" CssClass="control-label col-md-4"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlClass" DataTextField="Text" DataValueField="Value"
							CssClass="form-control">
						</asp:DropDownList>
					</div>
				</div>
				<div class="form-group">
					<label class="control-text">Select One or More Sections</label>
					<asp:CheckBoxList runat="server" ID="cbSection" DataTextField="Text" DataValueField="Value"
						RepeatDirection="Horizontal" CssClass="table" RepeatColumns="5" title="Select Sections" >
					</asp:CheckBoxList>
					<%--<asp:CustomValidator ErrorMessage="A class must contain at least one section" Display="Dynamic"
						CssClass="text-danger" ControlToValidate="cbSection" runat="server" OnServerValidate="Unnamed_ServerValidate" />--%>
				</div>

			</div>
			<div class="panel-footer form-horizontal">
				<div class="form-group">
					<asp:Button Text="Assign" ID="btnAssignClass" OnClick="btnAssignClass_Click" ToolTip="Assign selected section(s) to selected class"
						CssClass="btn btn-default" runat="server" OnClientClick="return confirm('Are you sure to assign selected class and section[s] to selected year?');" />
				</div>
			</div>
		</div>
	</div>
	<br />
	<div class="row" style="border: 2px solid skyblue; border-radius: 5px 5px">
		<%-- Class & Section --%>

		<h2 class="text-center text-info">Sections According to Class</h2>
		<div id="ClassWiseOverview" class="panel panel-info col-md-6" style="border: none">
			<p style="font-size: xx-large" class="panel-heading">Overview</p>
			<div class="panel-body form-horizontal">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Class" AssociatedControlID="ddlExistingClass" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlExistingClass" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadGVExistingSection">
								</asp:DropDownList>
							</div>
						</div>
						<div class="from-group">
							<asp:GridView runat="server" ID="gvExistingSection" BorderColor="Transparent" CssClass="table table-striped table-hover"
								AutoGenerateColumns="false" HeaderStyle-CssClass="text-info" Caption='<span class="text-info" style="font-size:xx-large">Sections</span>'>
								<Columns>
									<asp:BoundField HeaderText="Serial" DataField="Value" />
									<asp:BoundField HeaderText="Label" DataField="Text" />
								</Columns>
							</asp:GridView>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>
		<div id="addSection" class="panel panel-primary col-md-6" style="border: none">
			<p style="font-size: xx-large" class="panel-heading">
				Assign Section to Selected Class
			</p>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<label class="control-text">Select One or More Sections</label>

					<asp:CheckBoxList runat="server" ID="cbSection2" DataTextField="Text" DataValueField="Value"
						RepeatDirection="Horizontal" CssClass="table" RepeatColumns="5" caption="Select Sections">
					</asp:CheckBoxList>
				</div>

			</div>
			<div class="panel-footer form-horizontal">
				<div class="form-group">
					<asp:Button Text="Assign" ID="btnAssignSection" ToolTip="Assign selected section(s) to selected class"
						OnClick="btnAssignSection_Click"
						CssClass="btn btn-default" runat="server" OnClientClick="return confirm('Are you sure to assign selected section[s] to selected class?');" />
				</div>
			</div>
		</div>

	</div>



	<%--<div class="panel panel-primary col-md-6" style="border: none">
			<h2 class="panel-heading text-center">Overview</h2>
			<div class="panel-body form-horizontal">
				
			</div>
			<h2 class="panel-heading text-center">Add Year</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<div class="col-md-8">
						<asp:TextBox runat="server" ID="txtYear" CssClass="form-control" placeholder="Write Year to be added"
							TextMode="Number">
						</asp:TextBox>
					</div>
					<div class="col-md-4">
						<asp:Button Text="Add Year" ID="btnYear" OnClick="btnYear_Click" OnClientClick="emptyStringCheck"
							CssClass="btn btn-success" runat="server" />
					</div>
				</div>
			</div>
		</div>
		<div class="panel panel-primary col-md-6" style="border: none">
			<h2 class="text-center panel-heading">Assign Class &amp; Section</h2>
			<div class="panel-body form-horizontal">
			</div>
			<h2 class="text-center panel-heading">Create Class</h2>
			
		</div>--%>
	</div>
</asp:Content>

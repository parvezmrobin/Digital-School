<%@ Page Title="Subject Management" Language="C#" MasterPageFile="~/Site.Master"
	AutoEventWireup="true"
	CodeBehind="Subject.aspx.cs" Inherits="Digital_School.Admin.Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style type="text/css">
		input[type="submit"] {
			min-width: 100px;
		}

		.panel-body{
			border: 2px solid #428bca; 
			border-radius: 0px 0px 5px 5px;
		}
		.panel{
			border: none;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminSubject').attr('class', 'active');
		})
	</script>
	<div class="row">
		
		<div class="panel panel-primary col-md-6 form-horizontal" >
			<h2 class="panel-heading text-center">Overview</h2>
			<div class="panel-body" >
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Year" AssociatedControlID="ddlYear" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlYear" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="SelectedYearChanged">
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
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadGVDDLExistingSubject">
								</asp:DropDownList>
							</div>
						</div>
						<div class="panel-footer from-group">
							<asp:GridView runat="server" ID="gvSubject" BorderColor="Transparent" Caption='<span class="text-info" style="font-size:x-large">Subjects</span>'
								CssClass="table table-striped table-hover" OnRowDeleting="gvSubject_RowDeleting"
								AutoGenerateColumns="false">
								<Columns>
                                    <asp:BoundField HeaderText="TeacherSubjectId" DataField="TSId" />
									<asp:BoundField HeaderText="Subject Id" DataField="SubjectId" />
									<asp:BoundField HeaderText="Subject Name" DataField="SubjectName" />
									<asp:BoundField HeaderText="Teacher" DataField="Teacher" />
									<asp:BoundField HeaderText="Total Mark" DataField="TotalMark" />
                                    <asp:CommandField ShowDeleteButton="true" />
								</Columns>
							</asp:GridView>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
			<br />
			<div class="panel-body">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Subject" AssociatedControlID="ddlExistingSubject" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlExistingSubject" DataTextField="Text" DataValueField="Value"
									AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LoadGVExistingMarkPortion">
								</asp:DropDownList>
							</div>
						</div>
						<div class="panel-footer from-group">
							<asp:GridView runat="server" ID="gvExistingMarkPortion" CssClass="table table-striped table-hover"
								HeaderStyle-CssClass="text-info" 
								AutoGenerateColumns="false" BorderColor="Transparent" OnRowDeleting="gvExistingMarkPortion_RowDeleting"
								Caption='<span class="text-info" style="font-size:x-large">Mark Portions</span>'>
								<Columns>
									<asp:BoundField HeaderText="Portion Name" DataField="Text" />
									<asp:BoundField HeaderText="Percentage" DataField="Value" />
                                    <asp:BoundField HeaderText="MPId" DataField="Id" />
<%--                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" Value='<%# Eval("Id") %>' ID="hfMarkPortionId" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:CommandField ShowDeleteButton="true" />
								</Columns>
							</asp:GridView>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</div>
		<div class="panel panel-primary col-md-6 form-horizontal">
			<h2 class="text-center panel-heading">Add Subject to Year</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<div class="col-md-6">
						<asp:DropDownList runat="server" ID="ddlAllSubject" CssClass="form-control" DataTextField="Text"
							DataValueField="Value">
						</asp:DropDownList>
					</div>
					<div class="col-md-6">
						<asp:TextBox runat="server" placeholder="Total Mark" TextMode="Number" ID="txtTotalMark"
							CssClass="form-control" />
						<asp:RequiredFieldValidator ErrorMessage="Total mark cannot be empty" Display="Dynamic"
							ControlToValidate="txtTotalMark"
							runat="server" ValidationGroup="SubjectYear" />
					</div>

				</div>
				<div class="panel-footer form-group">
					<asp:Button Text="Add" ID="btnAddSubjectYear" OnClick="btnAddSubjectYear_Click" ValidationGroup="SubjectYear"
						CssClass="btn btn-default" runat="server" />
				</div>
			</div>
			<h2 class="text-center panel-heading">Assign Subject</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:Label Text="Select Teacher" AssociatedControlID="ddlTeacher" CssClass="col-md-4 control-label"
						runat="server" />
					<div class="col-md-8">
						<asp:DropDownList runat="server" ID="ddlTeacher" CssClass="form-control" DataTextField="Text"
							DataValueField="Value">
						</asp:DropDownList>
					</div>
				</div>
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label Text="Select Subject" AssociatedControlID="ddlSubject" CssClass="col-md-4 control-label"
								runat="server" />
							<div class="col-md-8">
								<asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control" DataTextField="Text"
									DataValueField="Value">
								</asp:DropDownList>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
				<asp:GridView runat="server" ID="gvMarkPortions" CssClass="table table-striped table-hover"
					AutoGenerateColumns="false" BorderColor="Transparent" HeaderStyle-CssClass="text-info"
					Caption='<span class="text-info" style="font-size:x-large">Available Mark Portions</span>'>
					<Columns>
						<asp:TemplateField HeaderText="Include">
							<ItemTemplate>
								<asp:CheckBox runat="server" ID="cbInclude" />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Mark Portion Name">
							<ItemTemplate>
								<asp:Label runat="server" ID="lblPortionName" Text='<%# Eval("Text") %>' />
								<asp:HiddenField runat="server" ID="hfPortionId" Value='<%# Eval("Value") %>' />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Percentage">
							<ItemTemplate>
								<asp:TextBox runat="server" TextMode="Number" CssClass="form-control" ID="txtPercentage" />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
				<div class="panel-footer">
					<div class="from-group">
                        <ul>
                        <asp:HyperLink NavigateUrl="~/Admin/NewEntry.aspx" runat="server" Text="Add New MarkPortion"/>
                        </ul>
                        <br />
						<ul>
							<li class="text-danger">Clicking this button will remove any previous entry of selected subject and create
								a new mark portion combination</li>
						</ul>
					</div>
					<div class="panel-footer ">
						<asp:Button Text="Assign" ID="btnAssign" ToolTip="Assign selected section(s) to selected class"
							OnClick="btnAssign_Click" CausesValidation="false"
							CssClass="btn btn-default col-sm-offset-1 col-xs-offset-2" runat="server" OnClientClick="return confirm('Are you sure to assign selected subject(s) to selected class?');" />
					</div>
				</div>
			</div>
			
		</div>
	</div>
</asp:Content>

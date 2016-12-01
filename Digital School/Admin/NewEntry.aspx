<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="NewEntry.aspx.cs" Inherits="Digital_School.Admin.NewEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style type="text/css">
		.panel-footer {
			padding: 5px 1px;
			background-color: lavender;
			border-top: none;
			border-bottom: 2px solid #aaa;
			border-top-right-radius: 5px;
			border-top-left-radius: 5px;
			border-bottom-right-radius: 0px;
			border-bottom-left-radius: 0px;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#adminNewEntry').attr('class', 'active');

			$('#<%: hSuccess.ClientID %>').delay(5000).fadeOut(1000);
		})
	</script>
	<div class="row">
		
		<h3 class="text-success text-center" id="hSuccess" runat="server"></h3>
		<div class="panel panel-primary col-md-6 col-md-offset-3 col-sm-10 col-sm-offset-1"
			style="border-width:2px">
			<h2 class="panel-heading text-center">Add Year</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:Label Text="Year" AssociatedControlID="txtYear" CssClass="col-sm-3 control-label"
						runat="server" />
					<div class="col-sm-9">
						<asp:TextBox runat="server" ID="txtYear" CssClass="form-control" placeholder="Write Year Name"
							TextMode="Number" />
						<asp:RequiredFieldValidator ErrorMessage="Year field cannot be empty" CssClass="text-danger"
							Display="Dynamic" ControlToValidate="txtYear"
							runat="server" ValidationGroup="Year" />
						<asp:CustomValidator ErrorMessage="This year already exists" Display="Dynamic" CssClass="text-danger"
							ValidationGroup="Year" ControlToValidate="txtYear" runat="server" OnServerValidate="Year_ServerValidate" />
					</div>
				</div>
				<div class="panel-footer">
					<div class="form-group">
						<div class="col-sm-offset-3 col-sm-9">
							<asp:Button Text="Add Year" ID="btnAddYear" CssClass="btn btn-default" runat="server"
								ValidationGroup="Year" OnClick="btnAddYear_Click" />
						</div>
					</div>
				</div>
			</div>
            
			<h2 class="panel-heading text-center">Add Class</h2>
			<div class="panel-body form-horizontal">
				<%--<ul class="text-info">
					<li>Hints</li>
					
				</ul>
                <hr />--%>
                <div class="form-group">
                    <asp:Label Text="Class" AssociatedControlID="txtClassLabel" CssClass="col-sm-3 control-label"
                        runat="server" />
                    <div class="col-sm-9">
                        <asp:TextBox TextMode="SingleLine" runat="server" placeholder="Class" ID="txtClassLabel"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="Class cannot be empty" CssClass="text-danger"
                            ValidationGroup="Class" ControlToValidate="txtClassLabel" Display="Dynamic"
                            runat="server" />
                        <asp:CustomValidator ErrorMessage="This class already exists" Display="Dynamic" CssClass="text-danger"
                            ValidationGroup="Class" ControlToValidate="txtClassLabel" runat="server" OnServerValidate="Class_ServerValidate" />
                    </div>
                </div>
				<div class="panel-footer">
					<div class="form-group">
						<div class="col-sm-offset-3 col-sm-9">
							<asp:Button Text="Add Class" ID="btnAddClass" CssClass="btn btn-default" runat="server"
								ValidationGroup="Class" OnClick="btnAddClass_Click"  />
						</div>
					</div>
				</div>

			</div>
			<h2 class="text-center panel-heading">Add Section</h2>
			<div class="panel-body form-horizontal">
				<%--<ul class="text-info">
					<li>Hints</li>

				</ul>
				<hr />--%>
                <div class="form-group">
                    <asp:Label Text="Section" AssociatedControlID="txtSectionLabel" CssClass="col-sm-3 control-label"
                        runat="server" />
                    <div class="col-sm-9">
                        <asp:TextBox TextMode="SingleLine" runat="server" placeholder="Section" ID="txtSectionLabel"
                            CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="Section cannot be empty" CssClass="text-danger"
                            ValidationGroup="Section" ControlToValidate="txtSectionLabel"
                            runat="server" Display="Dynamic" />
                        <asp:CustomValidator ErrorMessage="This section already exists" Display="Dynamic" CssClass="text-danger"
                            ValidationGroup="Section" ControlToValidate="txtSectionLabel" runat="server" OnServerValidate="Section_ServerValidate" />
                    </div>
                </div>

				
				<div class="panel-footer">
					<div class="form-group">
						<div class="col-sm-offset-3 col-sm-9">
							<asp:Button Text="Add Section" ID="btnAddSection" CssClass="btn btn-default" runat="server"
								ValidationGroup="Section" OnClick="btnAddSection_Click" />
						</div>
					</div>
				</div>

			</div>
			<h2 class="panel-heading text-center">Add Term</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:Label Text="Term" AssociatedControlID="txtTerm" CssClass="col-sm-3 control-label"
						runat="server" />
					<div class="col-sm-9">
						<asp:TextBox runat="server" ID="txtTerm" CssClass="form-control" placeholder="Write Term Name"
							TextMode="SingleLine" Style="max-width: none" />
						<asp:RequiredFieldValidator ErrorMessage="Term field cannot be empty" CssClass="text-danger"
							Display="Dynamic" ControlToValidate="txtTerm"
							runat="server" ValidationGroup="Term" />
						<asp:CustomValidator ErrorMessage="This term already exists" Display="Dynamic"
							CssClass="text-danger"
							ValidationGroup="Term" ControlToValidate="txtTerm" runat="server"
							OnServerValidate="Term_ServerValidate" />
					</div>
				</div>
				<div class="panel-footer">
					<div class="form-group">
						<div class="col-sm-offset-3 col-sm-9">
							<asp:Button Text="Add Term" ID="btnAddTerm" CssClass="btn btn-default"
								runat="server"
								ValidationGroup="Term" OnClick="btnAddTerm_Click" />
						</div>
					</div>
				</div>
			</div>
			<h2 class="text-center panel-heading">Add Subject</h2>
			<div class="panel-body form-horizontal">
				<ul class="text-info" style="text-align:justify">
					<li>Subject code is a short-text which should be unique subject to subject</li>
					<li>
						If total mark of a subject varies by class (like in class 2, full mark of Social Science is 50 but in class 3, it is 100)
						two subject entry can be created with same subject name but different subject code
					</li>
					<li>Exaple of subject code: 102, BAN, ENG-5</li>
					<li>Subject name is what user will see as the name of subject</li>
					<li>Example of subject name: Bangla, Bangla I, Bangla First Paper</li>
				</ul>
				<hr />
				<div class="form-group">
					<div class="col-sm-6">
						<asp:TextBox TextMode="SingleLine" runat="server" placeholder="Subject Code" ID="txtSubjectCode"
							CssClass="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ErrorMessage="Subject code cannot be empty" ValidationGroup="Subject"
							CssClass="text-danger" Display="Dynamic"
							ControlToValidate="txtSubjectCode"
							runat="server" />
						<asp:CustomValidator ErrorMessage="A subject with this subject code already exists" CssClass="text-danger"
							ValidationGroup="Subject" ControlToValidate="txtSubjectCode" runat="server"
							Display="Dynamic" OnServerValidate="Subject_ServerValidate" />
					</div>
					<div class="col-sm-6">
						<asp:TextBox TextMode="SingleLine" runat="server" placeholder="Subejct Name" ID="txtSubjectName"
							CssClass="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ErrorMessage="Subject name cannot be empty" CssClass="text-danger"
							ValidationGroup="Subject" ControlToValidate="txtSubjectName"
							runat="server" Display="Dynamic" />
					</div>
				</div>
				<div class="panel-footer">
					<div class="form-group">
						<div class="col-sm-12">
							<asp:Button Text="Add Subject" ID="btnAddSubject" CssClass="btn btn-default" runat="server"
								ValidationGroup="Subject" OnClick="btnAddSubject_Click" />
						</div>
					</div>
				</div>

			</div>

			<h2 class="panel-heading text-center">Add Mark Portion</h2>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<asp:Label Text="Mark Portion" AssociatedControlID="txtMarkPortion" CssClass="col-sm-3 control-label"
						runat="server" />
					<div class="col-sm-9">
						<asp:TextBox runat="server" ID="txtMarkPortion" CssClass="form-control" placeholder="Write Mark Portion Name"
							TextMode="SingleLine" style="max-width:none" />
						<asp:RequiredFieldValidator ErrorMessage="Mark portion field cannot be empty" CssClass="text-danger"
							Display="Dynamic" ControlToValidate="txtMarkPortion"
							runat="server" ValidationGroup="MarkPortion" />
						<asp:CustomValidator ErrorMessage="This mark portion already exists" Display="Dynamic" CssClass="text-danger"
							ValidationGroup="MarkPortion" ControlToValidate="txtMarkPortion" runat="server" OnServerValidate="MarkPortion_ServerValidate" />
					</div>
				</div>
				<div class="panel-footer">
					<div class="form-group">
						<div class="col-sm-offset-3 col-sm-9">
							<asp:Button Text="Add Mark Portion" ID="btnAddMarkPortion" CssClass="btn btn-default"
								runat="server"
								ValidationGroup="MarkPortion" OnClick="btnAddMarkPortion_Click" />
						</div>
					</div>
				</div>
			</div>
			
		</div>
	</div>
</asp:Content>

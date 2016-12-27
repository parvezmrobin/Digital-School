<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Register.aspx.cs" Inherits="Digital_School.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<script type="text/javascript">

		$(document).ready(function () {
			var ddlas = $('#<%:ddlAs.ClientID %>');

			function divLoader(e) {

				var ddl = $('#<%:ddlAs.ClientID %>');
				var role = ddl.val();
				//$('#output').val('called ' + role);

				switch (role) {
					case 'student':
						$('#student').attr('hidden', false);
						$('#teacher').attr('hidden', true);
						$('#nonadmin1').attr('hidden', false);
						$('#nonadmin2').attr('hidden', false);
						break;
					case 'teacher':
						$('#student').attr('hidden', true);
						$('#teacher').attr('hidden', false);
						$('#nonadmin1').attr('hidden', false);
						$('#nonadmin2').attr('hidden', false);
						break;
					case 'admin':
						$('#student').attr('hidden', true);
						$('#teacher').attr('hidden', true);
						$('#nonadmin1').attr('hidden', true);
						$('#nonadmin2').attr('hidden', true);
						break;
					default:
						break;
				};
			};
			divLoader(null);
			ddlas.on('change', divLoader);
			
		});
	</script>

	<div class="row">
		<h2>Create a new account</h2>
		<p class="text-danger">
			<asp:Literal runat="server" ID="ErrorMessage" />
		</p>

		<div class="form-horizontal">
			<hr />
			<asp:ValidationSummary runat="server" CssClass="text-danger" />
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="ddlAs" CssClass="col-md-2 control-label">As</asp:Label>
				<div class="col-md-10">
					<select id="ddlAs" class="form-control" runat="server">
					</select>
				</div>
			</div>
			<br />
			<div id="nonadmin1">
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="Firstname" CssClass="col-md-2 control-label">First name</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="Firstname" CssClass="form-control" TextMode="SingleLine"
							placeholder="Write first name" />
						<%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Firstname"
							CssClass="text-danger" ErrorMessage="The username field is required." />--%>
					</div>
				</div>
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="Lastname" CssClass="col-md-2 control-label">Last name</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="Lastname" CssClass="form-control" TextMode="SingleLine"
							placeholder="Write last name" />
						<%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Lastname"
							CssClass="text-danger" ErrorMessage="The username field is required." />--%>
					</div>
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" ID="Username" CssClass="form-control" TextMode="SingleLine"
						placeholder="Write username [Required]" />
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
						CssClass="text-danger" ErrorMessage="The username field is required." />
				</div>
			</div>

			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Write email address [Required]" />
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
						CssClass="text-danger" ErrorMessage="The email field is required." />
					<asp:RegularExpressionValidator ErrorMessage="Invalid email format." ControlToValidate="Email"
						CssClass="text-danger" runat="server" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" />
				</div>
			</div>

			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control"
						placeholder="Write password [Required]" />
					<asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
						CssClass="text-danger" ErrorMessage="The password field is required." />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control"
						placeholder="Repeat password [Required]" />
					<asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
						CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
					<asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
						CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
				</div>
			</div>
			<br />
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label">Phone Number</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="Phone"
						placeholder="Write phone number" />
				</div>
			</div>
			<br />
			<div id="nonadmin2">
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="FathersName" CssClass="col-md-2 control-label">Father's Name</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="FathersName" CssClass="form-control" TextMode="Phone"
							placeholder="Write father's name" />
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="MothersName" CssClass="col-md-2 control-label">Mother's Name</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="MothersName" CssClass="form-control" TextMode="Phone"
							placeholder="Write mother's name" />
					</div>
				</div>
				<br />
			</div>

			<div id="teacher">
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="ddlDesignation" CssClass="col-md-2 control-label">Designation</asp:Label>
					<div class="col-md-10">
						<asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control" DataTextField="Text"
							DataValueField="Value">
						</asp:DropDownList>
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="txtQualification" CssClass="col-md-2 control-label">Qualification</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="txtQualification" CssClass="form-control"
							Style="max-width: 560px" TextMode="MultiLine"
							placeholder="Write Detail Qualification" />
					</div>
				</div>
				<br />
			</div>
			<div id="student">
				<asp:UpdatePanel runat="server">
					<ContentTemplate>
						<div class="form-group">
							<asp:Label runat="server" AssociatedControlID="ddlClass" CssClass="col-md-2 control-label">Class</asp:Label>
							<div class="col-md-10">
								<asp:DropDownList runat="server" CssClass="form-control" ID="ddlClass" DataTextField="Text" DataValueField="Value"
									OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" OnDataBound="ddlClass_SelectedIndexChanged" AutoPostBack="true">
								</asp:DropDownList>
							</div>
						</div>
						<br />
						<div class="form-group">
							<asp:Label runat="server" AssociatedControlID="ddlSection" CssClass="col-md-2 control-label">Section</asp:Label>
							<div class="col-md-10">
								<asp:DropDownList CssClass="form-control" runat="server" ID="ddlSection" DataTextField="Text"
									DataValueField="Value">
								</asp:DropDownList>
							</div>
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
				<br />
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="txtRoll" CssClass="col-md-2 control-label">Roll</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="txtRoll" TextMode="Number" CssClass="form-control" placeholder="Write Roll number" style="max-width:280px" />
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="txtGaurdianOccupation" CssClass="col-md-2 control-label">Gaurdian Occupation</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="txtGaurdianOccupation" CssClass="form-control" placeholder="Write Gaurdian Occupation" />
					</div>
				</div>
				<br />
				<div class="form-group">
					<asp:Label runat="server" AssociatedControlID="txtGaurdianOccupationDetail" CssClass="col-md-2 control-label">Gaurdian Occupation Detail</asp:Label>
					<div class="col-md-10">
						<asp:TextBox runat="server" ID="txtGaurdianOccupationDetail" CssClass="form-control"
							Style="max-width: 560px" TextMode="MultiLine"
							placeholder="Write Gaurdian Occupation Detail" />
					</div>
				</div>
				<br />
			</div>
			<%--<input type="text" id="output" />--%>
			<div class="form-group">
				<div class="col-md-offset-2 col-md-10">
					<asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-success" />
				</div>
			</div>
		</div>
	</div>
</asp:Content>

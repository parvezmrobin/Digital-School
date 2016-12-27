<%@ Page Title="Apply" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Apply.aspx.cs" Inherits="Digital_School.Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style type="text/css">
		h2.bg-success:hover,
		h2.bg-success:focus {
			background-color: #c1e2b3;
		}
	</style>
	<div class="jumbotron col-xs-12" id="divSuccessful" visible="false" runat="server"
		enableviewstate="true">
		<h4>Your application was submited successfully. </h4>
		<h4 class="text-info">Your application ID is 
		<span id="appId" runat="server" enableviewstate="true"></span>.</h4>
		<h4>Save this for future use.</h4>
	</div>
	<div class="form-horizontal">
		<h2 id="applicationTitle" runat="server">Application Title</h2>
		<h4 id="applicationSummary" runat="server" style="text-align: justify">Application Summary
		</h4>
		<hr />
		<asp:ValidationSummary runat="server" CssClass="text-danger" />

		<div class="form-group">
			<asp:Label Text="First Name" AssociatedControlID="txtFirstName" runat="server" CssClass="col-md-2 control-label" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
					CssClass="text-danger" ErrorMessage="First Name is required." />
			</div>
		</div>
		<div class="form-group">
			<asp:Label Text="Last Name" AssociatedControlID="txtLastName" runat="server" CssClass="col-md-2 control-label" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtLastNAme" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
					CssClass="text-danger" ErrorMessage="Last Name is required." />
			</div>
		</div>
		<div class="form-group">
			<asp:Label Text="Father's Name" AssociatedControlID="txtFathersName" runat="server"
				CssClass="col-md-2 control-label" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtFathersName" CssClass="form-control" TextMode="SingleLine" />
			</div>
		</div>
		<br />
		<div class="form-group">
			<asp:Label Text="Mother's Name" AssociatedControlID="txtMothersName" runat="server"
				CssClass="col-md-2 control-label" />
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtMothersName" CssClass="form-control" />
			</div>
		</div>
		<br />
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
					CssClass="text-danger" ErrorMessage="The email field is required." />
				<asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
					CssClass="text-danger" ErrorMessage="Input a valid Email address" Display="Dynamic"
					ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
				</asp:RegularExpressionValidator>
			</div>
		</div>

		<div class="form-group">
			<asp:Label Text="Select Gender" AssociatedControlID="ddlGender" runat="server" CssClass="col-md-2 control-label" />
			<div class="col-md-10">
				<asp:DropDownList ID="ddlGender" Width="280px" CssClass="form-control" runat="server">
					<asp:ListItem Text="Male" Value="1"></asp:ListItem>
					<asp:ListItem Text="Female" Value="2"></asp:ListItem>
					<asp:ListItem Text="Others" Value="3"></asp:ListItem>
				</asp:DropDownList>

			</div>
		</div>
		<br />
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtBirthDate" CssClass="col-md-2 control-label">Date of Birth</asp:Label>
			<div class="col-md-10">
				<asp:TextBox runat="server" Width="280px" ID="txtBirthDate" TextMode="Date" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtBirthDate"
					CssClass="text-danger" Display="Dynamic" ErrorMessage="Date of Birth is required." />
			</div>
		</div>
		<br />
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Address</asp:Label>
			<div class="col-md-10">
				<asp:TextBox runat="server" Style="max-width: 560px; min-height: 100px" ID="txtAddress"
					TextMode="MultiLine" CssClass="form-control" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
					CssClass="text-danger" Display="Dynamic" ErrorMessage="Address is required." />
			</div>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="txtPhone" CssClass="col-md-2 control-label">Phone </asp:Label>
			<div class="col-md-10">
				<asp:TextBox runat="server" Width="280px" ID="txtPhone" TextMode="Phone" CssClass="form-control" />
			</div>
		</div>
		<div id="divTeacher" runat="server">
			<div class="form-group">
				<asp:Label Text="Designation" AssociatedControlID="txtDesignation" runat="server"
					CssClass="col-md-2 control-label" />
				<div class="col-md-10">
					<asp:TextBox runat="server" Width="280px" ID="txtDesignation" TextMode="SingleLine"
						Enabled="false" CssClass="form-control" />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="txtQualification" CssClass="col-md-2 control-label">Qualification</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" Style="max-width: 560px; min-height: 100px" ID="txtQualification"
						TextMode="MultiLine"
						CssClass="form-control" />
					<asp:RequiredFieldValidator runat="server" ControlToValidate="txtQualification"
						CssClass="text-danger" Display="Dynamic" ErrorMessage="Qualification is required." />
				</div>
			</div>
		</div>
		<div id="divStudent" runat="server">
			<div class="form-group">
				<asp:Label Text="Class" AssociatedControlID="txtClass" runat="server"
					CssClass="col-md-2 control-label" />
				<div class="col-md-10">
					<asp:TextBox runat="server" Width="280px" ID="txtClass" TextMode="SingleLine" Enabled="false"
						CssClass="form-control" />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="txtGuardianOccupation" CssClass="col-md-2 control-label">Guardian Occupation</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" Width="280px" ID="txtGuardianOccupation" TextMode="SingleLine"
						CssClass="form-control" />
					<asp:RequiredFieldValidator runat="server" ControlToValidate="txtGuardianOccupation"
						CssClass="text-danger" Display="Dynamic" ErrorMessage="Guardian Occupation is required." />
				</div>
			</div>
			<div class="form-group">
				<asp:Label runat="server" AssociatedControlID="txtGuardianOccupationDetail" CssClass="col-md-2 control-label">Guardian Occupation Detail</asp:Label>
				<div class="col-md-10">
					<asp:TextBox runat="server" Style="max-width: 560px; min-height: 100px" ID="txtGuardianOccupationDetail"
						TextMode="MultiLine"
						CssClass="form-control" />
				</div>
			</div>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="fuImage" CssClass="col-md-2 control-label">Upload Image</asp:Label>
			<div class="col-md-10">
				<asp:FileUpload EnableViewState="true" ID="fuImage" CssClass="form-control" Width="280px"
					ToolTip="Upload a file with extension .jpg, .jpeg, .png, .bmp" runat="server"
					AllowMultiple="false" />
                
				<asp:CustomValidator ErrorMessage="Upload an image with extension .jpg, .jpeg, .png or .bmp"
					CssClass="text-danger"
					Display="Dynamic" OnServerValidate="imgValidator_ServerValidate" ControlToValidate="fuImage"
					runat="server" ID="imgValidator" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="fuCertificate" CssClass="col-md-2 control-label">Attach Certificate</asp:Label>
			<div class="col-md-10">
				<asp:FileUpload ID="fuCertificate" EnableViewState="true" CssClass="form-control"
					Width="280px" ToolTip="Upload certificate in zipped format"
					runat="server" AllowMultiple="false" />
				<asp:CustomValidator CssClass="text-danger" Display="Dynamic" ID="certValidator"
					ControlToValidate="fuCertificate" OnServerValidate="certValidator_ServerValidate"
					runat="server" />
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<asp:Button runat="server" Text="Apply" ID="btnApply"
					CssClass="btn btn-primary" OnClick="btnApply_Click" />
				<div>
					<br />
				</div>
				<h2 class="bg-success form-control" style="font-size: 130%; max-width: 560px"><a
					id="applicationUrl"
					runat="server">Click here</a> to view related notice.</h2>
			</div>
		</div>


	</div>
</asp:Content>

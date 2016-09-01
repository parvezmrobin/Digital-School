<%@ Page Title="Apply" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="Digital_School.Apply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="jumbotron col-xs-12" id="divSuccessful" visible="false" runat="server"
		enableviewstate="true">
		<h4>Your application was submited successfully. </h4>
		<h4 class="text-info">Your application ID is 
		<span id="appId" runat="server" enableviewstate="true"></span>.</h4>
		<h4>Save this for future use.</h4>
	</div>
	<div class="form-horizontal">
		<h2 id="applicationTitle" runat="server">Application Title</h2>
		<h4 id="applicationDetail" runat="server">Application Detail</h4>
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
			<asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
			<div class="col-md-10">
				<asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
				<asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
					CssClass="text-danger" ErrorMessage="The email field is required." />
				<asp:RegularExpressionValidator runat="server" ControlToValidate="Email" CssClass="text-danger"
					ErrorMessage="Input a valid Email address" Display="Dynamic"
					ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
			<asp:Label runat="server" AssociatedControlID="fuImage" CssClass="col-md-2 control-label">Upload Image</asp:Label>
			<div class="col-md-10">
				<asp:FileUpload ID="fuImage" CssClass="form-control" Width="280px" ToolTip="Upload a file with extension .jpg, .jpeg, .png, .bmp"
					runat="server" />
				<asp:CustomValidator ErrorMessage="Upload a file with ratio 4:6 " CssClass="text-danger"
					Display="Dynamic" ControlToValidate="fuCertificate" runat="server" />
			</div>
		</div>
		<br />
		<div class="form-group">
			<asp:Label runat="server" AssociatedControlID="fuCertificate" CssClass="col-md-2 control-label">Attach Certificate</asp:Label>
			<div class="col-md-10">
				<asp:FileUpload ID="fuCertificate" CssClass="form-control" Width="280px" ToolTip="Upload certificate in zipped format"
					runat="server" />
				<asp:CustomValidator ErrorMessage="Max File size 2 MB" CssClass="text-danger" Display="Dynamic"
					ControlToValidate="fuCertificate" runat="server" />
			</div>
		</div>
		<br />
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<asp:Button runat="server" Text="Apply" ID="btnApply"
					CssClass="btn btn-primary" OnClick="btnApply_Click" />
			</div>
		</div>
	</div>
</asp:Content>

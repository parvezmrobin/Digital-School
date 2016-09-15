<%@ Page Title="Response" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Response.aspx.cs" Inherits="Digital_School.Admin.Response" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#<%:imgThumb.ClientID%>').click(function () {
				window.open('<%:Server.MapPath(imgThumb.ImageUrl)%>', '_blank');
			});
		});
	</script>
	
	<div class="row">
		<h2 class="text-info text-center">Response ID : <span runat="server" id="spanResId">
		</span></h2>
		<hr />
		<div hidden="hidden">			
				<asp:Button Text="Previous" ID="btnPrevious" CssClass="btn btn-primary" runat="server" />			
				<asp:Button Text="Select" ID="btnSelect" CssClass="btn btn-success" runat="server" />			
				<asp:Button Text="Next" ID="btnNext" CssClass="btn btn-primary btn-next"
					runat="server" />			
		</div>
		<hr />
		<div>
			<div class="form-horizontal">
				<div class="form-group">
					<label class="control-label text-static col-sm-3" for="lblAppId">Application ID</label>
					<a runat="server" id="aAppId" href="#" class=" col-sm-4">
						<asp:Label runat="server" ID="lblAppId" CssClass="form-control" />
					</a>
					<%--<a class="col-sm-3" runat="server" id="aImage" href="#">--%>
						<%--<img runat="server" id="imgThumb" src="#" class="img img-responsive img-thumbnail"
							title="Click this thumbnail to see full size image" />--%>
					<asp:ImageButton ImageUrl="#" runat="server" ID="imgThumb" CssClass="col-sm-3" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblFirstName">First Name</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblFirstName" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblLastName">Last Name</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblLastName" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblFathersName">Father's Name</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblFathersName" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblMothersName">Mother's Name</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblMothersName" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblGender">Gender</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblGenderName" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblBirthDate">Date of Birth</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblBirthDate" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblAddress">Address</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblAddress" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblEmail">Email</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblEmail" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblPhoneNo">Phone Number</label>
				<div class=" col-sm-7">
					<asp:Label runat="server" ID="lblPhoneNo" CssClass="form-control" />
				</div>
			</div>
		</div>
		<br />
		<section runat="server" id="sectionTch" visible="false">
			<div class="form-horizontal">
				<div class="form-group">
					<label class="control-label text-static col-sm-3" for="lblDesignation">Designation</label>
					<div class=" col-sm-7">
						<asp:Label runat="server" ID="lblDesignation" CssClass="form-control" />
					</div>
				</div>
			</div>
			<br />
			<div class="form-horizontal">
				<div class="form-group">
					<label class="control-label text-static col-sm-3" for="lblQualification">Qualification</label>
					<div class=" col-sm-7">
						<asp:Label runat="server" ID="lblQualification" CssClass="form-control" />
					</div>
				</div>
			</div>
			<br />
		</section>
		<section runat="server" id="sectionStd" visible="false">
			<div class="form-horizontal">
				<div class="form-group">
					<label class="control-label text-static col-sm-3" for="lblClass">Class</label>
					<div class=" col-sm-7">
						<asp:Label runat="server" ID="lblClass" CssClass="form-control" />
					</div>
				</div>
			</div>
			<br />
			<div class="form-horizontal">
				<div class="form-group">
					<label class="control-label text-static col-sm-3" for="lblGaurdianOccupation">
						Gaurdian
						Occupation</label>
					<div class=" col-sm-7">
						<asp:Label runat="server" ID="lblGaurdianOccupation" CssClass="form-control" />
					</div>
				</div>
			</div>
			<br />
			<div class="form-horizontal">
				<div class="form-group">
					<label class="control-label text-static col-sm-3" for="lblGaurdianOccupationDetail">
						Gaurdian Occupation Detail</label>
					<div class=" col-sm-7">
						<asp:Label runat="server" ID="lblGaurdianOccupationDetail" CssClass="form-control" />
					</div>
				</div>
			</div>
			<br />
		</section>
		<div class="form-horizontal">
			<div class="form-group">
				<label class="control-label text-static col-sm-3" for="lblAttachment">Attachment</label>
				<div class=" col-sm-7">
					<a runat="server" id="aAttachment" href="#">
						<label id="lblAttachment" class="form-control">Download</label>
					</a>
				</div>
			</div>
		</div>
		<br />
	</div>
</asp:Content>

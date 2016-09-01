<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Digital_School.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyBezq20FEQ48YlxQQZltgWntzJBVPY7G-Q"></script>
	<script>
		function initialize() {
			var mapProp = {
				center: new google.maps.LatLng(22.8021, 89.5340),
				zoom: 15,
				mapTypeId: google.maps.MapTypeId.ROADMAP
			};
			var map = new google.maps.Map(document.getElementById("map"), mapProp);
		}
		google.maps.event.addDomListener(window, 'load', initialize);
	</script>

	<h2>Contact Info</h2>

	<div class="row" id="divContact">
		<div class=" col-sm-6">
			<h2>Digital School</h2>
			CSE Discipline,<br />
			Khulna University,<br />
			Khulna.

		<hr />
			<address>
				<strong>Support:</strong>   <a href="mailto:DigitalSchool@example.com">Support@example.com</a><br />
				<strong>Contact No:</strong> 01xxx-xxxxxx
			</address>
		</div>
		<div class="col-sm-6">
			<div id="map" style="height: 400px"></div>
		</div>
	</div>
</asp:Content>

<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Digital_School.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyBezq20FEQ48YlxQQZltgWntzJBVPY7G-Q"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $.ajax({
	            url: 'LoadLatLong.asmx/jsonRead',
	            data: {},
	            method: 'post',
	            dataType: 'xml',
	            error: function (err) {
	                alert(err.responseText);
	            },
	            success: function (data) {
	                var xml = $(data);
	                $('#txtLattitude').val(xml.find('Value').text());
	                $('#txtLongitude').val(xml.find('Value2').text());
	                $('#txtSupport').val(xml.find('Value3').text());
	                $('#txtContact').val(xml.find('Value4').text());
	                a1 = parseFloat(xml.find('Value').text());
	                a2 = parseFloat(xml.find('Value2').text());
	                //alert(a1);
	                //$('#history').val(xml.find('Value').text());
	            }
	        });
	    });
		function initialize() {
			var mapProp = {
				center: new google.maps.LatLng(a1, a2),
				zoom: 15,
				mapTypeId: google.maps.MapTypeId.ROADMAP
			};
			var map = new google.maps.Map(document.getElementById("map"), mapProp);
		}
		google.maps.event.addDomListener(window, 'load', initialize);
    </script>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#menuContact').attr('class', 'active');
		});
	</script>
	<h2>Contact Info</h2>

	<div class="row" id="divContact">
		<div class=" col-sm-6" >
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Enabled="false" CssClass="form-control" BackColor="Transparent" BorderColor="Transparent"/>
			<%--<h2>Digital School</h2>
			CSE Discipline,<br />
			Khulna University,<br />
			Khulna.--%>
		<hr />
			<address>
				<strong>Support:</strong>
                <input type="text" disabled="disabled" id="txtSupport" style="border-color: transparent; background-color: transparent; border-style: none" class="form-control" />
                  <%--<a href="mailto:DigitalSchool@example.com">Support@example.com</a>--%><br />
				<strong>Contact No:</strong>              
                <input type="text" disabled="disabled" id="txtContact" style="border-color:transparent;background-color:transparent;border-style:none" class="form-control" />
			</address>

            <input type="hidden" id="txtLattitude" class="form-control" />
            <br />
            <input type="hidden" id="txtLongitude" class="form-control" />
		</div>
		<div class="col-sm-6">
			<div id="map" style="height: 400px"></div>
		</div>
	</div>
</asp:Content>

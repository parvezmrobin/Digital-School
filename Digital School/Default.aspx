<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="Digital_School._Default" %>

<%@ Register Src="~/User Control/Tile.ascx" TagPrefix="uc1" TagName="Tile" %>
<%@ Register Src="~/User Control/PostListItem.ascx" TagPrefix="uc1" TagName="PostListItem" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#menuHome').attr('class', 'active');
		});
	</script>
	<style>
		input.panel-heading {
			font-size: 20px;
		}

		caption {
			font-size: large;
		}
	</style>
	<div class="row">
		<div class="col-md-12 hidden-xs hidden-sm">
			<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<asp:AdRotator ID="arSlideShow" runat="server" 
						AdvertisementFile="~/Xml/slideshow.xml" CssClass="img img-responsive img-thumbnail" />
					<asp:Timer ID="Timer1" runat="server" Interval="5000"></asp:Timer>
				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
				</Triggers>
			</asp:UpdatePanel>
		</div>
		<br />
		<div class="col-xs-12">
			<div class="col-xs-12 col-md-9">
				<uc1:Tile ID="sectionNews" runat="server" Title="News" Type="1"
					PostID="1" />
				<uc1:Tile ID="sectionNotice" runat="server" Title="Notice" Type="2"
					PostID="4" />

				<uc1:Tile ID="sectionGallary" runat="server" Title="Gallary"
					Detail="Click Here to view the image gallary and learn about various occasions held here." />

				<uc1:Tile ID="sectionTeacher" runat="server" Title="Teacher"
					Detail="Click Here to View the list of Teachers who are the back-end engineer of the lightning bolts of the school." />

			</div>
			<div class="col-xs-12 col-md-3">
				<div class="form-horizontal">
					<div class="form-group">
						<br />
						<asp:TextBox runat="server" TextMode="Search" CssClass="form-control" />
						
					</div>
					<button runat="server" class="btn btn-default" id="btnSearch" style="float: right"><span
						class="glyphicon glyphicon-search"></span>Search</button>
				</div>
			</div>
		</div>
	</div>

</asp:Content>

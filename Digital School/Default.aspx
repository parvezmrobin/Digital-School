<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Digital_School._Default" %>

<%@ Register Src="~/User Control/Tile.ascx" TagPrefix="uc1" TagName="Tile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<br />
	<style>
		input.panel-heading{
			font-size:20px;
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
		<div class="col-xs-12">
			<div class="col-xs-12 col-md-9">
				<uc1:Tile ID="sectionNews" runat="server" Title="News" Type="1"
					PostID="1" Detail="All of the examples on this page will show a navigation bar that takes up too much space on small screens (however, the navigation bar will be on one single line on large screens - because Bootstrap is responsive). This problem (with the small screens) will be solved in the last example on this page." />
				<uc1:Tile ID="sectionNotice" runat="server" Title="Notice" Type="2"
					PostID="4" Detail="All of the examples on this page will show a navigation bar that takes up too much space on small screens (however, the navigation bar will be on one single line on large screens - because Bootstrap is responsive). This problem (with the small screens) will be solved in the last example on this page." />

				<uc1:Tile ID="sectionGallary" runat="server" Title="Gallary"
					Detail="Click Here to view the image gallary and learn about various occasions held here." />

				<uc1:Tile ID="sectionTeacher" runat="server" Title="Teacher"
					Detail="Click Here to View the list of Teachers who are the back-end engineer of the lightning bolts of the school." />

			</div>
			<div class="col-md-3 col-sm-6 col-xs-9 ">
				<asp:UpdatePanel ID="UpdatePanel1" runat="server">
					<ContentTemplate>
						<asp:Calendar CssClass="text-primary" FirstDayOfWeek="Saturday" NextPrevFormat="ShortMonth"
							Caption="Academic Calendar" ID="cal" runat="server" WeekendDayStyle-ForeColor="Red"
							CaptionAlign="Top"></asp:Calendar>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="cal" EventName="Load" />
					</Triggers>
				</asp:UpdatePanel>
			</div>
		</div>
	</div>

</asp:Content>

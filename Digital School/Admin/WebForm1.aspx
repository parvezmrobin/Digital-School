<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Digital_School.Admin.WebForm1" %>

<%@ Register Src="~/User Control/SelectableImage.ascx" TagPrefix="uc1" TagName="SelectableImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#btnSelectAll').click(function () {
				var text = $('#btnSelectAll').html();
				if (text == 'Select All') {
					$('#btnSelectAll').html('Deselect All');
					$('span.cbclass input').prop('checked', true);
				} else {
					$('#btnSelectAll').html('Select All');
					$('span.cbclass input').prop('checked', false);
				}
			})
		})
	</script>
	<div class="row">
		<div>
			<a id="btnSelectAll" class="btn btn-default">Select All</a>
		</div>
		<br />
		<uc1:SelectableImage AutoPostBack="true" runat="server" WidthClass="col-md-4" ID="SelectableImage" />
		<uc1:SelectableImage runat="server" AutoPostBack="true" WidthClass="col-md-4" ID="SelectableImage1" />
		<uc1:SelectableImage runat="server" WidthClass="col-md-4" ID="SelectableImage2" />
		<uc1:SelectableImage runat="server" WidthClass="col-md-4" ID="SelectableImage3" />
		<uc1:SelectableImage runat="server" WidthClass="col-md-4" ID="SelectableImage4" />
		<uc1:SelectableImage runat="server" WidthClass="col-md-4" ID="SelectableImage5" />
	</div>
</asp:Content>

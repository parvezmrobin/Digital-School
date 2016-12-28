<%@ Page Title="Mark" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Mark.aspx.cs" Inherits="Digital_School.Teacher.Mark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	

	<script type="text/javascript">
		$(document).ready(function () {
			$('input[type="number"]').focus(function () {
				$('#prevValue').val($(this).val());
				$("#ppp").val(($('#prevValue').val() == "") ? 'empty' : 'non empty');

			});

			$('input[type="number"]').blur(function () {
				if ($('#prevValue').val() == "") {
					if ($(this).val() == "") {
						$("#ppp").val('empty-input');
						return;
					}
					$("#ppp").val('add-method');

					var textbox = $(this);
					var parent = textbox.parent();

					var _markPortionId = parent.children('input[type="hidden"]').first().val();
					var _studentId = parent.parent().children().first().children('input[type="hidden"]').first().val();
					var _classId = $('#<%: ddlClass.ClientID %>').val();
					var _sectionId = $('#<%: ddlSecion.ClientID %>').val();
					var _termId = $('#<%: ddlTerm.ClientID %>').val();
					var _mark = textbox.val();
					var _teacherId = '<%: User.Identity.GetUserId() %>';

					$.ajax({
						url: 'MarkWebService.asmx/AddMark',
						data: {
							markPortionId: _markPortionId,
							studentId: _studentId,
							classId: _classId,
							sectionId: _sectionId,
							termYearClassSectionId: _termId,
							mark: _mark,
							teacherId: _teacherId
						},
						method: 'post',
						dataType: 'xml',
						error: function (err) {
							alert(err.responseText);
						},
						success: function (data) {
							textbox.css('background-color', 'LightGreen');
							setTimeout(function () { textbox.css('background-color', 'white') }, 5000);

							var hf = textbox.parent().children('input[type="hidden"]').first();
							var xml = $(data);
							hf.val(xml.find('Value').text());

							$('#ppp').val(xml.find('Value').text());
							$('#inpNumber').val(parseInt(xml.find('Value').text()));
						}
					});
				} else {
					if ($(this).val() == "") {
						$(this).val($('#prevValue').val());
						$("#ppp").val('removal');
						return;
					}
					var textbox = $(this);
					var parent = textbox.parent();
					var hf = parent.children('input[type="hidden"]').first();
					$("#ppp").val('updated');

					$.ajax({
						url: 'MarkWebService.asmx/UpdateMark',
						data: { mark: textbox.val(), markId: hf.val() },
						method: 'post',
						dataType: 'xml',
						error: function (err) {
							alert(err.responseText);
						},
						success: function (data) {
							textbox.css('background-color', 'LightGreen');
							setTimeout(function () { textbox.css('background-color', 'white') }, 5000);

						}
					});
				}
			});
		});
	</script>

	<style type="text/css">
		input[type="number"].form-control {
			border: none;
			max-width:100px;
			min-width:50px;
		}
	</style>
	<div class="row">
		<div class="visible-sm">
			<br />
			<br />
		</div>
		<div class="panel panel-primary" style="border:none">
			<h2 class="panel-heading text-center">Mark Input</h2>
			<div class="panel-body">
				<div class="form-horizontal col-md-5">
					<div class="form-group">
						<asp:Label AssociatedControlID="ddlClass" runat="server" CssClass="control-label col-sm-4">Class</asp:Label>
						<div class="col-sm-8">
							<asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server" DataTextField="Text"
								DataValueField="Value" OnSelectedIndexChanged="LoadDDLSection" AutoPostBack="true">
							</asp:DropDownList>
						</div>
					</div>

					<br />
					<div class="form-group">
						<asp:Label AssociatedControlID="ddlSecion" runat="server" CssClass="control-label col-sm-4">Section</asp:Label>
						<div class="col-sm-8">
							<asp:DropDownList ID="ddlSecion" CssClass="form-control" runat="server" DataTextField="Text"
								DataValueField="Value" OnSelectedIndexChanged="LoadNextOfDDLSection" AutoPostBack="true">
							</asp:DropDownList>
						</div>
					</div>
					<br />
					<div class="form-group">
						<asp:Label AssociatedControlID="ddlTerm" runat="server" CssClass="control-label col-sm-4">Term</asp:Label>
						<div class="col-sm-8">
							<asp:DropDownList ID="ddlTerm" CssClass="form-control" runat="server"
								AutoPostBack="true" DataTextField="Text" DataValueField="Value" >
							</asp:DropDownList>
						</div>
					</div>
					<br />
					<div class="form-group">
						<asp:Label AssociatedControlID="ddlSubject" runat="server" CssClass="control-label col-sm-4">Subject</asp:Label>
						<div class="col-sm-8">
							<asp:DropDownList ID="ddlSubject" CssClass="form-control" runat="server" DataTextField="Text"
								DataValueField="Value" AutoPostBack="true">
							</asp:DropDownList>
						</div>
					</div>
				</div>
				<div class="col-md-7">
					<div class="table-responsive">
						<asp:GridView runat="server" ID="gvMark" CssClass="table table-striped table-hover"
							AutoGenerateColumns="false" OnRowDataBound="gvMark_RowDataBound" Style="border-color: lightgoldenrodyellow" HeaderStyle-CssClass="text-info">
						</asp:GridView>
					</div>
					<input type="hidden"  id="prevValue" />
					<input type="text" id="inpNumber" hidden />
					<input type="text" id="ppp" class="vugichugi" value="abcd" hidden />
				</div>
			</div>
		</div>
	</div>
</asp:Content>

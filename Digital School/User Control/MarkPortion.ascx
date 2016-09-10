<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarkPortion.ascx.cs"
	Inherits="Digital_School.User_Control.MarkPortion" %>
<div class="form-group">
	<asp:Label Text="Mark Portion" AssociatedControlID="txt" runat="server"
		CssClass="col-md-4 control-label" ID="lbl" />
	<div class="col-md-6">
		<asp:TextBox ID="txt" CssClass="form-control" runat="server" >
		</asp:TextBox>
	</div>
	<asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-info"
		runat="server" />
	<asp:HiddenField ID="hf1" runat="server"  />
	<asp:HiddenField ID="hf2" runat="server" />
</div>

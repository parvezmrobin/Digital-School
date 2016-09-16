<%@ Page Title="Gallery" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Gallery.aspx.cs" Inherits="Digital_School.Admin.Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="panel panel-primary col-md-6">
			<p class="panel-heading" style="font-size: xx-large">Choose Album</p>
			<div class="panel-body">
				<div runat="server" id="divAlbum" class="list-group pre-scrollable"></div>
				<div class="col-md-12 col-lg-12">
					<asp:Button Text="Remove" ToolTip="Remove selected album" ID="btnRemoveAlbum" 
						OnClick="btnRemoveAlbum_Click" CssClass="btn btn-danger" runat="server" 
						OnClientClick="return confirm('Are sure to delete this album?');" />
				</div>
			</div>
		</div>
		<div class="panel panel-primary col-md-6">
			<p class="panel-heading" style="font-size: xx-large">Manage Images</p>
			<div class="panel-body">
				<div>
					<div class="pre-scrollable list-group col-sm-12" runat="server" id="divImages"></div>
					<div class="col-sm-12">
						<asp:Button Text="Remove" CssClass="btn btn-danger" ToolTip="Remove Selected Images"
							OnClick="Unnamed_Click" OnClientClick="return confirm('Are sure to delete this image?');"
							runat="server" />
					</div>
				</div>
				<div class="form-horizontal">
					<div class="form-group">
						<asp:Label runat="server" AssociatedControlID="fuImages" CssClass="col-md-4 control-label">Upload New</asp:Label>
						<div class="col-md-6">
							<asp:FileUpload runat="server" ID="fuImages" AllowMultiple="true" CssClass="form-control" />
						</div>
						<asp:Button Text="Upload" ToolTip="Upload Selected Images" OnClick="btnUpload_Click"
							CssClass="btn btn-info" runat="server" />
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

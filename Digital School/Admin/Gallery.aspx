<%@ Page Title="Gallery" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Gallery.aspx.cs" Inherits="Digital_School.Admin.Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		.panel {
			border-color: transparent;
		}
	</style>

	<div class="row">
		<h2 class="text-info text-center">Manage Albums</h2>
		<hr />
		<div class="panel panel-primary col-md-6">
			<p class="panel-heading" style="font-size: xx-large">Create New Album</p>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<div class="col-md-8">
						<asp:TextBox runat="server" ID="txtNewAlbum" TextMode="SingleLine" placeholder="New Album Name"
							CssClass="form-control" />
					</div>
					<asp:Button Text="Create Album" runat="server" ID="btnCreateAlbum" CssClass="btn btn-success"
						OnClick="btnCreateAlbum_Click" />
				</div>
			</div>
			<p class="panel-heading" style="font-size: xx-large">Choose Album</p>
			<div class="panel-body">
				<div runat="server" id="divAlbum" class="list-group" style="overflow-y: auto"></div>
				<asp:Button Text="Remove" ToolTip="Remove selected album" ID="btnRemoveAlbum"
					OnClick="btnRemoveAlbum_Click" CssClass="btn btn-danger" runat="server"
					OnClientClick="return confirm('Are sure to delete this album?');" />
			</div>
		</div>
		<div class="panel panel-primary col-md-6">
			<p class="panel-heading" style="font-size: xx-large">Upload Image to Selected Album</p>
			<div class="panel-body form-horizontal">
				<div class="form-group">
					<div class="col-md-8">
						<asp:FileUpload accept=".jpg, .jpeg, .png, .bmp" runat="server" ID="fuImages" AllowMultiple="true"
							CssClass="form-control" style="max-width:280px" />
						
					</div>
					<asp:Button Text="Upload" ToolTip="Upload Selected Images" OnClick="btnUpload_Click"
						CssClass="btn btn-info" runat="server" />
				</div>
				
			</div>
		</div>
	</div>
	<div class="row">
		<br />
		<div class="panel panel-primary col-md-12" id="divImage" runat="server">
			<p class="panel-heading" style="font-size: xx-large">Existing Images</p>
			<div class="panel-body">
				<div>
					<div class="list-group col-sm-12" runat="server" id="divImages" style="overflow-y: auto;
						max-height: 500px">
					</div>
					<div class="col-sm-12">
					</div>
				</div>

			</div>
		</div>
	</div>
</asp:Content>

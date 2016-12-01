<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="Digital_School.Admin.EditPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#<%:editButton.ClientID%>').click(function () {
                $('#updating').val("Updating");
                $.ajax({
                    url: 'EditPost.asmx/UpdatePost',
                    data: {id:<%:Request.QueryString["postid"] %> ,title: $('#<%: postTitle.ClientID%>').val(), body: $('#<%: postBody.ClientID %>').val()},
                    method: 'post',
                    dataType: 'xml',
                    error: function (err) {
                        alert(err.responseText);
                    },
                    success: function (data) {
                        $('#updated').val("Updated");
                    }
                });
                return true;
            });
        });
    </script>--%>

    <style type="text/css">
        select.form-control {
			max-width: none;
		}
	</style>
    <div class="row ">
        <h3 style="color:cadetblue">Title</h3>
        <asp:TextBox ID="postTitle" CssClass="form-control" runat="server"  />
        <%--<h1 id="postTitle" runat="server" class="text-info" style="text-align: center" enableviewstate="true">Post Title</h1>--%>
        <hr />
        <h3 style="color: cadetblue">Summary</h3>
        
		<asp:TextBox ID="postSummary" CssClass="form-control" runat="server"  TextMode="MultiLine"/>
        <hr />
        <h3 style="color: cadetblue">Body</h3>
        
        <asp:TextBox ID="postBody" CssClass="form-control" runat="server" TextMode="MultiLine" />
        <%--<div class="col-md-8 col-sm-7 well" id="postBody" runat="server" style="text-align: justify"
            enableviewstate="true">
        </div>--%>
        <div class="col-sm-5 col-md-4">
            <asp:DropDownList ID="ddlCatagory" CssClass="form-control" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged" EnableViewState="true">
                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                <asp:ListItem Text="News" Value="1"></asp:ListItem>
                <asp:ListItem Text="Notice" Value="2"></asp:ListItem>
                <asp:ListItem Text="Speech" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <div id="PostList" runat="server" class="list-group">
            </div>
        </div>
        <%--<input type="button" id="editButton" runat="server" value="EditC" onserverclick="btnEdit_Click" />
        <input type="text" id="updating" />
        <input type="text" id="updated" />--%>
        <asp:Button ID="btnEdit" Text="Edit" CssClass="btn btn-default" runat="server" OnClick="btnEdit_Click"/>
		<asp:Button ID="btnAdd" Text="Add New" CssClass="btn btn-default" runat="server"
			OnClick="btnAdd_Click" />
    </div>
</asp:Content>

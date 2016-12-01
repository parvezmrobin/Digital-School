<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Digital_School.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$('#menuAbout').attr('class', 'active');
		});
	</script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            //$('#history').text("sd");
            $.ajax({
                url: 'LoadHistory.asmx/jsonRead',
                data: {},
                method: 'post',
                dataType: 'xml',
                error: function (err) {
                    alert(err.responseText);
                },
                success: function (data) {
                    var xml = $(data);
                    $('#history').text(xml.find('Value').text());
                }
            });
        });
    </script>--%>
	<div class="row">

		<div class="col-sm-6 panel panel-primary">
			<div class="panel-heading">History</div>
			<div class="panel-body">
                <asp:TextBox ID="txtHistory" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" BorderColor="Transparent" BackColor="Transparent" BorderStyle="None"/>
				<%--a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n
				o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b
				c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p
				q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d
				e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r
				s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f
				g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t
				u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h
				i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v
				w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j
				k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x
				y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l
				m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z
				a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n
				o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b
				c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p
				q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d
				e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r
				s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f
				g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t
				u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h
				i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v
				w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j
				k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x
				y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l
				m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z
				a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n
				o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b
				c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p
				q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d
				e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r
				s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f
				g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t
				u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h
				i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v
				w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j
				k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x
				y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l
				m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z
				a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n
				o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b
				c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p
				q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d
				e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r
				s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f
				g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t
				u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h
				i j k l m n o p q r s t u v w x y z --%>
			</div>
		</div>

		<div class="col-sm-6">
			<div class="panel panel-primary">
				<div class="panel-body" id="speeches" runat="server">
				</div>
			</div>
		</div>
	</div>
</asp:Content>

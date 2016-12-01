<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHistoryContact.aspx.cs" Inherits="Digital_School.Admin.EditHistoryContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Wizard ID="historyContactWiz" runat="server" CssClass="table" DisplaySideBar="false" StepNextButtonText="Contact" StepPreviousButtonText="History" StartNextButtonText="Contact" FinishPreviousButtonText="History" FinishCompleteButtonStyle-CssClass="hidden" StepPreviousButtonStyle-CssClass="btn btn-default" StepNextButtonStyle-CssClass="btn btn-default" StartNextButtonStyle-CssClass="btn btn-default" FinishPreviousButtonStyle-CssClass="btn btn-default">
        <WizardSteps>
            <asp:WizardStep>
                <asp:TextBox ID="history" runat="server" TextMode="MultiLine" CssClass="form-control" />
                <asp:Button ID="editButton" Text="Edit" runat="server" OnClick="editButton_Click" CssClass="btn btn-default" />
            </asp:WizardStep>
        </WizardSteps>
        <WizardSteps>
            <asp:WizardStep>
                <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyBezq20FEQ48YlxQQZltgWntzJBVPY7G-Q"></script>
                <script type="text/javascript">
                    $(document).ready(function () {

                        $.ajax({
                            url: 'LoadLatLong2.asmx/jsonRead',
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

                            }
                        });



                        $('#btntemp').click(function () {

                            $.ajax({
                                url: 'LoadLatLong2.asmx/jsonWrite',
                                data: { history: $('#txtLattitude').val(), history2: $('#txtLongitude').val(), history3: $('#txtSupport').val(), history4: $('#txtContact').val() },
                                method: 'post',
                                dataType: 'xml',
                                error: function (err) {
                                    alert(err.responseText);
                                },
                                success: function (data) {

                                }
                            });
                            initialize();
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


                <h2>Contact Info</h2>

                <div class="row" id="divContact">
                    <div class=" col-sm-6">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control" />
                        <%-- <h2>Digital School</h2>
            CSE Discipline,<br />
            Khulna University,<br />
            Khulna.--%>
                        <asp:Button ID="editContact" Text="Edit" runat="server" OnClick="editContact_Click" CssClass="btn btn-default" />
                        <hr />
                        <address>
                            <strong>Support:</strong>
                            <input type="text" id="txtSupport" class="form-control" />
                            <br />
                            <strong>Contact No:</strong>
                            <input type="text" id="txtContact" class="form-control" />
                        </address>
                        <br />
                        <hr />
                        <%-- <address>
                <strong>Support:</strong>   <a href="mailto:DigitalSchool@example.com">Support@example.com</a><br />
                <strong>Contact No:</strong> 01xxx-xxxxxx
            </address>--%>
                        <strong>Lattitude:</strong>
                        <input type="text" id="txtLattitude" class="form-control" />
                        <br />
                        <strong>Longitude:</strong>
                        <input type="text" id="txtLongitude" class="form-control" />
                        <br />
                        <input type="button" id="btntemp" value="Edit" class="btn btn-default" />
                    </div>
                    <div class="col-sm-6">
                        <div id="map" style="height: 400px"></div>
                    </div>
                </div>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>

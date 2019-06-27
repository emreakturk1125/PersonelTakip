B<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PTS2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/daterangepicker.css" rel="stylesheet" />
    <link href="css/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <link href="css/alertify.min.css" rel="stylesheet" />
    <link href="css/alertify.core.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/validator.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrapValidator.min.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/alertify.min.js"></script>

    <script type="text/javascript">

        $(document).ready()
        {  // Wait until the page has finished loading
            if ($(".ProgressBar"))  // Detect the element with class ProgressBar
            {
                $(".ProgressBar").hide();  // If found, set it to be display:none;
            }
        }

        function getConfirmation() {
            var retVal = confirm("Do you want to continue ?");
            if (retVal == true) {
                alert("User wants to continue!");
                return true;
            } else {
                alert("User does not want to continue!");
                return false;
            }
        }
    </script>

    <style type="text/css">
        .tbl tr {
            height: 30px;
        }
    </style>
</head>
<body>
    <div class="ProgressBar">
        <h2>Yetkili Sayfaya Yönlendiriliyorsunuz...</h2>
        <div class="progress">
            <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%;">
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="tbl" align="center">
            <table style="width: 500px; align-content: center; height: 30px">
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Lblemailgonder" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2>Yetkili Sayfaya Yönlendiriliyorsunuz...</h2>
                        <div class="progress">
                            <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%;">
                            </div>
                        </div>
                    </td>

                </tr>
                <tr>
                    <td style="width: 50%">fghfgh</td>
                    <td>
                        <asp:TextBox ID="Tbemail" runat="server"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td>

                        <asp:Button ID="btnSifre" Text="Şifre Üret" runat="server" OnClick="btnSifre_Click" />

                    </td>
                    <td>

                        <asp:TextBox ID="txtUret" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div class="dropdown">
                            <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                Dropdown
    <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                <li><a href="#">Action</a></li>
                                <li><a href="#">Another action</a></li>
                                <li><a href="#">Something else here</a></li>
                                <li><a href="#">Separated link</a></li>
                            </ul>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <%--<a href="#"  onclick="getConfirmation();" ><span class="glyphicon glyphicon-edit"></span>Güncelle</a>--%>
                        <%--<asp:Button ID="Button1" runat="server" Text="Button" onclick="getConfirmation();" />--%>
                        <input type="button" value="Click Me" onclick="getConfirmation();" />
                    </td>
                </tr>

                </td>
            </tr>
            </table>
        </div>
    </form>
</body>

</html>

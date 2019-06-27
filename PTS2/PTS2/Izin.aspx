<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Izin.aspx.cs" Inherits="PTS2.Izin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="img/users.ico" rel="shortcut_icon" />

    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/default.min.css" rel="stylesheet" />
    <link href="css/alertify.min.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/moment-with-locales.js"></script>
    <script src="js/validator.js"></script>
    <script src="js/bootstrap-datetimepicker.js"></script>
    <script src="js/alertify.min.js"></script>
    <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <style type="text/css">
        .kendiyazdigimCSS {
            margin-left: 20px;
        }

        .container {
            margin-bottom: 20px;
            margin-top: 20px;
        }

        .kendiyazdigimCSS td {
            padding: 2px;
        }

        .tablo {
            width: 325px;
        }
        .btn{
            margin-bottom:10px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            debugger;
            $('#datetimepicker1').datetimepicker(
                //{
                //format: 'DD.MM.YYYY'
                //}
            );
            $('#datetimepicker2').datetimepicker(
                //{
                //format: 'DD.MM.YYYY'
                //}
            );
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <div class=" container">
            <div>
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">İzin Kayıt</a></li>
                </ul>
            </div>
        </div>

        <div class="row">
            <div class='col-md-3 col-md-offset-2'>
                <div class=" container">
                    <table class="kendiyazdigimCSS">

                        <tr>
                            <td style="width: 25%; padding-bottom: 20px"><b>Personel AdSoyad:</b></td>
                            <td style="padding-bottom: 20px; padding-left: 5px; color: #d43f3a">
                                <asp:Label ID="lblPersonelAdi" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 25%; padding-bottom: 20px"></td>
                            <td  class="btn">
                                <div class="dropdown">
                                    <button class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">
                                        Kişisel Ayarlar
                                     <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <%--<li id="btnGorunurluk" visible="false" runat="server"><a href="PersonelGüncelle.aspx?personelID=<%#Eval("personelID") %>">Bilgileri Güncelle</a></li>--%>
                                        <li><a href="KullaniciIzinDurumu.aspx?personelID=<%#Eval("personelID") %>">İzin Durumu</a></li>
                                        <li><a href="#">Bilgileri Güncelle</a></li>
                                      
                                        
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-bottom: 20px">İzin Başlangıç:</td>
                            <td>
                                <%--<div class="row">
                            <div class='col-md-3 '>--%>
                                <div class="form-group">
                                    <div class='input-group date' id='datetimepicker1' style="width: 150px">
                                        <asp:TextBox ID="txtBaslangicTarihi" CssClass="form-control" data-format="dd.MM.yyyy" placeholder="Başlangıç Tarihi.." runat="server" Width="140px" required></asp:TextBox>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>

                                </div>
                                <%--</div>
                        </div>--%>

                            </td>

                        </tr>
                        <%-- <tr>
                <td>İzin Bitiş Tarihi:</td>
                <%--<td>

                    <asp:TextBox ID="txtBitisTarihi" CssClass="form-control"  data-format="dd.MM.yyyy" placeholder="Bitiş Tarihi.." runat="server" Width="140px"></asp:TextBox>

                </td>
            </tr>--%>
                        <tr>
                            <td style="width: 25%; padding-bottom: 20px">İzin Bitiş:</td>
                            <td>

                                <div class="form-group">
                                    <div class='input-group date' id='datetimepicker2' style="width: 150px">
                                        <asp:TextBox ID="txtBitisTarihi" CssClass="form-control" data-format="dd.MM.yyyy" placeholder="Bitiş Tarihi.." runat="server" Width="140px" required></asp:TextBox>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>

                                </div>

                            </td>

                        </tr>

                        <tr>
                            <td style="width: 25%">İzin Türü:</td>
                            <td>

                                <asp:DropDownList ID="ddlIzinTuru" runat="server" AppendDataBoundItems="true" required>
                                </asp:DropDownList>

                            </td>

                        </tr>

                        <tr>
                            <td style="width: 25%">Açıklama:</td>
                            <td style="padding-top: 20px">

                                <asp:TextBox ID="txtboxAciklama" runat="server" Height="97px" TextMode="MultiLine" Width="235px"></asp:TextBox>

                            </td>

                        </tr>


                        <tr>
                            <td></td>
                            <td>

                                <%-- <asp:Panel ID="pnlGeri" runat="server" Visible="false" Width="66px">--%>
                                <%-- <a href="admin.aspx">
                                         <button id="Button1" class="btn btn-success" runat="server" visible="false"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button>
                                         </a>--%>
                                <%-- </asp:Panel>--%>

                                <a href="IzinListesi.aspx">
                                    <button id="btnGERİ" type="button" visible="false" class="btn btn-success" runat="server"><span class="glyphicon glyphicon-arrow-left"></span>Geri</button>
                                </a>

                                <asp:Button ID="btnCıkış" Text=" Güvenli Çıkış" CssClass="btn btn-danger" runat="server" OnClick="btnCıkış_Click" Visible="false" />
                                <asp:Button ID="btnEkle" runat="server" CssClass="btn btn-primary" Text="İzin Ekle" OnClick="btnEkle_Click" />



                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td class="tablo">
                               
                                <asp:Literal ID="LiteralGuncelleme" runat="server" visible="false" ></asp:Literal>
                            </td>
                        </tr>


                    </table>
                </div>
            </div>
        </div>


    </form>
</body>
</html>

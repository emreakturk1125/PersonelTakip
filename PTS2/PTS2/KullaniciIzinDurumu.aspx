<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciIzinDurumu.aspx.cs" Inherits="PTS2.KullaniciIzinListesi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.min.js"></script>
    <link href="css/bootstrap.css" rel="stylesheet" />
     <link href="css/footable.min.css" rel="stylesheet" />
    <style type="text/css">
        .ustkısım {
            margin-bottom: 20px;
            margin-top: 20px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class=" container">
            <div class="ustkısım">
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">Personel İzin Durumu</a></li>
                </ul>

            </div>
            <a href="Izin.aspx">
                    <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button>

                </a>
            <%--<div class="list-group">
                <a href="#" class="list-group-item active">Cras justo odio
                </a>
                <a href="#" class="list-group-item">Dapibus ac facilisis in</a>
                <a href="#" class="list-group-item">Morbi leo risus</a>
                <a href="#" class="list-group-item">Porta ac consectetur ac</a>
                <a href="#" class="list-group-item">Vestibulum at eros</a>
            </div>--%>
              <div class="list-group" style="margin-top:20px">
                <%--<table id="example" class="footable table table-bordered">--%>
                <table id="example" class="footable table table-bordered">
                    <thead>
                        <tr role="row">
                            <th style="width: 5%">AD</th>
                            <th style="width: 5%">SOYAD</th>
                            <th style="width: 7%">BÖLÜM</th>
                            <th style="width: 10%">İZİN BAŞ.</th>
                            <th style="width: 10%">İZİN BİT.</th>
                            <th style="width: 10%">İZİN TÜRÜ</th>
                            <th style="width: 10%">AÇIKLAMA</th>
                            <th style="width: 8%">DURUMU</th>
                            <th style="width: 10%">ONAYLAYAN</th>
                            <th style="width: 10%">ONAY TAR.</th>
                            <th style="width: 10%">İŞLEM TAR.</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="dtIzinlerDurumListesi" runat="server">

                            <ItemTemplate>
                                <tr>
                                    <td style="width: 5%">
                                        <%#Eval("ad") %>
                                    </td>
                                    <td style="width: 5%">
                                        <%#Eval("soyad") %>
                                    </td>
                                    <td style="width: 7%">
                                        <%#Eval("bolumAdi") %>
                                    </td>
                                    <td style="width: 10%">
                                        <%#Eval("baslamaTarihi") %>
                                    </td>
                                    <td style="width: 10%">
                                        <%#Eval("bitisTarihi") %>
                                    </td>
                                    <td style="width: 10%">
                                     <%--veritabanında boş olursa bu kısım hata verir--%>
                                    <%# PTS2.Web.Utilities.EnumExtensionMethods.GetDescription((PTS2.Common.Enumlar.IzinTipi)Convert.ToInt32( Eval("izinTuru"))) %>
                                    </td>
                                    <td style="width: 10%">
                                        <%#Eval("aciklama") %>
                                    </td>
                                    <td style="width: 8%">
                                        <%# PTS2.Web.Utilities.EnumExtensionMethods.GetDescription((PTS2.Common.Enumlar.IzinDurum)Convert.ToInt32( Eval("durum"))) %>
                                    </td>
                                    <td style="width: 10%">
                                        <%#Eval("onaylayan") %>
                                    </td>
                                    <td style="width: 10%">
                                        <%#Eval("onayTarihi") %>
                                    </td>
                                    <td style="width: 10%">
                                        <%#Eval("islemTarihi") %>
                                    </td>
                                    

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

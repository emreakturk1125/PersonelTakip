<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonelListe.aspx.cs" Inherits="PTS2.data" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Personel Liste Sayfası</title>
    <link href ="img/users.ico" rel="shortcut_icon"/>
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-checkbox.css" rel="stylesheet" />

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/bootstrap-checkbox.js"></script>
    <link href="css/footable.min.css" rel="stylesheet" />
    <style type="text/css">
        .ustkısım {
            margin-bottom: 20px;
            margin-top: 20px;
        }

        .btn {
            margin-bottom: 10px;
        }
    </style>
    <script type="text/javascript">

        function btnSelete_Click() {
            var strconfirm = confirm("Are you sure you want to delete?");
            if (strconfirm == true) {
                return true;
            }
        }


        $(document).ready(function () {
            $('#example').DataTable();
        });

        function AddContact(personelId) {
            var data = { personelId: personelId };
            $.ajax({
                type: "POST",
                url: "/WebMethods.aspx/EngelleKaldir",
                data: data,
                contentType: "application/json",
                dataType: "json",
                error: OnAjaxError,
                success: OnAddContactSuccess
            });
        }

        function addOnClick(control, personelId) {
            $(control).attr('onchange', 'AddContact(' + personelId + ')');
        }

        function OnAddContactSuccess(data) {
            alert('Başarılı bir şekilde gerçekleştirildi.');
        }
        function OnAjaxError(data) {
            alert('Hata oluştu gardaş.');
        }
    </script>


</head>
<body>


    <form id="form1" runat="server">
        <div class="container">
            <div class="ustkısım">
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#" aria-controls="admin" role="tab" data-toggle="tab">Personel Liste</a></li>
                </ul>
            </div>
        </div>
        <!-- Tab panes -->
        <div class="container">
            <div class="tab-content">

                <div role="tabpanel" class="tab-pane active" id="home">
                </div>

                <div role="tabpanel" class="tab-pane" id="profile">
                </div>


            </div>
            <div class="btn">

                <div class="btn-group">
                    <button type="button" class="btn btn-primary"><span class="glyphicon glyphicon-plus"></span> Kayıt İşlemleri</button>
                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
                        <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="PersonelEkle.aspx">Personel Ekle</a></li>
                        <li><a href="BolumEkle.aspx">Personel Bölümü Ekle</a></li>
                    </ul>
                </div>

                <asp:Button ID="btnCikis" Text="Güvenli Çıkış" runat="server" CssClass="btn btn-danger" OnClick="btnCikis_Click" />
                <a href="Admin.aspx">
                    <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button>

                </a>

                <%--<asp:Button ID="btnCikis" Style="margin-left: 8px" Text="Güvenli Çıkış" runat="server" CssClass="btn btn-danger" OnClick="btnCikis_Click" />--%>
            </div>

           

            <table id="example" class="display  footable table table-bordered">
                <thead>
                    <tr role="row">
                        <th style="width: 13%">AD</th>
                        <th style="width: 13%">SOYAD</th>
                        <th style="width: 13%">POZİSYON</th>
                        <th style="width: 13%">EMAİL</th>
                        <th style="width: 13%">TEL</th>
                        <th style="width: 20%">DÜZENLE</th>


                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtMyList" runat="server" OnItemDataBound="dtMyList_ItemDataBound" OnItemCommand="dtMyList_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 13%">
                                    <%#Eval("ad") %>
                                </td>
                                <td style="width: 13%">
                                    <%#Eval("soyad") %>
                                </td>
                                <td style="width: 13%">
                                    <%#Eval("bolumAdi") %>
                                </td>
                                <td style="width: 13%">
                                    <%#Eval("email") %>
                                </td>
                                <td style="width: 13%">
                                    <%#Eval("tel") %>
                                </td>
                                <td style="width: 20%" class="col-md-4">

                                    <a onclick="return confirm('Silmek İstiyormusunuz ?')" href="PersonelListe.aspx?personelID=<%#Eval("personelID") %>&islem=sil"><span class="glyphicon glyphicon-trash"></span>Sil</a>
                                    <a href="PersonelGüncelle.aspx?personelID=<%#Eval("personelID") %>"><span class="glyphicon glyphicon-edit"></span>Güncelle</a>
                                    <%-- <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("personelID") %>' />--%>
                                    <asp:LinkButton ID="lbEngelle" CommandName="Engelle" runat="server" CommandArgument='<%#Eval("personelID") %>'><span id="spanEngelle" runat="server" class="glyphicon glyphicon-ban-circle"></span>Engelle</asp:LinkButton>
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <br />
    </form>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="PTS2.admin" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Admin Sayfası</title>
    <link href ="img/users.ico" rel="shortcut_icon"/>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/dataTables.bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" />

    <style type="text/css">
        .takvim td {
            padding: 2px;
        }

        .takvim {
            margin-left: 50px;
        }
        .ustkısım{
            
            margin-bottom:20px;
            margin-top:20px; 
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblBilgi" Text="Bu Bölümü görmek için yetkili değilsiniz..!!" runat="server" ForeColor="Red" Visible="false" />
        <asp:Panel ID="pnlYonetim" runat="server">
            
            <div class="container">

                <!-- Nav tabs -->
                <div class="ustkısım">
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#" aria-controls="admin" role="tab" data-toggle="tab">Admin Sayfası</a></li>
                    <%--<li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab"><a href="PersonelListe.aspx">Personel Liste</a></a></li>--%>
                </ul>
                </div>
                <!-- Tab panes -->
                <div class="tab-content">

                    <div role="tabpanel" class="tab-pane active" id="home">
                    </div>

                    <div role="tabpanel" class="tab-pane" id="profile">
                    </div>


                </div>
                
 

                <ul class="nav nav-pills nav-stacked panel panel-primary">
                    <li role="presentation" class="active" style="text-align: center">
                        <a href="#">Admin Yönetimi</a>
                    </li>
                    <li role="presentation">
                        <a href="PersonelListe.aspx">Personel Listesi</a>
                        <a href="IzinListesi.aspx">Personel İzin Listesi</a>
                    </li>
                </ul>

                <p>
                    <br />

                </p>


            </div>

        </asp:Panel>
    </form>
</body>
</html>

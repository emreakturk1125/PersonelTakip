<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BolumEkle.aspx.cs" Inherits="PTS2.PozisyonEkle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bölüm Ekle Sayfası</title>

    <link href="css/bootstrap.css" rel="stylesheet" />
   <link href ="img/users.ico" rel="shortcut_icon"/>
    <link href="css/footable.min.css" rel="stylesheet" />
     <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
      
    <script src="js/jquery.min.js"></script>
     <script src="js/validator.js"></script>   
    <script src="js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#tblCustomers').footable();
        });
    </script>
    <style type="text/css">
        /*.kendiyazdigimCSS {
            margin-left: 230px;
        }*/

        .kendiyazdigimCSS td {
            padding: 10px;
        }

     
       .container{
             margin-bottom:20px;
             margin-top:20px;
        }

         .error{
           
            color :#d43f3a;
        }
 
    </style>

  <%--  <script type="text/javascript">

        $(document).ready(function () {

            $('.error').hide();
            $('#btnBolumEKle').click(function (event) {

                var data = $('#TxtboxBolumAdı').val();
               

                var len = data.length;
                


                if (len < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }

                
            });
        });
    </script>--%>
 
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div>
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">Personel Bölümü Ekle</a></li>
                </ul>
            </div>
        </div>
     
        <div class="row">
            <%--<div class="col-md-3"></div>--%>
            <div class="col-md-4 col-md-offset-3">
                <table class="kendiyazdigimCSS">
                   
                    <tr>
                        <td>Bölümü:</td>
                        <td>
                            <asp:TextBox ID="TxtboxBolumAdı" CssClass="form-control" placeholder="Bölümü Adı Giriniz" runat="server" Width="235px" required></asp:TextBox>
                           <%-- <span class="error">Bölüm boş bırakılamaz..!</span>--%>
                        </td>
                    </tr>
                    <%--<tr>
                  <td></td>
                  <td></td>
                    </tr>--%>
                    <tr>
                        <td>
                            <p>&nbsp</p>
                        </td>
                        <td>
                            <div style="padding-bottom:10px;">
                            <a href="PersonelListe.aspx">
                                <button  type="button" class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button>
                            </a>
                            <asp:Button ID="btnBolumEKle" runat="server" CssClass="btn btn-primary" Text="Ekle" OnClick="btnBolumEKle_Click" />
                                </div>
                        </td>
                    </tr>
                </table>
                <table id="tblCustomers" class="footable table table-bordered">
                     <%--<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="rpBolumler_ItemDataBound">--%>
                    <asp:Repeater ID="rpBolumler" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 40%">
                                    <%#Eval("bolumAdi") %>
                                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("bolumID") %>' />
                                </td>
                                <td style="width: 10%">
                                   <%-- <asp:Panel ID="pnlGuncelle" runat="server">--%>
                                         <a href="BolumDuzenle.aspx?bolumID=<%#Eval("bolumID")%>"><span class="glyphicon glyphicon-edit"></span>Düzenle</a>
                                  <%--  </asp:Panel>--%>
                                   
                                </td>
                                <td style="width: 10%">
                                    <%--<asp:Panel ID="pnlSil" runat="server">--%>
                                        <a href="BolumEkle.aspx?bolumID=<%#Eval("bolumID")%>&islem=sil"><span class="glyphicon glyphicon-trash"></span>Sil</a>
                                   <%-- </asp:Panel>    --%>                              
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <%--<div class="col-md-3"></div>--%>
        </div>
       
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonelGüncelle.aspx.cs" Inherits="PTS2.PersonelGüncelle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personel Güncelle Sayfası</title>
    <link href ="img/users.ico" rel="shortcut_icon"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
     <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/default.min.css" rel="stylesheet" />
       <link href="css/alertify.min.css" rel="stylesheet" />
    <script src="js/jquery-2.1.1.min.js"></script>
    <script src="js/dataTables.bootstrap.min.js"></script>
    <script src="js/moment-with-locales.js"></script>
    <script src="js/bootstrap-datetimepicker.js"></script>
     <script src="js/alertify.min.js"></script>
   


    <style type="text/css">
        /*.kendiyazdigimCSS {
            margin-left: 230px;
        }*/

        .kendiyazdigimCSS td {
            padding: 2px;
        }

       .container{
             margin-bottom:20px;
            margin-top:20px;
        }
    </style>

     

    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker(
    {
        format: 'DD.MM.YYYY'
    });
        });
    </script>

    <script type="text/javascript">

        var zChar = new Array(' ', '(', ')', '-', '.');
        var maxphonelength = 13;
        var phonevalue1;
        var phonevalue2;
        var cursorposition;

        function ParseForNumber1(object) {
            phonevalue1 = ParseChar(object.value, zChar);
        }
        function ParseForNumber2(object) {
            phonevalue2 = ParseChar(object.value, zChar);
        }

        function backspacerUP(object, e) {
            if (e) {
                e = e
            } else {
                e = window.event
            }
            if (e.which) {
                var keycode = e.which
            } else {
                var keycode = e.keyCode
            }

            ParseForNumber1(object)

            if (keycode >= 48) {
                ValidatePhone(object)
            }
        }

        function backspacerDOWN(object, e) {
            if (e) {
                e = e
            } else {
                e = window.event
            }
            if (e.which) {
                var keycode = e.which
            } else {
                var keycode = e.keyCode
            }
            ParseForNumber2(object)
        }

        function GetCursorPosition() {

            var t1 = phonevalue1;
            var t2 = phonevalue2;
            var bool = false
            for (i = 0; i < t1.length; i++) {
                if (t1.substring(i, 1) != t2.substring(i, 1)) {
                    if (!bool) {
                        cursorposition = i
                        bool = true
                    }
                }
            }
        }

        function ValidatePhone(object) {

            var p = phonevalue1

            p = p.replace(/[^\d]*/gi, "")

            if (p.length < 3) {
                object.value = p
            } else if (p.length == 3) {
                pp = p;
                d4 = p.indexOf('(')
                d5 = p.indexOf(')')
                if (d4 == -1) {
                    pp = "(" + pp;
                }
                if (d5 == -1) {
                    pp = pp + ")";
                }
                object.value = pp;
            } else if (p.length > 3 && p.length < 7) {
                p = "(" + p;
                l30 = p.length;
                p30 = p.substring(0, 4);
                p30 = p30 + ")"

                p31 = p.substring(4, l30);
                pp = p30 + p31;

                object.value = pp;

            } else if (p.length >= 7) {
                p = "(" + p;
                l30 = p.length;
                p30 = p.substring(0, 4);
                p30 = p30 + ")"

                p31 = p.substring(4, l30);
                pp = p30 + p31;

                l40 = pp.length;
                p40 = pp.substring(0, 8);
                p40 = p40 + "-"

                p41 = pp.substring(8, l40);
                ppp = p40 + p41;

                object.value = ppp.substring(0, maxphonelength);
            }

            GetCursorPosition()

            if (cursorposition >= 0) {
                if (cursorposition == 0) {
                    cursorposition = 2
                } else if (cursorposition <= 2) {
                    cursorposition = cursorposition + 1
                } else if (cursorposition <= 5) {
                    cursorposition = cursorposition + 2
                } else if (cursorposition == 6) {
                    cursorposition = cursorposition + 2
                } else if (cursorposition == 7) {
                    cursorposition = cursorposition + 4
                    e1 = object.value.indexOf(')')
                    e2 = object.value.indexOf('-')
                    if (e1 > -1 && e2 > -1) {
                        if (e2 - e1 == 4) {
                            cursorposition = cursorposition - 1
                        }
                    }
                } else if (cursorposition < 11) {
                    cursorposition = cursorposition + 3
                } else if (cursorposition == 11) {
                    cursorposition = cursorposition + 1
                } else if (cursorposition >= 12) {
                    cursorposition = cursorposition
                }

                var txtRange = object.createTextRange();
                txtRange.moveStart("character", cursorposition);
                txtRange.moveEnd("character", cursorposition - object.value.length);
                txtRange.select();
            }

        }

        function ParseChar(sStr, sChar) {
            if (sChar.length == null) {
                zChar = new Array(sChar);
            }
            else zChar = sChar;

            for (i = 0; i < zChar.length; i++) {
                sNewStr = "";

                var iStart = 0;
                var iEnd = sStr.indexOf(sChar[i]);

                while (iEnd != -1) {
                    sNewStr += sStr.substring(iStart, iEnd);
                    iStart = iEnd + 1;
                    iEnd = sStr.indexOf(sChar[i], iStart);
                }
                sNewStr += sStr.substring(sStr.lastIndexOf(sChar[i]) + 1, sStr.length);

                sStr = sNewStr;
            }

            return sNewStr;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
           
             
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#">Güncelle</a></li>
                    </ul>
            
        </div>
        
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <table class="kendiyazdigimCSS">
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblEmailKontrol" runat="server"  ForeColor="#d43f3a" Style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlRol" runat="server" Visible="false">
                   <tr>
                        <td>Rol:</td>

                        <td>
                            <asp:DropDownList ID="ddlRolGuncelle" runat="server" CssClass="form-control" Width="235px" AutoPostBack="True" required>
                            </asp:DropDownList>
                             
                        </td>


                    </tr>
                    </asp:Panel>
                    <tr>
                        <td style="width: 25%">Adı:</td>
                        <td>
                            <asp:TextBox ID="TxtboxAdGuncelle" CssClass="form-control" placeholder="Adı Giriniz" runat="server" Width="235px" required></asp:TextBox>
                             
                        </td>

                    </tr>
                    <tr>
                        <td>Soyadı:</td>
                        <td>

                            <asp:TextBox ID="TxtboxsoyadGuncelle" CssClass="form-control" placeholder="Soyad Giriniz" runat="server" Width="235px" required></asp:TextBox>
                            
                        </td>
                    </tr>
                    <asp:Panel ID="pnlSifreGorunurluk" runat="server" Visible="false">
                    <tr>
                        <td>Eski Şifre:</td>
                        <td>
                            <asp:TextBox ID="TxtboxEskiSifreGuncelle"  CssClass="form-control" placeholder="Eski Şifrenizi Giriniz" runat="server" Width="235px" required/>  
                        </td>
                    </tr>
                     <tr>
                        <td>Yeni Şifre:</td>
                        <td>
                            <asp:TextBox ID="TxtboxYeniSifreGuncelle"  CssClass="form-control" placeholder="Yeni Şifrenizi Giriniz" runat="server" Width="235px" required/>  
                        </td>
                    </tr>
                     </asp:Panel>
                    <tr>
                        <td>Pozisyonu:</td>

                        <td>
                            <asp:DropDownList ID="ddlPozisyonGuncelle" runat="server" CssClass="form-control" Width="235px" AutoPostBack="True" required>
                            </asp:DropDownList>
                             
                        </td>


                    </tr>

                    <tr>
                        <td>E-Posta:</td>
                        <td>

                            <table>
                                <tr>
                                    <td style="width: 50%">
                                        <asp:TextBox ID="TxtboxepostaGuncelle" CssClass="form-control control-label" placeholder="E-Posta Giriniz" runat="server" Width="235px" required></asp:TextBox>
                                    </td>
                                    <td>
                                        <span>@</span>
                                    </td>
                                    <td style="width: 48%">
                                        <asp:DropDownList ID="ddlEmailGuncelleProviders" runat="server" AppendDataBoundItems="true" CssClass="form-control" required>
                                            <asp:ListItem Text="-Seçiniz-" Value=""></asp:ListItem>
                                            <asp:ListItem Text="hotmail.com" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="ismail.com" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="gmail.com" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                            </table>
                             
                    </tr>

                   <%-- <tr>
                        <td>Şifre:</td>
                        <td>

                            <asp:TextBox ID="TxtboxSifreGuncelle" CssClass="form-control" placeholder="Şifre Giriniz" runat="server" Width="235px" required></asp:TextBox>

                        </td>
                    </tr>--%>

                    <tr>
                        <td>Telefon:</td>
                        <td>

                            <asp:TextBox ID="TxtboxtelGuncelle" CssClass="form-control" placeholder="Telefon Giriniz" runat="server" Width="235px" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" name="txtInput" required></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>D. Tarihi:</td>
                    
                        <td>
                            <div class="row">
                                <div class='col-sm-6'>
                                    <div class="form-group">
                                        <div class='input-group date' id='datetimepicker1' style="width: 235px">
                                            <asp:TextBox ID="TxtboxdogumtarihiGuncelle" CssClass="form-control" placeholder="Doğum Tarihi Giriniz" runat="server" required></asp:TextBox>

                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                     
                                </div>
                            </div>

                        </td>
 
                    </tr>
 
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td>
                            <a href="Izin.aspx">
                                <button id="btnGorunurluk1" type="button" class="btn btn-success" visible="false" runat="server"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button></a>
                            <a href="PersonelListe.aspx">
                                <button id="btnGorunurluk2" type="button" class="btn btn-success" visible="false" runat="server"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button></a>
                            <asp:Button ID="btnGuncelle" runat="server" CssClass="btn btn-primary" Text="Güncelle" OnClick="btnGuncelle_Click" />


                        </td>
                    </tr>

                    <tr>
                        <td></td>
                        <td class="tablo"></td>
                    </tr>


                </table>
            </div>
        </div>
    </form>
</body>
</html>

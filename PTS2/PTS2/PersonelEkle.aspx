<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonelEkle.aspx.cs" Inherits="PTS2.PersonelEkle" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Personel Ekle Sayfası</title>
   <link href ="img/users.ico" rel="shortcut_icon"/>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/default.min.css" rel="stylesheet" />
    <link href="css/alertify.min.css" rel="stylesheet" />
    <script src="js/dataTables.bootstrap.min.js"></script>
    <script src="js/moment-with-locales.js"></script>     
    <script src="js/validator.js"></script>
     <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap-datetimepicker.js"></script>
    <script src="js/alertify.min.js"></script>
    

    <style type="text/css">
       
        .kendiyazdigimCSS td {
            padding: 2px;
        }

       .container{
             margin-bottom:20px;
            margin-top:20px;
        }

        .error{
           
            color :#d43f3a;
        }
       
    </style>

      
   
   <%-- <script type="text/javascript">
       
        $(document).ready(function () {
            
            $('.error').hide();
            $('#btnEkle').click(function (event) {

                var data = $('#TxtboxAd').val();
                var data1 = $('#Txtboxsoyad').val();
                var data2 = $('#ddlPozisyon').val();
                var data3 = $('#Txtboxeposta').val();
                var data4 = $('#Txtboxtel').val();
                var data5 = $('#Txtboxdogumtarihi').val();

                 
                var len = data.length;
                var len1 = data1.length;
                var len2 = data2.length;
                var len3 = data3.length;
                var len4 = data4.length;
                var len5 = data5.length;
                  

                if (len < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }
               
                if (len1 < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }

                if (len2 < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }

                if (len3 < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }

                if (len4 < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }

                if (len5 < 1) {
                    $('.error').show();
                    event.preventDefault();
                }
                else {
                    $('.error').hide();
                }

            });
        });
    </script>--%>

   
    <script type="text/javascript">
        $(function () {
            debugger;
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
    <form id="form1" runat="server" data-toggle="validator">
        <div class="container">

            <ul class="nav nav-tabs" role="tablist">

                <li role="presentation" class="active"><a href="#" aria-controls="admin" role="tab" data-toggle="tab">Personel Ekle</a></li>

            </ul>

        </div>
        <div class="col-md-3"></div>
        <div class="col-md-5">
            <asp:Panel ID="pnll" runat="server">
                <table class="kendiyazdigimCSS">
                    <tr>
                        <td></td>
                        <td>
                            <div>
                                <asp:Label ID="LblBilgi" runat="server"  ForeColor="#d43f3a"></asp:Label>
                            </div>
                        </td>
                    </tr>
                   

                    <tr>
                        <td>Adı:</td>
                        <td>
    <div style="width: 50%; float: left;">
    <asp:TextBox ID="TxtboxAd" CssClass="form-control" placeholder="Adı Giriniz" runat="server" Width="235px" required></asp:TextBox>
    </div>
                            
                            
 <%--<div style="float: right; width: 49.9%; padding-left: 40px">
    <span class="error">Ad boş bırakılamaz..!</span>
    </div>--%>
                        </td>


                    </tr>
                    
                    <tr>
                        <td>Soyadı:</td>
                        <td>

                            <asp:TextBox ID="Txtboxsoyad" CssClass="form-control" placeholder="Soyad Giriniz" runat="server" Width="235px" required></asp:TextBox>
                            

                        </td>
   <%-- <td>
    <span class="error">Soyad boş bırakılamaz..!</span>
    </td>--%>
                    </tr>
                    <tr>
                        <td>Pozisyonu:</td>

                        <td>
                            <asp:DropDownList ID="ddlPozisyon" runat="server" CssClass="form-control" Width="235px" AutoPostBack="True" required>
                            </asp:DropDownList>
                            
                        </td>
   <%-- <td>
    <span class="error">Pozisyon boş bırakılamaz..!</span>
    </td>--%>
                    </tr>

                    <tr>
                        <td>E-Posta:</td>
                        <td>

                            <table>
                                <tr>
                                    <td style="width: 50%">
                                        <asp:TextBox ID="Txtboxeposta" CssClass="form-control control-label" placeholder="E-Posta Giriniz" runat="server" Width="235px" required></asp:TextBox>
                                    </td>
                                   
                                    <td>
                                        <span>@</span>
                                    </td>
                                    <td style="width: 48%">
                                        <asp:DropDownList ID="ddlEmailProviders" runat="server" AppendDataBoundItems="true" CssClass="form-control" required>
                                            <asp:ListItem Text="-Seçiniz-" Value=""></asp:ListItem>
                                            <asp:ListItem Text="hotmail.com" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="ismail.com" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="gmail.com" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    
                                </tr>

                            </table>
    
                             </td>
                        <%--<td>
                        <span class="error">E-Posta boş bırakılamaz..!</span>
                        </td>--%>
                    </tr>

                    <tr>
                        <td>Telefon:</td>
                        <td>

                            <asp:TextBox ID="Txtboxtel" CssClass="form-control" placeholder="Telefon Giriniz" runat="server" Width="235px" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" name="txtInput" required></asp:TextBox>
                           
                        </td>
   
                    </tr>
                    
                    <tr>
                        
                        <td style="padding-bottom:20px">D. Tarihi:</td>
                        <td>
                            <div class="row">
                                <div class='col-sm-6'>
                                    <div class="form-group">
                                        <div class='input-group date' id='datetimepicker1' style="width: 235px">
                                            <asp:TextBox ID="Txtboxdogumtarihi" CssClass="form-control"  data-format="dd.MM.yyyy" placeholder="Doğum Tarihi Giriniz" runat="server" required></asp:TextBox>

                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                        </td>
   <%-- <td>
    <span class="error">D.T boş bırakılamaz..!</span>
    </td>--%>
                       
                    </tr>
                     
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                   
                    <tr>
                        <td></td>
                        
                        <td>
                            <a href="PersonelListe.aspx">
                                <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span> Geri</button></a>
                            <asp:Button ID="btnEkle" runat="server" CssClass="btn  btn-primary" Text="Ekle" OnClick="btnEkle_Click" />
                        </td>
                        <td></td>
                    </tr>
                    
                    <tr>
                        <td></td>
                        <td class="tablo"></td>
                    </tr>
                    
                </table>
             </asp:Panel>
        </div>
        <div class="col-md-4"></div>
    </form>
</body>
</html>

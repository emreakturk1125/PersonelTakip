<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PTS2.Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link href ="img/users.ico" rel="shortcut_icon"/>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Personel Giriş Sayfası</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    
     <script src="js/validator.js"></script>
</head>
<body style="background-image: url(img/background.png)">

    <div class="container">
        <div class="row">
            <p>
                <br />
            </p>
            <div class="col-md-4"></div>

            <div class="col-md-4">

                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align:center"><h2>Personel Kayıt Sistemi</h2></div>
                    <div class="panel-body">
                       <%-- <div class="page-header" style="text-align:center">
                            <h2>Personel Kayıt Sistemi</h2>
                        </div>--%>
                        <form id="form1" runat="server">



                            <div class="form-group">
                                <label for="exampleInputEmail1">E-Posta</label>

                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-user"></span></span>
                                    <table>
                                        <tr>
                                            <td style="width: 50%">
                                                <asp:TextBox ID="TextBoxemail" CssClass="form-control" placeholder="E-Posta" runat="server" required></asp:TextBox>
                                                <%--<asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="E-Posta" runat="server" type="email"  required></asp:TextBox>--%>
                                            </td>
                                            <td>
                                                <span class="form-control">@</span>
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

                                </div>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Şifre</label>
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-star"></span></span>
                                    <asp:TextBox ID="TextBoxsifre" CssClass="form-control" placeholder="Şifre" runat="server" TextMode="Password" required></asp:TextBox>
                                     
                                </div>
                            </div>
                            <div class="checkbox">
                                <label>

                                    <asp:CheckBox ID="Cbhatirla" runat="server" />Beni Hatırla
                                </label>
                                 </div>
                                <hr />

                                <a href="UyeOl.aspx">
                                <button type="button" class="btn btn-success"><span class="glyphicon glyphicon-plus-sign"></span> Üye Ol</button>
                                </a>
                               
                                <asp:Button ID="btnGiris" runat="server" CssClass="btn btn-primary" Text="Giriş" OnClick="btnGiris_Click" />
                               
                                <p>
                                    <br />
                                </p>
                             <asp:Label ID="lblUyari" runat="server"  ForeColor="#d43f3a"></asp:Label>
                        </form>
                    </div>
                    
                </div>

            </div>
            <div class="col-md-4"></div>
        </div>
    </div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

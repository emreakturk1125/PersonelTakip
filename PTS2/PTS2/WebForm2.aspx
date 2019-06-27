<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PTS2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="js/jquery.min.js"></script>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnl" runat="server">
        <table> 
          
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="ad"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="soyad"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="no"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="email"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                     
                </td>
                <td>
                    <asp:Button ID="btnekle" runat="server" Text="ekle" OnClick="btnekle_Click" />
                    <asp:Button ID="btnGuncelle" runat="server" Text="guncelle" OnClick="btnGuncelle_Click" />
                    <asp:Button ID="btnSil" runat="server" Text="sil" OnClick="btnSil_Click" />
                </td>
            </tr>
        </table>
            </asp:Panel>
    <div>
        
        
        
       
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        <div>
            <div class="progress">
  <div class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="min-width: 2em;">
    0%
  </div>
</div>
<div class="progress">
  <div class="progress-bar" role="progressbar" aria-valuenow="2" aria-valuemin="0" aria-valuemax="100" style="min-width: 2em; width: 2%;">
    2%
  </div>
</div>
        </div>
    </form>
</body>
</html>

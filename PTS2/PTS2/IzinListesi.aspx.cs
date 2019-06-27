using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PTS2.Common;
using System.Web.UI.HtmlControls;

namespace PTS2
{
    public partial class IzinListesi : System.Web.UI.Page
    {
        metodlar klas = new metodlar();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolId"].ToString() == "5")
            {
                //pnlVisbility.Visible = true;
                btnVisibilty.Visible = true;
            }
            PersonelGetir(null);
            

        }
        private void PersonelGetir(List<string> durumListe)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT dbo.Bolum.bolumAdi, dbo.Personel.ad, dbo.Personel.personelID, dbo.Personel.soyad, dbo.Izin.baslamaTarihi,dbo.Izin.aciklama,dbo.Izin.izinTuru, dbo.Izin.bitisTarihi, dbo.Izin.durum, dbo.Izin.islemTarihi, dbo.Izin.onaylayan, dbo.Izin.onayTarihi FROM  dbo.Bolum INNER JOIN dbo.Personel ON dbo.Bolum.bolumID = dbo.Personel.bolumID INNER JOIN dbo.Izin ON dbo.Personel.personelID = dbo.Izin.personelID where dbo.Personel.Aktif=1 and dbo.Personel.RolID IN (";

            //RolId sine göre onaylama yetksi oldugu bölümdeki kişileri getirir..
            string query = string.Empty;

            if (Session["RolId"] != null)
            {
                
                    //query = "SELECT dbo.Rol.RolID from dbo.Rol WHERE dbo.Rol.RolId>" + Session["RolId"].ToString();
                    query = "SELECT dbo.Rol.RolID from dbo.Rol WHERE dbo.Rol.RolId" + (Convert.ToInt32(Session["RolId"]) == 5 ? "!=5" : (">" + Session["RolId"].ToString()));
                
            }
            else
                Response.Redirect("/Login.aspx");

            SqlCommand cmdRol = new SqlCommand();
            cmdRol.CommandText = query;
            SqlConnection con = klas.baglan();
            cmdRol.Connection = con;
            SqlDataReader dr = cmdRol.ExecuteReader();
            string rolidleri = string.Empty;
            int count = 0;
            while (dr.Read())
            {
                if (dr["RolId"] != DBNull.Value)
                    rolidleri += dr["RolId"] + ",";
                count++;
            }
            dr.Close();

            if (count == 0)
            {
                dtIzinlerListesi.DataSource = null;
                dtIzinlerListesi.DataBind();
                return;
            }
            else if (count > 0)
            {
                rolidleri = rolidleri.Substring(0, rolidleri.Length - 1);
            }

            cmd.CommandText += rolidleri + ")";

            if (durumListe != null)
            {
                if (durumListe.Count > 0)
                {
                    cmd.CommandText += " and durum IN (";
                    for (int i = 0; i < durumListe.Count; i++)
                    {
                        cmd.CommandText += durumListe[i] + ",";
                    }
                    cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                    cmd.CommandText += ")";
                }
            }

            DataTable dtkullanıcı = klas.GetDataTable(cmd);
            dtIzinlerListesi.DataSource = dtkullanıcı;
            dtIzinlerListesi.DataBind();
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("personelID");
            Response.Redirect("Login.aspx");
        }

        protected void cbReddedilenler_CheckedChanged(object sender, EventArgs e)
        {

            DurumlariAl();
        }
        // Checbodaki seçililere göre getirme olayı
        private void DurumlariAl()
        {
            List<string> durumlar = new List<string>();
            if (cbReddedilenler.Checked)
            {
                durumlar.Add(((int)Enumlar.IzinDurum.REDDEDILDI).ToString());
            }
            if (cbOnaylananlar.Checked)
            {
                durumlar.Add(((int)Enumlar.IzinDurum.ONAYLANDI).ToString());
            }
            if (cbIslemdeOlanlar.Checked)
            {
                durumlar.Add(((int)Enumlar.IzinDurum.ISLEME_ALINDI).ToString());
            }
            PersonelGetir(durumlar);
        }

        protected void cbOnaylananlar_CheckedChanged(object sender, EventArgs e)
        {
            DurumlariAl();
        }

        protected void cbIslemdeOlanlar_CheckedChanged(object sender, EventArgs e)
        {
            DurumlariAl();
        }

        protected void dtIzinlerListesi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void dtIzinlerListesi_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }

      
        protected void lbOnayla_Click(object sender, EventArgs e)
        {
            //bool durumBool = false;
            if (IsPostBack)
            {
                LinkButton lbOnayla = (LinkButton)(sender);
                int personelID = Convert.ToInt32(lbOnayla.CommandArgument);
                SqlConnection baglanti = klas.baglan();
                SqlCommand cmd3 = new SqlCommand("update Izin set durum=2 where personelID=@personelID");
                cmd3.Connection = baglanti;
                cmd3.Parameters.AddWithValue("@personelID", personelID);
                cmd3.ExecuteNonQuery();
                lbOnayla.Text = "<span class=\"glyphicon glyphicon-remove\"></span>Onayı Kaldır";
            }
           
 
        }

        protected void lbReddet_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LinkButton lbOnayla = (LinkButton)(sender);
                int personelID = Convert.ToInt32(lbOnayla.CommandArgument);
                SqlConnection baglanti = klas.baglan();
                SqlCommand cmd3 = new SqlCommand("update Izin set durum=3 where personelID=@personelID");
                cmd3.Connection = baglanti;
                cmd3.Parameters.AddWithValue("@personelID", personelID);
                cmd3.ExecuteNonQuery();
                lbOnayla.Text = "<span class=\"glyphicon glyphicon-ok-circle\"></span>Red Kaldır";
            }
           
        }
        // linkButton a tıklayınca  update işlemi
        // HTML tarafı --> <asp:LinkButton ID="lbOnayla" Visible="true" CommandName="Onayla" onclick="lbOnayla_Click" CommandArgument='<%#Eval("personelID") %>' runat="server"><span id="spanOnayla" runat="server" class="glyphicon glyphicon-ok-circle"></span>Onayla</asp:LinkButton>
        //protected void lbReddet_Click(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        LinkButton lbOnayla = (LinkButton)(sender);
        //        int personelID = Convert.ToInt32(lbOnayla.CommandArgument);
        //        SqlConnection baglanti = klas.baglan();
        //        SqlCommand cmd3 = new SqlCommand("update Izin set durum=3 where personelID=@personelID");
        //        cmd3.Connection = baglanti;
        //        cmd3.Parameters.AddWithValue("@personelID", personelID);
        //        cmd3.ExecuteNonQuery();
        //        lbOnayla.Text = "<span class=\"glyphicon glyphicon-ok-circle\"></span>Red Kaldır";
        //    }

        //}

      
    }
}
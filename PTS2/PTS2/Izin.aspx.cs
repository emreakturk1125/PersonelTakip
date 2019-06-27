using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using PTS2.Common;

namespace PTS2
{
    public partial class Izin : System.Web.UI.Page
    {
        string personelID = "";
        metodlar klas = new metodlar();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["personelID"] == null)
                Response.Redirect("Login.aspx");
            if (Session["AdSoyad"] != null)
                lblPersonelAdi.Text = Session["AdSoyad"].ToString();
           
            if (Session["RolID"].ToString() == "5")
            {
                btnGERİ.Visible = true;
               
            }
            else
            {
                btnCıkış.Visible = true;
                LiteralGuncelleme.Visible = true;
                //btnGorunurluk.Visible = true;
            }
 

            if (!IsPostBack) // *** dropdownlist li enum kullanımı ***
            {


                //LiteralGuncelleme.Text = "<a href=\"PersonelGüncelle.aspx?personelID=" + Session["personelID"] + "\"><span class=\"glyphicon glyphicon-edit\"></span>Bilgilerini Güncelle</a>";
                LiteralGuncelleme.Text = "<a href=\"PersonelGüncelle.aspx?personelID=" + Session["personelID"] + "\">Bilgilerini Güncelle</a>";
                Array values = Enum.GetValues(typeof(Enumlar.IzinTipi));
                Array names = Enum.GetNames(typeof(Enumlar.IzinTipi));
            
                for (int i = 0; i < names.Length; i++)
                {
                    ddlIzinTuru.Items.Add(new ListItem(names.GetValue(i).ToString(), Convert.ToInt32(values.GetValue(i)).ToString()));
                }
                ddlIzinTuru.Items.Insert(0, new ListItem("Seçiniz", ""));
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {

            PTS2.Common.Enumlar.IzinDurum enm = new PTS2.Common.Enumlar.IzinDurum();

            SqlConnection con = klas.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Izin (baslamaTarihi,bitisTarihi,personelID,durum,islemTarihi,aciklama,izinTuru) values (@baslamaTarihi,@bitisTarihi,@personelID,@durum,@islemTarihi,@aciklama,@izinTuru)";
            cmd.Parameters.Add("@baslamaTarihi",txtBaslangicTarihi.Text);
            cmd.Parameters.Add("@aciklama", txtboxAciklama.Text);
            //<%# PTS2.Web.Utilities.EnumExtensionMethods.GetDescription((PTS2.Common.Enumlar.IzinTipi)Convert.ToInt32( Eval("izinTuru"))) %>
            cmd.Parameters.Add("@izinTuru", ddlIzinTuru.SelectedValue);
            //cmd.Parameters.Add("@bitisTarihi", txtBitisTarihi.Text);
            cmd.Parameters.Add("@bitisTarihi", txtBitisTarihi.Text);
            cmd.Parameters.Add("@islemTarihi", DateTime.Now);
            cmd.Parameters.Add("@durum", (short)Enumlar.IzinDurum.ISLEME_ALINDI);

            if (Session["personelID"] != null)
            {
                cmd.Parameters.Add("@personelID", System.Data.SqlDbType.SmallInt).Value = Convert.ToInt32(Session["personelID"].ToString());
            }
            cmd.ExecuteNonQuery();
            AlertCustom.ShowCustom(this.Page, "İzin İşlemi başarılı..");
        }
        protected void btnCıkış_Click(object sender, EventArgs e)
        {
            Session.Remove("personelID");
            Response.Redirect("Login.aspx");
        }
    }
}
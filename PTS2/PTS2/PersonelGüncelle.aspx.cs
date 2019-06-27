using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace PTS2
{
    public partial class PersonelGüncelle : System.Web.UI.Page
    {
        metodlar klas = new metodlar();
        string personelid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["personelID"] == null)
                Response.Redirect("Login.aspx");
            if (Session["RolId"].ToString() == "5")
            {

                btnGorunurluk2.Visible = true;
                pnlRol.Visible = true;
            }
            else
            {
                btnGorunurluk1.Visible = true;
                pnlSifreGorunurluk.Visible = true;
               
            }
            
            personelid = Request.QueryString["personelID"];
          
            if (Page.IsPostBack == false)
            {

                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "SELECT dbo.Bolum.bolumAdi, dbo.Personel.personelID, dbo.Personel.bolumID, dbo.Personel.ad, dbo.Personel.soyad, dbo.Personel.email, dbo.Personel.sifre, dbo.Personel.tel, dbo.Personel.dogumTarihi FROM dbo.Bolum INNER JOIN  dbo.Personel ON dbo.Bolum.bolumID = dbo.Personel.bolumID where dbo.Personel.personelID=@personelId";
                cmd.CommandText = "SELECT dbo.Rol.RolID, dbo.Bolum.bolumID, dbo.Personel.ad, dbo.Personel.soyad, dbo.Personel.email, dbo.Personel.tel, dbo.Personel.dogumTarihi, dbo.Personel.sifre FROM dbo.Bolum INNER JOIN dbo.Personel ON dbo.Bolum.bolumID = dbo.Personel.bolumID INNER JOIN dbo.Rol ON dbo.Personel.RolID = dbo.Rol.RolID where dbo.Personel.personelID=@personelId";
               // literal için
                cmd.Parameters.AddWithValue("@personelId", personelid);
                
                DataRow drPersonel = klas.GetDataRow(cmd);
                Rol();
                ddlRolGuncelle.SelectedValue = drPersonel["RolID"].ToString();
                TxtboxAdGuncelle.Text = drPersonel["ad"].ToString();
                TxtboxsoyadGuncelle.Text = drPersonel["soyad"].ToString();
                TxtboxepostaGuncelle.Text = drPersonel["email"].ToString().Substring(0, drPersonel["email"].ToString().IndexOf("@"));
                TxtboxEskiSifreGuncelle.Text = drPersonel["sifre"].ToString();
                TxtboxtelGuncelle.Text = drPersonel["tel"].ToString();
                TxtboxdogumtarihiGuncelle.Text = drPersonel["dogumTarihi"].ToString();
                Pozisyon();
                ddlPozisyonGuncelle.SelectedValue = drPersonel["bolumID"].ToString();
                
               
            }
        }
        public string MD5Olustur(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        void Pozisyon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Bolum";
            DataTable dtPozisyon = klas.GetDataTable(cmd);
            ddlPozisyonGuncelle.DataTextField = "bolumAdi";
            ddlPozisyonGuncelle.DataValueField = "bolumID";
            ddlPozisyonGuncelle.DataSource = dtPozisyon;
            ddlPozisyonGuncelle.DataBind();
        }
        void Rol()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Rol";
            DataTable dtRol = klas.GetDataTable(cmd);
            ddlRolGuncelle.DataTextField = "Adi";
            ddlRolGuncelle.DataValueField = "RolID";
            ddlRolGuncelle.DataSource = dtRol;
            ddlRolGuncelle.DataBind();
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Personel where personelID=@personelID";
          
            cmd.Parameters.Add("@personelID",personelid);
           
            DataRow drper = klas.GetDataRow(cmd);
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select * from Personel where email='" + TxtboxepostaGuncelle.Text + "@" + ddlEmailGuncelleProviders.SelectedItem + "' and email !='" + drper["email"].ToString() + "'";
            DataRow drpersonel = klas.GetDataRow(cmd1);
            if (drpersonel == null)
            {
                //if (drper["sifre"].ToString() == MD5Olustur(TxtboxEskiSifreGuncelle.Text))
                if (drper["sifre"].ToString() == TxtboxEskiSifreGuncelle.Text)
                {
                    
                    SqlConnection baglanti = klas.baglan();
                    SqlCommand cmd3 = new SqlCommand("update Personel set bolumID=@bolumID, RolID=@RolID ,ad=@ad, soyad=@soyad, email=@email, tel=@tel, dogumTarihi=@dogumTarihi, sifre=@sifre where personelID=" + personelid, baglanti);

                    //if (drper["RolID"].ToString() == "5")
                    //{
                        
                    //}
                    cmd3.Parameters.AddWithValue("@RolID", ddlRolGuncelle.SelectedValue);
                    cmd3.Parameters.AddWithValue("@bolumID", ddlPozisyonGuncelle.SelectedValue);
                    cmd3.Parameters.AddWithValue("@email", TxtboxepostaGuncelle.Text + "@" + ddlEmailGuncelleProviders.SelectedItem);
                    cmd3.Parameters.AddWithValue("@ad", TxtboxAdGuncelle.Text);
                    //cmd3.Parameters.AddWithValue("@sifre",MD5Olustur(TxtboxYeniSifreGuncelle.Text));
                    cmd3.Parameters.AddWithValue("@sifre", TxtboxYeniSifreGuncelle.Text);
                    cmd3.Parameters.AddWithValue("@soyad", TxtboxsoyadGuncelle.Text);
                    cmd3.Parameters.AddWithValue("@tel", TxtboxtelGuncelle.Text);
                    cmd3.Parameters.AddWithValue("@dogumTarihi",Convert.ToDateTime(TxtboxdogumtarihiGuncelle.Text));
                     
                    cmd3.ExecuteNonQuery();
                    if (Session["RolId"].ToString() == "5")
                    {
                        AlertCustom.ShowCustom(this.Page, "Güncelleme İşlemi Başarılı..");
                        //Response.Redirect("PersonelListe.aspx");
                    }
                    else
                    {
                        AlertCustom.ShowCustom(this.Page, "Güncelleme İşlemi Başarılı..");
                        //Response.Redirect("Izin.aspx");
                    }
                   
                }
                else
                {
                    lblEmailKontrol.Text = "Eski Şifreniz Uyuşmuyor..!";
                }
            }
            else
            {
                lblEmailKontrol.Text = "Bu E-Posta Kullanılmaktadır ..!";
            }

        }
    }
}
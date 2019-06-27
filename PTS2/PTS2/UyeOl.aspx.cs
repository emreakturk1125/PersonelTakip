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
using System.Configuration;

namespace PTS2
{
    public partial class UyeOl : System.Web.UI.Page
    {
        metodlar klas = new metodlar();
         
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                bolum();
                ddlPozisyonUye.Items.Insert(0, new ListItem("Seçiniz", ""));
            }
           
        }
        void bolum()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Bolum";
            DataTable bolum = klas.GetDataTable(cmd);
            ddlPozisyonUye.DataTextField = "bolumAdi";
            ddlPozisyonUye.DataValueField = "bolumID";
            ddlPozisyonUye.DataSource = bolum;
            ddlPozisyonUye.DataBind();
            

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
        string RastgeleUret()
        {
            Random rnd = new System.Random(unchecked((int)DateTime.Now.Ticks));
            string ret = "";
            for (int i = 0; i < 7; i++)
            {
                if (i == 0 || i == 5 || i == 6)
                {
                    ret += randkh(rnd);
                }
                if (i == 1 || i == 4)
                {
                    ret += randsayi(rnd);
                }
                if (i == 2)
                {
                    ret += randbh(rnd);
                }
                if (i == 3)
                {
                    ret += randnok(rnd);
                }

               

            }

            
            
            return ret;
            //return MD5Olustur(ret);
        }

        const string sayi = "0123456789";
        char randsayi(Random rnd)
        {
            return sayi[rnd.Next(sayi.Length)];
        }

        const string bh = "ABCDEFGHIJKLMNOPRSTUVYZ";
        char randbh(Random rnd)
        {
            return bh[rnd.Next(bh.Length)];
        }

        const string kh = "abcdefghijklmnoprstuvyz";
        char randkh(Random rnd)
        {
            return kh[rnd.Next(nok.Length)];
        }

        const string nok = "%&+@?!$#";
        char randnok(Random rnd)
        {
            return nok[rnd.Next(nok.Length)];
        }

         //bilgilendirme mesajı gönderme metodu..
         //appSetting email göndermek için webconfige eklenir

        public static void SendMail(string konu, string strBody, string kime)
        {
            string mailAdres = ConfigurationManager.AppSettings["EMailAdres"].ToString();
            string mailSifre = ConfigurationManager.AppSettings["Password"].ToString();

            //string Notifications = ConfigurationManager.AppSettings["Notifications"].ToString();
            //if (Notifications == "ON")
            //{
                string ssl = ConfigurationManager.AppSettings["SSL"].ToString();

                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(mailAdres, kime, konu, strBody);
                MyMailMessage.IsBodyHtml = true;
                int MailPortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["MailPortNumber"].ToString());//587
                string MailURL = ConfigurationManager.AppSettings["MailURL"].ToString();//
                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(mailAdres, mailSifre);
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(MailURL, MailPortNumber);
                if (ssl == "Enabled")
                    mailClient.EnableSsl = true;
                else if (ssl == "Disabled")
                    mailClient.EnableSsl = false;
                
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;
                mailClient.Send(MyMailMessage);

            //}
        }

        protected void btnUyeOl_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select * from Personel where email='" + TxtboxUyeeposta.Text + "@" + ddlEmailProvidersUye.SelectedItem + "'";
            DataRow drpersonel = klas.GetDataRow(cmd1);
            if (drpersonel == null)
            {

                SqlConnection baglanti = klas.baglan();
                SqlCommand cmd = new SqlCommand();
                string sifre = RastgeleUret();
                string sifreMD5 = MD5Olustur(sifre);
                cmd.Connection = baglanti;
                cmd.CommandText = "insert into Personel (ad,soyad,email,tel,dogumTarihi,bolumID,RolID,sifre) values (@ad,@soyad,@email,@tel,@dogumTarihi,@bolumID,4,@sifre)";
                cmd.Parameters.Add("@email", TxtboxUyeeposta.Text + "@" + ddlEmailProvidersUye.SelectedItem);
                cmd.Parameters.Add("@ad", TxtboxUyeAd.Text);
                //cmd.Parameters.Add("sifre", sifreMD5);
                cmd.Parameters.Add("sifre", sifre);
                cmd.Parameters.Add("@soyad", TxtboxUyesoyad.Text);
                cmd.Parameters.Add("@tel", TxtboxUyetel.Text);
                DateTime Tarih = DateTime.Today;
                TxtboxUyedogumtarihi.Text = Tarih.ToShortDateString();
                cmd.Parameters.Add("@dogumTarihi",Convert.ToDateTime(TxtboxUyedogumtarihi.Text));
                cmd.Parameters.Add("@bolumID", ddlPozisyonUye.SelectedValue);
                cmd.ExecuteNonQuery();

                SendMail("Personel Kayıt Sistemi Giriş Şifreniz", "Mail içeriği ve Şifre = " + sifre, TxtboxUyeeposta.Text + "@" + ddlEmailProvidersUye.SelectedItem);

                
                
            }
            else
            {
                LblBilgi.Text = "Bu E-Posta Kullanılmaktadır..!!";
            }
            AlertCustom.ShowCustom(this.Page, "Kayıt başarılı, şifreniz E-Posta adresinize gönderilmiştir.");
            temizle(pnl);
        }

        public void temizle(Panel PNL)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = "";
                }
                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).Text = "";
                }
                
            }
        }
    }
}
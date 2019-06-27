using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using personeltakip.Web;
using Personeltakip.VO;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;


namespace PTS2
{
    public partial class PersonelEkle : BasePage
    {
        metodlar klas = new metodlar();
        string personelID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["personelID"] == null)
                Response.Redirect("Login.aspx");
            if (Page.IsPostBack == false)
            {

                bolum();
                ddlPozisyon.Items.Insert(0, new ListItem("Seçiniz", ""));

            }

        }

        void bolum()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Bolum";
            DataTable bolum = klas.GetDataTable(cmd);
            ddlPozisyon.DataTextField = "bolumAdi";
            ddlPozisyon.DataValueField = "bolumID";
            ddlPozisyon.DataSource = bolum;
            ddlPozisyon.DataBind();

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {

            //Personel personel = new Personel();
            //personel.ad = TxtboxAd.Text;
            //personel.bolumID = Convert.ToInt32(ddlPozisyon.SelectedValue);
            //personel.soyad = Txtboxsoyad.Text;
            //personel.email = Txtboxeposta.Text;
            //personel.dogumTarihi = Convert.ToDateTime(Txtboxdogumtarihi.Text);
            //personel.tel = Txtboxtel.Text;
            //PersonelBLL.Insert(personel);

           
            //-------------------------------------------------------------------------------------------------
            //personelID = Request.QueryString("personelID");
          
            //SqlCommand cmdd = new SqlCommand();
            //cmdd.CommandText = "select * from Personel where email='"+(Txtboxeposta.Text+"@"+ddlEmailProviders.SelectedItem)+"'";          
            //DataRow drpersonel = klas.baglan(cmdd);
            //Session["personelID"] = drpersonel["personelID"].ToString();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select * from Personel where email='" + Txtboxeposta.Text + "@" + ddlEmailProviders.SelectedItem + "'";
            DataRow drpersonel = klas.GetDataRow(cmd1);
            if (drpersonel == null)
            {

                SqlConnection baglanti = klas.baglan();
                SqlCommand cmd = new SqlCommand();
                string sifre = RastgeleUret();
                string sifreMD5 = MD5Olustur(sifre);
                cmd.Connection = baglanti;
                cmd.CommandText = "insert into Personel (ad,soyad,email,tel,dogumTarihi,bolumID,RolID,sifre) values (@ad,@soyad,@email,@tel,@dogumTarihi,@bolumID,4,@sifre)";
                cmd.Parameters.Add("@email", Txtboxeposta.Text + "@" + ddlEmailProviders.SelectedItem);
                cmd.Parameters.Add("@ad", TxtboxAd.Text);
                //cmd.Parameters.Add("@sifre", sifreMD5);
                cmd.Parameters.Add("@sifre", sifre);
                cmd.Parameters.Add("@soyad", Txtboxsoyad.Text);
                cmd.Parameters.Add("@tel", Txtboxtel.Text);
                DateTime Tarih = DateTime.Today;
                Txtboxdogumtarihi.Text = Tarih.ToShortDateString();
                cmd.Parameters.Add("@dogumTarihi",Convert.ToDateTime(Txtboxdogumtarihi.Text));
                cmd.Parameters.Add("@bolumID", ddlPozisyon.SelectedValue);
                cmd.ExecuteNonQuery();
                SendMail("Personel Kayıt Sistemi Giriş Şifreniz", "Mail içeriği ve Şifre = " + sifre, Txtboxeposta.Text + "@" + ddlEmailProviders.SelectedItem);

                AlertCustom.ShowCustom(this.Page, "Kayıt başarılı, şifre E-Posta adresine gönderilmiştir.");
                temizle(pnll);
            }
            else
            {
                LblBilgi.Text = "Bu E-Posta Kullanılmaktadır..!!";
            }

        }
        public void temizle(Panel PNL)
        {
            foreach (Control ctrl in pnll.Controls)
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

            // ***************  şifre yi burdan email olarak gönder  ****************

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

    }

}


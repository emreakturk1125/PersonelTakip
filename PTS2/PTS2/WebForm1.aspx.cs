using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTS2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSifre_Click(object sender, EventArgs e)
        {
            txtUret.Text = RastgeleUret();
            //emailgonder();
            //Page.ClientScript.RegisterStartupScript(this.GetType(),"Scripts", "<script>alert('yoğğ yaa');</script>");
            AlertCustom.ShowCustom(this.Page, "Hello");
            
        }
       
        //protected void emailgonder()
        //{
        //    MailMessage msg = new MailMessage();
        //    msg.From = new MailAddress("emreakturk25@gmail.com");
        //    msg.To.Add(Tbemail.Text);
        //    msg.Subject = "konu";
        //    msg.Body = txtUret.Text;
        //    msg.IsBodyHtml = true;

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    System.Net.NetworkCredential networkcred = new System.Net.NetworkCredential();
        //    networkcred.UserName = "emreakturk@gmail.com";
        //    networkcred.Password = "emreakturk";
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = networkcred;
        //    smtp.Port = 587;
        //    smtp.EnableSsl = false;
        //    smtp.Send(msg);
        //    Lblemailgonder.Text = "email gonderildi";

        //}
        //public static void Show(string message)
        //{
        //    // Buradaki tek tırnak mesaj silmek için izin ister.
        //    string cleanMessage = message.Replace("'", "\\'");
        //    string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
        //    // Yüklenecek webformu alır.
        //    Page page = HttpContext.Current.CurrentHandler as Page;
        //    // Sayfa üzerinde allready olup olmadığını kontrol eder.
        //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //    {
        //        page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
        //    }
        //}    
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
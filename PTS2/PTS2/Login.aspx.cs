using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace PTS2
{
    public partial class Default : System.Web.UI.Page
    {
        metodlar klas = new metodlar();

        protected void Page_Load(object sender, EventArgs e)
        {



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

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
            SqlCommand cmd = new SqlCommand("select * from Personel where email=@email and sifre=@sifre");

            //cmd.CommandText = "select * from Personel where email=@email and sifre=@sifre and bolumID = @bolumID";
            //cmd.Parameters.AddWithValue("bolumID",bolumID);
            cmd.Parameters.AddWithValue("email", TextBoxemail.Text + "@" + ddlEmailProviders.SelectedItem);
            cmd.Parameters.AddWithValue("sifre", TextBoxsifre.Text);
            //cmd.Parameters.AddWithValue("sifre", MD5Olustur(TextBoxsifre.Text));
            DataRow drgiris = klas.GetDataRow(cmd);
            Session["RolID"] = drgiris["RolID"].ToString();

            //if (drgiris != null)
            if (true)
            {
                if (Convert.ToBoolean(drgiris["Aktif"]) == true && Convert.ToBoolean(drgiris["Engel"]) == false)
                {


                    if (Cbhatirla.Checked == true)
                    {
                        HttpCookie cerez = new HttpCookie("cerezim");
                        cerez.Values.Add("personelID", drgiris["personelID"].ToString());
                        cerez.Values.Add("email", drgiris["email"].ToString());
                        cerez.Expires = DateTime.Now.AddDays(1);
                    }


                    Session["personelID"] = drgiris["personelID"].ToString();
                    Session["AdSoyad"] = drgiris["ad"].ToString() + " " + drgiris["soyad"].ToString();
                    if (Session["RolID"].ToString() == "4")
                    {
                        //Response.Redirect("Izin.aspx");
                        Response.Redirect("YonlendirmeSayfası.aspx");
                    }
                    else if (Session["RolID"].ToString() == "3")
                    {
                        //Response.Redirect("IzinListesi.aspx");
                        Response.Redirect("YonlendirmeSayfası.aspx");
                    }
                    else if (Session["RolID"].ToString() == "5")
                    {
                        Response.Redirect("YonlendirmeSayfası.aspx");
                    }
                    else if (Session["RolID"].ToString() == "1")
                    {
                        //Response.Redirect("IzinListesi.aspx");
                        Response.Redirect("YonlendirmeSayfası.aspx");
                    }
                    else if (Session["RolID"].ToString() == "2")
                    {
                        //Response.Redirect("IzinListesi.aspx");
                        Response.Redirect("YonlendirmeSayfası.aspx");
                    }

                   
                }
     
            }
           

            }
            catch (Exception ex)
            {
                
                lblUyari.Text = "Şifre veya E-Posta hatalı..!";
            }

        }

        

    }
}
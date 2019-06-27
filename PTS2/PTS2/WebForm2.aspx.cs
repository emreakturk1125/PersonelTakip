using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PTS2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection baglan2 = new SqlConnection();
            //baglan2.ConnectionString("Data source = EMREE-BİLG\\MSSQL2014 ; initial catalog = ornek ; integrated security = true");
            //SqlCommand cmd2 = new SqlCommand();
            //cmd2.CommandText = "İnsert into KisiBilgileri (kisiAdi,kisiSoyad,kisiNo,kisiEmail) values (@kisiAdi,@kisiSoyad,@kisiNo,@kisiEmail)";
            //baglan2.Open();
            //cmd2.Connection(baglan2);
            //cmd2.Parameters.AddWithValue("@kisiAdi", TextBox1.Text);
            //cmd2.Parameters.AddWithValue("@kisiSoyad", TextBox2.Text);
            //cmd2.Parameters.AddWithValue("@kisiNo", TextBox3.Text);
            //cmd2.Parameters.AddWithValue("@kisiEmail", TextBox4.Text);
           
        }

       
        protected void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection baglan1 = new SqlConnection("data source = EMREE-BILG\\MSSQL2014 ; initial catalog = ornek; integrated security = true");
            baglan1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "insert into KisiBilgileri (kisiAdi,kisiSoyadi,kisiNo,kisiEmail) values (@kisiAdi,@kisiSoyadi,@kisiNo,@kisiEmail)";
            cmd1.Connection = baglan1;
            cmd1.Parameters.Add("@kisiAdi", TextBox1.Text);
            cmd1.Parameters.Add("@kisiSoyadi", TextBox2.Text);
            cmd1.Parameters.Add("@kisiNo", TextBox3.Text);
            cmd1.Parameters.Add("@kisiEmail", TextBox4.Text);
            cmd1.ExecuteNonQuery();
            baglan1.Close();
            temizle(pnl);
            Label1.Text = "Kayıt İşlemi Başarılı";
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

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
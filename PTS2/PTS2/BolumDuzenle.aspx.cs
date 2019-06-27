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
    public partial class BolumDuzenle : System.Web.UI.Page
    {
        metodlar klas = new metodlar();
        string bolumID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bolumID = Request.QueryString["bolumID"];
            if (Page.IsPostBack == false)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select *  from Bolum where bolumID = @bolumID";
                cmd.Parameters.AddWithValue("@bolumID", bolumID);
                DataRow drbolum = klas.GetDataRow(cmd);       
                TxtboxBolumAdiDuzenle.Text =  drbolum["bolumAdi"].ToString();
                
            }
        }

        protected void btnBolumDuzenle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = klas.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "update Bolum set bolumAdi = @bolumAdi where bolumID = @bolumID";
            cmd.Parameters.AddWithValue("@bolumID",bolumID);
            cmd.Parameters.Add("@bolumAdi",TxtboxBolumAdiDuzenle.Text);    
            cmd.ExecuteNonQuery();
            Response.Redirect("BolumEkle.aspx");
        }
    }
}
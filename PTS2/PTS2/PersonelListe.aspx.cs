using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace PTS2
{
    public partial class data : Page
    {
        metodlar klas = new metodlar();
        public int personelId;
        string islem = "";
        string personelID = "";
        DataTable dtkullanıcı;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["personelID"] == null)
                Response.Redirect("Login.aspx");
            try
            {
                islem = Request.QueryString["islem"];
                personelID = Request.QueryString["personelID"];
            }

            catch (Exception)
            {
            }

            if (islem == "sil")
            {
                klas.cmd("update Personel set Aktif=0 where personelID=" + personelID);
            }

            if (!IsPostBack)
            {
                PersonelGetir();
                
            }


        }

        private void PersonelGetir()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT dbo.Bolum.bolumAdi, dbo.Personel.personelID, dbo.Personel.ad, dbo.Personel.soyad, dbo.Personel.email, dbo.Personel.tel, dbo.Personel.Engel FROM dbo.Personel INNER JOIN dbo.Bolum ON dbo.Personel.bolumID = dbo.Bolum.bolumID where dbo.Personel.Aktif=1";
            dtkullanıcı = klas.GetDataTable(cmd);
            dtMyList.DataSource = dtkullanıcı;
            dtMyList.DataBind();
        }
 
        protected void dtMyList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbEngelle = e.Item.FindControl("lbEngelle") as LinkButton;
                //HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                HtmlGenericControl spanEngelle = e.Item.FindControl("spanEngelle") as HtmlGenericControl;
                int personelID = 0;
                bool engelli = false;
                if (DataBinder.Eval(e.Item.DataItem, "personelID") != DBNull.Value)
                    personelID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "personelID"));
                if (DataBinder.Eval(e.Item.DataItem, "Engel") != DBNull.Value)
                    engelli = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Engel"));
                if (spanEngelle != null)
                {
                    if (engelli)
                    {
                        
                        lbEngelle.Text = "<span class=\"glyphicon glyphicon-remove\"></span>Engeli Kaldır";
                        //spanEngelle.Attributes["class"] = "glyphicon glyphicon-remove";
                    }
                }
            }
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("personelID");
            Response.Redirect("Login.aspx");
        }

        protected void dtMyList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Engelle")
            {
                int personelId = Convert.ToInt32(e.CommandArgument);
                bool engel = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Engel FROM Personel where personelID=" + personelId;
                cmd.Connection = klas.baglan();
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Engel"] != DBNull.Value)
                        engel = Convert.ToBoolean(dr["Engel"]);
                }

                dr.Close();

                string engelUpdate = string.Empty;
                if (engel == true)
                    engelUpdate = "0";
                else
                    engelUpdate = "1";

                cmd.CommandText = "update personel set engel=" + engelUpdate + " where personelID=" + personelId;
                cmd.Connection = klas.baglan();
                cmd.ExecuteNonQuery();
                PersonelGetir();

             }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PTS2
{
    public partial class YonlendirmeSayfası : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["personelID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";

            if (Session["RolID"].ToString() == "4")
            {
               
                meta.Content = "1;url=Izin.aspx";
            }
            else if (Session["RolID"].ToString() == "3")
            {
                
                meta.Content = "1;url=IzinListesi.aspx";
            }
            else if (Session["RolID"].ToString() == "5")
            {
                meta.Content = "1;url=admin.aspx";
            }
            else if (Session["RolID"].ToString() == "1")
            {
                
                meta.Content = "1;url=IzinListesi.aspx";
            }
            else if (Session["RolID"].ToString() == "2")
            {
             
                meta.Content = "1;url=IzinListesi.aspx";
            }
            this.Page.Controls.Add(meta);
        }
    }
}
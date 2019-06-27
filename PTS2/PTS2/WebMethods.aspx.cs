using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTS2
{
    public partial class WebMethods : System.Web.UI.Page
    {
        [WebMethod]
        public static string EngelleKaldir(string personelId)
        {
            try 
	        {



                return "1";
	        }
	        catch (Exception)
	        {
                return string.Empty;
	        }
        }
    }
}
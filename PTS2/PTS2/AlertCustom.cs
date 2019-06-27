using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PTS2
{
    public static class AlertCustom
    {
        public static void ShowCustom(Page page, string message)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = message.Replace("'", "\\'");
            string script = "<script >alertify.alert(\"" + cleanMessage + "\" ); </script>";
            page = HttpContext.Current.CurrentHandler as Page;
            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alertcustom"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(AlertCustom), "alertcustom", script);
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace GestionListasRestrictivas
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {


            int sessionTimeout = Session.Timeout;
            int valortimeout = Convert.ToInt16(ConfigurationManager.AppSettings["timeout"]);
            sessionTimeout = sessionTimeout * valortimeout;
            //string value = sessionTimeout.ToString() + "; url=logout.aspx";
            //Response.AppendHeader("Refresh", value);
            if (!Page.IsPostBack)
            {
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";                
                //user.Value = Session["usuario"].ToString();
                //Session["ip"] = Request.UserHostAddress;
                
            //if (!Rsesion.RevisaSesion(Session["conexion"].ToString(), Session["usuario"].ToString()))
            //     Response.Redirect("~/inicio.aspx", false);
            }
            
            }



    }

 

    
}
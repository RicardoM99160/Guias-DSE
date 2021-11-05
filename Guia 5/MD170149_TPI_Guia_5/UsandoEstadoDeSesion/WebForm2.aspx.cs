using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoEstadoDeSesion
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null && Session["State"] != null)
            {
                Label1.Text = String.Format("Bienvenido, {0}", Session["Name"]);
                Label2.Text = String.Format("Estado: {0}", Session["State"]);
            }
            else {
                Response.Redirect("WebForm1.aspx");
            }
        }

        protected void Button1_Click (object sender, EventArgs e){
            Session.Remove("Name");
            Session.Remove("State");
            Response.Redirect("WebForm1.aspx");
        }
    }
}
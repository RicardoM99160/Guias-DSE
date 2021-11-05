﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            varSession.Text = Session["Login"].ToString();
            varApplication.Text = Application["Application"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Login"] = tbSession.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Application["Application"] = tbApplicacion.Text;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            varSession.Text = Session["Login"].ToString();
            varApplication.Text = Application["Application"].ToString();
        }
    }
}
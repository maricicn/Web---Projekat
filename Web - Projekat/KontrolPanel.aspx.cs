﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web___Projekat
{
    public partial class KontrolPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vlasnik"].ToString() == "no")
            {
                Response.Redirect("greska.aspx");
            }
        }
    }
}
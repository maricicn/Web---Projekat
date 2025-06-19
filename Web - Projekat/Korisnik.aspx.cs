using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web___Projekat
{
    public partial class Korisnik : System.Web.UI.Page
    {
        public static string email;
        public static string lozinka;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = ime_korisnika.Text;
            lozinka = lozinka_korisnika.Text;
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            int rezultat;
            AutoMehanicar korisnik_istina = new AutoMehanicar();
            rezultat = korisnik_istina.Provera_Korisnika(ime_korisnika.Text, lozinka_korisnika.Text);

            if (rezultat == 0)
            {
                Session["vlasnik"] = ime_korisnika.Text;
                Response.Redirect("kontrolpanel.aspx");
            }
            else
            {
                Response.Redirect("greska.aspx");
            }
        }
    }
}
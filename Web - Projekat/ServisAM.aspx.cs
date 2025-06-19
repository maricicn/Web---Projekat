using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace Web___Projekat
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vlasnik"].ToString() == "no")
            {
                Response.Redirect("greska.aspx");
            }
            ;
        }


        protected void btn_insert_usluga_Click(object sender, EventArgs e)
        {
            string naziv = txt_naziv.Text;
            int cena = Int32.Parse(txt_cena.Text);
            DateTime dp = datum_p.SelectedDate;
            DateTime dz = datum_z.SelectedDate;

            AutoMehanicar unos_usluge = new AutoMehanicar();
            int rezultat;
            rezultat = unos_usluge.Unos_Usluga(naziv, cena, dp, dz);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                txt_naziv.Text = "Ponovi upis";
            }
        }

        protected void btn_insert_zaposleni_Click(object sender, EventArgs e)
        {
            string ime = txt_ime.Text;
            string prezime = txt_prezime.Text;
            string jmbg = txt_jmbg.Text;
            int plata = Int32.Parse(txt_plata.Text);
            string usluga_id = dd_usluga_zaposleni.SelectedItem.Value;

            AutoMehanicar unos_zaposlenog = new AutoMehanicar();
            int rezultat;
            rezultat = unos_zaposlenog.Unos_Zaposlenog(ime, prezime, jmbg, plata, usluga_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                txt_ime.Text = "Ponovi upis";
            }
        }


        protected void btn_delete_zaposleni_Click(object sender, EventArgs e)
        {
            string zaposleni_id = ListaZaposlenih.SelectedItem.Value;
            AutoMehanicar obrisi_zaposlenog = new AutoMehanicar();
            int rezultat;
            rezultat = obrisi_zaposlenog.Obrisi_Zaposlenog(zaposleni_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                txt_ime.Text = "Ponovi upis";
            }

        }

        protected void btn_delete_uslugu_Click(object sender, EventArgs e)
        {
            string usluga_id = ListaUsluga.SelectedItem.Value;
            AutoMehanicar obrisi_uslugu = new AutoMehanicar();
            int rezultat;
            rezultat = obrisi_uslugu.Obrisi_Uslugu(usluga_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                MessageBox("Zeza baza - Referential integrity!");
            }
        }

        protected void btn_insert_vlasnik_Click(object sender, EventArgs e)
        {
            string ime = txt_vlasnik_ime.Text;
            string prezime = txt_vlasnik_prezime.Text;
            string email = txt_vlasnik_email.Text;
            string lozinka = txt_vlasnik_lozinka.Text;
            string jmbg = txt_vlasnik_jmbg.Text;

            AutoMehanicar unos_vlasnika = new AutoMehanicar();
            int rezultat;
            rezultat = unos_vlasnika.Unos_Vlasnika(ime, prezime, email, lozinka, jmbg);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                txt_naziv.Text = "Ponovi upis";
            }
        }

        protected void btn_delete_vlasnika_Click(object sender, EventArgs e)
        {
            
            string email = ListaVlasnika.SelectedItem.Value;
            if(email != Korisnik.email)
            {
                AutoMehanicar obrisi_vlasnika = new AutoMehanicar();
                int rezultat;
                rezultat = obrisi_vlasnika.Obrisi_Vlasnika(email);
                if (rezultat == 0)
                {
                    Response.Redirect("ServisAM.aspx");
                }
                else
                {
                    txt_naziv.Text = "Zeza baza";
                }
            }
            else
            {
                MessageBox("Ne mozete obrisati ulogovanog vlasnika!");
            }
            
            
            
        }
        public void MessageBox(string xMessage)
        {
            Response.Write("<script>alert('" + xMessage + "')</script>");
        }

        protected void btn_insert_auto_Click(object sender, EventArgs e)
        {
            string marka = txt_marka.Text;
            string registracija = txt_registracija.Text;
            string usluga_id = ListaUsluga1.SelectedItem.Value;

            AutoMehanicar unos_automobila = new AutoMehanicar();
            int rezultat;
            rezultat = unos_automobila.Unos_Automobila(marka, registracija, usluga_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
               MessageBox("Ponovi upis");
            }
        }

        protected void btn_delete_automobil_Click(object sender, EventArgs e)
        {
            string auto_id = ListaAuta.SelectedItem.Value;
            AutoMehanicar obrisi_auto = new AutoMehanicar();
            int rezultat;
            rezultat = obrisi_auto.Obrisi_Automobil(auto_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                MessageBox("Ponovi upis");
            }
        }

        protected void ListaVlasnika_SelectedIndexChanged(object sender, EventArgs e)
        {
            string email = ListaVlasnika.SelectedItem.Value;
            AutoMehanicar vlasnik_info = new AutoMehanicar();
            DataSet ds = vlasnik_info.Vlasnik_Info(email);

            if (ds != null)
            {
                txt_vlasnik_ime.Text = ds.Tables[0].Rows[0]["ime"].ToString();
                txt_vlasnik_prezime.Text = ds.Tables[0].Rows[0]["prezime"].ToString();
                txt_vlasnik_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
                txt_vlasnik_lozinka.Text = ds.Tables[0].Rows[0]["lozinka"].ToString();
                txt_vlasnik_jmbg.Text = ds.Tables[0].Rows[0]["JMBG"].ToString();
            }
        }

        protected void ListaUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ListaUsluga.SelectedItem.Value;
            AutoMehanicar usluga_info = new AutoMehanicar();
            DataSet ds = usluga_info.Usluga_Info(id);

            if (ds != null)
            {
                txt_naziv.Text = ds.Tables[0].Rows[0]["naziv"].ToString();
                txt_cena.Text = ds.Tables[0].Rows[0]["cena"].ToString();
                datum_p.SelectedDate = DateTime.Parse(ds.Tables[0].Rows[0]["datum_pocetka"].ToString());
                datum_z.SelectedDate = DateTime.Parse(ds.Tables[0].Rows[0]["datum_zavrsetka"].ToString());
            }
        }

        protected void ListaAuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ListaAuta.SelectedItem.Value;
            AutoMehanicar auto_info = new AutoMehanicar();
            DataSet ds = auto_info.Auto_Info(id);

            if (ds != null)
            {
                txt_marka.Text = ds.Tables[0].Rows[0]["marka"].ToString();
                txt_registracija.Text = ds.Tables[0].Rows[0]["registracija"].ToString();
                ListaUsluga1.SelectedValue = ds.Tables[0].Rows[0]["usluga_id"].ToString();
            }
        }

        protected void ListaZaposlenih_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ListaZaposlenih.SelectedItem.Value;
            AutoMehanicar zaposleni_info = new AutoMehanicar();
            DataSet ds = zaposleni_info.Zaposleni_Info(id);

            if (ds != null)
            {
                txt_ime.Text = ds.Tables[0].Rows[0]["ime"].ToString();
                txt_prezime.Text = ds.Tables[0].Rows[0]["prezime"].ToString();
                txt_jmbg.Text = ds.Tables[0].Rows[0]["JMBG"].ToString();
                txt_plata.Text = ds.Tables[0].Rows[0]["plata"].ToString();
                dd_usluga_zaposleni.SelectedValue = ds.Tables[0].Rows[0]["usluga_id"].ToString();
            }
        }

        protected void btn_update_usluga_Click(object sender, EventArgs e)
        {
            string usluga_id = ListaUsluga.SelectedItem.Value;
            string naziv = txt_naziv.Text;
            int cena = Int32.Parse(txt_cena.Text);
            DateTime dp = datum_p.SelectedDate;
            DateTime dz = datum_z.SelectedDate;

            AutoMehanicar izmena_usluge = new AutoMehanicar();
            int rezultat;
            rezultat = izmena_usluge.Izmeni_Usluga(usluga_id, naziv, cena, dp, dz);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                MessageBox("Ponovi upis");
            }

        }

        protected void btn_update_vlasnika_Click(object sender, EventArgs e)
        {
            string ime = txt_vlasnik_ime.Text;
            string prezime = txt_vlasnik_prezime.Text;
            string email = txt_vlasnik_email.Text;
            string lozinka = txt_vlasnik_lozinka.Text;
            string jmbg = txt_vlasnik_jmbg.Text;

            AutoMehanicar izmena_vlasnika = new AutoMehanicar();
            int rezultat;
            rezultat = izmena_vlasnika.Izmeni_Vlasnik(ime, prezime, email, lozinka, jmbg);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                MessageBox("Email se ne moze menjati!");
            }
        }

        protected void btn_update_zaposleni_Click(object sender, EventArgs e)
        {
            string zaposleni_id = ListaZaposlenih.SelectedItem.Value;
            string ime = txt_ime.Text;
            string prezime = txt_prezime.Text;
            string jmbg = txt_jmbg.Text;
            int plata = Int32.Parse(txt_plata.Text);
            string usluga_id = dd_usluga_zaposleni.SelectedItem.Value;

            AutoMehanicar izmena_zaposlenog = new AutoMehanicar();
            int rezultat;
            rezultat = izmena_zaposlenog.Izmeni_Zaposlenog(zaposleni_id, ime, prezime, jmbg, plata, usluga_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                MessageBox("Ponovi upis");
            }
        }

        protected void btn_update_automobil_Click(object sender, EventArgs e)
        {
            string auto_id = ListaAuta.SelectedItem.Value;
            string marka = txt_marka.Text;
            string registracija = txt_registracija.Text;
            string usluga_id = ListaUsluga1.SelectedItem.Value;

            AutoMehanicar izmena_automobila = new AutoMehanicar();
            int rezultat;
            rezultat = izmena_automobila.Izmeni_Automobil(auto_id,marka, registracija, usluga_id);
            if (rezultat == 0)
            {
                Response.Redirect("ServisAM.aspx");
            }
            else
            {
                MessageBox("Ponovi upis");
            }
        }
    }
}
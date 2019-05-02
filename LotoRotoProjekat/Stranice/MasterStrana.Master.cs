using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotoRotoProjekat.Strane
{
    public partial class MasterStrana : System.Web.UI.MasterPage
    {
        public ContentPlaceHolder placeHolderDropdown; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["bool_korisnik_ulogovan"] == null)
            {
                Session["bool_korisnik_ulogovan"] = false;
            }

            if( (bool)Session["bool_korisnik_ulogovan"] == false)
            {
                btnPrijaviOdjaviSe.Text = "Prijavi/Registruj se";
            }
            else
            {
                btnPrijaviOdjaviSe.Text = "Odjavi se";
            }

            // provera da li je ulogovan admin
            if(Session["tip_korisnika"]!= null)
            {
                if(Session["tip_korisnika"].ToString() == "admin")
                {
                    placeholderAdminDropdown.Visible = true;
                }
            }
            //Id racuna admina i fonda se cuvaju u sesiji, posto imamo samo po jedan racun za oba
            //pa nije potrebna logika trazenja po nekakvim kriterijumima / upitima
            Session["admin_racun_id"] = 4;
            Session["humanitarni_fond_racun_id"] = 3;

        }

        protected void LinkIgraj_Click(object sender, EventArgs e)
        {
            if((bool)Session["bool_korisnik_ulogovan"] == true)
            Response.Redirect("IgrajTiket.aspx");
            Response.Redirect("RegistrujPrijavi.aspx");
        }

            protected void btnPrijaviOdjaviSeClick(object sender, EventArgs e)
        {
            if (btnPrijaviOdjaviSe.Text == "Prijavi/Registruj se")
            {
                Response.Redirect("RegistrujPrijavi.aspx");
            }
            if(btnPrijaviOdjaviSe.Text == "Odjavi se")
            {
                if(Session["tip_korisnika"] != null)
                Session["tip_korisnika"] = null;

                Session["bool_korisnik_ulogovan"] = false;
                placeholderAdminDropdown.Visible = false;
                Response.Redirect("RegistrujPrijavi.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotoRotoProjekat
{
    public partial class AdminUklanjanje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUkloniKorisnika_Click(object sender, EventArgs e)
        {

        }

        protected void btnUkloniNeaktive_Click(object sender, EventArgs e)
        {
            string otklanjanjePreDatuma = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
            string naredbaIzbrisiNeaktivne = "DELETE FROM Korisnici  WHERE log_in_date < '" + otklanjanjePreDatuma + "'";
            konekcija.IzvrsiIzvrsiNonQuery(naredbaIzbrisiNeaktivne);
        }
    }
}
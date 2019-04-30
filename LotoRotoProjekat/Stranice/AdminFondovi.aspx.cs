using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotoRotoProjekat
{
    public partial class AdminFondovi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPotvrdi_Click(object sender, EventArgs e)
        {

            int idRacunaHumanitarnogFonda = DodajRacunUBazuIVratiID(TextBoxBrojRacunaFonda.Text);

            string naredbaDodajNoviHumanitarniFond = "INSERT INTO Humanitarni_Fondovi" +
                "(naziv,opis_humanitarnog_fonda,fk_racuni_id) " +
                "VALUES (" +
                "'"+TextBoxNazivFonda.Text + "', " +
                 "'" + TextBoxOpisFonda.Text + "', " +
                idRacunaHumanitarnogFonda +
                ");";
            konekcija.IzvrsiIzvrsiNonQuery(naredbaDodajNoviHumanitarniFond);
        }

        int DodajRacunUBazuIVratiID(string brojRacuna)
        {
            string naredbaNapraviRacun = "INSERT INTO Racuni (broj_racuna) VALUES (" +brojRacuna + ");";
            string naredbaBrRacuna = "SELECT pk_racuni_id FROM Racuni WHERE broj_racuna ='" + brojRacuna + "'";

            konekcija.IzvrsiIzvrsiNonQuery(naredbaNapraviRacun);
            int idRacunaHumanitarnogFonda = Int32.Parse(konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaBrRacuna));
            return idRacunaHumanitarnogFonda;
        }
    }
}
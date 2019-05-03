﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LotoRotoProjekat
{
    public partial class Rezultati : System.Web.UI.Page
    {

        List<Dobitnik> dobitnici = new List<Dobitnik>();

        int cenaJednogTiketa = 100;
        // Pojedinacne uplatne vrednosti zavisno od dobitka
        double fondZaDobitak4Pogotka = 0;
        double fondZaDobitak5Pogotka = 0;
        double fondZaDobitak6Pogotka = 0;
        double fondZaDobitak7Pogotka = 0;
        double fondZaHumanitarneSvrhe = 0;
        double fondZaNaplatuAdministratoru = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnZavrsiKolo_Click(object sender, EventArgs e)
        {
            bool izvucenaSedmica = ProveriIzvucenaSedmica();

            DopuniFond();
            UcitajDobitnike();
            IzracunajFondove(VratiNagradniFondIzBaze(), izvucenaSedmica);
            IzvrsiNaplateIzFonda();
            AzurirajFond(izvucenaSedmica);
            PrikaziRezultateNaStranici();
        }

        public bool ProveriIzvucenaSedmica()
        {
            string naredbaPrebrojDobitnikeVrste = "SELECT COUNT(*) AS broj FROM Dobitnici WHERE vrsta_pogotka = '7' ";
        
            string brojIzvucenihString = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaPrebrojDobitnikeVrste);
            int brojIzvucenih = Convert.ToInt32(brojIzvucenihString);
            return brojIzvucenih > 0;

        }

        private void DopuniFond()
        {
            //pocetni datum treba da je datum zavrsetka prethodnog kola; zavrsni datum je zavrsni datum tekuceg kola
            string pocetniDatum = "'2019-04-20'", zavrsniDatum = "'2019-04-23'";

            string naredbaDodajSumuTiketaUFond =
                "INSERT INTO Fondovi " +
                "SELECT SUM(iznos) " +
                "	FROM Transakcije " +
                "WHERE tip_transakcije = 'tiket' AND datum between" + pocetniDatum + "  AND" + zavrsniDatum + ";" +

                "INSERT INTO Fondovi " +
                "SELECT SUM(stanje_na_fondu) " +
                "FROM Fondovi " +
                "WHERE [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi) " +
                "OR [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)-1 " +
                "DELETE FROM Fondovi " +
                "WHERE  [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)-1";

            konekcija.IzvrsiNonQuery(naredbaDodajSumuTiketaUFond);
        }

        public void UcitajDobitnike()
        {
            SqlConnection conn = konekcija.Connect();
            conn.Open();
            SqlCommand komandaVratiSveDobitnike = new SqlCommand("SELECT [vrsta_pogotka],[fk_racuni_id] FROM Dobitnici", conn);
            var reader = komandaVratiSveDobitnike.ExecuteReader();
            while (reader.Read())
            {
                dobitnici.Add(
                   new Dobitnik(
                    reader["vrsta_pogotka"].ToString(),
                    Convert.ToInt32(reader["fk_racuni_id"])
                    ));
            }
            conn.Close();

        }

        public void IzracunajFondove(double ukupanFond,
                                    bool izvucenaSedmica)
        {
            int brojDobitnika4Vrste = Convert.ToInt32(PrebrojDobitnikeVrste("4"));

            //Izvaja se fond za cetiri dobitaka(zamena) od ukupnog fonda, pre racunanja fondova za vece dobitke
            ukupanFond -= fondZaDobitak4Pogotka = brojDobitnika4Vrste * cenaJednogTiketa;
            fondZaDobitak5Pogotka = VratiProcenat(ukupanFond, 10d);
            fondZaDobitak6Pogotka = VratiProcenat(ukupanFond, 30d);
            fondZaDobitak7Pogotka = VratiProcenat(ukupanFond, 60d);

            fondZaHumanitarneSvrhe += VratiProcenat(fondZaDobitak5Pogotka, 20d);
            fondZaNaplatuAdministratoru += VratiProcenat(fondZaDobitak5Pogotka, 2d);
            fondZaDobitak5Pogotka -= VratiProcenat(fondZaDobitak5Pogotka, 22d);

            fondZaHumanitarneSvrhe += VratiProcenat(fondZaDobitak6Pogotka, 20d);
            fondZaNaplatuAdministratoru += VratiProcenat(fondZaDobitak6Pogotka, 2d);
            fondZaDobitak6Pogotka -= VratiProcenat(fondZaDobitak6Pogotka, 22d);

            if (izvucenaSedmica)
            {
                fondZaHumanitarneSvrhe += VratiProcenat(fondZaDobitak7Pogotka, 20d);
                fondZaNaplatuAdministratoru += VratiProcenat(fondZaDobitak7Pogotka, 2d);
                fondZaDobitak7Pogotka -= VratiProcenat(fondZaDobitak7Pogotka, 22d);
            }

        }
        /// <summary>
        /// Pomocna Metoda koja poziva SQL upit nad bazom fondova
        /// </summary>
        /// <param name="polozajOdPoslednjeg">0 je poslednji, 1 pretposlednji itd.</param>
        /// <returns>Vraca nagradni fond iz baze na zadatom polozaju od pozadi</returns>
        public double VratiNagradniFondIzBaze(int polozajOdPoslednjeg = 0)
        {
            string naredbaVratiPoslednjuVrednostFonda = "SELECT stanje_na_fondu " +
                "FROM Fondovi " +
                "WHERE [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id)-" + polozajOdPoslednjeg + " FROM Fondovi)";
         
            string ukupanFondString = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaVratiPoslednjuVrednostFonda);
            return Convert.ToDouble(ukupanFondString);

        }

        public double PrebrojDobitnikeVrste(string vrstaDobitka)
        {
            double broj = 0;

            string naredbaPrebrojDobitnikeVrste = "SELECT COUNT(*) AS broj FROM Dobitnici WHERE vrsta_pogotka = '" + vrstaDobitka + "' ";
         
            string brojString = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaPrebrojDobitnikeVrste);
            broj = Convert.ToDouble(brojString);
            return broj;
        }


        public void IzvrsiNaplateIzFonda()
        {
            double pojedinacniDobitakZa4Pogotka = fondZaDobitak4Pogotka / PrebrojDobitnikeVrste("4");
            double pojedinacniDobitakZa5Pogotka = fondZaDobitak5Pogotka / PrebrojDobitnikeVrste("5");
            double pojedinacniDobitakZa6Pogotka = fondZaDobitak6Pogotka / PrebrojDobitnikeVrste("6");
            double pojedinacniDobitakZa7Pogotka = fondZaDobitak7Pogotka / PrebrojDobitnikeVrste("7");
            string datum = "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

            foreach (Dobitnik trenutni in dobitnici)
            {
                if (trenutni.vrstaPogotka == "4")
                {
                    BazaNapraviTransakciju(pojedinacniDobitakZa4Pogotka, datum, trenutni.idRacuna, "'nagrada'");
                }
                if (trenutni.vrstaPogotka == "5")
                {
                    BazaNapraviTransakciju(pojedinacniDobitakZa5Pogotka, datum, trenutni.idRacuna, "'nagrada'");
                }
                if (trenutni.vrstaPogotka == "6")
                {
                    BazaNapraviTransakciju(pojedinacniDobitakZa6Pogotka, datum, trenutni.idRacuna, "'nagrada'");
                }
                if (trenutni.vrstaPogotka == "7")
                {
                    BazaNapraviTransakciju(pojedinacniDobitakZa7Pogotka, datum, trenutni.idRacuna, "'nagrada'");
                }
            }

            int idRacunaHumanitarneOrganizacije = Convert.ToInt32(Session["humanitarni_fond_racun_id"]);
            int idRacunaAdmina = Convert.ToInt32(Session["admin_racun_id"]);
            BazaNapraviTransakciju(fondZaHumanitarneSvrhe, datum, idRacunaHumanitarneOrganizacije, "'humanitarna'");
            BazaNapraviTransakciju(fondZaNaplatuAdministratoru, datum, idRacunaAdmina, "'organizatoru'");

        }

        public void BazaNapraviTransakciju(double novac, string datum, int idRacuna, string tipTransakcije)
        {
            //SVE VREDNOSTI U JEDNOJ NAREDBI MOZDA? Klasa Transakcija
            string naredbaNapraviTransakcijuKorisniku = "INSERT INTO Transakcije " +
                "(iznos,datum,fk_racuni_id,tip_transakcije) " +
                "VALUES (" +
                 novac + "," +
                 datum + "," +
                 idRacuna + "," +
                 tipTransakcije + ");";
         
            konekcija.IzvrsiNonQuery(naredbaNapraviTransakcijuKorisniku);

        }

        public void AzurirajFond(bool izvucenaSedmica)
        {
            string naredbaAzuriraj = "";
            if (izvucenaSedmica)
            {
                naredbaAzuriraj = "INSERT INTO Fondovi (stanje_na_fondu) VALUES (0)";
            }
            else
            {
                naredbaAzuriraj = "INSERT INTO Fondovi (stanje_na_fondu) VALUES (" + fondZaDobitak7Pogotka + "); ";
            }

            konekcija.IzvrsiNonQuery(naredbaAzuriraj);

        }

        public void PrikaziRezultateNaStranici()
        {
            int pretposlednjiIzFonda = 1;
            double ukupanIznosFonda = VratiNagradniFondIzBaze(pretposlednjiIzFonda);

            double preneseniFondZaSledeceKolo = VratiNagradniFondIzBaze();
            // fiksirano na 10 jer nam je to kolo u kojem imamo sve test podatke
            int idPoslednjegKola = 10;
            string naredbaPrebrojUplacenoTiketa = "SELECT COUNT(*) FROM Tiketi WHERE fk_kola_id =" + idPoslednjegKola + ";";
            string uplacenoTiketa = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaPrebrojUplacenoTiketa);

            string naredbaPrebrojIzvuceneDobitnike = "SELECT COUNT(*) FROM Dobitnici ";
            string izvucenoDobitaka = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaPrebrojIzvuceneDobitnike);

            LabelUkupanIznosFonda.Text = ukupanIznosFonda.ToString();
            LabelPreneseniFond.Text = preneseniFondZaSledeceKolo.ToString();
            LabelUplacenoTiketa.Text = uplacenoTiketa;
            LabelIzvucenoDobitaka.Text = izvucenoDobitaka;

            LabelSedmica.Text = PrebrojDobitnikeVrste("7").ToString();
            LabelSestica.Text = PrebrojDobitnikeVrste("6").ToString();
            LabelPetica.Text = PrebrojDobitnikeVrste("5").ToString();
            LabelCetvorka.Text = PrebrojDobitnikeVrste("4").ToString();

            LabelIsplataSedmice.Text = fondZaDobitak7Pogotka.ToString();
            LabelIsplataSestice.Text = fondZaDobitak6Pogotka.ToString();
            LabelIsplataPetice.Text = fondZaDobitak5Pogotka.ToString();
            LabelIsplataCetvorke.Text = fondZaDobitak4Pogotka.ToString();
        }

        private class Dobitnik
        {
            public string username;
            public string vrstaPogotka;
            public int idRacuna;
            public int idTiketa;

            public Dobitnik(string vrstaPogotka, int idRacuna)
            {
                this.vrstaPogotka = vrstaPogotka;
                this.idRacuna = idRacuna;
            }
        }

        public double VratiProcenat(double vrednost, double procenat)
        {
            return vrednost / (100d / procenat);
        }

    
    }
}
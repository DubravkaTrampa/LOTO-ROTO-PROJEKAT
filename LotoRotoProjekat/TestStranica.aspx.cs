using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotoRotoProjekat
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Dobitnik> dobitnici = new List<Dobitnik>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonZavrsiKolo_Click(object sender, EventArgs e)
        {

            string pocetniDatum = "'2019-04-20'", zavrsniDatum = "'2019-04-23'";

            string naredbaDodajSumuTiketaUFond =
                "INSERT INTO Fondovi " +
                "SELECT SUM(iznos) " +
                "	FROM Transakcije " +
                "WHERE tip_transakcije = 'tiket' AND datum between"+ pocetniDatum +"  AND"+ zavrsniDatum + ";" +

                "INSERT INTO Fondovi " +
                "SELECT SUM(stanje_na_fondu) " +
                "FROM Fondovi " +
                "WHERE [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi) " +
                "OR [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)-1 " +
                "DELETE FROM Fondovi " +
                "WHERE  [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)-1";


            SqlConnection conn = konekcija.Connect();
            conn.Open();
            new SqlCommand(naredbaDodajSumuTiketaUFond, conn).ExecuteNonQuery();
            conn.Close();
           // int fkRacuniId = Int32.Parse(komandaNaciIdRacuna.ExecuteScalar().ToString());
        }

        int cenaJednogTiketa = 100;
        // Pojedinacne uplatne vrednosti zavisno od dobitka
        double fondZaDobitak4Pogotka = 0;
        double fondZaDobitak5Pogotka = 0;
        double fondZaDobitak6Pogotka = 0;
        double fondZaDobitak7Pogotka = 0;
        double fondZaHumanitarneSvrhe = 0;
        double fondZaNaplatuAdministratoru = 0;

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
        public void UcitajDobitnike()
        {
            //UPITI ZA PRONALAZENJE BROJA RACUNA, I PREKO BROJA RACUNA NACI USERNAME SVIH DOBITNIKA. TEST PODACI
            for(int i = 0; i < 4; i++)
            {
                dobitnici.Add(new Dobitnik("4", 2));
            }
            for (int i = 0; i < 3; i++)
            {
                dobitnici.Add(new Dobitnik("5", 2));
            }
            for (int i = 0; i < 2; i++)
            {
                dobitnici.Add(new Dobitnik("6", 2));
            }
            for (int i = 0; i < 1; i++)
            {
                dobitnici.Add(new Dobitnik("7", 2));
            }
        }

        public void NaplatiKorisniku(int idRacuna,
                                     double novac,
                                     string usernameKorisnika)
        {
            string tipTransakcije = "'nagrada'";
            string datum ="'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

            string naredbaNapraviTransakcijuKorisniku = "INSERT INTO Transakcije " +
                "(iznos,datum,fk_racuni_id,tip_transakcije) " +
                "VALUES (" +
                 novac + "," + 
                 datum + "," +
                 idRacuna + "," +
                 tipTransakcije + ");";

            new SqlCommand(naredbaNapraviTransakcijuKorisniku, konekcija.Connect());
        }

        public void NaplatiOrganizacijama(int idRacunaHumanitarne,int idRacunaVlasnika, int novac)
        {
            string tipTransakcije = "'humanitarna'";
            string datum = "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

            string naredbaNapraviTransakcijuKorisniku = "INSERT INTO Transakcije " +
                "(iznos,datum,fk_racuni_id,tip_transakcije) " +
                "VALUES (" +
                 novac + "," +
                 datum + "," +
                 idRacunaHumanitarne + "," +
                 tipTransakcije + ");";

            new SqlCommand(naredbaNapraviTransakcijuKorisniku, konekcija.Connect());
        }

        public void IzvrsiNaplateIzFonda()
        {   //IZVUCI IZ BAZE ODREDJENIM UPITOM KAKO BI MOGLI DA RASPOREDIMO NAGRADE
            double pojedinacniDobitakZa4Pogotka = fondZaDobitak4Pogotka / 4d;
            double pojedinacniDobitakZa5Pogotka = fondZaDobitak5Pogotka / 3d;
            double pojedinacniDobitakZa6Pogotka = fondZaDobitak6Pogotka / 2d;
            double pojedinacniDobitakZa7Pogotka = fondZaDobitak7Pogotka / 1d;
            string datum = "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            //IZVUCI IZ TABELE DOBITNIKA BROJ DOBITNIKA
            foreach (Dobitnik trenutni in dobitnici)
            {
                if(trenutni.vrstaPogotka == "4")
                {
                    NapraviTransakciju(pojedinacniDobitakZa4Pogotka, datum , 2, "'nagrada'");
                }
                if (trenutni.vrstaPogotka == "5")
                {
                    NapraviTransakciju(pojedinacniDobitakZa5Pogotka, datum , 2, "'nagrada'");
                }
                if (trenutni.vrstaPogotka == "6")
                {
                    NapraviTransakciju(pojedinacniDobitakZa6Pogotka, datum , 2, "'nagrada'");
                }
                if (trenutni.vrstaPogotka == "7")
                {
                    NapraviTransakciju(pojedinacniDobitakZa7Pogotka, datum , 2, "'nagrada'");
                }
            }

            NapraviTransakciju(fondZaHumanitarneSvrhe, datum, 2, "'humanitarna'");
            NapraviTransakciju(fondZaNaplatuAdministratoru, datum, 2, "'organizatoru'");

        }

        public void NapraviTransakciju(double novac, string datum , int idRacuna, string tipTransakcije)
        {

            string naredbaNapraviTransakcijuKorisniku = "INSERT INTO Transakcije " +
                "(iznos,datum,fk_racuni_id,tip_transakcije) " +
                "VALUES (" +
                 novac + "," +
                 datum + "," +
                 idRacuna + "," +
                 tipTransakcije + ");";
            SqlConnection conn = konekcija.Connect();
            conn.Open();
            new SqlCommand(naredbaNapraviTransakcijuKorisniku, conn).ExecuteNonQuery();
            conn.Close();
        }

        public double VratiNagradniFond()
        {
            string naredbaVratiPoslednjuVrednostFonda = "SELECT stanje_na_fondu " +
                "FROM Fondovi " +
                "WHERE [pk_fondovi_id] = (SELECT MAX(pk_fondovi_id) FROM Fondovi)";
            SqlConnection conn= konekcija.Connect();
            conn.Open();
            SqlCommand komandaVratiStanjeNaFondu = new SqlCommand(naredbaVratiPoslednjuVrednostFonda, conn);
            int ukupanFond = Int32.Parse(komandaVratiStanjeNaFondu.ExecuteScalar().ToString());
            conn.Close();
            return Convert.ToDouble(ukupanFond);
        }

        public void IzracunajFondove(double ukupanFond,
                                     int brojDobitnika4Kombinacije,
                                     bool izvucenaSedmica)
        {
            //Izvaja se fond za cetiri dobitaka(zamena) od ukupnog fonda, pre racunanja fondova za vece dobitke
            ukupanFond -= fondZaDobitak4Pogotka = brojDobitnika4Kombinacije * cenaJednogTiketa;
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
        public double VratiProcenat(double vrednost, double procenat)
        {
            return vrednost / (100d / procenat);
        }

        protected void buttonZapocniKolo_Click(object sender, EventArgs e)
        {
            UcitajDobitnike();
            IzracunajFondove(VratiNagradniFond(),4,true);
            IzvrsiNaplateIzFonda();
        }
    }
}
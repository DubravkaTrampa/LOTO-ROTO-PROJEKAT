using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;

namespace LotoRotoProjekat
{
    public partial class IgrajTiket : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                NapraviTiketGridView();
                NapraviMojiTiketiGridView();
            }

        }

        void NapraviMojiTiketiGridView()
        {

            DataTable dt = new DataTable();
            DodajKoloneUGridViewMojTiket(dt);
            //lista id-eva svih kombinacija koje je korisnik uplatio u trenutnom kolu
            List<int> IdkombinacijaTiketaLista = VratiListuIdTiketKombinacija();

            foreach (int trenutniIdKombinacije in IdkombinacijaTiketaLista)
            {
                DataRow novRed = NapraviRedOdBrojevaKombinacije(trenutniIdKombinacije, dt);
                //nakon punjenja reda podacima, dodajemo ga u tabelu
                dt.Rows.Add(novRed);
            }

           
            GridViewMojiTiketi.DataSource = dt;
            GridViewMojiTiketi.DataBind();
        }

        void DodajKoloneUGridViewMojTiket(DataTable dt)
        {
            string[] naziviKolona = { "Broj 1", "Broj 2", "Broj 3", "Broj 4", "Broj 5", "Broj 6", "Broj 7", "Broj 8", "Broj 9"
                ,"Broj 10", "Broj 11", "Broj 12", "Broj 13", "Broj 14"};
            int brojKolona = 14;
            //dodaj kolone u grid view
            for (int i = 0; i < brojKolona; i++)
            {
                dt.Columns.Add(naziviKolona[i], typeof(string));
            }
        }

        List<int> VratiListuIdTiketKombinacija()
        {
            string naredbaNadjiPoslednjeKolo = "SELECT MAX(pk_kola_id) FROM Kola";
            string naredbaBrojTiketaKorisnikaTrenutnoKolo = "SELECT [tiket_kombinacija_id]" +
               " FROM Tiketi" +
               " WHERE fk_korisnici_id = " + Session["id_ulogovanog_korisnika"]+
                     " AND fk_kola_id = "+konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaNadjiPoslednjeKolo);

            List<int> tiketKombinacijaIdevi = new List<int>();
            SqlConnection conn = konekcija.Connect();
            conn.Open();

            SqlCommand komanda = new SqlCommand(naredbaBrojTiketaKorisnikaTrenutnoKolo, conn);
            var reader = komanda.ExecuteReader();

            while (reader.Read())
            {
                int trenutniTiketKombinacijaId = Convert.ToInt32(reader["tiket_kombinacija_id"]);
                tiketKombinacijaIdevi.Add(trenutniTiketKombinacijaId);
            }

            conn.Close();
            return tiketKombinacijaIdevi;
        }

        DataRow NapraviRedOdBrojevaKombinacije(int idKombinacije, DataTable dt)
        {
            DataRow NewRow = dt.NewRow();
            SqlConnection conn = konekcija.Connect();
            conn.Open();

            string naredbaNadjiKombinaciju = "SELECT [broj] FROM Kombinacije WHERE kombinacija_id = " + idKombinacije;
            SqlCommand komanda = new SqlCommand(naredbaNadjiKombinaciju, conn);
            var reader = komanda.ExecuteReader();
            //promenljiva kolona sluzi za kretanje po kolonama
            int kolona = 0;

            while (reader.Read())
            {
                //u kolonu dodaj vrednost procitanog broja
                NewRow[kolona] = reader["broj"].ToString();
                kolona++;
            }

            return NewRow;
        }

        void NapraviTiketGridView()
        {
            DataTable dt = new DataTable();
            string[] naziviKolona = { "Prvo", "Drugo", "Trece", "Cetvrto", "Peto", "Sesto", "Sedmo", "Osmo", "Deveto"
                ,"Deseto", "Jedanaesto", "Dvanaesto", "Trinaesto"};
            int brojKolona = 13; int brojRedova = 3;

            for (int i = 0; i < brojKolona; i++)
            {
                dt.Columns.Add(naziviKolona[i], typeof(string));
            }

            for (int i = 0; i < brojRedova; i++)
            {
                DodajRedTiketa(brojKolona, dt, i);
            }
            //dodaj podatke u grid view
            GridViewNov.DataSource = dt;
            GridViewNov.DataBind();
        }

        void DodajRedTiketa(int brojKolona, DataTable dt, int indeksReda)
        {
            DataRow NewRow = dt.NewRow();
            for (int j = 0; j < brojKolona; j++)
            {
                //1,2,3,4... 37,38,39
                NewRow[j] = Convert.ToString((indeksReda * brojKolona) + j + 1);
            }
            //nakon punjenja reda podacima, dodajemo ga u tabelu
            dt.Rows.Add(NewRow);
        }


        protected void ButtonOtvoriTiket_Click(object sender, EventArgs e)
        {
            GridViewNov.Visible = true;
        }

        protected void GridViewNov_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ObradiKlikIAzurirajTiket(e);
            ButtonOtvoriTiket.Text = KombinacijeKlasa.kombinacije.Count.ToString();

        }

        void ObradiKlikIAzurirajTiket(GridViewCommandEventArgs e)
        {
            string[] naziviKolona = { "Prvo", "Drugo", "Trece", "Cetvrto", "Peto", "Sesto", "Sedmo", "Osmo", "Deveto"
                ,"Deseto", "Jedanaesto", "Dvanaesto", "Trinaesto"};
            int brojKolona = naziviKolona.Length;

            //kretanje po kolonama
            for (int indeksKolone = 0; indeksKolone < brojKolona; indeksKolone++)
            {
                // ako je naziv kliknute kolone jednak i-tom nazivu kolone
                if (e.CommandName == naziviKolona[indeksKolone])
                {
                    // commandArgument = indeks Reda
                    int indeksReda = Int32.Parse(e.CommandArgument.ToString());
                    int kliknutBroj = (indeksReda * brojKolona) + indeksKolone + 1;
                    AzurirajTiket(kliknutBroj, Int32.Parse(e.CommandArgument.ToString()), indeksKolone);
                }
            }
        }
        void AzurirajTiket(int broj, int red, int kolona)
        {
            if (KombinacijeKlasa.kombinacije.Count == 0)
            {
                KombinacijeKlasa.kombinacije.Add(broj);
                LabelPrikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();
                GridViewNov.Rows[red].Cells[kolona].BackColor = ColorTranslator.FromHtml("#e83e8c");
                return;
            }
            int i = 0;
            foreach (int trenutni in KombinacijeKlasa.kombinacije)
            {
                if (trenutni == broj)
                {
                    KombinacijeKlasa.kombinacije.RemoveAt(i);
                    GridViewNov.Rows[red].Cells[kolona].BackColor = ColorTranslator.FromHtml("#ffffff");
                    LabelPrikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();

                    return;
                }
                i++;

            }
            if (KombinacijeKlasa.kombinacije.Count < 14)
            {
                KombinacijeKlasa.kombinacije.Add(broj);
                GridViewNov.Rows[red].Cells[kolona].BackColor = ColorTranslator.FromHtml("#e83e8c");
                LabelPrikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();

            }
        }

        protected void BtnDodajRandomTiket_Click(object sender, EventArgs e)
        {
            List<int> randomKombinacije = new List<int>();
            int[] moguciBrojevi = new int[39];
            for (int i = 0; i < moguciBrojevi.Length; i++)
            {
                moguciBrojevi[i] = i + 1;
            }
            int brojDodatihRandomTiketaPoKliku = 5;
            for(int i = 0; i < brojDodatihRandomTiketaPoKliku; i++)
            {
                randomKombinacije = NapraviRandomKombinaciju(moguciBrojevi);
                PotvrdiTiketSaKombinacijom(randomKombinacije);
            }
           
        }

        List<int> NapraviRandomKombinaciju(int[] moguciBrojevi)
        {
            //Mesanje niza
            Random rnd = new Random();
            for (int i = moguciBrojevi.Length - 1; i > 0; i--)
            {
                int index = rnd.Next(i + 1);
                // Simple swap
                int a = moguciBrojevi[index];
                moguciBrojevi[index] = moguciBrojevi[i];
                moguciBrojevi[i] = a;
            }
            //punjenje liste sa prvih 14 izmesanih brojeva
            List<int> izmesanaLista = new List<int>();
            for(int i=0; i < 14; i++)
            {
                izmesanaLista.Add(moguciBrojevi[i]); 
            }
            return izmesanaLista;
        }

        protected void BtnPotvrdiTiket_Click(object sender, EventArgs e)
        {

            List<Int32> kombinacije = KombinacijeKlasa.kombinacije;
            PotvrdiTiketSaKombinacijom(kombinacije);
        }

        void PotvrdiTiketSaKombinacijom(List<int> kombinacije)
        {
            int maxBrojevaPoTiketu = 14;

            if (kombinacije.Count < maxBrojevaPoTiketu)
            {
                return;
            }

            kombinacije.Sort();
            //UPIT ZA NALAZENJE ID-A POSLEDNJEG KOLA U POMOCNOJ KLASI
            string naredbaNadjiPoslednjeKolo = "SELECT pk_kola_id FROM Kola WHERE pk_kola_id = (SELECT MAX(pk_kola_id) FROM Kola)";
            string idKolaString = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaNadjiPoslednjeKolo);
            int idKola = Convert.ToInt32(idKolaString);
            BazaPodatakaNapraviTiket(idKola);
            BazaPodatakaNapraviKombinacijuTiketa(kombinacije, NadjiTiketKombinacijaId());
            BazaPodatakaNapraviTransakcijuTiketa();
            ResetujTiket(kombinacije);
        } 


        public void BazaPodatakaNapraviTiket(int idKola)
        {
            StringBuilder potvrdiTiket = new StringBuilder("INSERT INTO");
            potvrdiTiket.Append(" Tiketi (fk_korisnici_id, fk_kola_id)");
            potvrdiTiket.Append("VALUES (" + Session["id_ulogovanog_korisnika"] + "," + idKola + ")");
            konekcija.IzvrsiNonQuery(potvrdiTiket.ToString());
        }


        public void BazaPodatakaNapraviKombinacijuTiketa(List<int> kombinacije, int tiketKombinacijaId)
        {
            //STRING BUILDER
            string narebaDodajBrojUKombinaciju = "INSERT INTO Kombinacije(broj,kombinacija_id) VALUES ";
            for (int i = 0; i < 13; i++)
            {
                narebaDodajBrojUKombinaciju += "(" + kombinacije[i] + "," + tiketKombinacijaId + "),";
            }
            narebaDodajBrojUKombinaciju += "(" + kombinacije[13] + "," + tiketKombinacijaId + ")";

            konekcija.IzvrsiNonQuery(narebaDodajBrojUKombinaciju);

        }

        public int NadjiTiketKombinacijaId()
        {
            string naredbaNadjiKombinacijaId = "SELECT MAX(tiket_kombinacija_id)" +
                " FROM Tiketi" +
                " WHERE fk_korisnici_id =" + Session["id_ulogovanog_korisnika"];
            int tiketKombinacijaId = Int32.Parse(konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaNadjiKombinacijaId));
            return tiketKombinacijaId;

        }

        public void BazaPodatakaNapraviTransakcijuTiketa()
        {
            //TREBA DA SE UNESE DANASNJI DATUM
            int idRacuna = Convert.ToInt32(Session["id_racuna"]);
            string naredbaZavrsniDatum = "SELECT datum FROM Kola WHERE pk_kola_id = (SELECT MAX(pk_kola_id) FROM Kola)";
            string zavrsniDatumKola = konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaZavrsniDatum);
            DateTime datum = DateTime.Parse(zavrsniDatumKola).AddDays(-1);
            //KLASA ZA RAD SA TRANSAKCIJAMA SA METODOM NAPRAVI TRANSAKCIJU
            string naredbaNapraviTransakciju = "INSERT INTO Transakcije" +
                " (iznos,datum,fk_racuni_id,tip_transakcije)" +
                " VALUES (100,'" + datum.ToString("yyyy-MM-dd")
                + "'," + idRacuna + ",'tiket')";
          
            konekcija.IzvrsiNonQuery(naredbaNapraviTransakciju);

        }
        public void ResetujTiket(List<int> kombinacije) {

            kombinacije.Clear();
            // GridViewNov.Rows.Count = broj redova
            for (int i = 0; i < GridViewNov.Rows.Count; i++)
            {
                //GridViewNov.Rows[i].Cells.Count = broj kolona
                for (int j = 0; j < GridViewNov.Rows[i].Cells.Count; j++)
                {
                    GridViewNov.Rows[i].Cells[j].BackColor = ColorTranslator.FromHtml("#ffffff");
                }
            }
            LabelPrikazKombinacijeTiketa.Text = "Uspešno ste uplatili tiket!";
            ButtonOtvoriTiket.Text = "Izaberi novu kombinaciju.";
        }
    }
}
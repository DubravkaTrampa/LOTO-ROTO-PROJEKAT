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

        String ispis ;
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
            SqlConnection conn = konekcija.Connect();//connection name

            conn.Open();
            int idUlogovanogKorisnika = Convert.ToInt32(Session["id_ulogovanog_korisnika"]);
            string naredbaSelektujMojeTikete = "SELECT * FROM Tiketi WHERE [fk_korisnici_id]=" + idUlogovanogKorisnika;
            SqlCommand cmd = new SqlCommand(naredbaSelektujMojeTikete, conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "ss");

            GridViewMojiTiketi.DataSource = ds.Tables["ss"];
            GridViewMojiTiketi.DataBind();
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
                DodajRed(brojKolona, dt, i);
            }
            //dodaj podatke u grid view
            GridViewNov.DataSource = dt;
            GridViewNov.DataBind();
        }

        void DodajRed(int brojKolona, DataTable dt, int indeksReda)
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

            for (int i = 0; i < brojKolona; i++)
            {
                // ako je naziv kliknute kolone jednak i-tom nazivu kolone
                if (e.CommandName == naziviKolona[i])
                {
                    // commandArgument = indeks Reda
                    int broj = (Int32.Parse(e.CommandArgument.ToString()) * brojKolona) + i + 1;
                    AzurirajTiket(broj, Int32.Parse(e.CommandArgument.ToString()), i);
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


        protected void BtnPotvrdiTiket_Click(object sender, EventArgs e)
        {

            List<Int32> kombinacije = KombinacijeKlasa.kombinacije;
            int maxBrojevaPoTiketu = 14;

            if (kombinacije.Count < maxBrojevaPoTiketu)
            {
                return;
            }

            kombinacije.Sort();
            //POSLEDNJE KOLO PREKO UPITA
            int idKola = 10;
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
            //KLASA ZA RAD SA TRANSAKCIJAMA SA METODOM NAPRAVI TRANSAKCIJU
            string naredbaNapraviTransakciju = "INSERT INTO Transakcije" +
                " (iznos,datum,fk_racuni_id,tip_transakcije)" +
                " VALUES (100,'2019-04-21'," + idRacuna + ",'tiket')";
          
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
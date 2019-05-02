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
            }

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
                NewRow[j] = Convert.ToString((indeksReda * brojKolona) + j + 1);
            }
            dt.Rows.Add(NewRow);
        }


        protected void buttonClick_Click1(object sender, EventArgs e)
        {
            GridViewNov.Visible = true;
        }

        protected void GridViewNov_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ObradiKlikIAzurirajTiket(e);
            PrikazTrenutneKombinacije();

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            SqlConnection conn = konekcija.Connect();
=======
>>>>>>> e31ae5226b6d7e68f9c4291dbcc73bd97d5981a8
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


        void ObradiKlikIAzurirajTiket(GridViewCommandEventArgs e)
        {
            string[] naziviKolona = { "Prvo", "Drugo", "Trece", "Cetvrto", "Peto", "Sesto", "Sedmo", "Osmo", "Deveto"
                ,"Deseto", "Jedanaesto", "Dvanaesto", "Trinaesto"};
            int brojKolona = naziviKolona.Length;
            int broj = 0;

            for (int i = 0; i < brojKolona; i++)
            {
                if (e.CommandName == naziviKolona[i])
                {
                    broj = (Int32.Parse(e.CommandArgument.ToString()) * brojKolona) + i + 1;
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
                GridViewNov.Rows[red].Cells[kolona].BackColor =ColorTranslator.FromHtml("#e83e8c");
                LabelPrikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();

            }
        }

        void PrikazTrenutneKombinacije()
        {
            foreach (int trenutni in KombinacijeKlasa.kombinacije)
            {
                ispis += Convert.ToString(trenutni) + " , ";
            }

            ButtonOtvoriTiket.Text = KombinacijeKlasa.kombinacije.Count.ToString();
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
            for (int i = 0; i < GridViewNov.Rows.Count; i++)
            {
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
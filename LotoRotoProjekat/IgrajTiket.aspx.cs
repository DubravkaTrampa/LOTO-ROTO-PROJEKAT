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
            SqlConnection conn = konekcija.Connect();
            List<Int32> kombinacije = Class1.kombinacije;
            int maxBrojevaPoTiketu = 14;

            if (kombinacije.Count < maxBrojevaPoTiketu)
            {
                return;
            }

            kombinacije.Sort();
            //POSLEDNJE KOLO PREKO UPITA
            int idKola = 10;
            BazaPodatakaNapraviTiket(idKola, conn);
            BazaPodatakaNapraviKombinacijuTiketa(kombinacije, NadjiTiketKombinacijaId(conn), conn);
            BazaPodatakaNapraviTransakcijuTiketa(conn);
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
            if (Class1.kombinacije.Count == 0)
            {
                Class1.kombinacije.Add(broj);
                LabelPrikazKombinacijeTiketa.Text = Class1.stringKombinacija();
                GridViewNov.Rows[red].Cells[kolona].BackColor = ColorTranslator.FromHtml("#e83e8c");
                return;
            }
            int i = 0;
            foreach (int trenutni in Class1.kombinacije)
                {
                if (trenutni == broj)
                {
                    Class1.kombinacije.RemoveAt(i);
                    GridViewNov.Rows[red].Cells[kolona].BackColor = ColorTranslator.FromHtml("#ffffff");
                    LabelPrikazKombinacijeTiketa.Text = Class1.stringKombinacija();

                    return;
                }
                i++;

            }
            if (Class1.kombinacije.Count < 14)
            {
                  Class1.kombinacije.Add(broj);
                GridViewNov.Rows[red].Cells[kolona].BackColor =ColorTranslator.FromHtml("#e83e8c");
                LabelPrikazKombinacijeTiketa.Text = Class1.stringKombinacija();

            }
        }

        void PrikazTrenutneKombinacije()
        {
            foreach (int trenutni in Class1.kombinacije)
            {
                ispis += Convert.ToString(trenutni) + " , ";
            }

            ButtonOtvoriTiket.Text = Class1.kombinacije.Count.ToString();
        }


        public void BazaPodatakaNapraviTiket(int idKola, SqlConnection conn)
        {
            StringBuilder potvrdiTiket = new StringBuilder("INSERT INTO");
            potvrdiTiket.Append(" Tiketi (fk_korisnici_id, fk_kola_id)");
            potvrdiTiket.Append("VALUES (" + Session["id_ulogovanog_korisnika"] + "," + idKola + ")");
            conn.Open();
            new SqlCommand(potvrdiTiket.ToString(), conn).ExecuteNonQuery();
            conn.Close();
        }


        public void BazaPodatakaNapraviKombinacijuTiketa(List<int> kombinacije, int tiketKombinacijaId, SqlConnection conn)
        {
            string narebaDodajBrojUKombinaciju = "INSERT INTO Kombinacije(broj,kombinacija_id) VALUES ";
            for (int i = 0; i < 13; i++)
            {
                narebaDodajBrojUKombinaciju += "(" + kombinacije[i] + "," + tiketKombinacijaId + "),";
            }
            narebaDodajBrojUKombinaciju += "(" + kombinacije[13] + "," + tiketKombinacijaId + ")";

            conn.Open();
            new SqlCommand(narebaDodajBrojUKombinaciju, conn).ExecuteNonQuery();
            conn.Close();

        }

        public int NadjiTiketKombinacijaId(SqlConnection conn)
        {
            string naredbaNadjiKombinacijaId = "SELECT MAX(tiket_kombinacija_id) FROM Tiketi WHERE fk_korisnici_id =" + Session["id_ulogovanog_korisnika"];
            conn.Open();
            SqlCommand komandaNadjiIdKombinacije = new SqlCommand(naredbaNadjiKombinacijaId, conn);
            int tiketKombinacijaId = Int32.Parse(komandaNadjiIdKombinacije.ExecuteScalar().ToString());
            conn.Close();
            return tiketKombinacijaId;

        }

        public void BazaPodatakaNapraviTransakcijuTiketa(SqlConnection conn)
        {
            //TREBA DA SE UNESE DANASNJI DATUM
            int idRacuna = Convert.ToInt32(Session["id_racuna"]);
            //KLASA ZA RAD SA TRANSAKCIJAMA SA METODOM NAPRAVI TRANSAKCIJU
            string naredbaNapraviTransakciju = "INSERT INTO Transakcije (iznos,datum,fk_racuni_id,tip_transakcije) VALUES (100,'2019-04-21'," + idRacuna + ",'tiket')";
            conn.Open();
            new SqlCommand(naredbaNapraviTransakciju, conn).ExecuteNonQuery();
            conn.Close();

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LotoRotoProjekat
{
    public partial class Igraj : System.Web.UI.Page
    {
        //List<Int32> kombinacije;
        String ispis = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Button button = new Button();
          
            if (!IsPostBack)
            {
                buttonClick.Text = "Izaberi kombinaciju";
                // kombinacije = new List<int>();
                ButtonField btn = new ButtonField();

                DataTable dt = new DataTable();

                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("Prvi", typeof(string));
                    dt.Columns.Add("Drugi", typeof(string));
                    dt.Columns.Add("Treci", typeof(string));
                }

                int i;
                for (i = 0; i < 13; i++)
                {

                    DataRow NewRow = dt.NewRow();
                    NewRow[0] = Convert.ToString(i * 3 + 1);
                    NewRow[1] = Convert.ToString(i * 3 + 2);
                    NewRow[2] = Convert.ToString(i * 3 + 3);

                    dt.Rows.Add(NewRow);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnSubmitName_Click(object sender, EventArgs e)
        {

        }

        protected void buttonClick_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int broj = 0;
            if (e.CommandName == "Prvi")
            {
                broj = (Int32.Parse(e.CommandArgument.ToString()) * 3) + 1;
                ObradiKliknutBrojKombinacije(broj, Int32.Parse(e.CommandArgument.ToString()), 0);
            }
            if (e.CommandName == "Drugi")
            {
                broj = (Int32.Parse(e.CommandArgument.ToString()) * 3) + 2;
                ObradiKliknutBrojKombinacije(broj, Int32.Parse(e.CommandArgument.ToString()),1);
            }
            if (e.CommandName == "Treci")
            {
                broj = (Int32.Parse(e.CommandArgument.ToString()) * 3) + 3;
                ObradiKliknutBrojKombinacije(broj, Int32.Parse(e.CommandArgument.ToString()), 2);
            }
            foreach (int trenutni in KombinacijeKlasa.kombinacije)
            {
                ispis += Convert.ToString(trenutni) + " , ";
            }
            buttonClick.Text = KombinacijeKlasa.kombinacije.Count.ToString();


        }

        void ObradiKliknutBrojKombinacije(int broj,int red,int kolona)
        {
            if (KombinacijeKlasa.kombinacije.Count == 0)
            {
                KombinacijeKlasa.kombinacije.Add(broj);
                prikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();
                GridView1.Rows[red].Cells[kolona].BackColor = System.Drawing.ColorTranslator.FromHtml("#e83e8c");
                return;
            }
            int i = 0;
            foreach (int trenutni in KombinacijeKlasa.kombinacije)
            {
                if (trenutni == broj)
                {
                    KombinacijeKlasa.kombinacije.RemoveAt(i);
                    GridView1.Rows[red].Cells[kolona].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    prikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();
                    return;
                }
                i++;

            }
            if (KombinacijeKlasa.kombinacije.Count < 14)
            {
                KombinacijeKlasa.kombinacije.Add(broj);
                GridView1.Rows[red].Cells[kolona].BackColor = System.Drawing.ColorTranslator.FromHtml("#e83e8c");
                prikazKombinacijeTiketa.Text = KombinacijeKlasa.stringKombinacija();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konekcija.Connect();
            List<Int32> kombinacije = KombinacijeKlasa.kombinacije;
            if (kombinacije.Count < 14)
            {
                return;
            }
            kombinacije.Sort();
            int idKola = 8;
            StringBuilder potvrdiTiket = new StringBuilder("INSERT INTO");
            potvrdiTiket.Append(" Tiketi (fk_korisnici_id, fk_kola_id)");
            //OVDE TREBA NACI ID TRENUTNOG KORISNIKA I ID TRENUTNOG KOLA
            potvrdiTiket.Append("VALUES (" +Session["id_ulogovanog_korisnika"] +","+idKola+")");
            conn.Open();
            new SqlCommand(potvrdiTiket.ToString(), conn).ExecuteNonQuery();
            //FK KORISNIKA SE UNOSI KAO VREDNOST TRENUTNO ULOGOVANOG KORISNIKA; Naredba vraca poslednji id kombinacije tiketa
            string naredbaNadjiKombinacijaId = "SELECT MAX(tiket_kombinacija_id) FROM Tiketi WHERE fk_korisnici_id ="+ Session["id_ulogovanog_korisnika"];
            SqlCommand komandaNadjiIdKombinacije = new SqlCommand(naredbaNadjiKombinacijaId, conn);
            int tiketKombinacijaId = Int32.Parse(komandaNadjiIdKombinacije.ExecuteScalar().ToString());

            string narebaDodajBrojUKombinaciju = "INSERT INTO Kombinacije(broj,kombinacija_id) VALUES ";
            for (int i = 0; i < 13; i++)
            {
                narebaDodajBrojUKombinaciju += "(" + kombinacije[i] + "," + tiketKombinacijaId + "),";
            }
            narebaDodajBrojUKombinaciju += "(" + kombinacije[13] + "," + tiketKombinacijaId + ")";

            new SqlCommand(narebaDodajBrojUKombinaciju, conn).ExecuteNonQuery();
            //TREBA DA SE UNESE BROJ RACUNA NA OSNOVU KORISNIKA KOJI JE ULOGOVAN I DANASNJI DATUM
            int brRacuna = 6;
            string naredbaNapraviTransakciju = "INSERT INTO Transakcije (iznos,datum,fk_racuni_id,tip_transakcije) VALUES (100,'2019-04-21',"+brRacuna+",'tiket')";
            new SqlCommand(naredbaNapraviTransakciju, conn).ExecuteNonQuery();

            conn.Close();
            kombinacije.Clear();
        }

    }
}
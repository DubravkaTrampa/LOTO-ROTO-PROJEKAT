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
    public partial class IgrajTiket : System.Web.UI.Page
    {
        String ispis = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Button button = new Button();

            if (!IsPostBack) {
                buttonClick1.Text = "Izaberi kombinaciju";
                // kombinacije = new List<int>();
                ButtonField btn = new ButtonField();

                DataTable dt = new DataTable();
                string [] nazivi = { "Prvo", "Drugo", "Trece", "Cetvrto", "Peto", "Sesto", "Sedmo", "Osmo", "Deveto"
                ,"Deseto", "Jedanaesto", "Dvanaesto", "Trinaesto"};
                if (dt.Columns.Count == 0)
                {
                    for (int i=0; i<13; i++)
                {
                   
                        dt.Columns.Add(nazivi[i], typeof(string));
                }
                    }
             
                for (int i = 0; i < 3; i++)
                {
                    DataRow NewRow = dt.NewRow();

                    for (int j = 0; j < 13; j++)
                    {
                        NewRow[j] = Convert.ToString((i * 13 )+ j+1);
                    }
                        dt.Rows.Add(NewRow);
                    
                }
                GridViewNov.DataSource = dt;
                GridViewNov.DataBind();
            }
        }
        protected void buttonClick_Click1(object sender, EventArgs e)
        {
            GridViewNov.Visible = true;
        }
        protected void GridViewNov_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] nazivi = { "Prvo", "Drugo", "Trece", "Cetvrto", "Peto", "Sesto", "Sedmo", "Osmo", "Deveto"
                ,"Deseto", "Jedanaesto", "Dvanaesto", "Trinaesto"};
            int brojKolona = 13;
            int broj = 0;
            for(int i=0; i<brojKolona; i++)
            {
                if (e.CommandName == nazivi[i])
                {
                    broj = (Int32.Parse(e.CommandArgument.ToString()) * brojKolona) + i+1;
                    ObradiKliknutBrojKombinacije(broj, Int32.Parse(e.CommandArgument.ToString()), i);
                }
            }

            foreach (int trenutni in Class1.kombinacije)
            {
                ispis += Convert.ToString(trenutni) + " , ";
            }
            buttonClick1.Text = Class1.kombinacije.Count.ToString();
        }
        void ObradiKliknutBrojKombinacije(int broj, int red, int kolona)
        {
            if (Class1.kombinacije.Count == 0)
            {
                Class1.kombinacije.Add(broj);
                prikazKombinacijeTiketa.Text = Class1.stringKombinacija();
                GridViewNov.Rows[red].Cells[kolona].BackColor = System.Drawing.ColorTranslator.FromHtml("#e83e8c");
                return;
            }
            int i = 0;
            foreach (int trenutni in Class1.kombinacije)
            {
                if (trenutni == broj)
                {
                    Class1.kombinacije.RemoveAt(i);
                    GridViewNov.Rows[red].Cells[kolona].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    prikazKombinacijeTiketa.Text = Class1.stringKombinacija();
                    return;
                }
                i++;

            }
            if (Class1.kombinacije.Count < 14)
            {
                Class1.kombinacije.Add(broj);
                GridViewNov.Rows[red].Cells[kolona].BackColor = System.Drawing.ColorTranslator.FromHtml("#e83e8c");
                prikazKombinacijeTiketa.Text = Class1.stringKombinacija();

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konekcija.Connect();
            List<Int32> kombinacije = Class1.kombinacije;
            if (kombinacije.Count < 14)
            {
                return;
            }
            kombinacije.Sort();

            StringBuilder potvrdiTiket = new StringBuilder("INSERT INTO");
            potvrdiTiket.Append(" Tiketi (fk_korisnici_id, fk_kola_id)");
            //OVDE TREBA NACI ID TRENUTNOG KORISNIKA I ID TRENUTNOG KOLA
            potvrdiTiket.Append("VALUES (1,2)");
            conn.Open();
            new SqlCommand(potvrdiTiket.ToString(), conn).ExecuteNonQuery();
            //FK KORISNIKA SE UNOSI KAO VREDNOST TRENUTNO ULOGOVANOG KORISNIKA; Naredba vraca poslednji id kombinacije tiketa
            string naredbaNadjiKombinacijaId = "SELECT MAX(tiket_kombinacija_id) FROM Tiketi WHERE fk_korisnici_id = 1";
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
            string naredbaNapraviTransakciju = "INSERT INTO Transakcije (iznos,datum,fk_racuni_id,tip_transakcije) VALUES (100,'2019-04-21',2,'tiket')";
            new SqlCommand(naredbaNapraviTransakciju, conn).ExecuteNonQuery();

            conn.Close();
            kombinacije.Clear();
        }
    }
}
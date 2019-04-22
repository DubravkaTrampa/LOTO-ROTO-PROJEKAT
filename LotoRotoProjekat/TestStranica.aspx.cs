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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonZavrsiKolo_Click(object sender, EventArgs e)
        {
           /* string naredbaZavrsiKolo = "INSERT INTO Fondovi SELECT SUM(iznos) FROM Transakcije WHERE tip_transakcije = 'tiket' AND datum between '2019-04-20' AND '2019-04-23';";
            SqlConnection conn = konekcija.Connect();
            SqlCommand komandaNaciIdRacuna = new SqlCommand(naredbaZavrsiKolo, conn);
            SqlCommand komandaUnesiNoviRacun = new SqlCommand(naredbaZavrsiKolo, conn);
            conn.Open();
            komandaUnesiNoviRacun.ExecuteNonQuery();
            int fkRacuniId = Int32.Parse(komandaNaciIdRacuna.ExecuteScalar().ToString());*/
        }
    }
}
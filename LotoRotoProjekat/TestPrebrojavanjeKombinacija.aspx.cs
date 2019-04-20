using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LotoRotoProjekat
{
    public partial class TestPrebrojavanjeKombinacija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection conn = konekcija.Connect();
            SqlCommand komanda = new SqlCommand("SELECT * FROM " + "Kombinacija", conn);
            conn.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                TableRow TR = new TableRow();
                for (int i = 0; i < citac.FieldCount; i++)
                {
                    TableCell TD = new TableCell();
                    TD.Text = citac[i].ToString();
                    TR.Cells.Add(TD);
                }
                Table1.Rows.Add(TR);
            }
            conn.Close();
        }
    }
}
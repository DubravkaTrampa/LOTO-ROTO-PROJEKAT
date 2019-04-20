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
                    ObradiKliknutBrojKombinacije(broj);
                

                }
                if (e.CommandName == "Drugi")
                {
                    broj = (Int32.Parse(e.CommandArgument.ToString()) * 3) + 2;
                    ObradiKliknutBrojKombinacije(broj);
                }
                if (e.CommandName == "Treci")
                {
                    broj = (Int32.Parse(e.CommandArgument.ToString()) * 3) + 3;
                    ObradiKliknutBrojKombinacije(broj);
                }
                foreach (int trenutni in Class1.kombinacije)
                {
                    ispis += Convert.ToString(trenutni) + " , ";
                }
                buttonClick.Text = Class1.kombinacije.Count.ToString();


            }

            void ObradiKliknutBrojKombinacije(int broj)
            {
                if (Class1.kombinacije.Count == 0)
                {
                    Class1.kombinacije.Add(broj);
                    prikazKombinacijeTiketa.Text = Class1.stringKombinacija();
                    return;
                }
                int i = 0;
                foreach (int trenutni in Class1.kombinacije)
                {
                    if (trenutni == broj)
                    {
                        Class1.kombinacije.RemoveAt(i);
                        prikazKombinacijeTiketa.Text = Class1.stringKombinacija();
                    return;
                    }
                    i++;

                }
                if (Class1.kombinacije.Count < 14)
                {
                Class1.kombinacije.Add(broj);
                prikazKombinacijeTiketa.Text = Class1.stringKombinacija();
                
                }
            }

            protected void Button1_Click(object sender, EventArgs e)
            {
                SqlConnection conn = konekcija.Connect();
                List<Int32> kombinacije = Class1.kombinacije;
                if (kombinacije.Count < 14)
                {
                    return;
                }
                kombinacije.Sort();


                StringBuilder PotvrdiUplatu = new StringBuilder("INSERT INTO ");
                PotvrdiUplatu.Append(" Kombinacija (");
                PotvrdiUplatu.Append("Broj_1,Broj_2,Broj_3,Broj_4 ,Broj_5 ");
                PotvrdiUplatu.Append(",Broj_6,Broj_7 ,Broj_8 ");
                PotvrdiUplatu.Append(",Broj_9,Broj_10 ,Broj_11 ");
                PotvrdiUplatu.Append(",Broj_12,Broj_13,Broj_14 )");
                PotvrdiUplatu.Append($"VALUES(");
                for (int i = 0; i < 13; i++)
                {
                    PotvrdiUplatu.Append($"'{kombinacije[i]}',");
                }
                PotvrdiUplatu.Append($"'{kombinacije[13]}')");
                /*  $"'{brKomb1}'," +
                  $"'{brKomb2}'," +
                  $"'{brKomb3}'," +
                  $"'{brKomb4}'," +
                  $"'{brKomb5}'," +
                  $"'{brKomb6}'," +
                  $"'{brKomb7}'," +
                  $"'{brKomb8}'," +
                  $"'{brKomb9}'," +
                  $"'{brKomb10}'," +
                  $"'{brKomb11}'," +
                  $"'{brKomb12}'," +
                  $"'{brKomb13}'," +
                  $"'{brKomb14}')");*/
                SqlCommand potvrdiTiketNaredba = new SqlCommand(PotvrdiUplatu.ToString(), conn);
                conn.Open();
                potvrdiTiketNaredba.ExecuteNonQuery();
                conn.Close();
                kombinacije.Clear();
            }
        }
}
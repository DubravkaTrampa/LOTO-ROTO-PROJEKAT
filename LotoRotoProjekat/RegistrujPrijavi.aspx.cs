using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LotoRotoProjekat
{
    public partial class RegistrujPrijavi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("korisnik=" + Session["Korisnik"]);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
                string Korisničko_ime = PlaceHolder_login.Text;
                string Lozinka = PlaceHolder_pass.Text;

                string naredba = "select * FROM korisnik WHERE Username='" + Korisničko_ime + "'";
                SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
                DataTable Korisnik = new DataTable();
                da.Fill(Korisnik);
                if (Korisnik.Rows.Count == 0)
                {   
                    Response.Redirect("RegistrujPrijavi.aspx");
                    
            }
                else
                {
                    string DBPass = Korisnik.Rows[0]["pass"].ToString();
                    if (!Lozinka.Equals(DBPass))
                    {
                        Response.Write("Losa lozinka");
                    }
                    else
                    {
                        // UPISI U SQL PODATKE O LOGOVANJU Time, Date...
                        Session["Korisnik"] = Korisničko_ime;
                        Session["TipKorisnika"] = Korisnik.Rows[0]["TipKorisnika"].ToString();
                        Session["Ime"] = Korisnik.Rows[0][3].ToString();

                        SqlConnection conn = konekcija.Connect();
                        SqlCommand komanda2 = new SqlCommand("update Korisnik set logInDate = GETDATE() where Username = '" + Korisničko_ime + "'", conn);
                        SqlCommand komanda3 = new SqlCommand("UPDATE KORISNIK SET logInTime = CONVERT( TIME, concat(datepart(hour, getdate()), ':',datepart(minute, getdate()), ':',datepart(SECOND, getdate()))) where Username = '" + Korisničko_ime + "'", conn);
                        conn.Open();
                        komanda2.ExecuteNonQuery();
                        komanda3.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("Igraj.aspx");
                    }
                
            }
        }
                protected void btnRegister_Click(object sender, EventArgs e)
                {
                    string username = PlaceHolder_register.Text;
                    string pass = PlaceHolder_password.Text;
                    string pass2 = PlaceHolder_pass2.Text;
                    string ime = PlaceHolder_ime.Text;
                    string prezime = PlaceHolder_prezime.Text;
                    string datumRodj = PlaceHolder_datum_rodj.Text;
                    string adresa = PlaceHolder_adresa.Text;
                    string grad = PlaceHolder_grad.Text;
                    string brRacuna = PlaceHolder_racun.Text;
                    string tel = PlaceHolder_tel.Text;
                    string email = PlaceHolder_email.Text;

                    bool lozinkeJednake = pass == pass2;



                    // Response.Write(ime +prezime+ datum+ email +username +password + password2);



                    string naredbaUname = "SELECT * FROM Korisnik WHERE Username='" + username + "'";
                    string naredbaGrad = "SELECT ID FROM Grad WHERE Naziv LIKE'" + grad + "'";
                    SqlConnection conn = konekcija.Connect();
                    SqlDataAdapter da = new SqlDataAdapter(naredbaUname, conn);
                    DataTable korisnik = new DataTable();
                    da.Fill(korisnik);

                    if (korisnik.Rows.Count == 0)
                    {

                        SqlCommand komandaNaciIDGrada = new SqlCommand(naredbaGrad, conn);
                        conn.Open();
                        int gradID = Int32.Parse(komandaNaciIDGrada.ExecuteScalar().ToString());


                        Response.Write("Nema ga");
                        string logInDate = DateTime.Now.ToString("yyyy-MM-dd");
                        DateTime sad = DateTime.Now;
                        string logInTime = sad.Hour.ToString() + ":" + sad.Minute.ToString();
                        StringBuilder NaredbaBtnPotvrdi = new StringBuilder("INSERT INTO ");
                        NaredbaBtnPotvrdi.Append(" Korisnik (");
                        NaredbaBtnPotvrdi.Append("Username,Pass,Ime,Prezime ,DatumRodj ");
                        NaredbaBtnPotvrdi.Append(",logInDate,logInTime ,Adresa ");
                        NaredbaBtnPotvrdi.Append(",GradID,BrRacuna ,Tel ");
                        NaredbaBtnPotvrdi.Append(",Email,TipKorisnika )");
                        NaredbaBtnPotvrdi.Append($"VALUES(" +
                            $"'{username}'," +
                            $"'{pass}'," +
                            $"'{ime}'," +
                            $"'{prezime}'," +
                            $"'{datumRodj}'," +
                            $"'{logInDate}'," +
                            $"'{logInTime}'," +
                            $"'{adresa}'," +
                            $"'{gradID}'," +
                            $"'{brRacuna}'," +
                            $"'{tel}'," +
                            $"'{email}'," +
                            $"'igrac')");
                        Response.Write(NaredbaBtnPotvrdi.ToString());


                        SqlCommand Komanda = new SqlCommand(NaredbaBtnPotvrdi.ToString(), conn);
                        Komanda.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        Response.Write("Ima ga");
                    }
                }
    }
 }

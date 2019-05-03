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
            //IZMENITI U POSLEDNJI PUT STE SE LOGOVALI
            Response.Write("korisnik=" + Session["Korisnik"]);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
                string Korisničko_ime = PlaceHolder_login.Text;
                string Lozinka = PlaceHolder_pass.Text;
                
                string naredba = "select * FROM korisnici WHERE username='" + Korisničko_ime + "'";
                SqlDataAdapter da = new SqlDataAdapter(naredba, konekcija.Connect());
                DataTable tabelaKorisnici = new DataTable();

                //UREDITI KOD
                da.Fill(tabelaKorisnici);

                if (tabelaKorisnici.Rows.Count == 0)
                    {   
                        Response.Redirect("RegistrujPrijavi.aspx");
                    }
                else
                    {
                  

                string DBPass = VratiPodatakIzTabele(tabelaKorisnici, "password").ToString();

                        if (!Lozinka.Equals(DBPass))
                        {
                        //URADITI ISPIS PORUKE NA EKRANU I SPRECITI LOGOVANJE
                            Response.Write("Losa lozinka");
                        }
                    else
                    {
                    int idKorisnika = Convert.ToInt32(VratiPodatakIzTabele(tabelaKorisnici, "pk_korisnici_id"));
                    int idRacuna = Convert.ToInt32(VratiPodatakIzTabele(tabelaKorisnici, "fk_racuni_id"));

                    Session["id_racuna"] = idRacuna;
                    Session["id_ulogovanog_korisnika"] = idKorisnika;
                    Session["tip_korisnika"] = VratiPodatakIzTabele(tabelaKorisnici, "tip_korisnika").ToString();
                    Session["ime"] = VratiPodatakIzTabele(tabelaKorisnici, "ime").ToString();
                    // KORISNIK
                    Session["Korisnici"] = Korisničko_ime;

                    string naredbaAzurirajLogInDate = "update Korisnici set log_in_date = GETDATE()" +
                        " where username = '" + Korisničko_ime + "'";
                    string naredbaAzurirajLogInTime = "UPDATE Korisnici SET log_in_time =" +
                        " CONVERT( TIME, concat(datepart(hour, getdate()), ':',datepart(minute, getdate()), ':',datepart(SECOND, getdate())))" +
                        " where username = '" + Korisničko_ime + "'";
                    
                    konekcija.IzvrsiNonQuery(naredbaAzurirajLogInDate);
                    konekcija.IzvrsiNonQuery(naredbaAzurirajLogInTime);
                    Session["bool_korisnik_ulogovan"] = true;
                    Response.Redirect("Pocetna.aspx");
                    }
            }
        }

        public object VratiPodatakIzTabele(DataTable tabela, string nazivKolone, int pronadjeniKorisnik = 0)
        {
            return tabela.Rows[pronadjeniKorisnik][nazivKolone];
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
                    string brRacuna = PlaceHolder_racun.Text;
                    string tel = PlaceHolder_tel.Text;
                    string email = PlaceHolder_email.Text;

                    bool lozinkeJednake = pass == pass2;
                    if (!lozinkeJednake)
                    {
                        //UBACITI PORUKU KOJA KAZE DA NISU JEDNAKE LOZINKE
                        return;
                    }

                    // KLASA PROVERI DA LI KORISNIK POSTOJI
                    string naredbaUname = "SELECT * FROM Korisnici WHERE username='" + username + "' OR email= '"+email+"' ";
            
                    SqlConnection conn = konekcija.Connect();
                    SqlDataAdapter da = new SqlDataAdapter(naredbaUname, conn);
                    DataTable tabelaKorisnici = new DataTable();
                    da.Fill(tabelaKorisnici);

                    bool korisnikNePostoji = tabelaKorisnici.Rows.Count == 0;
                    if (korisnikNePostoji)
                    {
                        int fkRacuniId = DodajNovRacunUBazuIVratiID(brRacuna);

                        string logInDate = DateTime.Now.ToString("yyyy-MM-dd");
                        DateTime sad = DateTime.Now;
                        string logInTime = sad.Hour.ToString() + ":" + sad.Minute.ToString();
                        StringBuilder NaredbaBtnPotvrdi = new StringBuilder("INSERT INTO ");
                        NaredbaBtnPotvrdi.Append(" Korisnici (");
                        NaredbaBtnPotvrdi.Append("username,password,ime,prezime ,datum_rodjenja ");
                        NaredbaBtnPotvrdi.Append(",log_in_date,log_in_time ,adresa ");
                        NaredbaBtnPotvrdi.Append(",telefon ,email");
                        NaredbaBtnPotvrdi.Append(",tip_korisnika ,fk_racuni_id )");
                        NaredbaBtnPotvrdi.Append($"VALUES(" +
                    $"'{username}'," +
                    $"'{pass}'," +
                    $"'{ime}'," +
                    $"'{prezime}'," +
                    $"'{datumRodj}'," +
                    $"'{logInDate}'," +
                    $"'{logInTime}'," +
                    $"'{adresa}'," +
                    $"'{tel}'," +
                    $"'{email}'," +
                    $"'igrac'," +
                    $"'{fkRacuniId}')");

                    konekcija.IzvrsiNonQuery(NaredbaBtnPotvrdi.ToString());
                     
                    }
                }

        int DodajNovRacunUBazuIVratiID(string brojRacuna)
        {
            string naredbaNapraviRacun = "INSERT INTO Racuni (broj_racuna) VALUES (" + brojRacuna + ");";
            string naredbaIdRacuna = "SELECT pk_racuni_id FROM Racuni WHERE broj_racuna ='" + brojRacuna + "'";

            konekcija.IzvrsiNonQuery(naredbaNapraviRacun);
            int idRacuna = Int32.Parse(konekcija.IzvrsiScalarQueryIVratiVrednost(naredbaIdRacuna));
            return idRacuna;
        }

    }
 }

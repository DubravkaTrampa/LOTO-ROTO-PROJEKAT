using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace LotoRotoProjekat
{
    public class konekcija
    {
        /* static public SqlConnection Connect()
       {
           SqlConnection conn = new SqlConnection(
           WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
           return conn;
       }*/


        static string myServer = Environment.MachineName;
        static string CS = ("Data Source= DESKTOP-ADN1GHD\\DUDASQL;Initial Catalog= LotoRotoNovo ;Integrated Security=True;MultipleActiveResultSets=True");
        static public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(CS);
            return conn;
        }

        public static void IzvrsiNonQuery(string naredba)
        {
            //PROVERITI DA LI POSTOJE JOS NEKE LOKACIJE U KODU GDE SE OVA METODA MOZE PRIMENITI
            SqlConnection conn = Connect();
            conn.Open();
            new SqlCommand(naredba, conn).ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Metoda koja uneti string upit izvrsava i treba da vrati njegovu skalarnu vrednost.
        /// Izvrsava je nad konekcijom definisanom u konekcija klasi
        /// </summary>
        /// <returns>string vrednost koju ExecuteScalarQuery vraca kao string</returns>
        public static string IzvrsiScalarQueryIVratiVrednost(string naredba)
        {
            //PROVERITI DA LI POSTOJE JOS NEKE LOKACIJE U KODU GDE SE OVA METODA MOZE PRIMENITI
            string scalar = "";
            SqlConnection conn = konekcija.Connect();
            conn.Open();
            scalar = new SqlCommand(naredba, conn).ExecuteScalar().ToString();
            conn.Close();
            return scalar;
        }

    }
}
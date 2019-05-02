using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotoRotoProjekat
{
    public class KombinacijeKlasa
    {
        public static List<Int32> kombinacije = new List<int>();

        public static string stringKombinacija()
        {
            if(kombinacije.Count!=0)
            kombinacije.Sort();
            string kombinacija = null;

            foreach (int trenutni in kombinacije)
            {
                if(kombinacija==null)
                kombinacija += trenutni.ToString();
                else
                kombinacija += ","+ trenutni.ToString();

            }

            return kombinacija;
        }

    }
}
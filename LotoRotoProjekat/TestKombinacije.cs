using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotoRotoProjekat
{
    public class TestKombinacije
    {
            static int PrebrojPogotke(int[] kombinacija, int[] dobitnaKombinacija)
            {
                int broj = 0;
                for (int i = 0; i < 14; i++)
                {
                    for (int j = 0; j < 14; j++)
                    {
                        //Ako su ostali brojevi dobitne kombinacije veci brojevi nemoj traziti dalje; premasili smo trazeni broj
                        if (kombinacija[i] < dobitnaKombinacija[j])
                            break;
                        if (kombinacija[i] == dobitnaKombinacija[j])
                        {
                            broj++;
                        }
                    }
                }

                return broj;
            }

            static void Main(string[] args)
            {
                int[] dobitnaKombinacija = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 26, 27, 30, 33, 36 };
                int[] kombinacija2Pogodaka = { 1, 4, 8, 11, 14, 18, 19, 21, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija3Pogodaka = { 1, 4, 7, 11, 14, 18, 19, 21, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija4Pogodaka = { 1, 4, 7, 10, 14, 18, 19, 21, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija5Pogodaka = { 1, 4, 7, 10, 13, 18, 19, 21, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija6Pogodaka = { 1, 4, 7, 10, 13, 17, 19, 21, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija7Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 21, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija8Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 23, 28, 29, 31, 34, 37 };
                int[] kombinacija9Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 28, 29, 31, 34, 37 };
                int[] kombinacija10Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 26, 29, 31, 34, 37 };
                int[] kombinacija11Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 26, 27, 31, 34, 37 };
                int[] kombinacija12Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 26, 27, 30, 34, 37 };
                int[] kombinacija13Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 26, 27, 30, 33, 37 };
                int[] kombinacija14Pogodaka = { 1, 4, 7, 10, 13, 16, 17, 20, 22, 26, 27, 30, 33, 36 };
                int[] kombinacija4PogodakaIzmesano = { 1, 10, 12, 13, 14, 16, 21, 23, 24, 25, 28, 34, 35, 39 };
                int[] kombinacija5PogodakaIzmesano = { 2, 4, 6, 7, 9, 15, 17, 20, 24, 28, 30, 32, 37, 38 };
                int[] kombinacija6PogodakaIzmesano = { 2, 4, 6, 7, 9, 15, 17, 20, 24, 26, 30, 32, 37, 38 };
                int[] kombinacija7PogodakaIzmesano = { 2, 4, 6, 7, 9, 15, 17, 20, 24, 26, 30, 32, 36, 38 };
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine("Testiranje dobitnih kombinacija: ");
                IspisTestaKombinacije(kombinacija2Pogodaka, dobitnaKombinacija, 2);
                IspisTestaKombinacije(kombinacija3Pogodaka, dobitnaKombinacija, 3);
                IspisTestaKombinacije(kombinacija4Pogodaka, dobitnaKombinacija, 4);
                IspisTestaKombinacije(kombinacija5Pogodaka, dobitnaKombinacija, 5);
                IspisTestaKombinacije(kombinacija6Pogodaka, dobitnaKombinacija, 6);
                IspisTestaKombinacije(kombinacija7Pogodaka, dobitnaKombinacija, 7);
                IspisTestaKombinacije(kombinacija8Pogodaka, dobitnaKombinacija, 8);
                IspisTestaKombinacije(kombinacija9Pogodaka, dobitnaKombinacija, 9);
                IspisTestaKombinacije(kombinacija10Pogodaka, dobitnaKombinacija, 10);
                IspisTestaKombinacije(kombinacija11Pogodaka, dobitnaKombinacija, 11);
                IspisTestaKombinacije(kombinacija12Pogodaka, dobitnaKombinacija, 12);
                IspisTestaKombinacije(kombinacija13Pogodaka, dobitnaKombinacija, 13);
                IspisTestaKombinacije(kombinacija14Pogodaka, dobitnaKombinacija, 14);
                IspisTestaKombinacije(kombinacija4Pogodaka, dobitnaKombinacija, 4);
                IspisTestaKombinacije(kombinacija5Pogodaka, dobitnaKombinacija, 5);
                IspisTestaKombinacije(kombinacija6Pogodaka, dobitnaKombinacija, 6);
                IspisTestaKombinacije(kombinacija7Pogodaka, dobitnaKombinacija, 7);
                Console.WriteLine(watch.ElapsedMilliseconds);
                Console.ReadKey();
            }

            public static void IspisTestaKombinacije(int[] kombinacija, int[] dobitnaKombinacija, int brojOcekivanihPogodaka)
            {
                Console.WriteLine("Dobitni Tiket je: ");
                for (int i = 0; i < 14; i++)
                {
                    Console.Write(dobitnaKombinacija[i] + " ,");
                }
                Console.WriteLine();
                Console.WriteLine("Uplaceni Tiket je:");
                for (int i = 0; i < 14; i++)
                {
                    Console.Write(kombinacija[i] + " ,");
                }
                Console.WriteLine();
                Console.WriteLine("Ukupno imamo : [" + PrebrojPogotke(kombinacija, dobitnaKombinacija) + "] dobitaka");
                Console.WriteLine("Ocekivani broj dobitaka je bio : [" + brojOcekivanihPogodaka + "] brojeva");
                Console.WriteLine();
            }
    }
}
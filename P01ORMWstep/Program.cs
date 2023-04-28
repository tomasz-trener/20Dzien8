using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P01ORMWstep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ORM - Object - Relation - Mapping 
            // Jest on wolniejszy niż natywne zapytania SQL 

            ModelBazyDataContext model = new ModelBazyDataContext();


            //select * from Zawodnicy
            Zawodnik[] zawodnicy = model.Zawodnik.ToArray();


            //select * from Zawodnicy where kraj = 'pol'

            // to zapytanie zadziało lokalnie (w naszej aplikacij)
            Zawodnik[] wyn1 = zawodnicy.Where(x => x.kraj == "POL").ToArray();

            // to zapytanie zadziałoło na bazie danych
            Zawodnik[] wyn2 = model.Zawodnik.Where(x => x.kraj == "pol").ToArray();


            // LINQ 

            string[] napisy = { "BACHLEDA", "MATEJA", "HERR" };

            string[] wynik = napisy.Where(x => x.Length > 4).ToArray();

            //Console.WriteLine(string.Join(" ",wynik));

            int[] liczby = { 4, 6, 33, 2, 30, 20, 22 };

            int[] wynik2 = liczby
                .Where(x => x > 20)
                .OrderByDescending(x => x)
                .ToArray();


            /*
             * select * from Zawodnicy
               where kraj = 'pol' or kraj = 'ger'
               order by kraj desc, wzrost
            */

            var wyn3 = model.Zawodnik
                .Where(x => x.kraj == "pol" || x.kraj == "ger")
                .OrderByDescending(x => x.kraj)
                .ThenBy(x => x.wzrost)
                .ToArray();


            var wyn4 = model.Zawodnik
              .Where(x => x.kraj.Equals("pol") || x.kraj == "ger")
              .OrderByDescending(x => x.kraj)
              .ThenBy(x => x.wzrost)
              .ToArray();


            string a = "ala";
            bool b = a.Equals("ala");

            var wyn5 = model.Zawodnik.Where(x => x.imie.Substring(0, 1) == "g").ToArray();

            var wyn6 = model.Zawodnik.Where(x => x.data_ur.Value.Year > 1980).ToArray();

            var wyn7 = model.Zawodnik
                .ToArray()
                .Where(x => x.data_ur != null && x.data_ur.Value.ToString("yyyy") == "1981" ||
                // x.kraj == "ger" ? x.kraj[0] == 'g' : x.kraj[1]=='o'
                (x.kraj == "pol" && x.kraj[0] == 'g') ||
                (x.kraj == "ger" && x.kraj[1] == 'o')
                ).ToArray();


            // znajdz zawodników, których nazwisko konczy się na litere a 
            // oraz wzrost jest ponad 2 razy wiekszy niz waga
            // urodzonych w II polowie roku, i posortouj po dlugosci imienia 

            int x1 = 4;
            int? x2 = 5;
            int x3 = x2.Value;
            //   int x4 = x2;

            /*
             * select * from Zawodnicy
            where RIGHT(nazwisko,1) = 'a' and wzrost > waga*2 and MONTH(data_ur) > 6
            order by len(imie)*/

            var wyn8 = model.Zawodnik
                .Where(x => x.nazwisko.EndsWith("a") && x.wzrost > x.waga * 2 &&
                 x.data_ur.Value.Month > 6)
                .OrderBy(x => x.imie.Length)
                .ToArray();


            //select * from Zawodnicy
            Zawodnik[] wyn9 = model.Zawodnik.Select(x => x).ToArray();

            string[] wyn10 = model.Zawodnik.Select(x=>x.imie).ToArray();

            string[] wyn11 = model.Zawodnik.Select(x => x.imie + " " + x.nazwisko).ToArray();

            ZawodnikMini[] wyn12 = model.Zawodnik.Select(x => new ZawodnikMini()
            {
                Imie = x.imie,
                Nazwisko = x.nazwisko
            }).ToArray();

            // typy anonimowe 

            var wyn13 = model.Zawodnik.Select(x=> new
            {
                MojeImie = x.imie,
                MojaWaga = x.waga
            }).ToArray();

            var wyn14 = model.Zawodnik.Select(x => new
            {
                 x.imie,
                 x.waga
            }).ToArray();

            foreach (var z in wyn14)
            {
                Console.WriteLine(z.imie + " " + z.waga);
            }

            // wypisz listę zawodnikow (imie nazwisko i BMI) 
            // i posortuj wyniki po BMI malejąco 
            //bmi = waga/wzrost[m]^2

            var wyn15 =model.Zawodnik.Select(x => new
            {
                x.imie,
                x.nazwisko,
                bmi =  Math.Round((double)(x.waga / Math.Pow(x.wzrost.Value / 100.0, 2)),2,MidpointRounding.AwayFromZero)
            }).ToArray();



            foreach (var z in wyn15)
            {
                Console.WriteLine(z.imie + " " + z.nazwisko + " " + z.bmi);
            }

            Console.ReadKey();



        }
    }
}

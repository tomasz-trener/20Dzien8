using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

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



            IQueryable<Zawodnik> wyn16 = model.Zawodnik.Where(x => x.kraj == "pol"); // to jeszcze nie zostało wysłane do bazy
          
            var wynik17 = wyn16.Where(x => x.wzrost > 170).ToArray();


            var wyn18=  model.Zawodnik
                .GroupBy(x => x.kraj)
                .Select(x => new
                {
                    Kraj = x.Key,
                    SredniWzrost = x.Average(y => y.wzrost)
                }).ToArray();

            //   var wyn19 = model.Zawodnik
            //      .GroupBy(x => x.kraj).ToArray();

            //  string kraj1 = wyn19[0].Key;
            //  double? wzrosty1= wyn19.Select(x => x.Average(y => y.wzrost)).First();


            // wypisz wszystkie wartości długości nazwisk, wraz z informacją ile osób posiada
            // nazwisko o podanej długości 
            //np:
            // nazwisko o długości 5 ma 4 osoby
            // nazwisko o długości 7 ma 6 osoby
            // nazwisko o długości 6 ma 6 osoby
            //.... itd..
            // wyniki posortuj po liczibie osób w grupie rosnąco
            // , a jeżeli liczba osób jest taka sama to po długości nazwiska malejąco

            // * uwzgędnij tylko zawodników, których nazwisko nie zaczyna się na "a"
            // i wypisz tylko te grupy, które zawierają co najmniej 2 osoby 



            var wyn19 = model.Zawodnik
                .Where(x => !x.nazwisko.StartsWith("a"))
                .GroupBy(x => x.nazwisko.Length)
                .Select(x => new
                {
                    DlugoscNazwiska = x.Key,
                    LiczbaOsob = x.Count(),
                    //Srednia = x.Average(y=>y.wzrost),
                    //Max = x.Max(y=>y.wzrost)
                })
                .Where(x => x.LiczbaOsob > 1)
                .OrderBy(x => x.LiczbaOsob)
                .ThenByDescending(x => x.DlugoscNazwiska)
                .ToArray();

                /*select len(nazwisko) dlugosc, count(*) liczbaOsob
                from Zawodnicy
                where LEFT(nazwisko,1) != 'a'
                group by len(nazwisko)
                having count(*) > 1
                order by liczbaOsob, dlugosc desc
                            */

            foreach (var g in wyn19)
            {
                Console.WriteLine($"Nazwisko o długości {g.DlugoscNazwiska} ma {g.LiczbaOsob} osoby");
            }

            Console.WriteLine( "------");

            var wyn20= model.Zawodnik
                .GroupBy(x => x.kraj)
                .Select(x => new
                {
                    Kraj = x.Key,
                    Nazwsika = x.Select(y=>y.nazwisko).OrderBy(y=>y)
                }).ToArray();

            foreach (var g in wyn20)
            {
                Console.WriteLine("kraj: " + g.Kraj );
                Console.WriteLine("\n - "+ string.Join("\n - ", g.Nazwsika));

            }




            //foreach (var z in wyn15)
            //{
            //    Console.WriteLine(z.imie + " " + z.nazwisko + " " + z.bmi);
            //}




            //do tej pory wiebieralśmy zawsze zbiór elementów 

            // teraz chcemy umieć znaleźć jeden wybrany rekord 

            Zawodnik wyn21 = model.Zawodnik.Where(x => x.nazwisko == "małysz").ToArray()[0];

            Zawodnik wyn22 = model.Zawodnik.Where(x => x.nazwisko == "małysz").FirstOrDefault();

            Zawodnik wyn23 = model.Zawodnik.FirstOrDefault(x => x.nazwisko == "małysz");

            Zawodnik wyn24 = model.Zawodnik.FirstOrDefault(x => x.id_zawodnika == 7);

            // znajdz zawodnikow których waga jest o dokładnie 1 kilogram mniejsza o wagi najwyższego zawodnika

            var najwyzszy = model.Zawodnik.OrderByDescending(x=>x.wzrost).FirstOrDefault();

            var wyn25 = model.Zawodnik.Where(x => x.waga == najwyzszy.waga - 1).ToArray();

            // inne rozwiazanie

            var wyn26 = model.Zawodnik.Where(x => x.waga == model.Zawodnik.OrderByDescending(y => y.wzrost).FirstOrDefault().waga - 1).ToArray();

            // jeszcze inaczej

            var najwyzszyWzrost = zawodnicy.Select(x => x.wzrost).Max();

            var wyn27 = zawodnicy
                .Where(x=> x.waga == model.Zawodnik.FirstOrDefault(y=>y.wzrost==najwyzszyWzrost).waga - 1).ToArray();

            // jeszcze inaczej

            var wyn28 = zawodnicy
              .Where(x => x.waga == model.Zawodnik.FirstOrDefault(y => y.wzrost == zawodnicy.Select(z => z.wzrost).Max()).waga - 1).ToArray();


            // dla każdego kraju wypisz imie i nazwisko najwyzszego zawodnika z tego kraju 

            var wyn29 = zawodnicy.GroupBy(x => x.kraj)
                .Select(x => new
                {
                    Kraj = x.Key,
                    Najwyzszy = x.OrderByDescending(y => y.wzrost).FirstOrDefault()
                }).ToArray();

            foreach (var g in wyn29)
            {
                Console.WriteLine(g.Kraj + " " + g.Najwyzszy.imie + " " + g.Najwyzszy.nazwisko);
            }


            // wypiz grupy nazwisk zawodnikow uruodznych w tym samym miesiacu 

            //przykładowy wynik:

            // 1 : małysz, herr, ...
            // 2 : bachleda, ....

            Console.WriteLine( "---------------");
            var wyn30 = zawodnicy
               .Where(x => x.data_ur != null)
               .GroupBy(x => x.data_ur.Value.Month)
               .Select(x => new // Grupa
               {
                   NrMiesiaca = x.Key,
                   Nazwiska = string.Join(", ", x.Select(y => y.nazwisko).ToArray())
               })
               .OrderBy(x => x.NrMiesiaca)
               .ToArray();

            //foreach( var g in wyn30)
            //    Console.WriteLine(
            //       CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.NrMiesiaca) 

            //        + " " + g.Nazwiska);


            var polskieWyrazy = new CultureInfo("pl-PL");

          
            foreach (var g in wyn30)
                Console.WriteLine(
                   polskieWyrazy.DateTimeFormat.GetMonthName(g.NrMiesiaca)

                    + " " + g.Nazwiska);


            Console.ReadKey();



        }
    }

    class Grupa
    {
        public int NrMiesiaca { get; set; }
        public string Nazwiska { get; set; }
    }
}

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
            Zawodnik[] zawodnicy= model.Zawodnik.ToArray();


            //select * from Zawodnicy where kraj = 'pol'

            // to zapytanie zadziało lokalnie (w naszej aplikacij)
            Zawodnik[] wyn1= zawodnicy.Where(x=>x.kraj=="POL").ToArray();

            // to zapytanie zadziałoło na bazie danych
            Zawodnik[] wyn2 = model.Zawodnik.Where(x => x.kraj == "pol").ToArray();


            // LINQ 

            string[] napisy = { "BACHLEDA", "MATEJA", "HERR" };

            string[] wynik = napisy.Where(x=>x.Length>4).ToArray();

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

            var wyn3= model.Zawodnik
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

            var wyn6 = model.Zawodnik.Where(x => x.data_ur.Value.Year>1980).ToArray();

            var wyn7 = model.Zawodnik
                .ToArray()
                .Where(x => x.data_ur != null && x.data_ur.Value.ToString("yyyy")=="1981" ||
              // x.kraj == "ger" ? x.kraj[0] == 'g' : x.kraj[1]=='o'
                (x.kraj =="pol" && x.kraj[0] == 'g') ||
                (x.kraj == "ger" && x.kraj[1] == 'o')
                ).ToArray();


            foreach (var z in wyn7)
            {
                Console.WriteLine(z.imie + " " + z.nazwisko + " " + z.wzrost);
            }

            Console.ReadKey();


           
        }
    }
}

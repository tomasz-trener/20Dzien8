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

            Console.WriteLine(string.Join(" ",wynik));

            int[] liczby = { 4, 6, 33, 2, 30, 20, 22 };

            int[] wynik2 = liczby.Where(x => x > 20).ToArray();


            foreach (var z in wyn1)
            {
                Console.WriteLine(z.imie + " " + z.nazwisko);
            }

            Console.ReadKey();


           
        }
    }
}

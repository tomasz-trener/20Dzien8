using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02OperacjeCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelBazyDataContext model = new ModelBazyDataContext();

            // Dodawanie danych do bazy 

            //Zawodnik nowy = new Zawodnik()
            //{
            //    imie = "adam",
            //    nazwisko = "nowak",
            //    waga = 70,
            //    wzrost = 180,
            //    kraj = "pol",
            //    data_ur = new DateTime(2000, 2, 4)
            //};

            //model.Zawodnik.InsertOnSubmit(nowy); // przygotowywujemy do wysłania do bazy 

            //Zawodnik nowy2 = new Zawodnik()
            //{
            //    imie = "jan",
            //    nazwisko = "nowak",
            //    waga = 70,
            //    wzrost = 180,
            //    kraj = "pol",
            //    data_ur = new DateTime(2000, 2, 4)
            //};

            // model.Zawodnik.InsertOnSubmit(nowy2)''

            ///model.Zawodnik.InsertAllOnSubmit(); // tutaj mogę przekazać tablicę lub listę zawodników 
            //model.SubmitChanges();


            // edycja zawodników 

            // podejście 1 
            // krok 1: najpierw pobieramy zawodnika z bazy, którego chcemy edytować 
            // krok 2: potem loklanie zmieniamy co chcemy 
            // krok 3: wywołujemy submitchantes - ta metoda sama wie co zostało zmienione i wysyła zapytanie SQL do bazy 
            //var doEdycji = model.Zawodnik.FirstOrDefault(x=>x.id_zawodnika == 2);
            //doEdycji.wzrost = doEdycji.wzrost + 5;
            //doEdycji.nazwisko = "MATEJKA";

            //Zawodnik nowy3 = new Zawodnik()
            //{
            //    wzrost = doEdycji.wzrost,
            //    nazwisko = doEdycji.nazwisko
            //};
            //model.Zawodnik.InsertOnSubmit(nowy3);


            //// podejście 2 

            //Zawodnik doEdycji = new Zawodnik()
            //{
            //    id_zawodnika = 2,
            //    nazwisko = "MATEJA2",
            //    wzrost = 200
            //};

            // model.Zawodnik.Attach(doEdycji);
            // model.SubmitChanges();

            // usuwanie 

            var doUsuniecia = model.Zawodnik.FirstOrDefault(x => x.id_zawodnika == 24);
            model.Zawodnik.DeleteOnSubmit(doUsuniecia);
            model.SubmitChanges();



        }
    }
}

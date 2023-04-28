using P02Biblioteka.Domain;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P02Biblioteka.Services
{
    public class ManagerZawodnikow
    {
      //  private List<Zawodnik> zawodnicyCache;
        private const string url = "C:\\dane\\zawodnicy.txt";

 

        public void Zapisz()
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
            var zawodnicy = model.Zawodnik.ToArray();
            const string naglowek = "id_zawodnika;id_trenera;imie;nazwisko;kraj;data urodzenia;wzrost;waga";

            string szablon = "{0};{1};{2};{3};{4};{5};{6};{7}";

            StringBuilder sb = new StringBuilder(naglowek + Environment.NewLine);
            foreach (var z in zawodnicy)
            {
                string wiersz = string.Format(szablon,
                    z.Id_zawodnika, z.Id_trenera, z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia == null? "null" : z.DataUrodzenia.Value.ToString("yyyy-MM-dd"), z.Wzrost, z.Waga);
                sb.AppendLine(wiersz);
            }
            File.WriteAllText(url, sb.ToString(), Encoding.UTF8);
        }

        // tutaj bedziemy uzywac ORM
        public Zawodnik[] WczytajZawodnikow()
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
            return model.Zawodnik.ToArray();

            //PolaczenieZBaza pzb = new PolaczenieZBaza();
            //object[][] dane = pzb.WyslijPolecenieSQL("select * from zawodnicy");

            //Zawodnik[] zawodnicy = new Zawodnik[dane.Length];
            //for ( int i = 0; i < dane.Length; i++)
            //{
            //    var w = dane[i];
            //    Zawodnik z = new Zawodnik();
            //    z.Id_zawodnika = (int)w[0];
            //    if (w[1] != DBNull.Value) // null w c# różni się od null w bazie danych 
            //        z.Id_trenera = (int)w[1];

            //    z.Imie = (string)w[2];
            //    z.Nazwisko = (string)w[3];
            //    z.Kraj= (string)w[4];

            //    if (w[5] !=  DBNull.Value)
            //        z.DataUrodzenia = (DateTime)w[5];
            //    if (w[6] != DBNull.Value)
            //        z.Wzrost = (int)w[6];
            //    if (w[7] != DBNull.Value)
            //        z.Waga = (int)w[7];

            //    zawodnicy[i] = z;
            //} 

            //zawodnicyCache = zawodnicy.ToList();
            //return zawodnicy;

        }

        // tutaj bedziemy uzuwac LINQ
        public string[] PodajKraje()
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
          //  return model.Zawodnik.Where(x=>x.Kraj != null).Select(x => x.Kraj).Distinct().ToArray();
            return model.Zawodnik.Where(x => x.Kraj != null).GroupBy(x=>x.Kraj).Select(x=>x.Key).ToArray();



            //// Zawodnik[] zawodnicy = WczytajZawodnikow();

            //if (zawodnicyCache == null)
            //    throw new Exception("Najpierw wczytaj zawodnikow");

            //List<string> kraje = new List<string>();

            //foreach (var z in zawodnicyCache)
            //    if (!kraje.Contains(z.Kraj))
            //        kraje.Add(z.Kraj);

            //return kraje.ToArray();
        }


        // tutaj mozemy zastosowac linq 
        public Zawodnik[] PodajZawodnikow(string kraj)
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
            return model.Zawodnik.Where(x => x.Kraj == kraj).ToArray();
            //List<Zawodnik> zawodnicy = new List<Zawodnik>();

            //foreach (var z in zawodnicyCache)
            //    if (z.Kraj == kraj)
            //        zawodnicy.Add(z);

            //return zawodnicy.ToArray();
        }

        // uzyc linq 
        public double PodajSredniWzrost(string kraj)
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
            return model.Zawodnik.Where(x => x.Kraj == kraj).Average(x => x.Wzrost).Value;

            //Zawodnik[] zawodnicy = PodajZawodnikow(kraj);

            //double suma = 0;
            //foreach (var z in zawodnicy)
            //    suma += z.Wzrost;

            //return suma / zawodnicy.Length;
        }

        
        // uzyc ORM 
        public void Usun(int id_zawodnika)
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
            var z = model.Zawodnik.FirstOrDefault(x=>x.Id_zawodnika == id_zawodnika);
            model.Zawodnik.DeleteOnSubmit(z);
            model.SubmitChanges();

            //PolaczenieZBaza pzb = new PolaczenieZBaza();

            //string szablon = "delete zawodnicy where id_zawodnika = {0}";

            //string sql = string.Format(szablon, id_zawodnika);

            //pzb.WyslijPolecenieSQL(sql);
            //WczytajZawodnikow();
        }

        // ORM 
        public void Edytuj(Zawodnik w)
        {
            ModelBazyDataContext model = new ModelBazyDataContext();
            var z = model.Zawodnik.FirstOrDefault(x => x.Id_zawodnika == w.Id_zawodnika);
            z.Imie = w.Imie;
            z.Nazwisko = w.Nazwisko;
            z.Kraj = w.Kraj;
            z.DataUrodzenia= w.DataUrodzenia;
            z.Wzrost= w.Wzrost;
            z.Waga= w.Waga;
            z.Id_trenera= w.Id_trenera;


            model.SubmitChanges();

            //PolaczenieZBaza pzb = new PolaczenieZBaza();

            //string szablon = @"update zawodnicy set 
            //                    imie = '{0}', 
            //                    nazwisko = '{1}',
            //                    kraj='{2}',
            //                    data_ur = {3},  
            //                    wzrost = {4},
            //                    waga = {5}
            //                    where id_zawodnika = {6}";

            //string sql = string.Format(szablon,
            //    w.Imie, w.Nazwisko, w.Kraj, w.DataUrodzenia == null? "null": $"'{ w.DataUrodzenia.Value.ToString("yyyyMMdd")}'", w.Wzrost, w.Waga, w.Id_zawodnika);

            //pzb.WyslijPolecenieSQL(sql);
            //WczytajZawodnikow();
        }

        // uzyc ORM 
        public void Dodaj(Zawodnik w)
        {
            ModelBazyDataContext modelBazyDataContext = new ModelBazyDataContext();
            modelBazyDataContext.Zawodnik.InsertOnSubmit(w);
            modelBazyDataContext.SubmitChanges();

            //PolaczenieZBaza pzb = new PolaczenieZBaza();

            //string szablon = "insert into zawodnicy values ({0},'{1}','{2}','{3}',{4},{5},{6})";

            //string sql= string.Format(szablon,
            //    w.Id_trenera == null ? "null" : w.Id_trenera.ToString(),
            //    w.Imie, w.Nazwisko, w.Kraj, w.DataUrodzenia == null ? "null" : $"'{w.DataUrodzenia.Value.ToString("yyyyMMdd")}'", w.Wzrost, w.Waga);

            //pzb.WyslijPolecenieSQL(sql);
            //WczytajZawodnikow();
        }

        public void Test()
        {

        }
    }
}

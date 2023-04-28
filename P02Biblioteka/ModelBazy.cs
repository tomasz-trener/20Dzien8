namespace P02Biblioteka
{
    partial class ModelBazyDataContext
    {

    }

    partial class Zawodnik
    {
        public string ImieNazwiskoKraj
        {
            get
            {
                return $"{Imie} {Nazwisko} ({Kraj})";
            }
        }

        public string DataSformatowana => DataUrodzenia?.ToString("yyyy-MM-dd");

        public string DaneRaportowe => $"{ImieNazwiskoKraj} {DataSformatowana}";
    }
}
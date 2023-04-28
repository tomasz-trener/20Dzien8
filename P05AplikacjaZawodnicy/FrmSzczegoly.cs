using P02Biblioteka;

using P02Biblioteka.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace P05AplikacjaZawodnicy
{

    public enum TrybOkienka
    {
        Dodawanie,
        Edycja,
        Usuwanie
    }
    public partial class FrmSzczegoly : Form
    {
   
        private Zawodnik wyswietlany;
        private ManagerZawodnikow mz;
        private FrmStartowy frmStartowy;
        private TrybOkienka trybOkienka;
        //private TrybOkienka trybOkienka => wyswietlany == null ? TrybOkienka.Dodawanie : TrybOkienka.Edycja;
        // private TrybOkienka trybOkienka
        //{
        //    get
        //    {
        //        if (wyswietlany==null)
        //        {
        //            return TrybOkienka.Dodawanie;
        //        }
        //        else
        //        {
        //            return TrybOkienka.Edycja;
        //        }
        //    }
        //}

        //tryb dodawania nowego zawodnika
        public FrmSzczegoly(ManagerZawodnikow mz, FrmStartowy frmStartowy, TrybOkienka trybOkienka)
        {
            InitializeComponent();

            this.trybOkienka = trybOkienka;
            this.mz = mz;
            this.frmStartowy = frmStartowy;

            if (trybOkienka == TrybOkienka.Edycja || trybOkienka == TrybOkienka.Dodawanie)
            {
                btnZapisz.Visible = true;
            }

            if (trybOkienka == TrybOkienka.Usuwanie)
            {
                btnUsun.Visible = true;

                //txtImie.Enabled = false;
                //txtNazwisko.Enabled = false;
                //txtKraj.Enabled = false;
                //....
                foreach (Control c in pnlKontrolkiDoEdycji.Controls)
                    if(!(c is Label))
                        c.Enabled = false;
                


            }


            // automatyczna zmiana koloru dla wszystkich kontrolek 
            foreach (Control kontrolka in this.Controls)
            {
                if ((kontrolka is Panel))
                    foreach (Control kontrolkaWewnetrzna in kontrolka.Controls)
                        kontrolkaWewnetrzna.BackColor = Color.Red;
                else
                    kontrolka.BackColor = Color.Red;
            }

            int p = 0;
            foreach (var k in mz.PodajKraje())
            {
                RadioButton rb = new RadioButton();
                rb.Name = "rbKraj_" + k;
                rb.Text = k;
                rb.Top = p;
                p += 20;
                pnlKraje.Controls.Add(rb);
                
            }

        }

        // tryb edycji lub usuwania
        public FrmSzczegoly(Zawodnik zawodnik, ManagerZawodnikow mz, FrmStartowy frmStartowy, TrybOkienka trybOkienka) : this(mz,frmStartowy, trybOkienka)
        {
            wyswietlany = zawodnik;
            txtImie.Text = wyswietlany.Imie;
            txtNazwisko.Text = wyswietlany.Nazwisko;
         
            foreach (Control k in pnlKraje.Controls)
            {
                if(k.Text == wyswietlany.Kraj)
                    ((RadioButton)k).Checked = true;
            }

            //txtKraj.Text = wyswietlany.Kraj;
           
            dtpDataUr.Value = wyswietlany.DataUrodzenia;
            
            if(wyswietlany.Waga != null)
                numWaga.Value = wyswietlany.Waga.Value;

            if (wyswietlany.Wzrost != null)
                numWzrost.Value = wyswietlany.Wzrost.Value;
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {    
            if (trybOkienka == TrybOkienka.Edycja)
            {
                zczytajDaneZkontrolek();
                mz.Edytuj(wyswietlany);
            }
            else if (trybOkienka == TrybOkienka.Dodawanie)
            {
                wyswietlany = new Zawodnik();
                zczytajDaneZkontrolek();
                mz.Dodaj(wyswietlany);
            }
               
            
            frmStartowy.Odswiez();
            this.Close();
        }

        private void zczytajDaneZkontrolek()
        {
            wyswietlany.Imie = txtImie.Text;
            wyswietlany.Nazwisko = txtNazwisko.Text;

            foreach (RadioButton k in pnlKraje.Controls)
            {
                if (k.Checked)
                {
                    wyswietlany.Kraj = k.Text;
                    break;
                }
            }
            //wyswietlany.Kraj = txtKraj.Text;

            wyswietlany.DataUrodzenia = dtpDataUr.Value;
            wyswietlany.Waga = Convert.ToInt32(numWaga.Value);
            wyswietlany.Wzrost = Convert.ToInt32(numWzrost.Value);
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Czy napewno chcesz usunąć zawodnika {wyswietlany.ImieNazwiskoKraj} ?", "Usuwanie",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                mz.Usun(wyswietlany.Id_zawodnika);
                frmStartowy.Odswiez();
                this.Close();
            }
        }

        private void txtKraj_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}

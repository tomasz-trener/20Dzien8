﻿using P05AplikacjaZawodnicy.Services;

using P02Biblioteka.Services;
using System;
using System.Net.Mail;
using System.Windows.Forms;
using P02Biblioteka;

namespace P05AplikacjaZawodnicy
{
    public partial class FrmStartowy : Form
    {
        ManagerZawodnikow mz = new ManagerZawodnikow();

        public FrmStartowy()
        {
            InitializeComponent();

            mz.WczytajZawodnikow();
            cbKraje.DataSource = mz.PodajKraje();
        }

        private void cbKraje_SelectedIndexChanged(object sender, EventArgs e)
        {
            Odswiez();
        }

        public void Odswiez()
        {
            string zaznaczonyKraj = (string)cbKraje.SelectedItem;

            if (zaznaczonyKraj != null)
            {
                lbDane.DataSource = mz.PodajZawodnikow(zaznaczonyKraj);
                lbDane.DisplayMember = "ImieNazwiskoKraj";

                double wzrost = mz.PodajSredniWzrost(zaznaczonyKraj);
                //lblSredniWzrost.Text = $"średni wzrost: {wzrost}";
                lblSredniWzrost.Text = string.Format("średni wzrost {0:0.00}", wzrost);
            }
        }

        private void btnSzczegoly_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zaznaczony,mz,this, TrybOkienka.Edycja);
            frmSzczegoly.Show();
           
        }

        private void btnUsunIPokaz_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zaznaczony,mz, this, TrybOkienka.Usuwanie);
            frmSzczegoly.Show();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            //  FrmSzczegoly frmSzczegoly = new FrmSzczegoly(null,mz,this);
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(mz, this, TrybOkienka.Dodawanie);
            frmSzczegoly.Show();
        }

     

        private void btnUsun_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

            DialogResult dr= MessageBox.Show($"Czy napewno chcesz usunąć zawodnika {zaznaczony.ImieNazwiskoKraj} ?", "Usuwanie",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                mz.Usun(zaznaczony.Id_zawodnika);
                Odswiez();
            }
           
        }

        private void btnGenerujPDF_Click(object sender, EventArgs e)
        {
            var zawodnicy = (Zawodnik[])lbDane.DataSource;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pliki pdf (*.pdf)|*.pdf";
            sfd.Title = "Wskaż miejsce zapisu raportu PDF";
            sfd.InitialDirectory = "c:\\dane";

            sfd.FileName = cbKraje.Text + "_" + DateTime.Now.ToString("ssmmhhddMMyy");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFManager pm = new PDFManager(sfd.FileName);
                pm.WygenerujPDF(zawodnicy);
                wbPrzegladrka.Navigate(sfd.FileName);
            }

           
        }
    }
}

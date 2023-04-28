namespace P05AplikacjaZawodnicy
{
    partial class FrmSzczegoly
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtImie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numWaga = new System.Windows.Forms.NumericUpDown();
            this.numWzrost = new System.Windows.Forms.NumericUpDown();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.pnlKontrolkiDoEdycji = new System.Windows.Forms.Panel();
            this.dtpDataUr = new P01AplikacjaZawodnicy.CustomDateTimePicker();
            this.pnlKraje = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numWaga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWzrost)).BeginInit();
            this.pnlKontrolkiDoEdycji.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtImie
            // 
            this.txtImie.Location = new System.Drawing.Point(14, 25);
            this.txtImie.Name = "txtImie";
            this.txtImie.Size = new System.Drawing.Size(175, 20);
            this.txtImie.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Imie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nazwisko";
            // 
            // txtNazwisko
            // 
            this.txtNazwisko.Location = new System.Drawing.Point(14, 71);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(175, 20);
            this.txtNazwisko.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kraj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data urodzenia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Waga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Wzrost";
            // 
            // numWaga
            // 
            this.numWaga.Location = new System.Drawing.Point(17, 335);
            this.numWaga.Name = "numWaga";
            this.numWaga.Size = new System.Drawing.Size(172, 20);
            this.numWaga.TabIndex = 13;
            // 
            // numWzrost
            // 
            this.numWzrost.Location = new System.Drawing.Point(14, 382);
            this.numWzrost.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numWzrost.Name = "numWzrost";
            this.numWzrost.Size = new System.Drawing.Size(175, 20);
            this.numWzrost.TabIndex = 14;
            // 
            // btnZapisz
            // 
            this.btnZapisz.Location = new System.Drawing.Point(126, 449);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(75, 23);
            this.btnZapisz.TabIndex = 15;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Visible = false;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Location = new System.Drawing.Point(26, 449);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(75, 23);
            this.btnUsun.TabIndex = 16;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Visible = false;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // pnlKontrolkiDoEdycji
            // 
            this.pnlKontrolkiDoEdycji.Controls.Add(this.pnlKraje);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.dtpDataUr);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.txtImie);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label1);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.txtNazwisko);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.numWzrost);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label2);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.numWaga);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label3);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label6);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label4);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label5);
            this.pnlKontrolkiDoEdycji.Location = new System.Drawing.Point(12, 24);
            this.pnlKontrolkiDoEdycji.Name = "pnlKontrolkiDoEdycji";
            this.pnlKontrolkiDoEdycji.Size = new System.Drawing.Size(204, 419);
            this.pnlKontrolkiDoEdycji.TabIndex = 17;
            // 
            // dtpDataUr
            // 
            this.dtpDataUr.Location = new System.Drawing.Point(14, 290);
            this.dtpDataUr.Name = "dtpDataUr";
            this.dtpDataUr.Size = new System.Drawing.Size(175, 21);
            this.dtpDataUr.TabIndex = 15;
            this.dtpDataUr.Value = new System.DateTime(2023, 4, 27, 14, 53, 29, 568);
            // 
            // pnlKraje
            // 
            this.pnlKraje.Location = new System.Drawing.Point(14, 127);
            this.pnlKraje.Name = "pnlKraje";
            this.pnlKraje.Size = new System.Drawing.Size(182, 144);
            this.pnlKraje.TabIndex = 16;
            // 
            // FrmSzczegoly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 501);
            this.Controls.Add(this.pnlKontrolkiDoEdycji);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnZapisz);
            this.Name = "FrmSzczegoly";
            this.Text = "FrmSzczegoly";
            ((System.ComponentModel.ISupportInitialize)(this.numWaga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWzrost)).EndInit();
            this.pnlKontrolkiDoEdycji.ResumeLayout(false);
            this.pnlKontrolkiDoEdycji.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numWaga;
        private System.Windows.Forms.NumericUpDown numWzrost;
        private System.Windows.Forms.Button btnZapisz;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Panel pnlKontrolkiDoEdycji;
        private P01AplikacjaZawodnicy.CustomDateTimePicker dtpDataUr;
        private System.Windows.Forms.Panel pnlKraje;
    }
}
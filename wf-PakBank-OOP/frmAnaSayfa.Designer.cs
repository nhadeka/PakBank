﻿namespace wf_PakBank_OOP
{
    partial class frmAnaSayfa
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
            this.mnuAnaSayfa = new System.Windows.Forms.MenuStrip();
            this.mitmHesapIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmYeniHesap = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmHesapDokumu = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnaSayfa.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAnaSayfa
            // 
            this.mnuAnaSayfa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mnuAnaSayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmHesapIslemleri});
            this.mnuAnaSayfa.Location = new System.Drawing.Point(0, 0);
            this.mnuAnaSayfa.Name = "mnuAnaSayfa";
            this.mnuAnaSayfa.Size = new System.Drawing.Size(625, 29);
            this.mnuAnaSayfa.TabIndex = 1;
            this.mnuAnaSayfa.Text = "menuStrip1";
            // 
            // mitmHesapIslemleri
            // 
            this.mitmHesapIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmYeniHesap,
            this.mitmHesapDokumu,
            this.mitmCikis});
            this.mitmHesapIslemleri.Name = "mitmHesapIslemleri";
            this.mitmHesapIslemleri.Size = new System.Drawing.Size(128, 25);
            this.mitmHesapIslemleri.Text = "&Hesap İşlemleri";
            // 
            // mitmYeniHesap
            // 
            this.mitmYeniHesap.Name = "mitmYeniHesap";
            this.mitmYeniHesap.Size = new System.Drawing.Size(231, 26);
            this.mitmYeniHesap.Text = "&Yeni Hesap Açılışı";
            this.mitmYeniHesap.Click += new System.EventHandler(this.mitmYeniHesap_Click);
            // 
            // mitmHesapDokumu
            // 
            this.mitmHesapDokumu.Name = "mitmHesapDokumu";
            this.mitmHesapDokumu.Size = new System.Drawing.Size(231, 26);
            this.mitmHesapDokumu.Text = "Hesap &Dökümü İncele";
            this.mitmHesapDokumu.Click += new System.EventHandler(this.mitmHesapDokumu_Click);
            // 
            // mitmCikis
            // 
            this.mitmCikis.Name = "mitmCikis";
            this.mitmCikis.Size = new System.Drawing.Size(231, 26);
            this.mitmCikis.Text = "Programdan &Çıkış";
            this.mitmCikis.Click += new System.EventHandler(this.mitmCikis_Click);
            // 
            // frmAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 446);
            this.Controls.Add(this.mnuAnaSayfa);
            this.IsMdiContainer = true;
            this.Name = "frmAnaSayfa";
            this.Text = "PAKBANK Anasayfa İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuAnaSayfa.ResumeLayout(false);
            this.mnuAnaSayfa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAnaSayfa;
        private System.Windows.Forms.ToolStripMenuItem mitmHesapIslemleri;
        private System.Windows.Forms.ToolStripMenuItem mitmYeniHesap;
        private System.Windows.Forms.ToolStripMenuItem mitmHesapDokumu;
        private System.Windows.Forms.ToolStripMenuItem mitmCikis;
    }
}
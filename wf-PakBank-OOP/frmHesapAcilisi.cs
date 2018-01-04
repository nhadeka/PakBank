using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_PakBank_OOP
{
    public partial class frmHesapAcilisi : Form
    {
        public frmHesapAcilisi()
        {
            InitializeComponent();
        }

        private void frmHesapAcilisi_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cbHesapTurleri.SelectedIndex = 0;
            lblTarih.Text = DateTime.Now.ToShortDateString();
            cHesap h = new cHesap();
            lblHesapID.Text = h.SonIDBul().ToString();
            lblHesapNo.Text = h.HesapVarmi();
        }
        private void btnHesapAc_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text.Trim() != "" && txtSoyadi.Text.Trim() != "" && txtTCKNo.Text.Trim() != "")
            {
                cHesap h = new cHesap();
                h.HesapID = Convert.ToInt32(lblHesapID.Text);
                h.HesapNo = lblHesapNo.Text;
                h.Tarih = lblTarih.Text;
                h.Ad = txtAdi.Text;
                h.Soyad = txtSoyadi.Text;
                h.Tckno = txtTCKNo.Text;
                h.Bakiye = Convert.ToDouble(txtBakiye.Text);
                h.HesapTuru = cbHesapTurleri.SelectedItem.ToString();
                bool Sonuc = h.HesapEkle(h);
                //bool Sonuc = h.HesapEkle(Convert.ToInt32(lblHesapID.Text), lblHesapNo.Text, lblTarih.Text, txtAdi.Text, txtSoyadi.Text, txtTCKNo.Text, Convert.ToDouble(txtBakiye.Text), cbHesapTurleri.SelectedItem.ToString());
                if(Sonuc)
                {
                    cHesapHareket hh = new cHesapHareket();
                    hh.HesapID = Convert.ToInt32(lblHesapID.Text);
                    hh.HesapNo = lblHesapNo.Text;
                    hh.Tarih = lblTarih.Text;
                    hh.Tutar = Convert.ToDouble(txtBakiye.Text);
                    hh.IslemTuru = "yatan";
                    Sonuc = hh.HareketEkle(hh);
                    //Sonuc = hh.HareketEkle(Convert.ToInt32(lblHesapID.Text), lblHesapNo.Text, lblTarih.Text, Convert.ToDouble(txtBakiye.Text), "yatan");
                    if(Sonuc)
                    {
                        MessageBox.Show("Hesap Açma İşlemleri Tamamlandı.", "Hesap Açıldı.");
                        Temizle();
                        lblHesapID.Text = h.SonIDBul().ToString();
                        lblHesapNo.Text = h.HesapVarmi();
                    }
                }
            }
            else
            {
                MessageBox.Show("Zorunlu alanları boş bırakmayınız!", "Dikkat Eksik Bilgi!");
                txtAdi.Focus();
            }
        }
        private void Temizle()
        {
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtTCKNo.Clear();
            txtBakiye.Text = "0";
            txtAdi.Focus();
        }
    }
}

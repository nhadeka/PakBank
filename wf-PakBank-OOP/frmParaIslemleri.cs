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
    public partial class frmParaIslemleri : Form
    {
        public frmParaIslemleri()
        {
            InitializeComponent();
        }

        private void frmParaIslemleri_Load(object sender, EventArgs e)
        {
            cbIslemTurleri.SelectedIndex = 1;
            lblTarih.Text = DateTime.Now.ToShortDateString();
            lblHesapID.Text = frmHesapDokumu.hesapID;
            lblHesapNo.Text = frmHesapDokumu.hesapNo;
        }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (txtTutar.Text.Trim() == "" || txtTutar.Text == "0")
            {
                MessageBox.Show("Öncelikle bir tutar bilgisi girilmelidir!");
                txtTutar.Focus();
            }
            else if (cbIslemTurleri.SelectedItem.ToString() == "cekilen" && Convert.ToDouble(txtTutar.Text) > frmHesapDokumu.bakiye)
            {
                MessageBox.Show("Hesabınızda " + frmHesapDokumu.bakiye + " TL. bulunmaktadır.", "Yetersiz Bakiye!");
                txtTutar.Focus();
            }
            else
            {
                cHesapHareket hh = new cHesapHareket();
                hh.HesapID = Convert.ToInt32(lblHesapID.Text);
                hh.HesapNo = lblHesapNo.Text;
                hh.Tarih = lblTarih.Text;
                hh.Tutar = Convert.ToDouble(txtTutar.Text);
                hh.IslemTuru = cbIslemTurleri.SelectedItem.ToString();
                if (hh.HareketEkle(hh))
                {
                    MessageBox.Show("Para İşlemleri tamamlandı.", "Kayıt yapıldı.");
                    this.Close();
                }
            }
        }
    }
}

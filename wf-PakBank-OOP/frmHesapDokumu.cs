using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_PakBank_OOP
{
    public partial class frmHesapDokumu : Form
    {
        public frmHesapDokumu()
        {
            InitializeComponent();
        }
        public static string hesapID;
        public static string hesapNo;
        public static double bakiye;
        Font fntBaslik = new Font("Times New Roman", 16, FontStyle.Bold);
        Font fntDetay = new Font("Times New Roman", 12, FontStyle.Regular);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void frmHesapDokumu_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            //cHesap h1 = new cHesap();
            //h1.Ad = "Ali";
            //h1.Soyad = "Uçar";
            //cHesap h2 = h1;
            //MessageBox.Show(h2.Ad + " " + h2.Soyad);
            //h2.Soyad = "Koşar";
            //MessageBox.Show(h1.Ad + " " + h1.Soyad);
        }
        private void btnBul_Click(object sender, EventArgs e)
        {
            if(txtHesapNo.Text.Trim() != "")
            {
                HesapBilgileriTemizle();
                cHesap h = new cHesap();
                //h.HesapBilgileriGoster(txtHesapNo.Text, txtAdi, txtSoyadi, txtTCKNo, txtAcilisTarihi, txtHesapTuru);
                h = h.HesapBilgileriGoster(txtHesapNo.Text);
                txtAdi.Text = h.Ad;
                txtSoyadi.Text = h.Soyad;
                txtTCKNo.Text = h.Tckno;
                txtAcilisTarihi.Text = h.Tarih;
                txtHesapTuru.Text = h.HesapTuru;
                cHesapHareket hh = new cHesapHareket();
                hh.HesapHareketleriGoster(txtHesapNo.Text, lvHareketler);
                ToplamlariGoster();
            }
        }
        private void ToplamlariGoster()
        {
            double TYatan = 0;
            double TCekilen = 0;
            for (int i = 0; i < lvHareketler.Items.Count; i++)
            {
                if (lvHareketler.Items[i].SubItems[4].Text == "yatan")
                {
                    TYatan += Convert.ToDouble(lvHareketler.Items[i].SubItems[3].Text);
                }
                else
                {
                    TCekilen += Convert.ToDouble(lvHareketler.Items[i].SubItems[3].Text);
                }
            }
            txtToplamYatan.Text = TYatan.ToString();
            txtToplamCekilen.Text = TCekilen.ToString();
            txtBakiye.Text = (TYatan - TCekilen).ToString();
        }
        private void HesapBilgileriTemizle()
        {
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtTCKNo.Clear();
            txtAcilisTarihi.Clear();
            txtHesapTuru.Clear();
        }
        private void btnParaIslemleri_Click(object sender, EventArgs e)
        {
            hesapID = lvHareketler.Items[0].SubItems[0].Text;
            hesapNo = txtHesapNo.Text;
            bakiye = Convert.ToDouble(txtBakiye.Text);
            frmParaIslemleri frm = new frmParaIslemleri();
            frm.ShowDialog();
            cHesapHareket hh = new cHesapHareket();
            hh.HesapHareketleriGoster(txtHesapNo.Text, lvHareketler);
            ToplamlariGoster();
        }

        #region Yazıcı İşlemleri
        private void btnYazici_Click(object sender, EventArgs e)
        {
            k = 0;
            ppdHareketler.ShowDialog();
        }
        int k = 0;
        private void pdocHareketler_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Müşteri : " + txtAdi.Text + " " + txtSoyadi.Text, fntBaslik, sb, 100, 80);
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), fntBaslik, sb, 620, 80);
            e.Graphics.DrawString("HesapNo : " + txtHesapNo.Text, fntBaslik, sb, 100, 110);
            e.Graphics.DrawString("Hesap Hareketleri", fntBaslik, sb, 300, 150);
            e.Graphics.DrawString("ID \t  HesapNo \t İşlemTarihi \t  Tutar \t  İşlemTürü ", fntBaslik, sb, 100, 200);
            e.Graphics.DrawString("_________________________________________________________", fntBaslik, sb, 100, 205);
            int j = 0;
            for (int i = k; i < lvHareketler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvHareketler.Items[i].SubItems[0].Text, fntDetay, sb, 100, 240 + j * 30, fmt);
                e.Graphics.DrawString(lvHareketler.Items[i].SubItems[1].Text, fntDetay, sb, 200, 240 + j * 30, fmt);
                e.Graphics.DrawString(lvHareketler.Items[i].SubItems[2].Text, fntDetay, sb, 370, 240 + j * 30, fmt);
                fmt.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(lvHareketler.Items[i].SubItems[3].Text, fntDetay, sb, 600, 240 + j * 30, fmt);
                fmt.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(lvHareketler.Items[i].SubItems[4].Text, fntDetay, sb, 650, 240 + j * 30, fmt);
                j++;
                k++;
                if (i % 26 == 0 && i != 0)
                {
                    e.HasMorePages = true;  //Yeni sayfaya geçmesini sağlar.
                    return; //Tekrar PrintPage olayına gönderir.
                }
                else { e.HasMorePages = false; }
            }
            e.Graphics.DrawString("_________________________________________________________", fntBaslik, sb, 100, 230 + j * 30);
            j++;
            e.Graphics.DrawString("Toplam Yatan ", fntBaslik, sb, 370, 230 + j * 30);
            fmt.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(string.Format("{0:#,##0}", Convert.ToDouble(txtToplamYatan.Text)), fntBaslik, sb, 600, 230 + j * 30, fmt);
            j++;
            e.Graphics.DrawString("Toplam Çekilen ", fntBaslik, sb, 370, 230 + j * 30);
            fmt.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(string.Format("{0:#,##0}", Convert.ToDouble(txtToplamCekilen.Text)), fntBaslik, sb, 600, 230 + j * 30, fmt);
            j++;
            e.Graphics.DrawString("Bakiye ", fntBaslik, sb, 370, 230 + j * 30);
            fmt.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(string.Format("{0:#,##0}", Convert.ToDouble(txtBakiye.Text)), fntBaslik, sb, 600, 230 + j * 30, fmt);
            //e.Graphics.DrawString(string.Format("{0:c}", Convert.ToDouble(txtBakiye.Text)), fntBaslik, sb, 600, 230 + j * 30, fmt);

        }
        #endregion

    }
}

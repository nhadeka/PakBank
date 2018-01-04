using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_PakBank_OOP
{
    class cHesapHareket
    {
        private int _hesapID;
        private string _hesapNo;
        private string _tarih;
        private double _tutar;
        private string _islemTuru;

        #region Properties
        public int HesapID
        {
            get
            {
                return _hesapID;
            }

            set
            {
                _hesapID = value;
            }
        }

        public string HesapNo
        {
            get
            {
                return _hesapNo;
            }

            set
            {
                _hesapNo = value;
            }
        }

        public string Tarih
        {
            get
            {
                return _tarih;
            }

            set
            {
                _tarih = value;
            }
        }

        public double Tutar
        {
            get
            {
                return _tutar;
            }

            set
            {
                _tutar = value;
            }
        }

        public string IslemTuru
        {
            get
            {
                return _islemTuru;
            }

            set
            {
                _islemTuru = value;
            }
        } 
        #endregion

        public bool HareketEkle(int ID, string HesapNumarasi, string IslemTarihi, double IslemTutari, string IslemTuru)
        {
            StreamWriter HareketEkle = new StreamWriter("HesapHareketleri.txt", true);
            HareketEkle.WriteLine(ID + ";" + HesapNumarasi + ";" + IslemTarihi + ";" + IslemTutari + ";" + IslemTuru);
            HareketEkle.Close();
            return true;
        }
        public bool HareketEkle(cHesapHareket hareket)
        {
            StreamWriter HareketEkle = new StreamWriter("HesapHareketleri.txt", true);
            HareketEkle.WriteLine(hareket._hesapID + ";" + hareket._hesapNo + ";" + hareket._tarih + ";" + hareket._tutar + ";" + hareket._islemTuru);
            HareketEkle.Close();
            return true;
        }
        public void HesapHareketleriGoster(string HesapNo, ListView liste)
        {
            liste.Items.Clear();
            StreamReader DosyaOku = new StreamReader("HesapHareketleri.txt");
            string okunan = DosyaOku.ReadLine();
            int i = 0;
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (Degerler[1] == HesapNo)
                {
                    liste.Items.Add(Degerler[0]);
                    liste.Items[i].SubItems.Add(Degerler[1]);
                    liste.Items[i].SubItems.Add(Degerler[2]);
                    liste.Items[i].SubItems.Add(Degerler[3]);
                    liste.Items[i].SubItems.Add(Degerler[4]);
                    i++;
                }
                okunan = DosyaOku.ReadLine();
            }
            DosyaOku.Close();
        }
    }
}

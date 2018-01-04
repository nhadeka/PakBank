using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_PakBank_OOP
{
    class cHesap
    {
        //Members
        private int _hesapID;
        private string _hesapNo;
        private string _tarih;
        private string _ad;
        private string _soyad;
        private string _tckno;
        private double _bakiye;
        private string _hesapTuru;

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

        public string Ad
        {
            get
            {
                return _ad;
            }

            set
            {
                _ad = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string Soyad
        {
            get
            {
                return _soyad;
            }

            set
            {
                _soyad = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string Tckno
        {
            get
            {
                return _tckno;
            }

            set
            {
                _tckno = value;
            }
        }

        public double Bakiye
        {
            get
            {
                return _bakiye;
            }

            set
            {
                _bakiye = value;
            }
        }

        public string HesapTuru
        {
            get
            {
                return _hesapTuru;
            }

            set
            {
                _hesapTuru = value;
            }
        }
        #endregion

        string YeniHesapNo;
        Random rnd = new Random();
        public int SonIDBul()
        {
            StreamWriter DosyaOlustur = new StreamWriter("HesapKartlari.txt", true);
            DosyaOlustur.Close();
            int ID;
            StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine(); //ilk satırı okur.
            if (okunan == null)
                ID = 1;
            else
            {
                string[] Degerler = new string[okunan.Split(';').Length];
                while (okunan != null)
                {
                    //string[] Degerler = okunan.Split(';');
                    Degerler = okunan.Split(';'); 
                    okunan = DosyaOku.ReadLine();
                }
                ID = Convert.ToInt32(Degerler[0]) + 1; //Sadece son kaydın ID'sini 1 artırır.
            }
            DosyaOku.Close();
            return ID;
        }
        public string HesapVarmi()
        {
            bool Varmi = false;
            do
            {
                Varmi = HesapNoOlustur();  //Bu metot; kullanılmamış yeni bir hesapno bulununcaya kadar true döndürüyor, bu nedenle do while çalışmaya devam ediyor. Ancak false geldiğinde işlem tamamlanıyor ve döngüden çıkılıyor.
            } while (Varmi);
            return YeniHesapNo;
        }
        private bool HesapNoOlustur()
        {
            YeniHesapNo = "ACC" + rnd.Next(1000, 10000);
            StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine(); //ilk satırı okur.
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (Degerler[1] == YeniHesapNo)
                {
                    DosyaOku.Close();
                    return true;
                }
                okunan = DosyaOku.ReadLine();
            }
            DosyaOku.Close();
            return false;
        }
        public bool HesapEkle(int ID, string HesapNumarasi, string AcilisTarihi, string MusteriAdi, string MusteriSoyadi, string KimlikNo, double Bakiye, string HesapTuru)
        {
            StreamWriter DosyaEkle = new StreamWriter("HesapKartlari.txt", true);
            DosyaEkle.WriteLine(ID + ";" + HesapNumarasi + ";" + AcilisTarihi + ";" + MusteriAdi + ";" + MusteriSoyadi + ";" + KimlikNo + ";" + Bakiye + ";" + HesapTuru);
            DosyaEkle.Close();
            return true;
        }
        public bool HesapEkle(cHesap h)
        {
            StreamWriter DosyaEkle = new StreamWriter("HesapKartlari.txt", true);
            DosyaEkle.WriteLine(h._hesapID + ";" + h._hesapNo + ";" + h._tarih + ";" + h._ad + ";" + h._soyad + ";" + h._tckno + ";" + h._bakiye + ";" + h._hesapTuru);
            DosyaEkle.Close();
            return true;
        }
        public void HesapBilgileriGoster(string HesapNo, TextBox Adi, TextBox Soyadi, TextBox TCKNo, TextBox Tarih, TextBox HesapTuru)
        {
            StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine();
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (Degerler[1] == HesapNo)
                {
                    Adi.Text = Degerler[3];
                    Soyadi.Text = Degerler[4];
                    TCKNo.Text = Degerler[5];
                    Tarih.Text = Degerler[2];
                    HesapTuru.Text = Degerler[7];
                    break; //hesabı bulduktan sonra aramaya devam etmesin.
                }
                okunan = DosyaOku.ReadLine();
            }
            DosyaOku.Close();
        }
        public cHesap HesapBilgileriGoster(string HesapNo)
        {
            cHesap h = new cHesap();
            StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine();
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (Degerler[1] == HesapNo)
                {                    
                    h.Ad = Degerler[3];
                    h.Soyad = Degerler[4];
                    h.Tckno = Degerler[5];
                    h.Tarih = Degerler[2];
                    h.HesapTuru = Degerler[7];
                    break; //hesabı bulduktan sonra aramaya devam etmesin.
                }
                okunan = DosyaOku.ReadLine();
            }
            DosyaOku.Close();
            return h;
        }
    }
}

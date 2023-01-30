using DevExpress.XtraEditors;
using StockProject.Entity;
using StockProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProject.Formlar.Bireysel_Müşteriler
{
    public partial class FrmBireyselMusteriKarti : Form
    {
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();

        //Formlar arası veri taşıma
        public int id;

        //Repo nesnesi
        Repository<TblBireyselMusteri> repo = new Repository<TblBireyselMusteri>();
        TblBireyselMusteri t = new TblBireyselMusteri();

        public FrmBireyselMusteriKarti()
        {
            InitializeComponent();
        }

        private void FrmBireyselMusteriKarti_Load(object sender, EventArgs e)
        {
            try
            {
                //Bireysel Müşteriler Listesinde Çift tıklayınca verilerin kartta açılması
                if (id != 0)
                {
                    var bmusteri = repo.Find(x => x.BireyselID == id);
                    TxtAdSoyad.Text = bmusteri.AdSoyad;
                    TxtTc.Text = bmusteri.TC;
                    TxtTelefon.Text = bmusteri.Telefon;
                    TxtMail.Text = bmusteri.Mail;
                    txtAciklama.Text = bmusteri.Aciklama;
                    TxtAdres.Text = bmusteri.Adres;
                    lookUpEditUlke.EditValue = bmusteri.Ulke;
                    lookUpEditSehir.EditValue = bmusteri.Sehir;
                    lookUpEditIlce.EditValue = bmusteri.Ilce;
                }
                else
                {
                    BtnGuncelle.Visible = false;
                }
            }
            catch
            {
                XtraMessageBox.Show("Bir hata oluştu lütfen girilen değerleri kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            //lookupeditleri forma bağlama
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke select new { x.UlkeID, x.UlkeAd }).ToList();
            lookUpEditSehir.Properties.DataSource = (from x in db.iller select new { x.id, x.sehir }).ToList();
        }
        //Seçilen şehre göre ilçeleri getirme
        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int select;
            select = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditIlce.Properties.DataSource = (from x in db.ilceler select new { ID = x.id, İlçe = x.ilce, x.sehir }).Where(y => y.sehir == select).ToList();
        }
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* Önce Repository Class çağırılır
         * TblBireyselMusteri parametre olarak çağırılır
         * t nesnesi oluşturulur */
        //Kaydetme işlemi
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTc.Text;
                t.Mail = TxtMail.Text;
                t.Telefon = TxtTelefon.Text;
                t.Aciklama = txtAciklama.Text;
                t.Adres = TxtAdres.Text;
                t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                t.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                t.Ilce = int.Parse(lookUpEditIlce.EditValue.ToString());
                t.Durum = 1;

                repo.TAdd(t);
                XtraMessageBox.Show("Bireysel müşteri başarılı bir şekilde sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                XtraMessageBox.Show("Bir hata oluştu lütfen girilen değerleri kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.BireyselID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Mail = TxtMail.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Aciklama = txtAciklama.Text;
            deger.Adres = TxtAdres.Text;
            deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            deger.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            deger.Ilce = int.Parse(lookUpEditIlce.EditValue.ToString());
            deger.Durum = 1;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Bilgiler başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}

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

namespace StockProject.Formlar.Kurumsal_Müşteriler
{
    public partial class FrmKurumsalMusteriKartı : Form
    {
        public FrmKurumsalMusteriKartı()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        //Formlar arası veri taşıma
        public int id;
        //Repo nesnesi
        Repository<TblKurumsalMusteri> repo = new Repository<TblKurumsalMusteri>();
        TblKurumsalMusteri t = new TblKurumsalMusteri();
        private void FrmBireyselKurumsalKartı_Load(object sender, EventArgs e)
        {
            //Bireysel Müşteriler Listesinde Çift tıklayınca verilerin kartta açılması
            if (id != 0)
            {
                var bmusteri = repo.Find(x => x.KurumsalID == id);
                TxtFirmaAd.Text = bmusteri.FirmaAd;
                TxtVKN.Text = bmusteri.VKN;
                TxtTelefon.Text = bmusteri.Telefon;
                TxtMail.Text = bmusteri.Mail;
                txtAciklama.Text = bmusteri.Aciklama;
                TxtAdres.Text = bmusteri.Adres;
                lookUpEditUlke.EditValue = bmusteri.Ulke;
                lookUpEditSehir.EditValue = bmusteri.Sehir;
                lookUpEditIlce.EditValue = bmusteri.İlce;
            }
            else
            {
                BtnGuncelle.Visible = false;
            }
            //lookupeditleri forma bağlama
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke select new { x.UlkeID, x.UlkeAd }).ToList();
            lookUpEditSehir.Properties.DataSource = (from x in db.iller select new { x.id, x.sehir }).ToList();
        }

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
        //try-cacth blokları eklenecek 
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.FirmaAd = TxtFirmaAd.Text;
            t.VKN = TxtVKN.Text;
            t.Mail = TxtMail.Text;
            t.Telefon = TxtTelefon.Text;
            t.Aciklama = txtAciklama.Text;
            t.Adres = TxtAdres.Text;
            t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            t.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            t.İlce = int.Parse(lookUpEditIlce.EditValue.ToString());
            t.Durum = 1;

            repo.TAdd(t);
            XtraMessageBox.Show("Kurumsal müşteri başarılı bir şekilde sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.KurumsalID == id);
            deger.FirmaAd = TxtFirmaAd.Text;
            deger.VKN = TxtVKN.Text;
            deger.Mail = TxtMail.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Aciklama = txtAciklama.Text;
            deger.Adres = TxtAdres.Text;
            deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            deger.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            deger.İlce = int.Parse(lookUpEditIlce.EditValue.ToString());
            deger.Durum = 1;

            repo.TUpdate(deger);
            XtraMessageBox.Show("Bilgiler başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

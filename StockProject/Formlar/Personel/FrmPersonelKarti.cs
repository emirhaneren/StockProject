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

namespace StockProject.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        //Formlar arası veri taşıma
        public int id;
        //Repo nesnesi
        Repository<TblPersonel> repo = new Repository<TblPersonel>();
        TblKurumsalMusteri t = new TblKurumsalMusteri();
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            //try-catch eklenecek
            if (id != 0)
            {
                var personel = repo.Find(x => x.PersonelID == id);
                TxtAdSoyad.Text = personel.AdSoyad;
                TxtTc.Text = personel.TC;
                TxtAdres.Text = personel.Adres;
                TxtTelefon.Text = personel.Telefon;
                TxtMail.Text = personel.Mail;
                dateEditGiris.Text = personel.IseGirisTarihi.ToString();
                dateEditCikis.Text = personel.IstenCikisTarihi.ToString();
                TxtAciklama.Text = personel.Aciklama;
                pictureEditKimlikOn.Image = Image.FromFile(personel.KimlikOn);
                pictureEditKimlikArka.Image = Image.FromFile(personel.KimlikArka);
                lookUpEditDepartman.EditValue = personel.Departman;
                lookUpEditGorev.EditValue = personel.Gorev;
                //labellara image konumları ataması
                labelControl15.Text = personel.KimlikOn;
                labelControl16.Text = personel.KimlikArka;
            }
            else
            {
                BtnGuncelle.Visible = false;
            }

            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman select new { x.DepartmanID, x.DepartmanAd }).ToList();
            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev select new { x.GorevID, x.GorevAd }).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTc.Text;
            t.Adres = TxtAdres.Text;
            t.Telefon = TxtTelefon.Text;
            t.IseGirisTarihi = DateTime.Parse(dateEditGiris.Text);
            t.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            t.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.Mail = TxtMail.Text;
            t.Durum = 1;
            t.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
            t.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();

            repo.TAdd(t);
            XtraMessageBox.Show("Personel başarılı bir şekilde sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.IseGirisTarihi = DateTime.Parse(dateEditGiris.Text);
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            deger.Mail = TxtMail.Text;
            //deger.Durum = 1;
            deger.KimlikOn = labelControl15.Text;
            deger.KimlikArka = labelControl16.Text;
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            
            repo.TUpdate(deger);
            XtraMessageBox.Show("Personel Kartı Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl15.Text = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl16.Text = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }
    }
}

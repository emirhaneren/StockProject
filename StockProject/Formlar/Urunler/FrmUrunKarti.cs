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

namespace StockProject.Formlar.Urunler
{
    public partial class FrmUrunKarti : Form
    {
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        //id
        public int id;
        //repo
        Repository<TblUrun> repo = new Repository<TblUrun>();
        TblUrun t = new TblUrun();
        public FrmUrunKarti()
        {
            InitializeComponent();
        }

        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            //Ürün Güncelleme Alanı
            if (id != 0)
            {
                var urun = repo.Find(x => x.UrunID == id);
                TxtUrunAdi.Text = urun.UrunAd;
                TxtAlisFiyat.Text = urun.AlisFiyat.ToString();
                TxtSatisFiyati.Text = urun.SatisFiyat.ToString();
                TxtToplam.Text = urun.Toplam.ToString();
                TxtKdv.Text = urun.Kdv.ToString();
                lookUpEditUrunGrup.EditValue = urun.UrunGrup;
                lookUpEditBirim.EditValue = urun.Birim;
                lookUpEditDurum.EditValue = urun.Durum;
            }

            //UrunGrup Listesi
            lookUpEditUrunGrup.Properties.DataSource = (from x in db.TblUrunGrup select new { x.UrunGrupID, x.UrunGrupAd }).ToList();
            //Birim Listesi,Anonymus Type
            lookUpEditBirim.Properties.DataSource = (from x in db.TblBirim select new { x.BirimID, x.BirimAd }).ToList();
            //Durum Listesi
            lookUpEditDurum.Properties.DataSource = (from x in db.TblDurum select new { x.DurumID, x.DurumAd }).ToList();
        }
        //Vazgeç Butonu
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Kaydet Butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.UrunAd = TxtUrunAdi.Text;
            t.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            t.SatisFiyat = decimal.Parse(TxtSatisFiyati.Text);
            t.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            t.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            t.Toplam = decimal.Parse(TxtToplam.Text);
            t.Kdv = byte.Parse(TxtKdv.Text);

            repo.TAdd(t);
            XtraMessageBox.Show("Ürün sistme başarılı bir şekilde kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urundeger = repo.Find(x => x.UrunID == id);
            urundeger.UrunAd = TxtUrunAdi.Text;
            urundeger.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            urundeger.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            urundeger.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            urundeger.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            urundeger.SatisFiyat = decimal.Parse(TxtSatisFiyati.Text);
            urundeger.Toplam = decimal.Parse(TxtToplam.Text);
            urundeger.Kdv = byte.Parse(TxtKdv.Text);
            
            repo.TUpdate(urundeger);
            XtraMessageBox.Show("Ürün Kartı Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

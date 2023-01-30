using StockProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProject.Formlar.Ana_Form
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DbStockProjectEntities db = new DbStockProjectEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            //Ürün Listesi
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunID,
                                           x.UrunAd,
                                           x.TblBirim.BirimAd,
                                           x.Toplam,
                                           x.TblDurum.DurumAd
                                       }).ToList();
            //Personel Listesi
            gridControl2.DataSource = (from x in db.TblPersonel
                                       select new
                                       {
                                           x.PersonelID,
                                           x.AdSoyad,
                                           x.Telefon,
                                           x.TblDepartman.DepartmanAd,
                                       }).ToList();
            //Ürün-Stok Grafiği
            var urunler = db.TblUrun.ToList();
            foreach (var x in urunler)
            {
                chartControl1.Series["Urun-Stok"].Points.AddPoint(x.UrunAd, double.Parse(x.Toplam.ToString()));
            }
        }
    }
}

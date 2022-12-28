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

namespace StockProject.Formlar.Grafikler
{
    public partial class UrunStokGrafigi : Form
    {
        public UrunStokGrafigi()
        {
            InitializeComponent();
        }
        DbStockProjectEntities db = new DbStockProjectEntities();
        private void UrunStokGrafigi_Load(object sender, EventArgs e)
        {
            //Urun-Stok Grafiği
            var urunler = db.TblUrun.ToList();
            foreach (var x in urunler)
            {
                chartControl1.Series["Urun-Stok"].Points.AddPoint(x.UrunAd, double.Parse(x.Toplam.ToString()));
            }
        }
    }
}

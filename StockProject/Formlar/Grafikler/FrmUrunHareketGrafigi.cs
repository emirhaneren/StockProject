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
    public partial class FrmUrunHareketGrafigi : Form
    {
        public FrmUrunHareketGrafigi()
        {
            InitializeComponent();
        }
        DbStockProjectEntities db = new DbStockProjectEntities();
        private void FrmUrunHareketGrafigi_Load(object sender, EventArgs e)
        {
            var turler = db.UrunHareketGrf();
            foreach(var x in turler)
            {
                chartControl1.Series["Urun-Hareket"].Points.AddPoint(x.HareketTuru, double.Parse(x.Sayı.ToString()));
            }
        }
    }
}

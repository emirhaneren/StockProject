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

namespace StockProject.Formlar.Urunler
{
    public partial class FrmUrunCikisHareketleri : Form
    {
        public FrmUrunCikisHareketleri()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        private void FrmUrunCikisHareketleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrunHareket
                                       select new
                                       {
                                           x.HareketID,
                                           x.TblUrun.UrunAd,
                                           x.Miktar,
                                           x.Tarih,
                                           x.HareketTuru
                                       }).Where(y => y.HareketTuru == "Çıkış").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunHareketTanimi fr = new FrmUrunHareketTanimi();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("HareketID").ToString());
            fr.Show();
        }
    }
}

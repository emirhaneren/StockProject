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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunID,
                                           x.UrunAd,
                                           x.TblUrunGrup.UrunGrupAd,
                                           x.TblBirim.BirimAd,
                                           x.AlisFiyat,
                                           x.SatisFiyat,
                                           x.Toplam,
                                           x.TblDurum.DurumAd
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunKarti fr = new FrmUrunKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("UrunID").ToString());
            fr.Show();
        }
    }
}

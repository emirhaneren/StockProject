using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockProject.Entity;

namespace StockProject.Formlar.Bireysel_Müşteriler
{
    public partial class FrmBireyselMusteriListesi : Form
    {
        public FrmBireyselMusteriListesi()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        
        //istenilen veriler
        private void FrmBireyselMusteriListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblBireyselMusteri
                                       select new
                                       {
                                           x.BireyselID,
                                           x.AdSoyad,
                                           x.TC,
                                           x.Mail,
                                           x.Telefon,
                                           x.Adres,
                                       }).ToList();
        }

        private void FrmBireyselMusteriListesi_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmBireyselMusteriKarti fr = new FrmBireyselMusteriKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("BireyselID").ToString());
            fr.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
            db.SaveChanges();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        
    }
}

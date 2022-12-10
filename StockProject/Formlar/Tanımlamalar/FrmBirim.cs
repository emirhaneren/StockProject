using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockProject.Entity;

namespace StockProject.Formlar.Tanımlamalar
{
    public partial class FrmBirim : Form
    {
        //Database ile formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        public FrmBirim()
        {
            InitializeComponent();
        }

        private void FrmBirim_Load(object sender, EventArgs e)
        {
            db.TblBirim.Load();
            bindingSource1.DataSource = db.TblBirim.Local;

            //repositorylookupedit ile bağlanan değerler
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAd
                                                        }).ToList();
        }
        //Events -> Cell Value Change  değişiklikleri kaydetmemizi sağlar 
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}

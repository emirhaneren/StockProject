using StockProject.Entity;
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

namespace StockProject.Formlar.Tanımlamalar
{
    public partial class FrmGorev : Form
    {
        //Database ile formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        public FrmGorev()
        {
            InitializeComponent();
        }

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            db.TblGorev.Load();
            bindingSource1.DataSource = db.TblGorev.Local;

            //repositoryLookUpEdit ile bağlanan değerleri gösterme
            //NullText (departman seciniz) , Display Member(DurumAd) , ValueMember (DurumID) (properties)
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum select new { x.DurumID, x.DurumAd }).ToList();

            repositoryItemLookUpDepartman.DataSource = (from x in db.TblDepartman select new { x.DepartmanID, x.DepartmanAd }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

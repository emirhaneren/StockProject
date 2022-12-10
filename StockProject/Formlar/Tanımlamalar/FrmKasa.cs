using DevExpress.XtraEditors;
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
    public partial class FrmKasa : Form
    {
        //Database ile formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        public FrmKasa()
        {
            InitializeComponent();
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            db.TblKasa.Load();
            bindingSource1.DataSource = db.TblKasa.Local;

            //repositoryLookUpEdit ile bağlanan değerleri gösterme (Durum)
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum select new { x.DurumID, x.DurumAd }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Bilgiler kaydedilirken hata oluştu, kontrol edip tekrar deneyiniz");
            }
        }
    }
}

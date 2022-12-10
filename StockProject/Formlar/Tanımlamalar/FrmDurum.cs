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
    
    public partial class FrmDurum : Form
    {
        //Database ile formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        public FrmDurum()
        {
            InitializeComponent();
        }

        private void FrmDurum_Load(object sender, EventArgs e)
        {
            db.TblDurum.Load();
            bindingSource1.DataSource = db.TblDurum.Local;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();

            //hata yakalamak için try catch kullanılır
            //karakter sayısı aşılırsa hata mesajı pencere olarak belirtilir
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    XtraMessageBox.Show("Lütfen değerleri kontrol edip yeniden giriş yapın !", " Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}

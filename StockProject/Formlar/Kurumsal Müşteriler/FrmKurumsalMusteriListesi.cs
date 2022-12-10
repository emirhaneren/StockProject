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

namespace StockProject.Formlar.Kurumsal_Müşteriler
{
    public partial class FrmKurumsalMusteriListesi : Form
    {
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        public FrmKurumsalMusteriListesi()
        {
            InitializeComponent();
        }

        private void FrmKurumsalMusteriListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblKurumsalMusteri
                                       select new
                                       {
                                           x.KurumsalID,
                                           x.FirmaAd,
                                           x.VKN,
                                           x.Mail,
                                           x.Telefon,
                                           x.Adres
                                       }).ToList();
        }
    }
}

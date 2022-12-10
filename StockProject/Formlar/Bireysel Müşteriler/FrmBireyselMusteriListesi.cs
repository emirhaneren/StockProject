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
    }
}

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

namespace StockProject.Formlar.Bireysel_Müşteriler
{
    public partial class FrmBireyselMusteriKarti : Form
    {
        DbStockProjectEntities db = new DbStockProjectEntities();
        public FrmBireyselMusteriKarti()
        {
            InitializeComponent();
        }
    }
}

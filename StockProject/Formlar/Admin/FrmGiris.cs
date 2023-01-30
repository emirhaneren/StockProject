using DevExpress.XtraEditors;
using StockProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockProject.Formlar.Admin
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbStockProjectEntities db = new DbStockProjectEntities();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            var kullanici = db.TblAdmin.Where(x => x.Kullanici == txtKullanici.Text && x.Sifre == txtSifre.Text).FirstOrDefault();
            if(kullanici!=null)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Kullanıcı adı veya şifre hatalı , tekrar deneyiniz","Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2500);
        }
    }
}

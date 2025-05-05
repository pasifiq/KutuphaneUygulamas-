using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneUygulaması
{
    public partial class KullaniciListeForm : Form
    {
        public KullaniciListeForm()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            KutuphaneEntities db = new KutuphaneEntities();
            var kullanicilar = db.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();

            //kayıtlar kolonunu gizleme
            dataGridView1.Columns[7].Visible = false;
        }
        private void KullaniciListeForm_Load(object sender, EventArgs e)
        {
            Listele();

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneUygulaması.Kullanici
{
    public partial class KullaniciSilForm : Form
    {
        public KullaniciSilForm()
        {
            InitializeComponent();
        }

        KutuphaneEntities db = new KutuphaneEntities();
        public void Listele()
        {

            var kullanicilar = db.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            //kayıtlar kolonunu gizleme
            dataGridView1.Columns[7].Visible = false;
        }

        private void KullaniciSilForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici=db.Kullanicilar.Where(x => x.kullanici_id == secilenId).FirstOrDefault();
            db.Kullanicilar.Remove(kullanici);
            db.SaveChanges();
            Listele();
        }
    }
}

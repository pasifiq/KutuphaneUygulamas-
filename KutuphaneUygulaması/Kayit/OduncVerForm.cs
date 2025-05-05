using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneUygulaması.Kayit
{
    public partial class OduncVerForm : Form
    {
        public OduncVerForm()
        {
            InitializeComponent();
        }

        KutuphaneEntities db = new KutuphaneEntities();
        private void OduncVerForm_Load(object sender, EventArgs e)
        {
            //listeleme (kayıtlar)
            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();

            //listeleme(kaynaklar)
            var kaynakList = db.Kaynaklar.ToList();
            dataGridView2.DataSource = kaynakList.ToList();

            //istenmeyen kaynak ve kullanıcı kolonunu gizleme
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arananSecilen = TCBultxt.Text;
            var kullaniciVarMi = db.Kullanicilar.Where(x=>x.kullanici_tc == arananSecilen).FirstOrDefault();
            if(kullaniciVarMi != null)
                label2.Text = kullaniciVarMi.kullanici_ad + " " + kullaniciVarMi.kullanici_soyad;
            else
                label2.Text = "Kullanıcı bulunamadı";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string gelenAd = textBox1.Text;
            var bulunanKaynaklar = db.Kaynaklar.Where(x => x.kaynak_ad.Contains(gelenAd)).ToList();
            dataGridView2.DataSource = bulunanKaynaklar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //kişiyi alma
            string secilenKisiTC = TCBultxt.Text;
            var secilenKisi = db.Kullanicilar.Where(x => x.kullanici_tc.Equals(secilenKisiTC)).FirstOrDefault();

            //kitabı alma
            int secilenKitapId = Convert.ToInt16(dataGridView2.CurrentRow.Cells[0].Value);
            var secilenKitap = db.Kaynaklar.Where(x => x.kaynak_id.Equals(secilenKitapId)).FirstOrDefault();

            Kayitlar yeniKayit = new Kayitlar();
            yeniKayit.kitap_id = secilenKitap.kaynak_id;
            yeniKayit.kullanici_id = secilenKisi.kullanici_id;
            yeniKayit.alis_tarih = DateTime.Today;
            yeniKayit.son_tarih = DateTime.Today.AddDays(15);
            db.Kayitlar.Add(yeniKayit);
            db.SaveChanges();

            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();
        }

        
    }
}

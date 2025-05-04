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
    public partial class Form1 : Form
    {

        KutuphaneEntities db = new KutuphaneEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void personelGirisbtn_Click(object sender, EventArgs e)
        {
            string gelenAd = adGiristxt.Text;
            string gelenSifre = sifreGiristxt.Text;
            //veritabanından gelen kullanıcı adı ve şifreyi alıyoruz

            //linq sorgusu ile veritabanından kullanıcı adı ve şifre kontrolü yapıyoruz

            var personel=db.Personeller.Where(x=>x.personel_ad.Equals(gelenAd)&&x.personel_sifre.Equals(gelenSifre)).FirstOrDefault();

            if(personel==null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
            else
            {
                MessageBox.Show("Başarılı");
                IslemPaneli panel = new IslemPaneli();
                panel.Show();
                this.Hide();
            }

            

        }
    }
}

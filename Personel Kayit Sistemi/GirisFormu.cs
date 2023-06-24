using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit_Sistemi
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=OSMAN\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_Yonetici Where KullaniciAdi=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtKullanici.Text);
            komut.Parameters.AddWithValue("@p2",textSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre! Lütfen Tekrar Deneyiniz..");
            }
            baglanti.Close();
        }
    }
}

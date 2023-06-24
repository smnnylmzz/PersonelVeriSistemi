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
using System.Data.Common;
using Microsoft.SqlServer.Server;

namespace Personel_Kayit_Sistemi
{

    public partial class GrafikFormu : Form
    {
        public GrafikFormu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=OSMAN\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void GrafikFormu_Load(object sender, EventArgs e)
        {
            //1.Grafik
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel Group By PerSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();


            //2.Grafik
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek,Avg(PerMaas) From Tbl_Personel Group By PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek - Maaş"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}

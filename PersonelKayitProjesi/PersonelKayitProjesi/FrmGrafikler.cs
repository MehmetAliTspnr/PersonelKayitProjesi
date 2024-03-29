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
using System.Threading;
using System.Runtime.InteropServices;

namespace PersonelKayitProjesi
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-8S41M5JH;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();//GRAFİK 1 
            SqlCommand komutg1 = new SqlCommand("select PERSEHİR,count(*)From Tbl_Personel group by PERSEHİR",baglanti);
            SqlDataReader reader = komutg1.ExecuteReader();
            while (reader.Read()) { chart1.Series["Sehirler"].Points.AddXY(reader[0], reader[1]); }
            baglanti.Close();

            //GRAFİK 2 MAAS 
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select PERMESLEK,Avg(PERMAAS)  From Tbl_Personel group by PERMESLEK",baglanti);
            SqlDataReader r=komutg2.ExecuteReader();
            while (r.Read()) { chart2.Series["MESLEK-MAAS"].Points.AddXY(r[0], r[1]); }
            baglanti.Close();
        }
    }
}

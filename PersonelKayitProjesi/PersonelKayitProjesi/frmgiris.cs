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

namespace PersonelKayitProjesi
{
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-8S41M5JH;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)//veritabanı tablosu oluşturuldu admin paneli eklendi.
        {
             baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *From Yöneticipaneli where kullaniciad=@p1 and sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide(); }
            else
            { MessageBox.Show("Hatalı Kullanıcı Adı Ve Şifre"); }
           
            baglanti.Close();
        }
    }
}

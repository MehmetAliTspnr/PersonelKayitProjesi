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
using System.Security.Cryptography;

namespace PersonelKayitProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=LAPTOP-8S41M5JH;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
        void temizle()
        { txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            cmbsehir.Text = "";
            txtmeslek.Text = "";
            mskmaas.Text = "";
            radioButton1.Checked =false;
            radioButton2.Checked =false;
            txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet1.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
           

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PERAD,PERSOYAD,PERSEHİR,PERMAAS,PERMESLEK,PERDURUM) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4",mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label6.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel bilgisi eklendi.");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "True";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "False";
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }
    }
}

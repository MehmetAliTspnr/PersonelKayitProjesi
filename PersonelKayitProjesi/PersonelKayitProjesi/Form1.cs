﻿using System;
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
            if(radioButton1.Checked==true)
            { label6.Text = "True"; }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            { label6.Text = "False"; }
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
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString() ;
            mskmaas.Text=dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label6.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();



        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            if(label6.Text=="True")//Herhangi bir kolona tıklanıldığında radiobutton üzerinde degişiklik yapıyor.
            { radioButton1.Checked = true; }
            if(label6.Text=="False") 
            {  radioButton2.Checked = true; }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {   //Kayit Silme işlemi kolona çift tıklayıp basınca siliniyor.Ancak tek tıkla silinmiyor.
           
            baglanti.Open();
            SqlCommand komutsil=new SqlCommand("Delete From Tbl_Personel Where PERİD=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("KAYIT SİLİNDİ..." );
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_personel Set PERAD=@a1,PERSOYAD=@a2,PERSEHİR=@a3,PERMAAS=@a4,PERDURUM=@a5,PERMESLEK=@a6 where PERİD=@a7", baglanti);
            //id ye göre güncelleme sağlandı.
            komutguncelle.Parameters.AddWithValue("@a1",txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label6.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtid.Text);

            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr=new Frmİstatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler grfrm=new FrmGrafikler();//grafik formuna yönlendiriyor.
            grfrm.Show();
        }
    }
}

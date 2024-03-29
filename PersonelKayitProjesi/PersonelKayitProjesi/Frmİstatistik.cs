using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonelKayitProjesi
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-8S41M5JH;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
           
           
               //Toplam Personel Sayısı..
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("SELECT COUNT(*)FROM Tbl_Personel", baglanti);
                SqlDataReader dr1 = komut1.ExecuteReader();//select komutunda okuma yapma.
                while (dr1.Read())
                { lbltotalpersonel.Text = dr1[0].ToString(); }
                baglanti.Close();

                baglanti.Open();//evli personel sayısını bulma kodu..
                SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel where PERDURUM=1", baglanti);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read()) { evlipersonelsayi.Text = dr2[0].ToString(); }
                baglanti.Close();

                baglanti.Open();//bekar personel sayılarını yazdırdık.
                SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel where PERDURUM=0", baglanti);
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read()) { bekarpersonelsayi.Text = dr3[0].ToString(); }
                baglanti.Close();

                baglanti.Open();
                //Toplam kaç farklı şehir var?distinct komutu ile aynı şehirleri tek şehir olarak saydık Count ile de sayılaştırdık kaç tane olduğunu bulduk.
                SqlCommand komut4 = new SqlCommand("SELECT COUNT(DISTINCT(PERSEHİR)) FROM Tbl_Personel", baglanti);
                SqlDataReader dr4 = komut4.ExecuteReader();
                while (dr4.Read()) { farklisehir.Text = dr4[0].ToString(); }
                baglanti.Close();

                //TOPLAM MAAŞ
                baglanti.Open();
                SqlCommand komut5 = new SqlCommand("SELECT SUM(PERMAAS) FROM  Tbl_Personel", baglanti);
                SqlDataReader dr5 = komut5.ExecuteReader();
                while (dr5.Read())
                { totalmaas.Text = dr5[0].ToString(); }
                baglanti.Close();

                baglanti.Open();
                SqlCommand komut6 = new SqlCommand("SELECT AVG(PERMAAS) FROM  Tbl_Personel", baglanti);
                SqlDataReader dr6 = komut6.ExecuteReader();
                while (dr6.Read())
                { ortmaas.Text = dr6[0].ToString(); }
                baglanti.Close();
            }
    }
}

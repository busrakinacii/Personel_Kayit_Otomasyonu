using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NJJCU5K\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
       
        void temizle()
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMeslek.Text = "";
            CmbSehir.Text = "";
            MskMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Txtid.Focus();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new  SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "False";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", Txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", MskMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", Txtid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgisi Güncellendi");

        }

        private void Btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik istatistik = new Frmistatistik();
            istatistik.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}

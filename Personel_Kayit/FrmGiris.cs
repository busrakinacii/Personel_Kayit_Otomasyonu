using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NJJCU5K\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("Select * from Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            giris.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            giris.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm ana = new FrmAnaForm();
                ana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız Ya da Şifreniz Yanlıştır Lütfen Kontrol Ediniz");
            }
            baglanti.Close();

        }
    }
}

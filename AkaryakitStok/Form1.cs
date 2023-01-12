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

namespace AkaryakitStok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=DESKTOP-BITUB47;Initial Catalog=DbMvcKamp;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BITUB47;Initial Catalog=AkaryakitStok;Integrated Security=True");




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        void listele()
        {
            //Kurşunsuz 95

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tblbenzın where petroltur='Kurşunsuz95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                label18.Text = dr[4].ToString();
            }
            baglanti.Close();

            //VMAX Diesel

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * From tblbenzın where petroltur='VMAX Diesel'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label12.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                label19.Text = dr2[4].ToString();
            }
            baglanti.Close();

            //VPRO Diesel

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * From tblbenzın where petroltur='VPRO Diesel'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label13.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                label20.Text = dr3[4].ToString();
            }
            baglanti.Close();

            //VPRO Diesel

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * From tblbenzın where petroltur='Otogaz'", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label14.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                label21.Text = dr4[4].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * From tblkasa", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label24.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(label6.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            textBox2.Text = tutar.ToString();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double vmax, litre, tutar;
            vmax = Convert.ToDouble(label12.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = vmax * litre;
            textBox4.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double vpro, litre, tutar;
            vpro = Convert.ToDouble(label13.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = vpro * litre;
            textBox6.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double otogaz, litre, tutar;
            otogaz = Convert.ToDouble(label14.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = otogaz * litre;
            textBox8.Text = tutar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox9.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textBox2.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar = mıktar + @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(textBox2.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok = stok - @p1 where petroltur = 'kurşunsuz95'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            else if (numericUpDown2.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox9.Text);
                komut.Parameters.AddWithValue("@p2", "VMAX Diesel");
                komut.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textBox4.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar = mıktar + @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(textBox4.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok = stok - @p1 where petroltur = 'VMAX Diesel'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            else if (numericUpDown3.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox9.Text);
                komut.Parameters.AddWithValue("@p2", "VPRO Diesel");
                komut.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textBox6.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar = mıktar + @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(textBox6.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok = stok - @p1 where petroltur = 'VPRO Diesel'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
            if (numericUpDown4.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket(plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox9.Text);
                komut.Parameters.AddWithValue("@p2", "Otogaz");
                komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textBox8.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar = mıktar + @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(textBox8.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok = stok - @p1 where petroltur = 'Otogaz'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");
                listele();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

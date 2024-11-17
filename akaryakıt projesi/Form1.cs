using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace akaryakıt_projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=BenzinAkaryakıt;Integrated Security=True;");
      void temizle()
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            txtkursunsuzfiyat.Text = "";
            txteurodizelfiyat.Text = "";
            txtmaxdizelfiyat.Text = "";
            txtgazfiyat.Text = "";
            txtplaka.Text = "";
        }
      
        void listele()
        {
            // Benzin95

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='Kurşunsuz95'", conn);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lblkursunsuz95.Text = rdr[3].ToString();

                progressBar95.Value = Convert.ToInt32(rdr[4]);

                lbl95miktar.Text = rdr[4].ToString();

            }

            conn.Close();



            // Benzin102

            conn.Open();

            SqlCommand cmd2 = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='eurodizel'", conn);

            SqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())

            {

                lbleurodizel.Text = rdr2[3].ToString();

                progressBarEuro.Value = Convert.ToInt32(rdr2[4]);

                lbleuromiktar.Text = rdr2[4].ToString();

            }

            conn.Close();



            // EuroDizel

            conn.Open();

            SqlCommand cmd3 = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='maxdizel'", conn);

            SqlDataReader rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())

            {

                lblmaxdizel.Text = rdr3[3].ToString();

                progressBarmaxdizel.Value = Convert.ToInt32(rdr3[4]);

                lblmaxdizelmiktar.Text = rdr3[4].ToString();

            }

            conn.Close();



            // Power Dizel

            conn.Open();

            SqlCommand cmd4 = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='gaz'", conn);

            SqlDataReader rdr4 = cmd4.ExecuteReader();

            while (rdr4.Read())

            {

                lblgaz.Text = rdr4[3].ToString();

                progressBargaz.Value = Convert.ToInt32(rdr4[4]);

                labelgazmiktar.Text = rdr4[4].ToString();

            }

            conn.Close();




            conn.Close();

            conn.Open();

            SqlCommand cmd6 = new SqlCommand("Select * From TBLKASA", conn);

            SqlDataReader rdr6 = cmd6.ExecuteReader();

            while (rdr6.Read())

            {

                lblkasa.Text = rdr6[0].ToString();

            }
            conn.Close();
            conn.Open();
            SqlCommand cmd10 = new SqlCommand("select*from TBLKASA",conn);
            SqlDataReader dr10 = cmd10.ExecuteReader();
            while (dr10.Read())
            {
                lblkasa.Text = dr10[0].ToString();
            }
            conn.Close();
                }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(lblkursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            txtkursunsuzfiyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(lbleurodizel.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = eurodizel * litre;
            txteurodizelfiyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double maxdizel, litre, tutar;
            maxdizel = Convert.ToDouble(lblmaxdizel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = maxdizel * litre;
           txtmaxdizelfiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(lblmaxdizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = gaz * litre;
           txtgazfiyat.Text = tutar.ToString();
        }

        private void btndepodoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET2(PLAKA,BENZINTURU,LITRE,FIYAT) VALUES(@P1,@P2,@P3,@P4)",conn);
                komut.Parameters.AddWithValue("@P1", txtplaka.Text);
                komut.Parameters.AddWithValue("@P2","Kurşunsuz 95");
                komut.Parameters.AddWithValue("@P3",numericUpDown1.Value);
                komut.Parameters.AddWithValue("@P4", decimal.Parse(txtkursunsuzfiyat.Text));
                komut.ExecuteNonQuery();
                 conn.Close();
                
                conn.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE  TBLKASA SET MIKTAR=MIKTAR+@P1",conn);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtkursunsuzfiyat.Text));
                komut2.ExecuteNonQuery();
                conn.Close();
                

                conn.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@P1 WHERE PETROLTUR='Kurşunsuz95'", conn);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();
                temizle();

            }
            else if (numericUpDown2.Value != 0)
            {

                conn.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET2(PLAKA,BENZINTURU,LITRE,FIYAT) VALUES(@P1,@P2,@P3,@P4)", conn);
                komut.Parameters.AddWithValue("@P1", txtplaka.Text);
                komut.Parameters.AddWithValue("@P2", "Euro Dizel");
                komut.Parameters.AddWithValue("@P3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@P4", decimal.Parse(txteurodizelfiyat.Text));
                komut.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE  TBLKASA SET MIKTAR=MIKTAR+@P1", conn);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txteurodizelfiyat.Text));
                komut2.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@P1 WHERE PETROLTUR='eurodizel'", conn);
                komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();
                temizle();
            }
            else if (numericUpDown3.Value != 0)
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET2(PLAKA,BENZINTURU,LITRE,FIYAT) VALUES(@P1,@P2,@P3,@P4)", conn);
                komut.Parameters.AddWithValue("@P1", txtplaka.Text);
                komut.Parameters.AddWithValue("@P2", "Max Dizel");
                komut.Parameters.AddWithValue("@P3", numericUpDown3.Value);
                komut.Parameters.AddWithValue("@P4", decimal.Parse(txtmaxdizelfiyat.Text));
                komut.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE  TBLKASA SET MIKTAR=MIKTAR+@P1", conn);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtmaxdizelfiyat.Text));
                komut2.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@P1 WHERE PETROLTUR='maxdizel'", conn);
                komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();
                temizle();
            }
            else if(numericUpDown4.Value != 0)
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET2(PLAKA,BENZINTURU,LITRE,FIYAT) VALUES(@P1,@P2,@P3,@P4)", conn);
                komut.Parameters.AddWithValue("@P1", txtplaka.Text);
                komut.Parameters.AddWithValue("@P2", "Max Dizel");
                komut.Parameters.AddWithValue("@P3", numericUpDown4.Value);
                komut.Parameters.AddWithValue("@P4", decimal.Parse(txtgazfiyat.Text));
                conn.Close();

                conn.Open();
                SqlCommand komut2 = new SqlCommand("UPDATE  TBLKASA SET MIKTAR=MIKTAR+@P1", conn);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(txtgazfiyat.Text));
                komut2.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand komut3 = new SqlCommand("UPDATE TBLBENZIN SET STOK=STOK-@P1 WHERE PETROLTUR='gaz'", conn);
                komut3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();
                temizle();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DEPOMIKTARI FR = new DEPOMIKTARI();
            FR.Show();
            this.Hide();
        }

        private void lblkursunsuz95_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

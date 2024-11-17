using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace akaryakıt_projesi
{
    public partial class DEPOMIKTARI : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=BenzinAkaryakıt;Integrated Security=True;");
        public DEPOMIKTARI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult sec = new DialogResult();
           
            sec =MessageBox.Show("FIYATLARI ONAYLIYOR MUSUNUZ?", "GÜNCELLE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sec == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("Update TBLBENZIN SET ALISFIYAT=@P1 WHERE PETROLTUR='Kurşunsuz95'", conn);
                komut.Parameters.AddWithValue("@P1", Decimal.Parse(txtAL95.Text));
                komut.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut2 = new SqlCommand("Update TBLBENZIN SET SATISFIYAT=@P1 WHERE PETROLTUR='Kurşunsuz95'", conn);
                komut2.Parameters.AddWithValue("@P1", Decimal.Parse(txtSAT95.Text));
                komut2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut3 = new SqlCommand("Update TBLBENZIN SET ALISFIYAT=@P1 WHERE PETROLTUR='eurodizel'", conn);
                komut3.Parameters.AddWithValue("@P1", Decimal.Parse(txtalEuro.Text));
                komut3.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut4 = new SqlCommand("Update TBLBENZIN SET SATISFIYAT=@P1 WHERE PETROLTUR='eurodizel'", conn);
                komut4.Parameters.AddWithValue("@P1", Decimal.Parse(txtEurosat.Text));
                komut4.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand komut5 = new SqlCommand("Update TBLBENZIN SET ALISFIYAT=@P1 WHERE PETROLTUR='maxdizel'", conn);
                komut5.Parameters.AddWithValue("@P1", Decimal.Parse(txtalmaxdize.Text));
                komut5.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut6 = new SqlCommand("Update TBLBENZIN SET SATISFIYAT=@P1 WHERE PETROLTUR='maxdizel'", conn);
                komut6.Parameters.AddWithValue("@P1", Decimal.Parse(txtsatmax.Text));
                komut6.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand komut7 = new SqlCommand("Update TBLBENZIN SET ALISFIYAT=@P1 WHERE PETROLTUR='gaz'", conn);
                komut7.Parameters.AddWithValue("@P1", Decimal.Parse(txtalgaz.Text));
                komut7.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand komut8 = new SqlCommand("Update TBLBENZIN SET SATISFIYAT=@P1 WHERE PETROLTUR='gaz'", conn);
                komut8.Parameters.AddWithValue("@P1", Decimal.Parse(txtsatgaz.Text));
                komut8.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("FİYATLAR GUNCELLENDİ!");
                listele();
            }
            else
            {
                MessageBox.Show("FİYAT GÜNCELLEMESİ YAPILMADI");
            }
            txtAL95.Text = "";
            txtSAT95.Text = "";
            txtalEuro.Text = "";
            txtEurosat.Text = "";
            txtalmaxdize.Text = "";
            txtsatmax.Text = "";
            txtalgaz.Text = "";
            txtsatgaz.Text = "";
        }
        void listele()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='Kurşunsuz95'", conn);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblalıskursunsuz95.Text = rdr[2].ToString();
            }

            conn.Close();
            // Benzin102

            conn.Open();

            SqlCommand cmd2 = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='eurodizel'", conn);

            SqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())

            {
               lblalıseurodizel.Text = rdr2[2].ToString();
            }
            conn.Close();
            // EuroDizel


            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='maxdizel'", conn);

            SqlDataReader rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())

            {
                lblalısmaxdizel.Text = rdr3[2].ToString();

            }
            conn.Close();


            // Power Dizel

            conn.Open();

            SqlCommand cmd4 = new SqlCommand("Select * From TBLBENZIN Where PETROLTUR='gaz'", conn);

            SqlDataReader rdr4 = cmd4.ExecuteReader();

            while (rdr4.Read())
            {
                lblalısgaz.Text = rdr4[2].ToString();

            }
            conn.Close();
            conn.Open();
            SqlCommand cmd10 = new SqlCommand("select*from TBLKASA", conn);
            SqlDataReader dr10 = cmd10.ExecuteReader();
            while (dr10.Read())
            {
                lblkasa2.Text = dr10[0].ToString();
            }
            conn.Close();


        }
        private void DEPOMIKTARI_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'benzinAkaryakıtDataSet.TBLBENZIN' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLBENZINTableAdapter.Fill(this.benzinAkaryakıtDataSet.TBLBENZIN);
            listele();
            

            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("Update TBLBENZIN SET STOK=STOK+@P1 WHERE PETROLTUR='Kurşunsuz95'", conn);
            komut.Parameters.AddWithValue("@p1", numericUpDown1.Value);
            komut.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand komut2 = new SqlCommand("update TBLKASA SET MIKTAR=MIKTAR-@P1", conn);
            komut2.Parameters.AddWithValue("@P1", Convert.ToDouble(textBox1.Text));
            komut2.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand komut3 = new SqlCommand("Update TBLBENZIN SET STOK=STOK+@P1 WHERE PETROLTUR='eurodizel'", conn);
            komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
            komut3.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand komut4 = new SqlCommand("update TBLKASA SET MIKTAR=MIKTAR-@P1", conn);
            komut4.Parameters.AddWithValue("@P1", Convert.ToDouble(textBox2.Text));
            komut4.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            SqlCommand komut5 = new SqlCommand("Update TBLBENZIN SET STOK=STOK+@P1 WHERE PETROLTUR='maxdizel'", conn);
            komut5.Parameters.AddWithValue("@p1", numericUpDown3.Value);
            komut5.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand komut6 = new SqlCommand("update TBLKASA SET MIKTAR=MIKTAR-@P1", conn);
            komut6.Parameters.AddWithValue("@P1", Convert.ToDouble(textBox3.Text));
            komut6.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            SqlCommand komut7 = new SqlCommand("Update TBLBENZIN SET STOK=STOK+@P1 WHERE PETROLTUR='gaz'", conn);
            komut7.Parameters.AddWithValue("@p1", numericUpDown4.Value);
            komut7.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand komut8 = new SqlCommand("update TBLKASA SET MIKTAR=MIKTAR-@P1", conn);
            komut8.Parameters.AddWithValue("@P1", Convert.ToDouble(textBox4.Text));
            komut8.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("DEPOLAR VE KASA DÜZENLENDİ!");
            listele();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
                
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
      
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 FRM = new Form1();
            FRM.Show();

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            double kursunuz95, litre, tutar;
            kursunuz95 = double.Parse(lblalıskursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunuz95 * litre;
            textBox1.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            double euro, litre, tutar;
            euro = double.Parse(lblalıseurodizel.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = euro * litre;
            textBox2.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            double max, litre, tutar;
            max = double.Parse(lblalısmaxdizel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = max * litre;
            textBox3.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged_1(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = double.Parse(lblalısgaz.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = gaz * litre;
            textBox4.Text = tutar.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace sinemabilet
{
    public partial class biletdetaybilgi : Form
    {
        public biletdetaybilgi()
        {
            InitializeComponent();

           
        }


        public string film;
        public string ucret;
        public string biletsayi;

        SqlConnection baglanti = new SqlConnection("Data Source=Gozde_Huawei;Initial Catalog=sinemabilet;Integrated Security=True");
        private void biletdetaybilgi_Load(object sender, EventArgs e)
        {
            lblfilm.Text = film.ToUpper();
            lblfilmad.Text = film;
            lblucret.Text = ucret;
            lblbiletsayi.Text = biletsayi;

           

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select SEANS from bilet where FİLMAD=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", lblfilm.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cBseans.Items.Add(dr[0].ToString());

            }
            baglanti.Close();

        }

        private void Seat_Click(object sender, EventArgs e)
        {

            int koltuksayi = int.Parse(lblbiletsayi.Text);

            Label selectedSeat = sender as Label;


            if (koltuksayi > 0)
            {
                if (selectedSeat.BackColor == Color.Silver)
                {
                    MessageBox.Show("Bu koltuk dolu.", "Koltuk Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    selectedSeat.BackColor = Color.Red;



                    DialogResult result = MessageBox.Show("Bu koltuğu seçmek istiyor musunuz?", "Koltuk Seçim Sorusu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        int kalankoltuk = koltuksayi - 1;

                        lblbiletsayi.Text = kalankoltuk.ToString();

                        string lastTwoChars = selectedSeat.Name.Substring(selectedSeat.Name.Length - 2);


                        if (rBkoltuk.Text.Length > 0)
                        {
                            rBkoltuk.Text += ", ";
                        }
                        rBkoltuk.Text += lastTwoChars;

                    }
                    else
                    {
                        selectedSeat.BackColor = Color.Ivory;


                    }

                }
            }
            else if (koltuksayi == 0)
            {
                MessageBox.Show("Biletinizde olan koltuk sayısı kadar koltuk seçtiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnbiletal.Enabled = true;

                
            }
                
           
            


          

        }









        private void txtseans_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBseans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lblseans.Text = cBseans.Text;

            baglanti.Open();
            SqlCommand salon = new SqlCommand("Select SALONNO from bilet where FİLMAD=@p1 AND SEANS=@p2", baglanti);
            salon.Parameters.AddWithValue("@p1", lblfilm.Text);
            salon.Parameters.AddWithValue("@p2", lblseans.Text);
            SqlDataReader dr2 = salon.ExecuteReader();
            while (dr2.Read())
            {
                lblsalon.Text = dr2[0].ToString();
                lblsalonno.Text = lblsalon.Text;

            }
            baglanti.Close();

            
           
            List<Label> seats = new List<Label> { lbl1A, lbl1B, lbl1C, lbl2A, lbl2B, lbl2C, lbl3A, lbl3B, lbl3C, lbl3D, lbl3E, lbl4A, lbl4B, lbl4C, lbl4D, lbl4E, lbl5A, lbl5B, lbl5C, lbl5C, lbl5D, lbl5E };

          
     
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select KOLTUK from bilet where FİLMAD=@p1 AND SEANS=@p2", baglanti);
            cmd.Parameters.AddWithValue("@p1", lblfilm.Text);
            cmd.Parameters.AddWithValue("@p2", lblseans.Text);
            SqlDataReader sdr = cmd.ExecuteReader();

                      
            while (sdr.Read())
            {
                
                string koltukNo = sdr[0].ToString();
                foreach (Label seat in seats)
                {
                    seat.BackColor = SystemColors.Window;
                    if (koltukNo.Contains(seat.Text))
                    {
                        seat.BackColor = Color.Silver;

                    }
                }
            }

            foreach (Label seat in seats)
            {
               
                seat.MouseClick += new MouseEventHandler(Seat_Click);
            }


            baglanti.Close();

           

             

           
                
            
            




        }

        private void btnbiletal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Biletleriniz Başarı ile Alınmıştır." , "Bilgi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            Application.Exit();
        }
    }
        }


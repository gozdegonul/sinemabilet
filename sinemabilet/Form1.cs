using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinemabilet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int ucret = 0;
       
      
        private void btnuyumsuz_Click(object sender, EventArgs e)
        {
            btnyetiskinarti.Enabled = true;
            btnyetiskineksi.Enabled = true;
            btnogrenciarti.Enabled = true;
            btnogrencieksi.Enabled = true;
            btncocukarti.Enabled = true;
            btncocukeksi.Enabled = true;
            btndevam.Enabled = true;
            lblfilm.Text = "Uyumsuz";
            pBbilet.Image=pBuyumsuz.Image;
        }

        private void btnavengers_Click(object sender, EventArgs e)
        {
            btnyetiskinarti.Enabled = true;
            btnyetiskineksi.Enabled = true;
            btnogrenciarti.Enabled = true;
            btnogrencieksi.Enabled = true;
            btncocukarti.Enabled = true;
            btncocukeksi.Enabled = true;
            btndevam.Enabled = true;
            lblfilm.Text = "Avengers : End Game";

            pBbilet.Image = pBavengers.Image;
        }

        private void btntopgun_Click(object sender, EventArgs e)
        {

            btnyetiskinarti.Enabled = true;
            btnyetiskineksi.Enabled = true;
            btnogrenciarti.Enabled = true;
            btnogrencieksi.Enabled = true;
            btncocukarti.Enabled = true;
            btncocukeksi.Enabled = true;
            btndevam.Enabled = true;
            lblfilm.Text = "Top Gun : Maverick";
            pBbilet.Image=pBtopgun.Image;
        }

        private void btnyetiskinarti_Click(object sender, EventArgs e)
        {
            int yetiskinsayi = Convert.ToInt16(txtyetiskinsayi.Text);
            int yetiskinarti = yetiskinsayi + 1;
            txtyetiskinsayi.Text = yetiskinarti.ToString();
            txtyetiskinbilet.Text = txtyetiskinsayi.Text;
            ucret += 150;
            lblucret.Text = ucret.ToString() + " TL";



        }

        private void btnyetiskineksi_Click(object sender, EventArgs e)
        {
            
            int yetiskinsayi = Convert.ToInt16(txtyetiskinsayi.Text);

            if(yetiskinsayi > 0)
            {
                int yetiskineksi = yetiskinsayi - 1;
                txtyetiskinsayi.Text = yetiskineksi.ToString();

            }
            else
            {
                MessageBox.Show("Bilet Sayısı Eksiltemezsiniz." , "Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtyetiskinbilet.Text = txtyetiskinsayi.Text;
            int sayi = Convert.ToInt16(txtyetiskinbilet.Text);

            if ( yetiskinsayi > 0)
            {
            ucret -= 150 ;
            lblucret.Text = ucret.ToString() + " TL";
            }
            

        }

        private void btnogrenciarti_Click(object sender, EventArgs e)
        {
            int ogrencisayi = Convert.ToInt16(txtogrencisayi.Text);
            int ogrenciarti = ogrencisayi + 1;
            txtogrencisayi.Text = ogrenciarti.ToString();
            txtogrencibilet.Text = txtogrencisayi.Text;
            ucret += 120;
            lblucret.Text = ucret.ToString() + " TL";

        }

        private void btnogrencieksi_Click(object sender, EventArgs e)
        {
            int ogrencisayi = Convert.ToInt16(txtogrencisayi.Text);

            if (ogrencisayi > 0)
            {
                int ogrencieksi = ogrencisayi - 1;
                txtogrencisayi.Text = ogrencieksi.ToString();

            }
            else
            {
                MessageBox.Show("Bilet Sayısı Eksiltemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtogrencibilet.Text = txtogrencisayi.Text; 
            int sayi = Convert.ToInt16(txtogrencibilet.Text);

            if(ogrencisayi > 0)
            { 
                ucret -= 120;
                lblucret.Text = ucret.ToString() + " TL";

            }
           
        }
      

        private void btncocukarti_Click(object sender, EventArgs e)
        {
            int cocuksayi = Convert.ToInt16(txtcocuksayi.Text); 
            int cocukarti  = cocuksayi + 1;
            txtcocuksayi.Text = cocukarti.ToString();
            txtcocukbilet.Text = txtcocuksayi.Text;
            ucret += 75;
            lblucret.Text = ucret.ToString() + " TL";
        }

        private void btncocukeksi_Click(object sender, EventArgs e)
        {
            int cocuksayi = Convert.ToInt16(txtcocuksayi.Text);

            if (cocuksayi > 0)
            {
                int cocukeksi = cocuksayi - 1;
                txtcocuksayi.Text = cocukeksi.ToString();

            }
            else
            {
                MessageBox.Show("Bilet Sayısı Eksiltemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtcocukbilet.Text = txtcocuksayi.Text;
            int sayi = Convert.ToInt16(txtcocukbilet.Text);

            if (cocuksayi > 0)
            {  
                ucret -= 75;
                lblucret.Text = ucret.ToString() + " TL";

            }
          
        }

        private void txtyetiskinbilet_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnyetiskinarti.Enabled = false;
            btnyetiskineksi.Enabled = false;
            btnogrenciarti.Enabled = false;
            btnogrencieksi.Enabled = false;
            btncocukarti.Enabled = false;
            btncocukeksi.Enabled = false;
            btndevam.Enabled = false;

        }

        private void btndevam_Click(object sender, EventArgs e)
        {
            biletdetaybilgi bd = new biletdetaybilgi();
            bd.film = lblfilm.Text;
            bd.ucret = lblucret.Text;

            int yetiskinsayi = Convert.ToInt16(txtyetiskinbilet.Text);
            int ogrencisayi = Convert.ToInt16(txtogrencibilet.Text);
            int cocuksayi = Convert.ToInt16(txtcocukbilet.Text); 
            int biletsayi = yetiskinsayi + ogrencisayi + cocuksayi;
            bd.biletsayi = biletsayi.ToString();
            bd.Show();
            this.Hide();
        }
    }
}

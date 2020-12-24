using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hafıza_oyunu
{
    public partial class Form1 : Form
    {
        Image[] resimler = { Properties.Resources.fa615a015acca9189a2744e9c683947b,
                             Properties.Resources.Lumpy,
                             Properties.Resources.roo,
                             Properties.Resources.winnie_the_pooh_characters_main_characters_kanga_1,
                             Properties.Resources._129_1296099_clip_arts_related_to_winnie_the_pooh_characters,
                             Properties.Resources.s_l400,
                             Properties.Resources._24a74ad9_32b7_4448_b337_259c9f138852_1_385e9efc2eec1df090af85b4c42d65c0,
                             Properties.Resources._2h83z2,
                             Properties.Resources._1_ctvAF16KvjuF8YfBZHJ3UQ,
                             Properties.Resources._1_Al0I0P8AsHFCi6MGa787tA
        };

        int[] indeksler = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9};
        PictureBox ilkkutu;
        int ilkindeks,bulunan,deneme;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimlerikaristir();
        }

        private void btn_basla_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        int sure = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sure++;
            lbl_sure.Text = sure.ToString();
        }

        public void resimlerikaristir()
        {
            Random rnd = new Random();
            for(int i=0;i<20;i++)
            {
                int sayi = rnd.Next(20);

                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }
   
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo-1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkindeks = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                kutu.Image = null;

                if(ilkindeks ==indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;

                    if(bulunan==10)
                    {
                        MessageBox.Show("Tebrikler." + deneme + "denemede buldunuz");
                        bulunan = 0;
                        deneme = 0;
                        foreach(Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimlerikaristir();
                    }
                }
                ilkkutu = null;
            }
        }

     }   
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_otomasyonu_sistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int starr_point = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            starr_point += 2;
            MyProgres.Value = starr_point;
            if (MyProgres.Value == 100)
            {
                MyProgres.Value = 0;
                timer1.Stop();
                Form1 log =new Form1();
                this.Hide();
                log.Show();


            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }
        int starr_point2 = 100;
        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            starr_point2 -= 2;
            Myprogres2.Value = starr_point2;
            if (Myprogres2.Value == 100)
            {

                Myprogres2.Value = 0;
                timer2.Stop();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

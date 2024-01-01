using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace market_otomasyonu_sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region
        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 900;
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ad_TXT.Text) || string.IsNullOrEmpty(sifre_TXT.Text))
            {
                MessageBox.Show("Kullanıcı adı veya şifre girilmedi.");
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Lütfen rolünüzü seçin.");
            }
            else
            {
                if (comboBox1.Text == "Yönetici")
                {
                    // yönetici girişi yapılacak
                }
                else if (comboBox1.Text == "satıcı")
                {
                    // satıcı girişi yapılacak
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir rol seçin (Yönetici veya Satıcı).");
                }
            } 


            
           
               

                if (comboBox1.Text == "Yönetici")
                {

                        try
                        {
                            MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=loader;port=3306;password=495566");
                            connection.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM kullanici_bilgi WHERE kullanici_ad=@kullanici_ad AND sifre=@sifre", connection);
                            mySqlCommand.Parameters.AddWithValue("@kullanici_ad", (object)this.ad_TXT.Text);
                            mySqlCommand.Parameters.AddWithValue("@sifre", (object)this.sifre_TXT.Text);
                            if (mySqlCommand.ExecuteReader().Read())
                            {
                                Form3 loaderhack = new Form3();
                                this.Hide();
                                loaderhack.Show();
                                this.ad_TXT.Text = "";
                                this.sifre_TXT.Text = "";
                                     MessageBox.Show("Hoşgeldiniz Yönetici");
                        }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                            }
                           



                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bir hata oluştu: " + ex.Message);
                        }
                    

                }

                
                

                else
                {
                    if (comboBox1.Text == "satıcı")
                    {
                        try
                        {
                            MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
                            connection.Open();
                            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sellertbl WHERE SellerName=@kullanici_ad AND Sellerpass=@sifre", connection);
                            mySqlCommand.Parameters.AddWithValue("@kullanici_ad", (object)this.ad_TXT.Text);
                            mySqlCommand.Parameters.AddWithValue("@sifre", (object)this.sifre_TXT.Text);
                            if (mySqlCommand.ExecuteReader().Read())
                            {
                                Selling loaderhack = new Selling();
                                this.Hide();
                                loaderhack.Show();
                                this.ad_TXT.Text = "";
                                this.sifre_TXT.Text = "";
                                MessageBox.Show("Hoşgeldiniz Satıcı");
                            }

                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                            }
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bir hata oluştu: " + ex.Message);
                        }
                    }
                            

                            
                }
                
                
            
        }
        #region
        private void ad_TXT_MouseEnter(object sender, EventArgs e)
        {
            if (ad_TXT.Text == "Kullanıcı Adı")
            {
                ad_TXT.Text = "";
            }
        }

        private void ad_TXT_MouseLeave(object sender, EventArgs e)
        {
            if (ad_TXT.Text == "")
            {
                ad_TXT.Text = "Kullanıcı Adı";
            }
        }

        private void sifre_TXT_MouseEnter(object sender, EventArgs e)
        {
            if (sifre_TXT.Text == "Şifre")
            {
                sifre_TXT.Text = "";
            }
        }

        private void sifre_TXT_MouseLeave(object sender, EventArgs e)
        {
            if (sifre_TXT.Text == "")
            {
                sifre_TXT.Text = "Şifre";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ad_TXT.Text = "";
            sifre_TXT.Text = "";
        }
#endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace market_otomasyonu_sistemi
{
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string queryt = "insert into categori1tbl values(@ID, @Kategori_İsim, @Ürün)";
                MySqlCommand cmd = new MySqlCommand(queryt, con);
                cmd.Parameters.AddWithValue("@ID", CatidTb.Text);
                cmd.Parameters.AddWithValue("@Kategori_İsim", CatNameTb.Text);
                cmd.Parameters.AddWithValue("@Ürün", CatDescTb.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategoriye başarıyla eklenmiştir");

                // datagridview'i güncellemek için verileri yeniden yükleyin
                string query = "select * from categoritbl";
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                CatDGV.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        bool move;
        int mouse_x;
        int mouse_y;
        private void Kategori_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Kategori_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Kategori_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            con.Open();
            try
            {
               
                string query = "select * from categori1tbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, con);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sde);
                var ds = new DataSet();
                sde.Fill(ds);
                CatDGV.DataSource = ds.Tables[0];
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


        }
        private void Kategori_Load(object sender, EventArgs e)
        {
            this.Opacity = 900;
            populate();
        }

        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        DataSet ds = new DataSet();
        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open(); // Veritabanı bağlantısını aç
                string query = "select * from categori1tbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, conn);
                ds.Clear(); // Önceki verileri temizle
                sde.Fill(ds, "categori1tbl"); // Yeni verileri yükle
                CatDGV.DataSource = ds.Tables["categori1tbl"]; // DataGridView'a verileri ata
                conn.Close(); // Veritabanı bağlantısını kapat
                MessageBox.Show("Veriler başarıyla yenilendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {


            if (CatidTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
            {
                MessageBox.Show("Eksik Vaye Hatalı bilgi");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
                try
                {
                    con.Open();
                    string query = "UPDATE categori1tbl SET Kategori_İsim = @kategori, Ürün = @urun WHERE ID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@kategori", CatNameTb.Text);
                    cmd.Parameters.AddWithValue("@urun", CatDescTb.Text);
                    cmd.Parameters.AddWithValue("@id", CatidTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Başarıyla Güncellenmiştir");
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }


        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              CatidTb.Text = CatDGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CatDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = CatDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {
            // data grid view içindeki veriyi silmek

            try
            {
                if (CatidTb.Text == "")
                {
                    MessageBox.Show("Silinecek kategöriyi seçin");
                }
                else
                {
                    conn.Open();

                    string query = "DELETE FROM categori1tbl WHERE ID = " + CatidTb.Text;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Başarıyla silinmiştir");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            this.Hide();
            frm4.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}

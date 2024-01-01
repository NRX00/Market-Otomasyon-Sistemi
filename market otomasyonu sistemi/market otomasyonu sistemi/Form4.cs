using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace market_otomasyonu_sistemi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            // ekleme

            try
            {
                con.Open();
                string queryt = "insert into productbl values(@Prodid, @ProdName, @ProdQty,@ProdPrice,@ProdCat)";
                MySqlCommand cmd = new MySqlCommand(queryt, con);
                cmd.Parameters.AddWithValue("@Prodid", Textbox1.Text);
                cmd.Parameters.AddWithValue("@ProdName", Textbox2.Text);
                cmd.Parameters.AddWithValue("@ProdQty", Textbox3.Text);
                cmd.Parameters.AddWithValue("@ProdPrice", Textbox4.Text);
                cmd.Parameters.AddWithValue("@ProdCat", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategoriye başarıyla eklenmiştir");

                // datagridview'i güncellemek için verileri yeniden yükleyin
                string query = "select * from prodtbl";
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gunaDataGridView1.DataSource = dt;
                Textbox1.Text = "";
                Textbox2.Text = "";
                Textbox3.Text = "";
                Textbox4.Text = "";


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

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Kategori cat = new Kategori();

            this.Hide();
            cat.Show();
        }

        private void populate()
        {
            con.Open();
            try
            {

                string query = "select * from productbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, con);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sde);
                var ds = new DataSet();
                sde.Fill(ds);
                gunaDataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


        }

        private void fillcombo()
        {
            // bu yöntem Combobox'ı veri tabanına bağlayacak
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Kategori_İsim FROM categori1tbl", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                comboBox1.DisplayMember = "Kategori_İsim";
                comboBox1.ValueMember = "Kategori_İsim";
                comboBox1.DataSource = dt;
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
      
        private void fillcom()
        {
            
        }


        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
            {
               // düzeltme

            if (Textbox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "")
            {
                MessageBox.Show("Eksik Vaye Hatalı bilgi");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
                try
                {
                    con.Open();
                    string query = "UPDATE productbl SET ProdName = @kategori,ProdCat = @urun , ProdQty = @QTY WHERE Prodid = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@QTY", Textbox4.Text);
                    cmd.Parameters.AddWithValue("@kategori", Textbox3.Text);
                    cmd.Parameters.AddWithValue("@urun", Textbox2.Text);
                    cmd.Parameters.AddWithValue("@id", Textbox1.Text);
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

        private void gunaGradientTileButton3_Click(object sender, EventArgs e)
        {

            try
            {
                if (Textbox1.Text == "")
                {
                    MessageBox.Show("Silinecek kategöriyi seçin");
                }
                else
                {
                    con.Open();

                    string query = "DELETE FROM productbl WHERE Prodid = " + Textbox1.Text;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Başarıyla silinmiştir");
                    populate();
                }
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

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gunaDataGridView1.SelectedRows.Count > 0)
                {
                    gunaDataGridView1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Textbox1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Textbox2.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    Textbox3.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    Textbox4.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        DataSet ds = new DataSet();
        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); // Veritabanı bağlantısını aç
                string query = "select * from productbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, conn);
                ds.Clear(); // Önceki verileri temizle
                sde.Fill(ds, "productbl"); // Yeni verileri yükle
                gunaDataGridView1.DataSource = ds.Tables["productbl"]; // DataGridView'a verileri ata
                conn.Close(); // Veritabanı bağlantısını kapat
                MessageBox.Show("Veriler başarıyla yenilendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Opacity = 900;
            populate();
            fillcombo();
            fillcom();
          

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            Form3 kategori = new Form3();
            this.Hide();
            kategori.Show();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form4_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

  
       
    }
}
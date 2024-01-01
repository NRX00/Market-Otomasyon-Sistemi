using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace market_otomasyonu_sistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region
        bool move;
        int mouse_x;
        int mouse_y;
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        #endregion
        MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
      /*  private void fillcombo()
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
        }*/
        private void populate()
        {
            con.Open();
            try
            {

                string query = "select * from sellertbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, con);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sde);
                var ds = new DataSet();
                sde.Fill(ds);
                DataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Opacity = 900;
            //fillcombo();
            populate();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Kategori ct = new Kategori();
            this.Hide();
            ct.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string queryt = "insert into sellertbl values(@Sellerid, @SellerName, @SellerAge, @Sellerphone, @SellerPass)";
                MySqlCommand cmd = new MySqlCommand(queryt, con);
                cmd.Parameters.AddWithValue("@Sellerid", Textbox1.Text);
                cmd.Parameters.AddWithValue("@SellerName", Textbox2.Text);
                cmd.Parameters.AddWithValue("@SellerAge", Textbox3.Text);
                cmd.Parameters.AddWithValue("@Sellerphone", Textbox4.Text);
                cmd.Parameters.AddWithValue("@SellerPass", Textbox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kategoriye başarıyla eklenmiştir");

                // datagridview'i güncellemek için verileri yeniden yükleyin
                string query = "select * from sellertbl";
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataGridView1.DataSource = dt;
                                              
                Textbox1.Text = "";
                Textbox2.Text = "";
                Textbox3.Text = "";
                Textbox4.Text = "";
                Textbox5.Text = "";

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
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        DataSet ds = new DataSet();
        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); // Veritabanı bağlantısını aç
                string query = "select * from sellertbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, conn);
                ds.Clear(); // Önceki verileri temizle
                sde.Fill(ds, "sellertbl"); // Yeni verileri yükle
                DataGridView1.DataSource = ds.Tables["sellertbl"]; // DataGridView'a verileri ata
                conn.Close(); // Veritabanı bağlantısını kapat
                MessageBox.Show("Veriler başarıyla yenilendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView1.SelectedRows.Count > 0)
                {
                    DataGridView1.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Textbox1.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Textbox2.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    Textbox3.Text = DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    Textbox4.Text = DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    Textbox5.Text = DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            if (Textbox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == ""|| Textbox5.Text == "")
            {
                MessageBox.Show("Eksik Vaye Hatalı bilgi");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
                try
                {
                    con.Open();
                    string query = "UPDATE sellertbl SET Sellerid = @Seller, SellerName = @Name,  SellerAge = @Age, Sellerphone = @phone, SellerPass = @Pass";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Seller", Textbox1.Text);
                    cmd.Parameters.AddWithValue("@Name", Textbox2.Text);
                    cmd.Parameters.AddWithValue("@Age", Textbox3.Text);
                    cmd.Parameters.AddWithValue("@phone", Textbox4.Text);
                    cmd.Parameters.AddWithValue("@Pass", Textbox5.Text);
                    Textbox1.Text = "";
                    Textbox2.Text = "";
                    Textbox3.Text = "";
                    Textbox4.Text = "";
                    Textbox5.Text = "";
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
                    conn.Open();

                    string query = "DELETE FROM sellertbl WHERE Sellerid = " + Textbox1.Text;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Başarıyla silinmiştir");
                    Textbox1.Text = "";
                    Textbox2.Text = "";
                    Textbox3.Text = "";
                    Textbox4.Text = "";
                    Textbox5.Text = "";

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

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();  
            this.Hide();
            form4.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace market_otomasyonu_sistemi
{
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        private void populate()
        {

            con.Open();
            try
            {

                string query = "select ProdName,ProdQty,ProdPrice from productbl";
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

        private void populatebills()
        {

            connn.Open();
            try
            {

                string query = "select FatıraİD, SatıcıAdı, FaturaTarihi,ToplamTutar from billtbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, connn);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sde);
                var ds = new DataSet();
                sde.Fill(ds);
                gunaDataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connn.Close();


        }
        private void fillcombo()
        {
            
           
        }



        private void Selling_Load(object sender, EventArgs e)
        {
            this.Opacity = 900;
            populate();
            populatebills();
            fillcombo();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void Selling_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Selling_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Selling_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gunaDataGridView1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Textbox2.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Textbox4.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Textbox3.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label5.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        int Grdtotal = 0;
        private void gunaGradientTileButton5_Click(object sender, EventArgs e)
        {
            int n = 0, total = Convert.ToInt32(Textbox3.Text) * Convert.ToInt32(Textbox4.Text);

            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(gunaDataGridView2);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = Textbox2.Text;
            newRow.Cells[2].Value = Textbox3.Text;
            newRow.Cells[3].Value = Textbox4.Text;
            newRow.Cells[4].Value = Convert.ToInt32(Textbox3.Text) * Convert.ToInt32(Textbox4.Text);
            gunaDataGridView2.Rows.Add(newRow);
            Grdtotal = Grdtotal + total;
            label10.Text = "" + Grdtotal;


            /* gunaDataGridView2.ColumnCount = 5; 
            int n = 0, total = Convert.ToInt32(Textbox3.Text) * Convert.ToInt32(Textbox4.Text);
            int Grdtotal = 0;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(gunaDataGridView2);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = Textbox2.Text;
            newRow.Cells[2].Value = Textbox3.Text;
            newRow.Cells[3].Value = Textbox4.Text;
            newRow.Cells[4].Value = Convert.ToInt32(Textbox3.Text) * Convert.ToInt32(Textbox4.Text);
            gunaDataGridView2.Rows.Add(newRow);
            Grdtotal = Grdtotal + total;
            label10.Text = "TL " + Grdtotal;*/
        }
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=marketim;port=3306;password=495566");
        DataSet ds = new DataSet();
        private void gunaGradientTileButton4_Click(object sender, EventArgs e)
        {
            // birinci yenileme butonu
            try
            {
                conn.Open(); // Veritabanı bağlantısını aç
                string query = "SELECT ProdName, ProdQty, ProdPrice FROM productbl"; // Sadece istenen sütunları seç
                MySqlDataAdapter sde = new MySqlDataAdapter(query, conn);
                ds.Clear(); // Önceki verileri temizle
                sde.Fill(ds, "productbl"); // Yeni verileri yükle
                gunaDataGridView1.DataSource = ds.Tables["productbl"]; // DataGridView'a verileri ata
                conn.Close(); // Veritabanı bağlantısını kapat
                MessageBox.Show("Veriler başarıyla yenilendi.");
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            if (Textbox1.Text == "")
            {
                MessageBox.Show("Fatura ID Bölümünü Doldurunuz");
            }
            else
            {
                try
                {
                    connn.Open();
                    string queryt = "insert into billtbl values(@FatıraİD, @SatıcıAdı, @FaturaTarihi,@ToplamTutar)";
                    MySqlCommand cmd = new MySqlCommand(queryt, connn);
                    cmd.Parameters.AddWithValue("@FatıraİD", Textbox1.Text);
                    cmd.Parameters.AddWithValue("@SatıcıAdı", Textbox5.Text);
                    cmd.Parameters.AddWithValue("@FaturaTarihi", label5.Text);
                    cmd.Parameters.AddWithValue("@ToplamTutar", label10.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategoriye başarıyla eklenmiştir");

                    // datagridview'i güncellemek için verileri yeniden yükleyin
                    string query = "select * from categoritbl";
                    MySqlCommand cmd2 = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gunaDataGridView1.DataSource = dt;
                    Textbox1.Text = "";
                    Textbox2.Text = "";
                    Textbox3.Text = "";
                    Textbox4.Text = "";
                    populatebills();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connn.Close();
                }

            }


        }
        MySqlConnection connn = new MySqlConnection("server=localhost;user=root;database=loader;port=3306;password=495566");
        private void gunaGradientTileButton6_Click(object sender, EventArgs e)
        {
            // ikinci yenileme butonu
            try
            {
                connn.Open(); // Veritabanı bağlantısını aç
                string query = "select * from billtbl";
                MySqlDataAdapter sde = new MySqlDataAdapter(query, connn);
                ds.Clear(); // Önceki verileri temizle
                sde.Fill(ds, "billtbl"); // Yeni verileri yükle
                DataGridView1.DataSource = ds.Tables["billtbl"]; // DataGridView'a verileri ata
                connn.Close(); // Veritabanı bağlantısını kapat
                MessageBox.Show("Veriler başarıyla yenilendi.");
                // populatebills();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    connn.Open();

                    string query = "DELETE FROM billtbl WHERE FatıraİD = " + Textbox1.Text;
                    MySqlCommand cmd = new MySqlCommand(query, connn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategori Başarıyla silinmiştir");
                    Textbox1.Text = "";
                    Textbox2.Text = "";
                    Textbox3.Text = "";
                    Textbox4.Text = "";
                    populatebills();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connn.Close();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            flag = 1;

            DataGridView1.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Textbox1.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Textbox2.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Textbox5.Text = DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Textbox4.Text = DataGridView1.SelectedRows[0].Cells[3].Value.ToString();




        }
        int flag;
        private void gunaGradientTileButton2_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString("BENİM MARKETİM", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
                e.Graphics.DrawString("Fatura Numarası: " + DataGridView1.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
                e.Graphics.DrawString("Satıcı İsmi: " + DataGridView1.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Blue, new Point(100, 110));
                e.Graphics.DrawString("Tarih: " + DataGridView1.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Blue, new Point(100, 150));
                e.Graphics.DrawString("Toplam Tutar: " + DataGridView1.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Blue, new Point(100,190 ));
                e.Graphics.DrawString("By Eyüp", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.Red, new Point(270, 230));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void gunaGradientTileButton7_Click(object sender, EventArgs e)
        {
            gunaDataGridView2.Rows.Clear();
            label10.Text = "";
            
        }
    }
}   

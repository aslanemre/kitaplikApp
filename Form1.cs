using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System;
using System.Data.SqlClient;

namespace kitaplık
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        SqlCommand cmd;
        DataSet ds;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emrea\Desktop\kitaplık\kutuphane.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter da = new SqlDataAdapter("Select * From kitaplik", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emrea\Desktop\kitaplık\kutuphane.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form1_Load(object sender, EventArgs e)
        {

            MessageBox.Show("Silme İşlemi Yaparken Sadece Silinecek Öğenin ID'sini Giriniz.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // listeleme
            ds = new DataSet();
            da.Fill(ds, "kitaplik");
            dataGridView1.DataSource = ds.Tables["kitaplik"];
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into kitaplik values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı.");
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            ds = new DataSet();
            da.Fill(ds, "kitaplik");
            dataGridView1.DataSource = ds.Tables["kitaplik"];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("delete from kitaplik where id="+textBox1.Text+"", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi.");
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            ds = new DataSet();
            da.Fill(ds, "kitaplik");
            dataGridView1.DataSource = ds.Tables["kitaplik"];
        }
    }
}
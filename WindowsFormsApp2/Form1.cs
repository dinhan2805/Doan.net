using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Loai A");
            comboBox1.Items.Add("Loai B");
            comboBox1.Items.Add("Loai C");
            comboBox1.Items.Add("Loai D");
        }
        KetNoi kn = new KetNoi();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text =  "";
            textBox4.Text =     "";
            textBox5.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = string.Format(
               "insert into SanPham values(N'{0}', N'{1} ', N'{2}', N'{3}', N'{4}', N'{5}',N'{6}')",
               textBox1.Text,
               textBox2.Text,
               textBox3.Text,
               textBox4.Text,
               textBox5.Text,
               textBox7.Text,
               comboBox1.SelectedValue

               );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Mới Thành Công ! ");
                button1.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm Mới Thất Bại ! ");
            }
        }
        public void getLoaiNV()
        {
            string query = "select * from LoaiNguoiDung ";
            DataSet ds = kn.LayDuLieu(query);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "MaSP";
            comboBox1.ValueMember = "LoaiSP";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Format(
              "update SanPham set TenSP=N'{1}',DonGia=N'{2}',HinhAnh=N'{3}',MoTaNgan=N'{4}',MoTaChiTiet=N'{5}', LoaiSP=N'{6}' where MaSP = '{0}'",
              textBox1.Text,
              textBox2.Text,
              textBox3.Text,
              textBox4.Text,
              textBox5.Text,
              textBox7.Text,
              comboBox1.SelectedValue
              );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa Thành Công ! ");
                button1.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại ! ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = string.Format(
              "delete from SanPham where MaSP ='{0}'",
                 textBox1.Text
                 );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành Công ! ");
                button1.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại ! ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = String.Format("select * from SanPham where MaSP like N'%{0}%'",
   textBox6.Text
   );
            DataSet ds = kn.LayDuLieu(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
            getLoaiNV();
        }
        public void getData()
        {
            string query = "select * from SanPham";
            DataSet ds = kn.LayDuLieu(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {

                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                textBox1.Text = dataGridView1.Rows[r].Cells["MaSP"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[r].Cells["TenSP"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[r].Cells["DonGia"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[r].Cells["HinhAnh"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[r].Cells["MoTaNgan"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[r].Cells["MoTaChiTiet"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[r].Cells["LoaiSP"].Value.ToString();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
        }

    }
}

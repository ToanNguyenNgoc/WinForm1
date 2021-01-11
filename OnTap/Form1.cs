using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace OnTap
{
    public partial class Form1 : Form
        
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=OnTap;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NhanVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_Ma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_ten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_ngaySinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_gioiTinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_chucVu.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_luong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into NhanVien values('" + txt_Ma.Text + "','" + txt_ten.Text + "', '" + txt_ngaySinh.Text+ "','" + txt_gioiTinh.Text + "','" + txt_chucVu.Text+ "','" + txt_luong.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from NhanVien where MaNV='" + txt_Ma.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công!");
            loaddata();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
           
            command = connection.CreateCommand();
            command.CommandText = "update NhanVien set tenNV='" + txt_ten.Text + "',NgaySinh='" + txt_ngaySinh.Text + "',GioiTinh='"+txt_gioiTinh.Text+"', ChucVu='" + txt_chucVu.Text+"', TienLuong=" + txt_luong.Text + " where MaNV='" + txt_Ma.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }
    }
}

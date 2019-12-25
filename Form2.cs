using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        ManageDatabase mdb = ManageDatabase.getInstance();
        int selTag = -1;
        int selRow = -1;
        MySqlConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = mdb.getConnection();
            InitDataview();
        }
        void InitDataview()
        {
            DataGridView dgv = this.dataGridView1;
            dgv.Rows.Clear();
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            String sql = "select * from addressbook";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int index = dgv.Rows.Add();
                String name = reader.GetString("name");
                String sex = reader.GetString("sex");
                String email = reader.GetString("email");
                String phone = reader.GetString("phone");
                dgv.Rows[index].Tag = reader.GetInt32("uid");
                dgv.Rows[index].Cells[0].Value = name;
                dgv.Rows[index].Cells[1].Value = sex;
                dgv.Rows[index].Cells[2].Value = phone;
                dgv.Rows[index].Cells[3].Value = email;
            }
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = this.dataGridView1;

            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                selRow = e.RowIndex;
                selTag = Convert.ToInt32(dgv.Rows[e.RowIndex].Tag);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridView dgv = this.dataGridView1;
            conn.Open();
            String sql=$"insert into addressbook (name,sex,phone,email) values('{dgv.Rows[selRow].Cells[0].Value.ToString()}'," +
                $"'{dgv.Rows[selRow].Cells[1].Value.ToString()}','{dgv.Rows[selRow].Cells[2].Value.ToString()}','{dgv.Rows[selRow].Cells[3].Value.ToString()}')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int status=cmd.ExecuteNonQuery();
            if (status == 1)
            {
                this.label1.Text = "添加成功！";
            }
            else
            {
                this.label1.Text = "添加失败！";
            }
            conn.Close();
            InitDataview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridView dgv = this.dataGridView1;
            conn.Open();
            String sql = $"update addressbook set name='{dgv.Rows[selRow].Cells[0].Value.ToString()}',sex='{dgv.Rows[selRow].Cells[1].Value.ToString()}',"+
                $"phone='{dgv.Rows[selRow].Cells[2].Value.ToString()}',email='{dgv.Rows[selRow].Cells[3].Value.ToString()}' where uid={selTag}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status == 1)
            {
                this.label1.Text = "编辑成功！";
            }
            else
            {
                this.label1.Text = "编辑失败！";
            }
            conn.Close();
            InitDataview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridView dgv = this.dataGridView1;
            conn.Open();
            String sql = $"delete from addressbook where uid={selTag}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status == 1)
            {
                this.label1.Text = "删除成功！";
            }
            else
            {
                this.label1.Text = "删除失败！";
            }
            conn.Close();
            InitDataview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("通讯录帮助手册.CHM");
        }
    }
}

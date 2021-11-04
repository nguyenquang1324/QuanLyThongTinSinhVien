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

namespace WindowsFormsApp1
{
    public partial class Formchinh : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = @"Data Source = DESKTOP-2021XUP\SQLEXPRESS; Initial Catalog = QLSV; Integrated Security = True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Formchinh()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            ketnoicsdl();

        }
        private void ketnoicsdl()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from Sinhvien";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }



        private void btnadd_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (radioButton1.Checked == true)
            {
                gender = "Nam";
                
            }
            if (radioButton2.Checked == true)
            {
                gender = "Nu";
                
            }

            cmd = con.CreateCommand();
            cmd.CommandText = "insert into Sinhvien(MaSV, Hovaten, Address, Phone, birthday, Year, Nganh, Gioitinh, Class, Email) values ('" + textBoxmsv.Text + "',N'" + textBoxht.Text + "',N'" +comboBoxdiachi.Text + "','" + textBoxphone.Text + "','" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "'," +
                "'" + comboBoxyear.Text + "','" + comboBoxnganh.Text + "',N'" + gender+ "'" +",'"+comboBoxclass.Text+"','" + textBoxemail.Text + "')";
            cmd.ExecuteNonQuery();
            ketnoicsdl();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dataGridView1.CurrentRow.Index;
            textBoxmsv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBoxht.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBoxdiachi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBoxphone.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            comboBoxyear.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            comboBoxnganh.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            string gt = dataGridView1.Rows[i].Cells[7].Value.ToString();
            if (gt.Trim() == "Nam")
            {
                radioButton1.Checked = true;
            }
              else
            {
                radioButton2.Checked = true;
            }
            comboBoxclass.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            textBoxemail.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "delete from Sinhvien where MaSV = '"+textBoxmsv.Text+"'";
            cmd.ExecuteNonQuery();
            ketnoicsdl();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (radioButton1.Checked == true)
            {
                gender = "Nam";

            }
            if (radioButton2.Checked == true)
            {
                gender = "Nữ";

            }
            cmd = con.CreateCommand();
            cmd.CommandText = "update Sinhvien set MaSV= N'" + textBoxmsv.Text + "', Hovaten=N'" + textBoxht.Text + "', Address=N'" + comboBoxdiachi.Text + "', Phone='" + textBoxphone.Text + "', birthday=" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + ", Year='" + comboBoxyear.Text + "', Nganh='" + comboBoxyear.Text + "', Gioitinh=N'" + gender + "', Class='" + comboBoxclass.Text + "', Email  ='" + textBoxemail.Text + "' where MaSV = '"+textBoxmsv.Text+"'";
            cmd.ExecuteNonQuery();
            ketnoicsdl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxmsv.Text = "";
            textBoxht.Text = "";
            comboBoxdiachi.Text = "";
            textBoxphone.Text = "";
            dateTimePicker1.Text = "1/1/2000";
            comboBoxyear.Text = " ";
            comboBoxnganh.Text = "";
            radioButton1.Checked = true;
            comboBoxclass.Text = "";
            textBoxemail.Text = "";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from Sinhvien where MaSV= '"+textBox1.Text+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

    
    }
}

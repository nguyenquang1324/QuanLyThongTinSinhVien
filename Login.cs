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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
      
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-2021XUP\SQLEXPRESS; Initial Catalog = QLSV; Integrated Security = True");
            try
            {
                con.Open();
                string taikhoan = textBox1.Text;
                string matkhau = textBox2.Text;
                string sql = "select * from users where Taikhoan = '" + taikhoan + "' and Matkhau='"+matkhau+"' ";
                SqlCommand cm = new SqlCommand(sql, con);
                SqlDataReader dta = cm.ExecuteReader();
                if (dta.Read() == true)
                {
                    this.Hide();
                    Formchinh form = new Formchinh();
                    form.ShowDialog();
                    

                }
                else MessageBox.Show("đăng nhập thất bại");

            }
            catch (Exception)
            {

                //MessageBox.Show("lỗi kết nối");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

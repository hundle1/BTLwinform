using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Report
{
    public partial class dangnhap : Form
    {
   

        string mk = "1234";

        public dangnhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kiemtra(txttk.Text, txtmk.Text) == 0)
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            } else if(kiemtra(txttk.Text, txtmk.Text) == 1)
            {
                Form2 f = new Form2();
                f.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
        int kiemtra(string tk, string mk)
        {
            if (tk == "admin1" && mk == this.mk)
            {
                return 0;
            } else if(tk == "admin2" && mk == this.mk) 
            {
                return 1;
            }
            return 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(txtmk.PasswordChar == '*')
            {
                pictureBox2.BringToFront();
                txtmk.PasswordChar = '\0';
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtmk.PasswordChar == '\0')
            {
                pictureBox3.BringToFront();
                txtmk.PasswordChar = '*';
            }
        }
    }

}

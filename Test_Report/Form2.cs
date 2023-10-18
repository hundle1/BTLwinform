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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            this.Hide();
            fm_rpSV fm = new fm_rpSV();
            fm.ShowDialog(this);
        }

        private void danhSáchSinhViênĐangTrọExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fm_SV_Tro fm_SV_Tro = new fm_SV_Tro();
            fm_SV_Tro.ShowDialog();
        }

        private void danhSáchPhòngĐangTrốngKèmDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fm_Phong_Trong fm_Phong_Trong = new fm_Phong_Trong();
            fm_Phong_Trong.ShowDialog();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            this.Hide();
            fm_rpTT fm_RpTT = new fm_rpTT();
            fm_RpTT.ShowDialog();
        }

        private void xuấtHóaĐơnCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangnhap dangnhap = new dangnhap();
            dangnhap.ShowDialog();
        }

        private void hợpĐồngĐăngKýTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fm_dk fm_Dk = new fm_dk();
            fm_Dk.ShowDialog();
        }
    }
}

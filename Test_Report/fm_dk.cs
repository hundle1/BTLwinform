using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Report
{
    public partial class fm_dk : Form
    {
        public fm_dk()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJT0QMV;Initial Catalog=QLKTX;Integrated Security=True");
        public DataTable LayDL(string sql)
        {
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        private void fm_dk_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            DataTable dt = new DataTable();
            dt = LayDL("Select * from SinhVien");
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Masv";
            comboBox1.DisplayMember = "Masv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "Select * from SinhVien where Masv='" + comboBox1.Text + "'";


            DataTable dt = new DataTable();
            dt = LayDL(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Users\admin\source\repos\Test_Report\Test_Report\rp_dk.rdlc";
            if (dt.Rows.Count >= 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet2";
                rds.Value = dt;
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                reportViewer1.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                reportViewer1.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                reportViewer1.RefreshReport();
            }
            else MessageBox.Show("Khong co du lieu");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

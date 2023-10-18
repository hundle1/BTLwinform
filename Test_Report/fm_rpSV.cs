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
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DTO;
using BUS;


namespace Test_Report
{
    public partial class fm_rpSV : Form
    {
        public fm_rpSV()
        {
            InitializeComponent();
            this.Controls.Add(this.reportViewer1);
        }

        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJT0QMV;Initial Catalog=QLKTX;Integrated Security=True");
        public DataTable LayDL(string sql)
        {
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        private void fm_rpSV_Load(object sender, EventArgs e)
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
            string sql = "Select * from SinhVien";
            
            sql += " where Masv ='" + comboBox1.SelectedValue.ToString() + "' ";
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Users\admin\source\repos\Test_Report\Test_Report\rp_SV.rdlc";
            if (dt.Rows.Count >= 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "QLKTX";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "Select Masv,Tensv,Ngaysinh,Que,Gioitinh,Sodienthoai from SinhVien";
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Users\admin\source\repos\Test_Report\Test_Report\rp_SV.rdlc";
            if (dt.Rows.Count >= 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "QLKTX";
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
    }
}

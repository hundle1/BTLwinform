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
using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Test_Report
{
    public partial class fm_rpTT : Form
    {
        public fm_rpTT()
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
        private void fm_rpTT_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            DataTable dt = new DataTable();
            dt = LayDL("Select * from ThanhToan");
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Mahoadon";
            comboBox1.DisplayMember = "Mahoadon";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "Select Thang,SinhVien.Tensv,Sodienthoai,Phong.Tenphong,Phong.Giaphong,DichVu.Tendichvu,DichVu.Giatien,(Giatien + Phong.Giaphong)  AS Tongtien  from SinhVien,Phong,Dichvu,HopDong,ThanhToan " +
                " Where SinhVien.Masv = ThanhToan.Masv and HopDong.Masv = SinhVien.Masv and DichVu.Tendichvu = HopDong.Tendichvu and Phong.Tenphong = HopDong.TenPhong and ThanhToan.Mahoadon ='" + comboBox1.SelectedValue.ToString() + "' " +
                " Group by ThanhToan.Mahoadon,ThanhToan.Thang,Sinhvien.Tensv,SinhVien.Sodienthoai,Phong.Tenphong,Phong.Giaphong,DichVu.Tendichvu,DichVu.Giatien,ThanhToan.Tongtien";

          
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Users\admin\source\repos\Test_Report\Test_Report\rp_TT.rdlc";
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

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

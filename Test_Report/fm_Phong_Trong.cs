using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using OfficeOpenXml;
using System.IO;
using System.Windows.Media;
using System.Data.SqlClient;
namespace Test_Report
{
    public partial class fm_Phong_Trong : Form
    {
        public fm_Phong_Trong()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel | *.xlsx | Excel 2012 | *.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            using (ExcelPackage p = new ExcelPackage())
            {

                p.Workbook.Properties.Author = "Nguyễn Văn Ninh";
                p.Workbook.Properties.Title = "Báo cáo thống kê";
                p.Workbook.Worksheets.Add("Danh_sach_SV");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Danh_sach_Sinh_Vien";
                ws.Cells.Style.Font.Size = 12;
                ws.Cells.Style.Font.Name = "Calibri";
                string[] arrColumnHeader = { "Mã số", "Họ tên", "Ngày sinh", "Quê", "Giới tính", "Số Điện Thoại", "Tên Phòng", "Ngày Thuê" };
                var countColHeader = arrColumnHeader.Count();
                ws.Cells[1, 1].Value = "Thống kê thông tin Sinh Viên Đang Trọ";
                ws.Cells[1, 1].Style.Font.Size = 18;
                ws.Cells[1, 1, 1, countColHeader].Merge = true;
                ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;

                int colIndex = 1;
                int rowIndex = 2;
                foreach (var item in arrColumnHeader)
                {
                    var cell = ws.Cells[rowIndex, colIndex];
                    cell.Value = item;
                    colIndex++;
                }
                List<SinhVien> userList1 = new List<SinhVien>();
                List<HopDong> userList2 = new List<HopDong>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SinhVien oa = new SinhVien();
                    oa.Masv = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    oa.Tensv = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    oa.Ngaysinh = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    oa.Que = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    oa.Gioitinh = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    oa.Sodienthoai = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    userList1.Add(oa);
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    HopDong ob = new HopDong();
                    ob.Tenphong = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    ob.Ngaythue = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    userList2.Add(ob);
                }
                foreach (var item in userList1)
                {
                    colIndex = 1;
                    rowIndex++;
                    ws.Cells[rowIndex, colIndex++].Value = item.Masv;
                    ws.Cells[rowIndex, colIndex++].Value = item.Tensv;
                    ws.Cells[rowIndex, colIndex++].Value = item.Ngaysinh;
                    ws.Cells[rowIndex, colIndex++].Value = item.Que;
                    ws.Cells[rowIndex, colIndex++].Value = item.Gioitinh;
                    ws.Cells[rowIndex, colIndex++].Value = item.Sodienthoai;
                }
                foreach (var item in userList2)
                {
                    colIndex = 7;
                    rowIndex += 1;
                    ws.Cells[rowIndex, colIndex++].Value = item.Tenphong;
                    ws.Cells[rowIndex, colIndex++].Value = item.Ngaythue;
                }

                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
            }
            MessageBox.Show("Xuất excel thành công!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
        }
        Phong_BUS phong = new Phong_BUS();
        HopDong_BUS hd = new HopDong_BUS();
        DichVu_Bus dv = new DichVu_Bus();
        private void fm_Phong_Trong_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = phong.Load_BUS_PT();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

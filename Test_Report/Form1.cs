using DTO;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
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

using BUS;

using OfficeOpenXml;
using System.IO;
using System.Windows.Media;

using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

namespace Test_Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJT0QMV;Initial Catalog=QLKTX;Integrated Security=True");

        Lop_Bus lop = new Lop_Bus();
        Phong_BUS phong = new Phong_BUS();
        HopDong_BUS hd = new HopDong_BUS();
        DichVu_Bus dv = new DichVu_Bus();
        ThanhToan_Bus tt = new ThanhToan_Bus();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lop.Load_Bus();
            dataGridView2.DataSource = lop.Load_Bus();
            dataGridView3.DataSource = phong.Load_Bus();
            dataGridView4.DataSource = dv.Load_BUS();
            dataGridView5.DataSource = hd.Load_BUS();
            dataGridView6.DataSource = tt.Load_BUS();
            DataTable at = new DataTable();
            at = LayDL("Select * from SinhVien");
            comboBox2.DataSource = at;
            comboBox2.ValueMember = "Masv";
            comboBox2.DisplayMember = "Masv";
            DataTable bt = new DataTable();
            bt = LayDL("Select * from Phong");
            comboBox3.DataSource = bt;
            comboBox3.ValueMember = "Maphong";
            comboBox3.DisplayMember = "Maphong";
            DataTable ct = new DataTable();
            ct = LayDL("Select * from DichVu");
            comboBox4.DataSource = ct;
            comboBox4.ValueMember = "Tendichvu";
            comboBox4.DisplayMember = "Tendichvu";
            DataTable dt = new DataTable();
            dt = LayDL("Select * from ThanhToan");
            comboBox6.DataSource = dt;
            comboBox6.ValueMember = "Mahoadon";
            comboBox6.DisplayMember = "Mahoadon";
        }
        public DataTable LayDL(string sql)
        {
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Select * from " + comboBox1.Text;
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            dataGridView1.DataSource = dt;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void xuấtHóaĐơnCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xuấtDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void button10_Click(object sender, EventArgs e)
        {
            DichVu ob = new DichVu(textBox18.Text,float.Parse(textBox17.Text));
            dv.Insert_BUS(ob);
            Form1_Load(sender, e);
            dataGridView4.DataSource = dv.Load_BUS();
            textBox17.Clear();
            textBox18.Clear();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            HopDong ob = new HopDong(textBox24.Text, textBox23.Text, textBox22.Text, textBox21.Text, textBox20.Text, textBox19.Text,textBox7.Text);
            hd.Insert_BUSHD(ob);
            Form1_Load(sender, e);
            dataGridView5.DataSource = hd.Load_BUS();
            textBox24.Clear();
            textBox23.Clear();
            textBox22.Clear();
            textBox21.Clear();
            textBox20.Clear();
            textBox19.Clear();
            textBox7.Clear();
        }
        private void insert_Click(object sender, EventArgs e)
        {
            SinhVien ob = new SinhVien(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            lop.Insert_Bus(ob);
            Form1_Load(sender, e);
            dataGridView2.DataSource = lop.Load_Bus();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Phong ob = new Phong(textBox12.Text, textBox11.Text, textBox10.Text, textBox8.Text, textBox9.Text);
            phong.Insert_Bus(ob);
            Form1_Load(sender, e);
            dataGridView3.DataSource = phong.Load_Bus();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ThanhToan ob = new ThanhToan(textBox30.Text, textBox29.Text, float.Parse(textBox28.Text), textBox26.Text, textBox27.Text, textBox25.Text);
            tt.Insert_BUS(ob);
            Form1_Load(sender, e);
            dataGridView6.DataSource = tt.Load_BUS();
            textBox30.Clear();
            textBox29.Clear();
            textBox28.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox25.Clear();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            lop.Delete_Bus(textBox1.Text);
            Form1_Load(sender, e);
            textBox1.Clear();
            dataGridView2.DataSource = lop.Load_Bus();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            hd.Delete_BUS(textBox24.Text);
            Form1_Load(sender, e);
            textBox24.Clear();
            dataGridView5.DataSource = hd.Load_BUS();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            dv.Delete_BUS(textBox18.Text);
            Form1_Load(sender, e);
            textBox18.Clear();
            dataGridView4.DataSource = dv.Load_BUS();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            phong.Delete_Bus(textBox12.Text);
            Form1_Load(sender, e);
            textBox12.Clear();
            dataGridView3.DataSource = phong.Load_Bus();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            tt.Delete_BUS(textBox30.Text);
            Form1_Load(sender, e);
            textBox30.Clear();
            dataGridView6.DataSource = tt.Load_BUS();
        }
        private void update_Click(object sender, EventArgs e)
        {
            SinhVien ob = new SinhVien(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            lop.Update_Bus(ob); 
            Form1_Load(sender, e);
            dataGridView2.DataSource = lop.Load_Bus();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            HopDong ob = new HopDong(textBox24.Text, textBox23.Text, textBox22.Text, textBox21.Text, textBox20.Text, textBox19.Text,textBox7.Text);
            hd.Update_BUS(ob);
            Form1_Load(sender, e);
            dataGridView5.DataSource = hd.Load_BUS();
            textBox24.Clear();
            textBox23.Clear();
            textBox22.Clear();
            textBox21.Clear();
            textBox20.Clear();
            textBox19.Clear();
            textBox7.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ThanhToan ob = new ThanhToan(textBox30.Text, textBox29.Text, float.Parse(textBox28.Text), textBox26.Text, textBox27.Text, textBox25.Text);
            tt.Update_BUS(ob);
            Form1_Load(sender, e);
            dataGridView6.DataSource = tt.Load_BUS();
            textBox30.Clear();
            textBox29.Clear();
            textBox28.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox25.Clear();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DichVu ob = new DichVu(textBox18.Text, float.Parse(textBox17.Text));
            dv.Update_BUS(ob);
            Form1_Load(sender, e);
            dataGridView4.DataSource = dv.Load_BUS();
            textBox18.Clear();
            textBox17.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Phong ob = new Phong(textBox12.Text, textBox11.Text, textBox10.Text, textBox8.Text, textBox9.Text);
            phong.Update_Bus(ob);
            Form1_Load(sender, e);
            dataGridView3.DataSource = phong.Load_Bus();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string sql = "Select * from SinhVien where Masv ='" + comboBox2.Text +"'";
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            dataGridView2.DataSource = dt;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            string sql = "Select * from Phong where Maphong ='" + comboBox3.Text + "'";
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            dataGridView3.DataSource = dt;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string sql = "Select * from DichVu where Tendichvu ='" + comboBox4.Text + "'";
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            dataGridView4.DataSource = dt;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            string sql = "Select * from ThanhToan where Mahoadon ='" + comboBox6.Text + "'";
            DataTable dt = new DataTable();
            dt = LayDL(sql);
            dataGridView6.DataSource = dt;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

        }
        private void button3_Click(object sender, EventArgs e)
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
                p.Workbook.Properties.Title = "Báo cáo thống kê Phòng";
                p.Workbook.Worksheets.Add("Danh_sach_Phong");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Danh_sach_Phong_Tro";
                ws.Cells.Style.Font.Size = 12;
                ws.Cells.Style.Font.Name = "Calibri";
                string[] arrColumnHeader = { "Mã phòng", "Tên phòng", "Trạng Thái", "Số Lượng", "Giá Phòng"};
                var countColHeader = arrColumnHeader.Count();
                ws.Cells[1, 1].Value = "Thống kê thông tin Phòng Đang có";
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
                List<Phong> userList = new List<Phong>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Phong ob = new Phong();
                    ob.Maphong = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    ob.Tenphong = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    ob.Trangthai = dataGridView3.Rows[i].Cells[3].Value.ToString();
                    ob.Soluong = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    ob.Giaphong = dataGridView3.Rows[i].Cells[5].Value.ToString();
                    userList.Add(ob);
                }
                foreach (var item in userList)
                {

                    colIndex = 1;
                    rowIndex++;
                    ws.Cells[rowIndex, colIndex++].Value = item.Maphong;
                    ws.Cells[rowIndex, colIndex++].Value = item.Tenphong;
                    ws.Cells[rowIndex, colIndex++].Value = item.Trangthai;
                    ws.Cells[rowIndex, colIndex++].Value = item.Soluong;
                    ws.Cells[rowIndex, colIndex++].Value = item.Giaphong;
                }
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
            }
            MessageBox.Show("Xuất excel thành công!");

        }

        

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i =0; i < dataGridView1.Rows.Count -1; i++ ) {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView4_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView5_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                dataGridView5.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView6_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
            {
                dataGridView6.Rows[i].Cells[0].Value = i + 1;
            }

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

      

       

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            dangnhap dangnhap = new dangnhap();
            dangnhap.ShowDialog();  
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox6.Text = row.Cells[6].Value.ToString();
        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
            textBox12.Text = row.Cells[1].Value.ToString();
            textBox11.Text = row.Cells[2].Value.ToString();
            textBox10.Text = row.Cells[3].Value.ToString();
            textBox8.Text = row.Cells[4].Value.ToString();
            textBox9.Text = row.Cells[5].Value.ToString();
    
        }

        private void dataGridView4_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
            textBox18.Text = row.Cells[1].Value.ToString();
            textBox17.Text = row.Cells[2].Value.ToString();
        }

        private void dataGridView5_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView5.Rows[e.RowIndex];
            textBox24.Text = row.Cells[1].Value.ToString();
            textBox23.Text = row.Cells[2].Value.ToString();
            textBox22.Text = row.Cells[3].Value.ToString();
            textBox21.Text = row.Cells[4].Value.ToString();
            textBox20.Text = row.Cells[5].Value.ToString();
            textBox19.Text = row.Cells[6].Value.ToString();
            textBox7.Text = row.Cells[7].Value.ToString();
        }

        private void dataGridView6_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView6.Rows[e.RowIndex];
            textBox30.Text = row.Cells[1].Value.ToString();
            textBox29.Text = row.Cells[2].Value.ToString();
            textBox28.Text = row.Cells[3].Value.ToString();
            textBox26.Text = row.Cells[4].Value.ToString();
            textBox27.Text = row.Cells[5].Value.ToString();
            textBox25.Text = row.Cells[6].Value.ToString();
        }

       
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        public string Masv { get; set; }
        public string Tensv { get; set; }
        public string Ngaysinh { get; set; }
        public string Que { get; set; }
        public string Gioitinh { get; set; }
        public string Sodienthoai { get; set; }

        public SinhVien() { }
        public SinhVien(string Masv, string Tensv, string Ngaysinh, string Que, string Gioitinh, string Sodienthoai)
        {
            this.Masv = Masv;
            this.Tensv = Tensv;
            this.Ngaysinh = Ngaysinh;
            this.Que = Que;
            this.Gioitinh = Gioitinh;
            this.Sodienthoai = Sodienthoai;
        }
    }
   

    public class Phong
    {
        public string Maphong { get; set; }
        public string Tenphong { get; set; }
        public string Trangthai { get; set; }
        public string Soluong { get; set; }
        public string Giaphong { get; set; }
        public Phong() { }
        public Phong(string Maphong, string Tenphong, string Trangthai, string Soluong, string Giaphong)
        {
            this.Maphong = Maphong;
            this.Tenphong = Tenphong;
            this.Trangthai = Trangthai;
            this.Soluong = Soluong;
            this.Giaphong = Giaphong;
        }

    }

    public class HopDong { 
        public string Masv { get; set; }
        public string Tensv { get; set; }
        public string Mahopdong { get; set; }
        public string Tenphong { get; set; }
        public string Giaphong { get; set; }
        public string Ngaythue { get; set; }
        public string Tendichvu { get; set; }

        public HopDong() { }
        public HopDong(string Masv, string Tensv, string Mahopdong, string Tenphong, string Giaphong, string Ngaythue,string Tendichvu) {
            this.Masv = Masv;
            this.Tensv = Tensv;
            this.Mahopdong = Mahopdong;
            this.Tenphong= Tenphong;
            this.Giaphong= Giaphong;
            this.Ngaythue= Ngaythue;
            this.Tendichvu= Tendichvu;
        }
    }

    public class ThanhToan { 
        public string Mahoadon { get; set; }
        public string Thang { get; set; }
        public float Tongtien { get; set; }
        public string Masv { get; set; }
        public string Tensv { get; set; }
        public string Ghichu { get; set; }
       
        public ThanhToan() { }
        public ThanhToan(string Mahoadon, string Thang, float Tongtien, string Masv, string Tensv, string Ghichu ) { 
            this.Mahoadon = Mahoadon;
            this.Thang = Thang;
            this.Tongtien = Tongtien;
            this.Masv = Masv;
            this.Tensv= Tensv;
            this.Ghichu = Ghichu;
        }
    }

    public class DichVu
    {
        public string Tendichvu { get; set;}
        public float Giatien { get; set; }
        public DichVu() { }
        public DichVu(string Tendichvu, float Giatien) {
            this.Tendichvu = Tendichvu;
            this.Giatien = Giatien;
        }
    }
    public class thanhtoan
    {
        public string Thang { get; set; }
        public string Tensv { get; set; }
        public string Sodienthoai { get; set; }
        public string Tenphong { get; set; }
        public float Giaphong { get; set; }
        public string Tendichvu { get; set; }
        public float Giatien { get; set; }
        public float Tongtien { get; set; }
    }

}
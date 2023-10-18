using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class SV_DAL:connect
    {
        public SV_DAL() { }

        // Load
        public DataTable Load_SV()
        {
            return Load_DL("select * from SinhVien");
        }
        public DataTable Load_SV_Tro()
        {
            return Load_DL("Select SinhVien.Masv,SinhVien.Tensv,Ngaysinh,Que,Gioitinh,Sodienthoai,Tenphong,Ngaythue from SinhVien,HopDong Where SinhVien.Masv = HopDong.Masv");
        }
        public void Insert_SV(SinhVien ob)
        {
            string sql = "insert into SinhVien values('" + ob.Masv + "',N'" + ob.Tensv + "','" + ob.Ngaysinh + "',N'" + ob.Que + "',N'" + ob.Gioitinh + "','" + ob.Sodienthoai + "')";
            Excecute(sql);
        }
        public void Update_SV(SinhVien ob)
        {
            string sql = "update SinhVien set Tensv=N'" + ob.Tensv + "', Ngaysinh = '"+ob.Ngaysinh+"', Que = N'"+ob.Que+"', Gioitinh=N'"+ob.Gioitinh+"', Sodienthoai='"+ob.Sodienthoai+"' where Masv='" + ob.Masv + "'";
            Excecute(sql);
        }
        public void Delete_SV(string Masv)
        {
            string sql = "delete from SinhVien where Masv='" + Masv + "'";
            Excecute(sql);

        }

    }
}

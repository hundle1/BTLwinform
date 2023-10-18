using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class P_DAL:connect
    {
        public DataTable Load_P()
        {
            return Load_DL("select * from Phong");
        }

        public DataTable Load_P_T()
        {
            return Load_DL("select Phong.Maphong,Phong.Tenphong,Phong.Trangthai,Phong.Soluong,Phong.Giaphong,DichVu.Tendichvu,DichVu.Giatien " +
                " From Phong,Dichvu,HopDong" +
                " Where Phong.Tenphong = HopDong.Tenphong and HopDong.Tendichvu = DichVu.Tendichvu and Soluong='6/6'" +
                " Group by Phong.Maphong,Phong.Tenphong,Phong.Trangthai,Phong.Soluong,Phong.Giaphong,DichVu.Tendichvu,DichVu.Giatien");
   
        }
        public void Insert_P(Phong ob)
        {
            string sql = "insert into Phong values('" + ob.Maphong + "',N'" + ob.Tenphong + "',N'" + ob.Trangthai + "','" + ob.Soluong + "','" + ob.Giaphong + "')";
            Excecute(sql);
        }
        public void Update_P(Phong ob)
        {
            string sql = "update Phong set Tenphong=N'" + ob.Tenphong + "',Trangthai=N'"+ob.Trangthai+"',Soluong='"+ob.Soluong+"',Giaphong='"+ob.Giaphong+"' " + "where Maphong='" + ob.Maphong + "'";
            Excecute(sql);
        }
        public void Delete_P(string Maphong)
        {
            string sql = "delete from Phong where Maphong='" + Maphong + "'";
            Excecute(sql);

        }
    }
}

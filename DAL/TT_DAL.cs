using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TT_DAL:connect
    {
        
        public DataTable Load_TT()
        {
            return Load_DL("Select ThanhToan.Mahoadon,Thang,SUM(HopDong.Giaphong +  DichVu.Giatien) as Tongtien,ThanhToan.Masv,ThanhToan.Tensv,Ghichu\r\nfrom ThanhToan,Phong,HopDong,DichVu \r\nwhere Phong.Tenphong = HopDong.Tenphong \r\nand DichVu.Tendichvu = HopDong.Tendichvu \r\nand ThanhToan.Masv = HopDong.Masv\r\nGroup by ThanhToan.Mahoadon, ThanhToan.Masv, ThanhToan.Tensv,ThanhToan.Thang,ThanhToan.Ghichu\r\n");
        }
      
        public void Insert_TT(ThanhToan ob)
        {
            string sql = "insert into ThanhToan values('" + ob.Mahoadon + "','" + ob.Thang + "','"+ob.Tongtien + "','"+ ob.Masv + "',N'"+ob.Tensv+"',N'"+ob.Ghichu + "')";
            Excecute(sql);
        }
        public void Update_TT(ThanhToan ob)
        {
            string sql = "update ThanhToan set Thang='" + ob.Thang + "',Tongtien='"+ob.Tongtien+"', Masv='"+ob.Masv+"',Tensv=N'"+ob.Tensv+"',Ghichu=N'"+ob.Ghichu+"' where Mahoadon='" + ob.Mahoadon + "'";
            Excecute(sql);
        }
        public void Delete_TT(string Mahoadon)
        {
            string sql = "delete from ThanhToan where Masv='" + Mahoadon + "'";
            Excecute(sql);

        }
    }
}

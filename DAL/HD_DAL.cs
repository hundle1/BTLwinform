using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HD_DAL:connect
    {
        public DataTable Load_HD()
        {
            return Load_DL("select * from HopDong");
        }
        public void Insert_HD(HopDong ob)
        {
            string sql = "insert into HopDong values('" + ob.Masv + "',N'" + ob.Tensv + "','" + ob.Mahopdong + "',N'" + ob.Tenphong + "','" + ob.Giaphong + "','" + ob.Ngaythue + "',N'"+ob.Tendichvu+"')";
            Excecute(sql);
        }
        public void Update_HD(HopDong ob)
        {
            string sql = "update HopDong set Masv='" + ob.Masv + "',Tensv =N'"+ob.Tensv+"',Tenphong=N'"+ob.Tenphong+"',Giaphong='"+ob.Giaphong+"',Ngaythue='"+ob.Ngaythue+ "',Tendichvu=N'"+ob.Tendichvu + "' " + "where Mahopdong='" + ob.Mahopdong + "'";
            Excecute(sql);
        }
        public void Delete_HD(string Mahopdong)
        {
            string sql = "delete from HopDong where Mahopdong='" + Mahopdong + "'";
            Excecute(sql);

        }
    }
}

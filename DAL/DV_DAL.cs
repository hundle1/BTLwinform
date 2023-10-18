using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
namespace DAL
{
    public class DV_DAL:connect
    {
        public DataTable Load_DV()
        {
            return Load_DL("Select * from DichVu");
        }
        public void Insert_HD(DichVu ob)
        {
            string sql = "insert into DichVu values(N'" + ob.Tendichvu + "','" + ob.Giatien + "')";
            Excecute(sql);
        }
        public void Update_HD(DichVu ob)
        {
            string sql = "update DichVu set Giatien='" + ob.Giatien + "' " + "where Tendichvu=N'" + ob.Tendichvu + "'";
            Excecute(sql);
        }
        public void Delete_HD(string Tendichvu)
        {
            string sql = "delete from DichVu where Tendichvu='" + Tendichvu + "'";
            Excecute(sql);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class Lop_Bus
    {
        SV_DAL sv = new SV_DAL();
        public DataTable Load_Bus()
        {
            return sv.Load_SV();
        }
        public DataTable Load_Tro()
        {
            return sv.Load_SV_Tro();
        }
        public void Insert_Bus(SinhVien ob)
        {
            sv.Insert_SV(ob);
        }
        public void Update_Bus(SinhVien ob)
        {
            sv.Update_SV(ob);
        }
        public void Delete_Bus(string Masv)
        {
            sv.Delete_SV(Masv);
        }
    }
    public class Phong_BUS
    {
        P_DAL p = new P_DAL();
        public DataTable Load_Bus()
        {
            return p.Load_P();
        }
        public DataTable Load_BUS_PT()
        {
            return p.Load_P_T();
        }
        public void Insert_Bus(Phong ob)
        {
            p.Insert_P(ob);
        }
        public void Update_Bus(Phong ob)
        {
            p.Update_P(ob);
        }
        public void Delete_Bus(string Maphong)
        {
            p.Delete_P(Maphong);
        }
    }
    public class HopDong_BUS
    {
        HD_DAL hd = new HD_DAL();
        public DataTable Load_BUS()
        {
            return hd.Load_HD();
        }
        public void Insert_BUSHD(HopDong ob)
        {
            hd.Insert_HD(ob);
        }
        public void Update_BUS(HopDong ob)
        {
            hd.Update_HD(ob);
        }
        public void Delete_BUS(string Mahopdong)
        {
            hd.Delete_HD(Mahopdong);
        }
    }
    public class DichVu_Bus
    {
        DV_DAL dv = new DV_DAL();
        public DataTable Load_BUS()
        {
            return dv.Load_DV();
        }
        public void Insert_BUS(DichVu ob)
        {
            dv.Insert_HD(ob);
        }
        public void Update_BUS(DichVu ob)
        {
            dv.Update_HD(ob);
        }
        public void Delete_BUS(string Tenhopdong)
        {
            dv.Delete_HD(Tenhopdong);
        }
    }
    public class ThanhToan_Bus
    {
        TT_DAL tt = new TT_DAL();
        public DataTable Load_BUS()
        {
            return tt.Load_TT();
        }

        public void Insert_BUS(ThanhToan ob)
        {
            tt.Insert_TT(ob);
        }
        public void Update_BUS(ThanhToan ob)
        {
            tt.Update_TT(ob);
        }
        public void Delete_BUS(string Tenhopdong)
        {
            tt.Delete_TT(Tenhopdong);
        }
    }
}

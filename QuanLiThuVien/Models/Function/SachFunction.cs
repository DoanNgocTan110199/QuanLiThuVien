using QuanLiThuVien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLiThuVien.Models.Function
{
    public class SachFunction
    {
        private QuanLiThuVienDb db;
        public SachFunction()
        {
            db = new QuanLiThuVienDb();
        }
        public List<Sach> AllBooks()
        {
            return db.Saches.ToList();
        }
        //get sach for slide
        public List<Sach> SachChoSlide(int top)
        {
            return db.Saches.Where(x => x.Namxuatban > DateTime.Now).Take(top).ToList();
        }
        //
        public List<Sach> SachMoi(DateTime dateTime)
        {
            return db.Saches.Where(x => x.Namxuatban >= dateTime).ToList();
        }

        //Lay top cac cuon sach muon nhieu
        public List<Sach> SachMuonNhieu(int top)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Top", top)
            };
            return db.Saches.SqlQuery("SachDuocMuon @Top", sqlParameters).ToList();
        }
        public List<Sach> SachSXAZ()
        {
            var links = from l in db.Saches select l;
            links = links.OrderBy(s => s.Tensach);
            return links.ToList();
        }
    }
}
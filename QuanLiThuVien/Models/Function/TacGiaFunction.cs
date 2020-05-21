using QuanLiThuVien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThuVien.Models.Function
{
    public class TacGiaFunction
    {
        private QuanLiThuVienDb db;
        public TacGiaFunction()
        {
            db = new QuanLiThuVienDb();
        }
        public List<TacGia> GetTacGias()
        {
            return db.TacGias.ToList();
        }
    }
}
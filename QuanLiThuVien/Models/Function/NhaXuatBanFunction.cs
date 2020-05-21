using QuanLiThuVien.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThuVien.Models.Function
{
    public class NhaXuatBanFunction
    {
        private QuanLiThuVienDb db;
        public NhaXuatBanFunction()
        {
            db = new QuanLiThuVienDb();
        }
        public List<NhaXuatBan> GetNhaXuatBans()
        {
            return db.NhaXuatBans.ToList();
        }
    }
}
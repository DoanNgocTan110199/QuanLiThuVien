using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiThuVien.Models.Entities;
namespace QuanLiThuVien.Models.Function
{
    public class CartItemFunction
    {
        private QuanLiThuVienDb db = null;
        public CartItemFunction()
        {
            db = new QuanLiThuVienDb();
        }
        public Sach ViewDetail(long id)
        {
            return db.Saches.Find(id);
        }
    }
}
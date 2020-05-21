using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiThuVien.Models.Entities;
namespace QuanLiThuVien.Models.ViewModel
{
    public class CartItemModel
    {
        public Sach sach { get; set; }
        public int Quantity { set; get; }
    }
}
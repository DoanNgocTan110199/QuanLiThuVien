using QuanLiThuVien.Models.Function;
using QuanLiThuVien.Models.ViewModel;
using QuanLiThuVien.Models.Entities;
using QuanLiThuVien.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLiThuVien.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItemModel>();
            if (cart != null)
            {
                list = (List<CartItemModel>)cart;
            }
            return View(list);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderTop()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItemModel>();
            if (cart != null)
            {
                list = (List<CartItemModel>)cart;
            }
            return PartialView(list);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderMid()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItemModel>();
            if (cart != null)
            {
                list = (List<CartItemModel>)cart;
            }
            return PartialView(list);
        }
        [ChildActionOnly]
        public PartialViewResult ShowCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItemModel>();
            if (cart != null)
            {
                list = (List<CartItemModel>)cart;
            }
            return PartialView(list);
        }
        private const string CartSession = "CartSession";
        /*public ActionResult dIndex()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }*/
        public ActionResult AddItem(int sachID, int Quantity)
        {
            var sanpham = new CartItemFunction().ViewDetail(sachID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItemModel>)cart;
                if (list.Exists(x => x.sach.SachID == sachID))
                {
                    foreach (var item in list)
                    {
                        if (item.sach.SachID == sachID)
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItemModel();
                    item.sach = sanpham;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItemModel();
                item.sach = sanpham;
                item.Quantity = Quantity;
                var list = new List<CartItemModel>();
                list.Add(item);
                //gan vao sesion
                Session[CartSession] = list;
            }
            return RedirectToAction("Index","Cart");
        }
        public RedirectToRouteResult XoaKhoiGio(int sachID)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItemModel>)cart;
                CartItemModel itemXoa = list.FirstOrDefault(m => m.sach.SachID == sachID);
                if (itemXoa != null)
                {
                    list.Remove(itemXoa);
                }
                Session[CartSession] = list;
            }
            // List<CartItemModel> giohang = Session["CartSession"] as List<CartItemModel>;
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        /*
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }*/
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItemModel>>(cartModel);
            var sessionCart = (List<CartItemModel>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.FirstOrDefault(x => x.sach.SachID == item.sach.SachID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}
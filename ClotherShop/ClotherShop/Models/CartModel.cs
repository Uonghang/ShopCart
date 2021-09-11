using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherShop.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ID_Product { get; set; }
        public int ID_Member { get; set; }
        public int Status { get; set; }
        public CartModel()
        {
        }

        public CartModel(int quantity, int iD_Product, int iD_Member)
        {
            Quantity = quantity;
            ID_Product = iD_Product;
            ID_Member = iD_Member;
        }

        public CartModel(int quantity, int iD_Product, int iD_Member, int status)
        {
            Quantity = quantity;
            ID_Product = iD_Product;
            ID_Member = iD_Member;
            Status = status;
        }

        public CartModel(int id, int quantity, int iD_Product, int iD_Member, int status)
        {
            Id = id;
            Quantity = quantity;
            ID_Product = iD_Product;
            ID_Member = iD_Member;
            Status = status;
        }
    }
}
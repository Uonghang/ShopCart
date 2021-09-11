using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherShop.Models
{
    public class OderModel
    {
        public int ID { get; set; }
        public int ID_Product { get; set;}
        public int Id_Member { get; set;}
        public int Quanlity { get; set;}

        public OderModel(int iD_Product, int id_Member, int quanlity)
        {
            ID_Product = iD_Product;
            Id_Member = id_Member;
            Quanlity = quanlity;
        }

        public OderModel(int iD, int iD_Product, int id_Member, int quanlity)
        {
            ID = iD;
            ID_Product = iD_Product;
            Id_Member = id_Member;
            Quanlity = quanlity;
        }

    }
}
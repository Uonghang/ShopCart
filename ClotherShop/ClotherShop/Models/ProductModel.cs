using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherShop.Models
{
    public class ProductModel
    {
        public int ID { get; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Rating { get; set; }
        public string Image { get; set; }
        public string Des { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(int iD, string name, float cost, float rating, string image)
        {
            ID = iD;
            Name = name;
            Cost = cost;
            Rating = rating;
            Image = image;
        }

        public ProductModel(int iD, string name, float cost, float rating, string image, string des)
        {
            ID = iD;
            Name = name;
            Cost = cost;
            Rating = rating;
            Image = image;
            Des = des;
        }
    }
}
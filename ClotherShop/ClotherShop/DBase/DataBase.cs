using ClotherShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClotherShop.DBase
{
    public class DataBase
    {
        public static DataBase singleton = null;
        public string conString;
        public SqlCommand cmd;

        public SqlConnection con;
        public string Name;

        public static DataBase Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new DataBase();
                return singleton;
            }

        }
        private DataBase()
        {
            conString = @"Data Source=DESKTOP-U8OMTB9\SQLEXPRESS;Initial Catalog=ClotherManager;Persist Security Info=True;User ID=hang;Password=a01234567";
        }
        public MemberModel SelectLogin(string sql)
        {
            MemberModel m = new MemberModel();
            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                SqlDataReader dt = cmd.ExecuteReader();
                if (dt.HasRows)
                {
                    if (dt.Read())
                    {
                        int id = (int)dt[0];
                        string email = ((string)dt[1]);
                        string password = ((string)dt[2]);
                        string name = ((string)dt[3]);
                        string phone = ((string)dt[4]);
                        string address = ((string)dt[5]);
                        m = new MemberModel(id, email, password, name, phone, address);
                    }
                }

                this.con.Close();
                return m;
            }
        }
        public List<ProductModel> Product(string sql)
        {
            List<ProductModel> item = new List<ProductModel>();


            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                SqlDataReader dt = cmd.ExecuteReader();
                while (dt != null && dt.Read())
                {
                    int id = (int)dt[0];
                    string name = (string)dt[1];
                    float cost = Convert.ToSingle(dt[2]);
                    float rating = Convert.ToSingle(dt[3]);
                    string image = (string)dt[4];

                    ProductModel model = new ProductModel(id, name, cost, rating, image);
                    item.Add(model);
                }

                this.con.Close();
                return item;
            }
        }
        public ProductModel ProductDetail(string sql)
        {
            ProductModel model = new ProductModel();


            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                SqlDataReader dt = cmd.ExecuteReader();
                while (dt != null && dt.Read())
                {
                    int id = (int)dt[0];
                    string name = (string)dt[1];
                    float cost = Convert.ToSingle(dt[2]);
                    float rating = Convert.ToSingle(dt[3]);
                    string image = (string)dt[4];
                    string des = (string)dt[5];

                    model = new ProductModel(id, name, cost, rating, image,des);
                    
                }

                this.con.Close();
                return model;
            }
        }
        public List<CartModel> listCart(string sql)
        {
            List<CartModel> item = new List<CartModel>();


            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                SqlDataReader dt = cmd.ExecuteReader();
                while (dt != null && dt.Read())
                {
                    int id = (int)dt[0];
                    int id_product = (int)dt[1];
                   
                    int quantity = (int)dt[2];
                    int id_member = (int)dt[3];
                    int status = (int)dt[4];

                    CartModel model = new CartModel( quantity, id_product,id_member,status);
                    item.Add(model);
                }

                this.con.Close();
                return item;
            }
        }
        public Dictionary<CartModel,ProductModel> CartDetail(string sql)
        {
            Dictionary<CartModel, ProductModel> item = new Dictionary<CartModel, ProductModel>();


            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                SqlDataReader dt = cmd.ExecuteReader();
                while (dt != null && dt.Read())
                {
                    int id = (int)dt[0];
                    int id_product = (int)dt[1];
                    int quantity = (int)dt[2];
                    int id_member = (int)dt[3];
                    int status = (int)dt[4];
                    int idsp= (int)dt[5];
                    string name= (string)dt[6];
                    float cost = Convert.ToSingle(dt[7]);
                    float rating = Convert.ToSingle(dt[8]);
                    string image= (string)dt[9];


                    CartModel cart = new CartModel(id,quantity, id_product, id_member,status);
                    ProductModel product = new ProductModel(idsp,name, cost, rating, image);
                    item.Add(cart,product);
                }

                this.con.Close();
                return item;
            }
        }
        public Boolean Cart(string sql)
        {
            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

                this.con.Close();
            }
        }
        public int Count(string sql)
        {
            using (con = new SqlConnection(conString))
            {
                int count = 0;
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                try
                {
                    SqlDataReader dt = cmd.ExecuteReader();
                    
                    if (dt.HasRows)
                    {
                        if (dt.Read())
                        {
                            count=(int)dt[0];
                        }
                    }
                    return count;
                }
                catch (Exception ex)
                {
                    return 0;
                }

                this.con.Close();
            }
        }
        public List<CartModel> listOder(string sql)
        {
            List<CartModel> item = new List<CartModel>();


            using (con = new SqlConnection(conString))
            {
                this.con.Open();
                cmd = new SqlCommand(sql, this.con);
                SqlDataReader dt = cmd.ExecuteReader();
                while (dt != null && dt.Read())
                {
                    int id = (int)dt[0];
                    int id_product = (int)dt[1];

                    int quantity = (int)dt[2];
                    int id_member = (int)dt[3];
                    int status = (int)dt[4];

                    CartModel model = new CartModel(id,quantity, id_product, id_member, status);
                    item.Add(model);
                }

                this.con.Close();
                return item;
            }
        }
    }
}
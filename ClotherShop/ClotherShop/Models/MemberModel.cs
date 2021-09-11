using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClotherShop.Models
{
    public class MemberModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public MemberModel()
        {
        }

        public MemberModel(int id, string email, string password, string name, string phone, string address)
        {
            Id = id;
            Email = email;
            Password = password;
            Phone = phone;
            Name = name;
            Address = address;
        }
    }
}
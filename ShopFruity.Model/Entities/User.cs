using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFruity.Model.Entities
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

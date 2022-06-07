using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFruity.Model.Entities
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int? PId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UId { get; set; }

        public virtual Permission PIdNavigation { get; set; }
        public virtual User UIdNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFruity.Model.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            Accounts = new HashSet<Account>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}

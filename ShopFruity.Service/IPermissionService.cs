using ShopFruity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public interface IPermissionService
    {
        IEnumerable<Permission> GetAllPermission();
        Permission GetPermission(int id);
        void InsertPermission(Permission permission);
        void UpdatePermission(Permission permission);
        void DeletePermission(int id);
    }
}

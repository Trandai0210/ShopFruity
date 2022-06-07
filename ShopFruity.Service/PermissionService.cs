using ShopFruity.Model.Entities;
using ShopFruity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IGenericRepository<Permission> _repository;
        public PermissionService(IGenericRepository<Permission> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Permission> GetAllPermission()
        {
            return _repository.GetAll();
        }
        public Permission GetPermission(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertPermission(Permission permission)
        {
            _repository.Insert(permission);
        }
        public void UpdatePermission(Permission permission)
        {
            _repository.Update(permission);
        }
        public void DeletePermission(int id)
        {
            _repository.Delete(id);
        }

        public static implicit operator PermissionService(GenericRepository<Permission> v)
        {
            throw new NotImplementedException();
        }
    }
}

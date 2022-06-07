using ShopFruity.Model.Entities;
using ShopFruity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _repository.GetAll();
        }
        public User GetUser(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertUser(User user)
        {
            _repository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }
        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }

        public static implicit operator UserService(GenericRepository<User> v)
        {
            throw new NotImplementedException();
        }
    }
}

using ShopFruity.Model.Entities;
using ShopFruity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<Account> _repository;
        public AccountService(IGenericRepository<Account> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return _repository.GetAll();
        }
        public Account GetAccount(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertAccount(Account account)
        {
            _repository.Insert(account);
        }
        public void UpdateAccount(Account account)
        {
            _repository.Update(account);
        }
        public void DeleteAccount(int id)
        {
            _repository.Delete(id);
        }

        public static implicit operator AccountService(GenericRepository<Account> v)
        {
            throw new NotImplementedException();
        }
    }
}

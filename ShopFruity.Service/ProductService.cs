using ShopFruity.Model.Entities;
using ShopFruity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public class ProductService : IProductService
    {
        public readonly IGenericRepository<Product> _repository;
        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _repository.GetAll();
        }
        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertProduct(Product product)
        {
            _repository.Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }
        public void DeleteProduct(int id)
        {
            _repository.Delete(id);
        }

        public static implicit operator ProductService(GenericRepository<Product> v)
        {
            throw new NotImplementedException();
        }
    }
}

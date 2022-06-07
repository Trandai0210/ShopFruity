using ShopFruity.Model.Entities;
using ShopFruity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public class OrderDetailService:IOrderDetailService
    {
        private readonly IGenericRepository<OrderDetail> _repository;
        public OrderDetailService(IGenericRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail()
        {
            return _repository.GetAll();
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            _repository.Insert(orderDetail);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _repository.Update(orderDetail);
        }
        public void DeleteOrderDetail(int id)
        {
            _repository.Delete(id);
        }

        public static implicit operator OrderDetailService(GenericRepository<OrderDetail> v)
        {
            throw new NotImplementedException();
        }
    }
}

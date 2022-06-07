using ShopFruity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetail();
        void InsertOrderDetail(OrderDetail orderdetail);
        void UpdateOrderDetail(OrderDetail orderdetail);
        void DeleteOrderDetail(int id);
    }
}

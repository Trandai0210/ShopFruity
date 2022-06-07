using ShopFruity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Models
{
    public class CartItem
    {
        public Product ProductOrder { get; set; }//thông tin sản phẩm
        public int Quantity { get; set; }//số lượng sản phẩm
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFruity.Model.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? ViewCount { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFruity.Model.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public string CustomerMessage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public string getStatus()
        {
            string result = "";
            if (Status == null)
            {
                result = "Chờ xác nhận";
            }
            else if (Status == false)
            {
                result = "Đã hủy";
            }
            else
            {
                result = "Thành công";
            }
            return result;
        }
    }
}

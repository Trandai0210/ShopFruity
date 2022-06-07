using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFruity.Model.Entities
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool Status { get; set; }
        public int? ViewCount { get; set; }
    }
}

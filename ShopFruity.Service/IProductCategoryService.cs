using ShopFruity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAllProductCategory();
        ProductCategory GetProductCategory(int id);
        void InsertProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(int id);
    }
}

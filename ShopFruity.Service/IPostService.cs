using ShopFruity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPost();
        Post GetPost(int id);
        void InsertPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
}

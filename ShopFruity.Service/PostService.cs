using ShopFruity.Model.Entities;
using ShopFruity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFruity.Service
{
    public class PostService : IPostService
    {
        private readonly IGenericRepository<Post> _repository;
        public PostService(IGenericRepository<Post> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Post> GetAllPost()
        {
            return _repository.GetAll();
        }
        public Post GetPost(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertPost(Post post)
        {
            _repository.Insert(post);
        }
        public void UpdatePost(Post post)
        {
            _repository.Update(post);
        }
        public void DeletePost(int id)
        {
            _repository.Delete(id);
        }

        public PostService(GenericRepository<Post> v)
        {
            throw new NotImplementedException();
        }
    }
}

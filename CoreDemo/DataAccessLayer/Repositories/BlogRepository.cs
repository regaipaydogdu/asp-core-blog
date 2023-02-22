using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {
        Context context = new Context();
        public void AddBlog(Blog blog)
        {
            context.Add(blog);
            context.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            context.Remove(blog);
            context.SaveChanges();
        }

        public Blog GetById(int id)
        {
            return context.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            return context.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            context.Update(blog);
            context.SaveChanges();
        }
    }
}

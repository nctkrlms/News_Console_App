using NewsApp.AppDbContext;
using NewsApp.Models;
using NewsApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Repository
{
    internal class CommentRepository : IRepository<Comment>
    {
        DataContext db = new DataContext();
        public bool Add(Comment entity)
        {
            var exists = db.Comment.Any(c => c.Id == entity.Id);
            if (!exists)
            {
                db.Comment.Add(entity);
                db.SaveChanges();

            }
            return !exists;
        }

        public bool Delete(int id)
        {
            bool status = true;
            Comment comment = new Comment();
            comment = db.Comment.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                comment.IsDelete = true;
                db.SaveChanges();

            }
            else
            {
                status = false;
            }
            return status;
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            return db.Comment.ToList();
        }

        public bool Update(Comment entity)
        {

            var comment = db.Comment.Find(entity.Id);
            bool status = true;
            if (comment!=null && !String.IsNullOrWhiteSpace(entity.Content))
            {
                comment.Content = entity.Content;
                db.SaveChanges();
            }
            else
            {
                status = false;
            }
            return status;

        }
    }
}

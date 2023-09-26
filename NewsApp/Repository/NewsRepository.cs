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
    internal class NewsRepository : IRepository<New>
    {
        DataContext db = new DataContext();
        public bool Add(New entity)
        {
            var exists = db.New.Any(c => c.Id == entity.Id);
            if (!exists)
            {
                db.New.Add(entity);
                db.SaveChanges();

            }
            return !exists;
        }

        public bool Delete(int id)
        {
            var news = db.New.Find(id);
            bool status = false;
            if (news != null)
            {
                try
                {
                    news.IsDelete = true;
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }
            return status;
        }

        public New Get(int id)
        {
            var news = db.New.Find(id);
            return news;
        }

        public List<New> GetAll()
        {
            return db.New.ToList();
        }

        public bool Update(New entity)
        {
            var news = db.New.Find(entity.Id);
            bool status = true;
            if (news != null)
            {
                if (!String.IsNullOrWhiteSpace(entity.Title))
                {
                    news.Title = entity.Title;
                }
                else
                {
                    news.Title = news.Title;
                }
                if (!String.IsNullOrWhiteSpace(entity.Content))
                {
                    news.Content = entity.Content;
                }
                else
                {
                    news.Content = news.Content;
                }
                if (news.CategoryId > 0)
                {
                    news.CategoryId = entity.CategoryId;
                }
                else
                {
                    news.CategoryId = news.CategoryId;
                }

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

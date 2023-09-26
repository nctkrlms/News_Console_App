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
    internal class CategoryRepository : IRepository<Category>
    {
        DataContext db = new DataContext();
        public bool Add(Category entity)
        {
            var exists = db.Category.Any(c => c.Name == entity.Name);
            if (!exists)
            {
                db.Category.Add(entity);
                db.SaveChanges();

            }
            return !exists;
        }

        public bool Delete(int id)
        {
            var category = db.Category.Find(id);
            bool status = false;
            if (category != null)
            {
                try
                {
                    category.IsDelete = true;
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

        public Category Get(int id)
        {
            var category = db.Category.Find(id);
            return category;
        }

        public List<Category> GetAll()
        {
            return db.Category.ToList();
        }

        public bool Update(Category entity)
        {
            var category = db.Category.Find(entity.Id);
            bool status = false;
            if (category != null && !String.IsNullOrWhiteSpace(entity.Name))
            {
                category.Name = entity.Name;
                db.SaveChanges();
                status = true;
            }
            return status;
        }

    }
}

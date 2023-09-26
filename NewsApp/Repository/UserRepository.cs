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
    internal class UserRepository : IRepository<User>
    {
        DataContext db = new DataContext();
        public bool Add(User entity)
        {
            var exists = db.New.Any(c => c.Id == entity.Id);
            if (!exists)
            {
                db.User.Add(entity);
                db.SaveChanges();

            }
            return !exists;
        }

        public bool Delete(int id)
        {
            var users = db.User.Find(id);
            bool status = false;
            if (users != null)
            {
                try
                {
                    users.IsDelete = true;
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

        public User Get(int id)
        {
            var users = db.User.Find(id);
            return users;
        }

        public List<User> GetAll()
        {
            return db.User.ToList();
        }

        public bool Update(User entity)
        {
            var users = db.User.FirstOrDefault(x=>x.Id == entity.Id);
            bool status = true;
            if (users != null)
            {
                if (!String.IsNullOrWhiteSpace(entity.Name))
                {
                    users.Name = entity.Name;
                }
                else
                {
                    users.Name = users.Name;
                }
                if (!String.IsNullOrWhiteSpace(entity.Surname))
                {
                    users.Surname = entity.Surname;
                }
                else
                {
                    users.Surname = users.Surname;
                }
                if (!String.IsNullOrWhiteSpace(entity.Username))
                {
                    users.Username = entity.Username;
                }
                else
                {
                    users.Username = users.Username;
                }
                if (!String.IsNullOrWhiteSpace(entity.Password))
                {
                    users.Password = entity.Password;
                }
                else
                {
                    users.Password = users.Password;
                }                


                db.SaveChanges();
            }
            else
            {
                status = false;
            }
            return status;
        }        
        public bool UserUpdate(User entity)
        {
            var users = db.User.Find(Program.userId);
            bool status = true;
            if (users != null)
            {
                if (!String.IsNullOrWhiteSpace(entity.Name))
                {
                    users.Name = entity.Name;
                }
                else
                {
                    users.Name = users.Name;
                }
                if (!String.IsNullOrWhiteSpace(entity.Surname))
                {
                    users.Surname = entity.Surname;
                }
                else
                {
                    users.Surname = users.Surname;
                }
                if (!String.IsNullOrWhiteSpace(entity.Username))
                {
                    users.Username = entity.Username;
                }
                else
                {
                    users.Username = users.Username;
                }
                if (!String.IsNullOrWhiteSpace(entity.Password))
                {
                    users.Password = entity.Password;
                }
                else
                {
                    users.Password = users.Password;
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

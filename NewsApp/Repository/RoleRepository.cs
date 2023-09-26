using NewsApp.AppDbContext;
using NewsApp.Models;
using NewsApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Repository
{
    internal class RoleRepository : IRepository<Role>
    {
        DataContext db = new DataContext();
        public bool Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            return db.Role.ToList();
        }

        public bool Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}

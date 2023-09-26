using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        List<T> GetAll();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models.Interfaces
{
    public interface IProcess<T>
    {
        void Add();
        void Update();
        void Delete();
        T Get();
        void GetAll();
        void Menu();

    }
}

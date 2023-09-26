using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public List<New> News { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    internal class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId  { get; set; }
        public User User { get; set; }
        public int NewId { get; set; }
        public New New { get; set; }
        public bool IsDelete { get; set; } = false;
        

    }
}

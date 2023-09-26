using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    internal class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required] 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Comment> Comments { get; set; } 

    }
}

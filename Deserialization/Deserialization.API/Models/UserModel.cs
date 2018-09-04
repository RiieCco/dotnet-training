using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deserialization.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
    }
}

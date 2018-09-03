using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.API.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public virtual ICollection<IdorModel> Idor { get; set; }
    }
}

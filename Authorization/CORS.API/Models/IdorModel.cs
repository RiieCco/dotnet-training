using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.API.Models
{
    public class IdorModel
    {
        [Key]
        public int IdorId { get; set; }
        public string IdorValue { get; set; }
        public string Owner { get; set; }
    }
}

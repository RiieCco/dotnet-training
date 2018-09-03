using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.API.ViewModels
{
    public class IdorViewModel
    {
        [Required]
        public string IdorValue { get; set; }
    }
}

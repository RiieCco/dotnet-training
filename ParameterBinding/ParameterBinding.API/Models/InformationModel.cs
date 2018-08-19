using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParameterBinding.API.Models
{
    public class InformationModel
    {
        [Key]
        public int InformationId { get; set; }
        public string Name     { get; set; }
        public string Lastname { get; set; }
        public bool SuperUser  { get; set; }
    }
}

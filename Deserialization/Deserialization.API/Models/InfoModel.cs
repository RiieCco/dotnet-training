using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Deserialization.Models
{
    public class InfoModel
    {
        [Key]
        public string InformationId { get; set; }
        public string Information { get; set; }
    }
}

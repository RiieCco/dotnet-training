using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deserialization.ViewModels
{
    public class InfoViewModel
    {
        public string Information { get; set; }
        public IList<IDictionary<string, object>> data { get; set; }
    }
}

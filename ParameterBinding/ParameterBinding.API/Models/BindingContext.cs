using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParameterBinding.API.Models
{
    public class BindingContext : DbContext 
    {
        public BindingContext(DbContextOptions<BindingContext> options) : base(options) { }
        public DbSet<InformationModel> InformationModel { get; set; }
    }
}

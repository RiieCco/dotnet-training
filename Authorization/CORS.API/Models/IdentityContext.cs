using Authorization.API.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Authorization.API.Models;

namespace CORS.API.Models
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options){}
        public DbSet<CsrfModel> Csrf { get; set; }
        public DbSet<IdorModel> Idor { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}

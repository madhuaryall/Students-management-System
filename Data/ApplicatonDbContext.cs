using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class ApplicatonDbContext:IdentityDbContext
    {
        public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext>options)
            :base(options)
        {
                
        }
       public DbSet<Student>Students { get; set; }
    }
}

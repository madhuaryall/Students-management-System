﻿using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class ApplicatonDbContext:DbContext
    {
        public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext>options)
            :base(options)
        {
                
        }
       public DbSet<Student>Students { get; set; }
    }
}

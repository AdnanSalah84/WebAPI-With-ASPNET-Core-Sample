using ASPNet_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_WebAPI.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) 
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                Database.Migrate();
                this.EnsureSeedData();
            }
        }

        public DbSet<Student> Students { get; set; }
    }
}

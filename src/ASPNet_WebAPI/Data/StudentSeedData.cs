using ASPNet_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_WebAPI.Data
{
    public static class StudentSeedData
    {
        public static void EnsureSeedData(this StudentDbContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student() { FirstName = "Kane", LastName = "Smith", Gender = "Male", Age = 31 },
                        new Student() { FirstName = "Bob", LastName = "Smith", Gender = "Male", Age = 29 },
                        new Student() { FirstName = "Maria", LastName = "David", Gender = "Female", Age = 35 },
                        new Student() { FirstName = "Uri", LastName = "Ken", Gender = "Male", Age = 36 }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}

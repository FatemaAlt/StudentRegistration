using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace student_registration.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
             new Level { Id = 1, Code = "PHD", Description = "A Doctor of Philosophy is an academic degree focused on original research, data analysis, and the evaluation of theory." },
             new Level { Id = 2, Code = "PG", Description = "A Postgraduate degree is a type of qualification that is completed after an undergraduate degree." },
             new Level { Id = 3, Code = "G", Description = "A Graduate degree is an advanced academic degree in a specialized field of study, pursued after one has already obtained a bachelor�s degree." },
             new Level { Id = 4, Code = "D", Description = "A diploma is a certificate awarded by an educational institution to a student for completing a specific course and passing the examination." }
            );
        }

        public DbSet<Student>Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Level> Levels { get; set; }
    }
}
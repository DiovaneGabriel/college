using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using College.Models;

namespace College.Data
{
    public class CollegeContext : DbContext
    {
        public CollegeContext (DbContextOptions<CollegeContext> options)
            : base(options)
        {
        }

        public DbSet<College.Models.Student> Student { get; set; }

        public DbSet<College.Models.Course> Course { get; set; }

        public DbSet<College.Models.Grade> Grade { get; set; }

        public DbSet<College.Models.Subject> Subject { get; set; }

        public DbSet<College.Models.Teacher> Teacher { get; set; }
    }
}

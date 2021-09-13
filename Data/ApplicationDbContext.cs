using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT.Data.DataModel.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCHOOL_MANAGEMENT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TeacherModel> Teacher { get; set; }
    }
}

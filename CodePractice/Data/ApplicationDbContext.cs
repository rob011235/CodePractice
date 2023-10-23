using CodePractice.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePractice.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Exercise> Exercises { get; set; } 
        DbSet<Competency> Competencies { get; set; }
        DbSet<Submission> Submissions { get; set; }
    }
}
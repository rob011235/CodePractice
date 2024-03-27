using CodePractice.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePractice.Server.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<FileSubmission> FileSubmissions { get; set; }
        public DbSet<Submission> Submissions { get; set; }
    }
}

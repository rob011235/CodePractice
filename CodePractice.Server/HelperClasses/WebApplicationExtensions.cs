using CodePractice.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CodePractice.Server.HelperClasses
{
    public static class WebApplicationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
        }
    }
}

using CodePractice.Shared.Models;

namespace CodePractice.Shared.Interfaces
{
    public interface IUsersRepo
    {
        public Task<ApplicationUser?> GetUserAsync();
    }
}
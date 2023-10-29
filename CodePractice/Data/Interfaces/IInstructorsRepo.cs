using CodePractice.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CodePractice.Data.Interfaces
{
    public interface IInstructorsRepo
    {
        Task<bool> AddInstructor(IdentityUser instructor);
        Task<IdentityUser> GetInstructor(string id);
        Task<List<IdentityUser>> GetInstructors();
        Task<bool> IsInstructor(string id);
        Task<bool> RemoveInstructor(string id);
    }
}
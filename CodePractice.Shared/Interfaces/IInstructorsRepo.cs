using CodePractice.Server.Data;

namespace CodePractice.Shared.Interfaces
{
    public interface IInstructorsRepo
    {
        Task<bool> AddInstructor(ApplicationUser instructor);
        Task<ApplicationUser> GetInstructor(string id);
        Task<List<ApplicationUser>> GetInstructors();
        Task<bool> IsInstructor(string id);
        Task<bool> RemoveInstructor(string id);
    }
}
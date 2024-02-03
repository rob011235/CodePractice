using CodePractice.Shared.Models;
using CodePractice.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CodePractice.Data.Repos
{
    public class InstructorsRepo : IInstructorsRepo
    {
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public InstructorsRepo(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<ApplicationUser>> GetInstructors()
        {
            var instructors = await _userManager.GetUsersInRoleAsync("Instructor");
            return instructors.ToList();
        }

        public async Task<ApplicationUser> GetInstructor(string id)
        {
            var instructor = await _userManager.FindByIdAsync(id);
            return instructor;
        }

        public async Task<bool> IsInstructor(string id)
        {
            var instructor = await _userManager.FindByIdAsync(id);
            return await _userManager.IsInRoleAsync(instructor, "Instructor");
        }

        public async Task<bool> AddInstructor(ApplicationUser instructor)
        {
            var result = await _userManager.CreateAsync(instructor);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(instructor, "Instructor");
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveInstructor(string id)
        {
            var instructor = await _userManager.FindByIdAsync(id);
            var result = await _userManager.RemoveFromRoleAsync(instructor, "Instructor");
            return result.Succeeded;
        }
    }
}

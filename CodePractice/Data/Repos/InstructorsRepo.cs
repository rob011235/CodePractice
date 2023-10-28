using CodePractice.Data.Interfaces;
using CodePractice.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CodePractice.Data.Repos
{
    public class InstructorsRepo : IInstructorsRepo
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public InstructorsRepo(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<IdentityUser>> GetInstructors()
        {
            var instructors = await _userManager.GetUsersInRoleAsync("Instructor");
            return instructors.ToList();
        }

        public async Task<IdentityUser> GetInstructor(string id)
        {
            var instructor = await _userManager.FindByIdAsync(id);
            return instructor;
        }

        public async Task<bool> IsInstructor(string id)
        {
            var instructor = await _userManager.FindByIdAsync(id);
            return await _userManager.IsInRoleAsync(instructor, "Instructor");
        }

        public async Task<bool> AddInstructor(IdentityUser instructor)
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

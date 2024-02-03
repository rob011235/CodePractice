using CodePractice.Shared.Interfaces;
using CodePractice.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace CodePractice.Server.Data.Repos
{
    public class UsersRepo: IUsersRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private Task<AuthenticationState> authenticationState => _authenticationStateProvider.GetAuthenticationStateAsync();

        public UsersRepo(ApplicationDbContext applicationDbContext, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = applicationDbContext;
            _authenticationStateProvider = authenticationStateProvider;
        }

        private async Task<ApplicationUser?> GetUser()
        {
            var userPrincipal = (await authenticationState).User;
            var userid = userPrincipal.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            if (!string.IsNullOrEmpty(userid))
                return _context.Users.Where(u => u.Id == userid).FirstOrDefault();
            return null;
        }
    }
}

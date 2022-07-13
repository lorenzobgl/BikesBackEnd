using BikesBackEnd.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BikesBackEnd.Services
{
    public class UtenteServices
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UtenteServices(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public bool CheckUser(string userName, string password)
        {
            if(userName == null || password == null)
            {
                return false;
            }
            var user = _userManager.Users.Where(x => x.UserName.Equals(userName) && x.PasswordHash.Equals(password.GetHashCode())).First();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}

using System.Threading.Tasks;
using RMSDesktopUI.Models;

namespace RMSDesktopUI.Helper
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}
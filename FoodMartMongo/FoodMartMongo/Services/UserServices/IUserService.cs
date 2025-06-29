using FoodMartMongo.Entities;
using System.Threading.Tasks;

namespace FoodMartMongo.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task RegisterUserAsync(User user);
        Task<bool> CheckPasswordAsync(User user, string password);

        Task MigratePlaintextPasswordsAsync();
    }
}

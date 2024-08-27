using ApiPreferencia.Model;
using System.Security.Claims;

namespace ApiPreferencia.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers(int page = 0, int pageSize = 10);
        UserModel? GetIdUser(int id);
        UserModel? GetByUsername(string username);
        void AddUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
        string GetUserFromToken(ClaimsPrincipal user);
    }
}

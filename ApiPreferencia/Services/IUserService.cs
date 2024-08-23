using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers(int page = 0, int pageSize = 10);
        UserModel? GetIdUser(int id);
        void AddUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
    }
}

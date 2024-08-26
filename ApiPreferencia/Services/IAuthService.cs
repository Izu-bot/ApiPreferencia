using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string email,  string password);

    }
}

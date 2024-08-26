using ApiPreferencia.Data.Repository;
using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;

        public AuthService(IUserRepository repository) => _repository = repository;
        public UserModel Authenticate(string email, string password)
        {
            var user = _repository.GetUsername(email);

            // verifica se o usuario é null ou se a senha passada é diferente da senha armazenada
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;

            return user;
        }
    }
}

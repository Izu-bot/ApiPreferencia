﻿using ApiPreferencia.Data.Repository;
using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) => _repository = repository;

        public void AddUser(UserModel user)
        {
            if (user == null) throw new ArgumentNullException("O usuário está nulo");

            var userExist = _repository.GetUsername(user.UserEmail);
            if (userExist != null) throw new InvalidOperationException($"O email {user.UserEmail} já está em uso!");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _repository.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetId(id);

            if(user != null)
            {
                _repository.Delete(user);
            }
        }

        public IEnumerable<UserModel> GetAllUsers(int page = 0, int pageSize = 10) => _repository.GetAll(page, pageSize);

        public UserModel? GetIdUser(int id) => _repository.GetId(id);

        public void UpdateUser(UserModel user) => _repository.Update(user);

        public UserModel? GetByUsername(string username) => _repository.GetUsername(username);
    }
}

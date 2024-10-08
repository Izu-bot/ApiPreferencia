﻿using ApiPreferencia.Model;

namespace ApiPreferencia.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll(int page, int pageSize); // Implementando a paginação
        UserModel? GetId(int id);
        UserModel? GetUsername(string username);
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(UserModel user);
    }
}

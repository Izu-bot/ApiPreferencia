using ApiPreferencia.Data.Context;
using ApiPreferencia.Model;

namespace ApiPreferencia.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context) => _context = context;

        public void Add(UserModel user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(UserModel user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserModel> GetAll(int page, int pageSize)
        {
            return _context.Users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public UserModel? GetId(int id) => _context.Users.Find(id);

        public void Update(UserModel user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}

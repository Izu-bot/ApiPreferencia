using ApiPreferencia.Data.Context;
using ApiPreferencia.Model;

namespace ApiPreferencia.Data.Repository
{
    public class PreferenceRepository : IPreferenceRepository
    {

        private readonly DatabaseContext _context;

        public PreferenceRepository(DatabaseContext context) => _context = context;

        public void Add(PreferenceModel preference)
        {
            _context.Add(preference);
            _context.SaveChanges();
        }

        public void Delete(PreferenceModel preference)
        {
            _context.Remove(preference);
            _context.SaveChanges();
        }

        public PreferenceModel? GetId(int id) => _context.Preferences.Find(id);

        public void Update(PreferenceModel preference)
        {
            _context.Update(preference);
            _context.SaveChanges();
        }
    }
}

using ApiPreferencia.Data.Context;
using ApiPreferencia.Model;

namespace ApiPreferencia.Data.Repository
{
    public class LabelRepository : ILabelRepository
    {

        private readonly DatabaseContext _context;

        public LabelRepository(DatabaseContext context) => _context = context;
        public void Add(LabelModel label)
        {
            _context.Add(label);
            _context.SaveChanges();
        }

        public void Delete(LabelModel label)
        {
            _context.Remove(label);
            _context.SaveChanges();
        }

        public IEnumerable<LabelModel> GetAll(int page, int pageSize)
        {
            return _context.Labels
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public LabelModel? GetId(int id) => _context.Labels.Find(id);

        public IEnumerable<LabelModel>? GetName(string name)
        {
            return _context.Labels.Where(label => label.Name == name).ToList();
        }

        public void Update(LabelModel label)
        {
            _context.Update(label);
            _context.SaveChanges();
        }
    }
}

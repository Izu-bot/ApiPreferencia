using ApiPreferencia.Model;

namespace ApiPreferencia.Data.Repository
{
    public interface ILabelRepository
    {
        IEnumerable<LabelModel> GetAll(string username, int page, int pageSize);
        IEnumerable<LabelModel>? GetName(string name);
        LabelModel? GetId(int id);
        void Add(LabelModel label);
        void Update(LabelModel label);
        void Delete(LabelModel label);
    }
}

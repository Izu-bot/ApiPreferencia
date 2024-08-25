using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public interface ILabelService
    {
        IEnumerable<LabelModel> GetAll(int page = 0, int pageSize = 10);
        IEnumerable<LabelModel>? GetName(string name);
        LabelModel? GetById(int id);
        void AddLabel(LabelModel label);
        void UpdateLabel(LabelModel label);
        void DeleteLabel(int id);
    }
}

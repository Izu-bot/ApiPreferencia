using ApiPreferencia.Data.Repository;
using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public class LabelService : ILabelService
    {

        private readonly ILabelRepository _repository;

        public LabelService(ILabelRepository repository) => _repository = repository;
        public void AddLabel(LabelModel label)
        {
            if (label == null) throw new ArgumentNullException("O rotulo está nulo.");

            _repository.Add(label);
        }

        public void DeleteLabel(int id)
        {
            var label = _repository.GetId(id);
            if (label == null) throw new ArgumentNullException("Valor de rotuno nullo");

            _repository.Delete(label);
        }

        public IEnumerable<LabelModel> GetAll(int page = 0, int pageSize = 10) => _repository.GetAll(page, pageSize);

        public LabelModel? GetById(int id) => _repository.GetId(id);

        public IEnumerable<LabelModel>? GetName(string name) => _repository.GetName(name);

        public void UpdateLabel(LabelModel label) => _repository.Update(label);
    }
}

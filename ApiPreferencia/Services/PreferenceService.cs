using ApiPreferencia.Data.Context;
using ApiPreferencia.Data.Repository;
using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IPreferenceRepository _repository;

        public PreferenceService(IPreferenceRepository repository) => _repository = repository;

        public void AddPreference(PreferenceModel model)
        {
            if (model == null) throw new ArgumentNullException("Está tentando cadastrar um tema nulo.");

            _repository.Add(model);
        }

        public void DeletePreference(int id)
        {
            var preference = _repository.GetId(id);
            if (preference == null) throw new ArgumentNullException($"O valor para {preference} é nulo.");

            _repository.Delete(preference);
        }

        public PreferenceModel? GetById(int id)
        {
            var preference = _repository.GetId(id);

            if (preference != null) return preference;

            throw new Exception("A preferencia não existe...");
        }

        public void UpdatePreference(PreferenceModel model) => _repository.Update(model);
    }
}

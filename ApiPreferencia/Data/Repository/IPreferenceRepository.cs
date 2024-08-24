using ApiPreferencia.Model;

namespace ApiPreferencia.Data.Repository
{
    public interface IPreferenceRepository
    {
        PreferenceModel? GetId(int id);
        void Add(PreferenceModel preference);
        void Update(PreferenceModel preference);
        void Delete(PreferenceModel preference);
    }
}

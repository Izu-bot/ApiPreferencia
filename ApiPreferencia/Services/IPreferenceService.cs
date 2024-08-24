using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public interface IPreferenceService
    {
        PreferenceModel? GetById(int id);
        void AddPreference(PreferenceModel model);
        void UpdatePreference(PreferenceModel model);
        void DeletePreference(int id);
    }
}

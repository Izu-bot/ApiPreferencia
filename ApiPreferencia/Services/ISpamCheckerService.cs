using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public interface ISpamCheckerService
    {
        void CheckForSpam(EmailModel email);
    }
}

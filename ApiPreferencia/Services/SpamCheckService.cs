using ApiPreferencia.Model;

namespace ApiPreferencia.Services
{
    public class SpamCheckService : ISpamCheckerService
    {

        private readonly List<string> spamKeywords = new()
        {
            "sorteio", "última chance", "tempo limitado", "promoção", "grátis"
        };

        public void CheckForSpam(EmailModel email)
        {
            foreach (var keyword in spamKeywords)
            {
                if (email.Body.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || email.Subject.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    email.IsSpam = true;
                    break; // Sai do loop assim que encontrar a primeira palavra de spam
                }
            }
        }
    }
}

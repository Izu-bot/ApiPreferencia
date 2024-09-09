using ApiPreferencia.Services;

namespace ApiPreferencia.Model.MockData
{
    public class EmailMock
    {
        private static List<EmailModel> _emails = new()
    {
        new() { Id = 1, Email = "Example01@email.com", Title = "Email 1", Subject = "Hello World", Body = "This is test a email!", LabelId = 0 },
        new() { Id = 2, Email = "Undefined@email.com", Title = "Email 2", Subject = "Job description", Body = "This is test a email!", LabelId = 0 },
        new() { Id = 3, Email = "NotFound@email.com", Title = "Email 3", Subject = "Http Http", Body = "This is test a email!", LabelId = 0 },
        new() { Id = 4, Email = "Email@email.com", Title = "Email 4", Subject = "About", Body = "This is test a email!", LabelId = 0 },
        new() { Id = 5, Email = "Spam@example.com", Title = "Email 5", Subject = "Última chance!", Body = "Participe do nosso sorteio!", LabelId = 0 },
        new() { Id = 6, Email = "Spam@example.com", Title = "Email 6", Subject = "Tempo limitado", Body = "Vamos concorra a uma casa gastando R$ 500,00, é por tempo limitado!", LabelId = 0 },
        new() { Id = 7, Email = "Spam@example.com", Title = "Email 7", Subject = "Promoção", Body = "Não perca essa promoção imperdivel!!", LabelId = 0 },
        new() { Id = 8, Email = "Spam@example.com", Title = "Email 8", Subject = "Sorteio", Body = "Participe do nosso sorteio!", LabelId = 0 },
        new() { Id = 9, Email = "Spam@example.com", Title = "Email 9", Subject = "Concorra", Body = "Última chance para um desconto de 50%!", LabelId = 0 }
    };

        // Método para verificar se cada e-mail é spam ao inicializar
        static EmailMock()
        {
            var spamChecker = new SpamCheckService();
            foreach (var email in _emails)
            {
                spamChecker.CheckForSpam(email); // Marca como spam se aplicável
            }
        }

        // Retorna todos os e-mails não marcados como spam
        public static List<EmailModel> GetMockEmail()
        {
            return _emails.Where(e => !e.IsSpam).ToList(); // Retorna apenas emails não spam
        }

        // Retorna um e-mail específico por ID, mesmo que seja spam
        public static EmailModel? GetEmailById(int id)
        {
            return _emails.FirstOrDefault(x => x.Id == id);
        }

        // Método opcional para listar os e-mails que foram marcados como spam
        public static List<EmailModel> GetSpamEmails()
        {
            return _emails.Where(e => e.IsSpam).ToList();
        }
    }

}

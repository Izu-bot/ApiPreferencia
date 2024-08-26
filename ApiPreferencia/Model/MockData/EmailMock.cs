namespace ApiPreferencia.Model.MockData
{
    public class EmailMock
    {
        private static List<EmailModel> _emails = new()
        { 
            new() {Id = 1, Email = "Example01@email.com", Title = "Email 1", Subject = "Hello World", Body = "This is test a email!", LabelId = 0},
            new() {Id = 2, Email = "Undefined@email.com", Title = "Email 2", Subject = "Job description", Body = "This is test a email!", LabelId = 0},
            new() {Id = 3, Email = "NotFound@email.com", Title = "Email 3", Subject = "Http Http", Body = "This is test a email!", LabelId = 0},
            new() {Id = 4, Email = "Email@email.com", Title = "Email 4", Subject = "About", Body = "This is test a email!", LabelId = 0}
        };

        public static List<EmailModel> GetMockEmail()
        {
            return _emails;
        }

        public static EmailModel? GetEmailById(int id)
        {
            return _emails.FirstOrDefault(x => x.Id == id);
        }

    }
}

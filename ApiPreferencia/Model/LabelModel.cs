namespace ApiPreferencia.Model
{
    public class LabelModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int UserId { get; set; }
        public UserModel? User { get; set; }

        public int EmailId { get; set; }
        public EmailModel? Email { get; set; }
    }
}

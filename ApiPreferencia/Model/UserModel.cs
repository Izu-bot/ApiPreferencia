namespace ApiPreferencia.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public string? PasswordHash { get; set; }

        public List<LabelModel>? Labels { get; set; }
    }
}

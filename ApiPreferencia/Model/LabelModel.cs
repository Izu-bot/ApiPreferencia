namespace ApiPreferencia.Model
{
    public class LabelModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int UserId { get; set; }
        public UserModel? User { get; set; }

        public List<EmailLabel>? EmailLabels { get; set; }
    }
}

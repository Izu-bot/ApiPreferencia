namespace ApiPreferencia.Model
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public int LabelId { get; set; }
    }
}

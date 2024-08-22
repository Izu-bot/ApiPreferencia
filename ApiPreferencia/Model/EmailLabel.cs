namespace ApiPreferencia.Model
{
    public class EmailLabel
    {
        public int EmailId { get; set; }
        public EmailModel? Email { get; set; }
        
        public int LabelId { get; set; }
        public LabelModel? Label { get; set; }
    }
}

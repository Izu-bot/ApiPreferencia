namespace ApiPreferencia.Model
{
    public class PreferenceModel
    {
        public int Id { get; set; }
        public string Theme { get; set; } = "Default";
        public int UserId { get; set; }
        public UserModel? User { get; set; }
    }
}

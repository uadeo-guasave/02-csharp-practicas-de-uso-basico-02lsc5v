namespace _02_csharp_primeros_pasos.Models
{
    public enum gender {
        FEMENINO, MASCULINO
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string RememberToken { get; set; }
        public gender Gender { get; set; }

    }
}
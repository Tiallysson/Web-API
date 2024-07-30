namespace Account.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Seria adicionado em um cen�rio real de forma segura
        public string Telephone { get; set; }
    }
}

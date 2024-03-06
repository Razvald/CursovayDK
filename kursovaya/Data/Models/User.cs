namespace rlf.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } // Внешний ключ на роль
        public Role Role { get; set; } // Навигационное свойство для связи с ролью
        public List<Transaction> Transactions { get; set; } // Связь с транзакциями
        public UserProfile UserProfile { get; set; } // Профиль пользователя
    }
}

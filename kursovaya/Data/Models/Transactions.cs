namespace rlf.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Sum { get; set; }
        public int CategoryID { get; set; } // Внешний ключ на категорию
        //public Category? Category { get; set; } // Навигационное свойство для связи с категорией
        public int UserId { get; set; } // Внешний ключ на пользователя
        //public User? User { get; set; } // Навигационное свойство для связи с пользователем
    }
}

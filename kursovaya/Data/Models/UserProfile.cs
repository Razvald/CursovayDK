namespace rlf.Data.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string PlaceOfResidence { get; set; }
        public string TimeZone { get; set; }
        public int UserId { get; set; } // Внешний ключ на пользователя
        public User User { get; set; } // Навигационное свойство для связи с пользователем
    }
}

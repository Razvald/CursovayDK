using System.ComponentModel.DataAnnotations;
namespace rlf.ViewModels
{
    public class RegisterModel

    {
        public string Name { get; set; }
        public string NickName { get; set; }

        public string Phone { get; set; }
        public string PlaceOfResidence { get; set; }

        public string TimeZone { get; set; }
       [Required(ErrorMessage = "Введен неверный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введен неверный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введен неверный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

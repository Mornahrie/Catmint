using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [ForeignKey("Right")]
        public int right_id { get; set; }

        [ForeignKey("Sex")]
        [DisplayName("Пол")]
        public int sex_id { get; set; }

        [ForeignKey("Cat")]
        [DisplayName("Фаворит")]
        public int? cat_id { get; set; }

        [DisplayName("Имя")]
        [Required(ErrorMessage = "Имя не указано.")]
        public string name { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Фамилия не указана.")]
        public string surname { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage = "Отчество не указано.")]
        public string fathername { get; set; }

        [DisplayName("Дата Рождения")]
        [Required(ErrorMessage = "Дата рождения не указана.")]
        [Remote(action: "CheckDate", controller: "Users", ErrorMessage = "Минимальный возраст для регистрации должен быть 14 лет.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_of_birth { get; set; }

        [DisplayName("Номер телефона")]
        [RegularExpression(@"^\+\d{3}\(\d{2}\)\d{3}-\d{2}-\d{2}$", ErrorMessage = "Введите номер телефона в формате: +375(__)___-__-__")]
        [Remote(action: "CheckPhone", controller: "Users", ErrorMessage = "Телефон уже используется")]
        [Required(ErrorMessage = "Номер телефона не указан.")]
        public string phone_num { get; set; } //UN

        [DisplayName("Почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Users", ErrorMessage = "Почта уже используется")]
        [Required(ErrorMessage = "Электронный адрес не указан.")]
        public string email { get; set; } //UN

        [DisplayName("Логин")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Длина логина должна быть от 6 до 30 символов")]
        [Remote(action: "CheckLogin", controller: "Users", ErrorMessage = "Логин уже используется")]
        [Required(ErrorMessage = "Логин не может быть пустым!")]
        public string login { get; set; } //UN

        [DisplayName("Пароль")]
        [StringLength(18, MinimumLength = 4, ErrorMessage = "Длина пароля должна быть от 6 до 18 символов")]
        [Remote(action: "CheckPass", controller: "Users", ErrorMessage = "Пароль ненадежный.")]
        [Required(ErrorMessage = "Пароль не может быть пустым!")]
        public string password { get; set; } //UN
    }
}
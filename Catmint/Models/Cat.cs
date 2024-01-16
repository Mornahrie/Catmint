using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Cat
    {
        [Key]
        public int cat_id { get; set; }
        [ForeignKey("Sex")]
        [DisplayName("Пол")]
        public int sex_id { get; set; }
        [ForeignKey("Lazalka")]
        [DisplayName("Место")]
        public int? place_id { get; set; } //если 0 - то статус 0
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Имя не указано.")]
        public string cat_name { get; set; } //UN
        [DisplayName("Возраст")]
        [Range(1, 25, ErrorMessage = "Возраст может быть от 1 до 25 лет.")]
        [Required(ErrorMessage = "Возраст не указан.")]
        public int cat_age { get; set; }
        [DisplayName("История")]
        [Required(ErrorMessage = "История не указана.")]
        public string history { get; set; }

        [DisplayName("Фото")]
        [Required(ErrorMessage = "Фотография не добавлена.")]
        public string cat_photo { get; set; }

        [Range(0, 1)]
        public int status { get; set; } //Доступен или Нет  - зависит от того, есть ли кот в Lazalka

    }
}

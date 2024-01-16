using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Comment
    {
        [Key]
        public int comm_id { get; set; }
        [ForeignKey("User")]
        [DisplayName("Идентификатор пользователя")]
        public int user_id { get; set; }
        [DisplayName("Оценка")]
        [Required(ErrorMessage = "Вы не указали оценку!")]
        public int rank { get; set; }
        [DisplayName("Комментарий")]
        [Required(ErrorMessage = "Комментарий не может быть пустым!")]
        public string comment_text { get; set; }
        [Required(ErrorMessage = "Модерка не может быть пустым!")]
        public int modered { get; set; } 
        //1 - на модерации
        //2 - прошли
        //3 - не прошли
    }
}

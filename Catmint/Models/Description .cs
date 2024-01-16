using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Description
    {
        [Key]
        public int desc_id { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; } //кто добавил
        [ForeignKey("Right")]
        public int right_id { get; set; } //админ может менять картинки котов и содержимого на сайте, пользователь только свое фото
        public int? cat_id { get; set; } //если фото принадлежит котейке
        public string value_name { get; set; } //id элемента
        public string text { get; set; } //либо текст, либо ссылка на фото/гифку
    }
}

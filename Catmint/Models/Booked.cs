using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Booked
    {
        [Key]
        [DisplayName("Идентификатор резервации")]
        public int book_id { get; set; }
        [ForeignKey("Table")]
        [DisplayName("Столик")]
        public int table_id { get; set; }
        [ForeignKey("User")]
        [DisplayName("Идентификатор пользователя")]
        public int user_id { get; set; }
        [DisplayName("Дата резервации")]
        public DateTime booked_date { get; set; }
        // год - месяц - день - час - минута - секунда
        // через 15 минут после наступления удаляется, либо вручную админом
    }
}

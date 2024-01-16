using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        [DisplayName("Категория")]
        public string categ_name { get; set; } //UN
    }
}

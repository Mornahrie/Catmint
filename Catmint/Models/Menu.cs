using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Catmint.Models
{
    public class Menu
    {
        [Key]
        public int dish_id { get; set; }
        [ForeignKey("Category")]
        public int category_id { get; set; }
        public string dish_name { get; set; } //UN
        public float dish_price { get; set; }
        public int weight { get; set; }
    }
}

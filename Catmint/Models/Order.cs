using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        [ForeignKey("Table")]
        public int table_id { get; set; }
        [ForeignKey("Menu")]
        public int dish_id { get; set; }
        public double price { get; set; }
        public DateTime order_date { get; set; }
        [Range(0, 1)]
        public int order_status { get; set; }
    }
}

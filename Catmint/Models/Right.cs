using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Right
    {
        [Key]
        public int right_id { get; set; }
        public int right_value { get; set; } //UN
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Lazalka
    {
        [Key]
        public int place_id { get; set; }
        public int place_num { get; set; }
    }
}

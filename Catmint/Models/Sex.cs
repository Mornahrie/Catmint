using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Sex
    {
        [Key]
        public int sex_id { get; set; }
        public string sex_name { get; set; } //UN
    }
}

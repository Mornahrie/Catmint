using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catmint.Models
{
    public class Tables
    {
        [Key]
        public int table_id { get; set; }
        public int capacity { get; set; }
    }
}

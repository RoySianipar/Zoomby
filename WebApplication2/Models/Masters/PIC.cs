using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models.Masters
{
    [Table("M_PIC")]
    public class PIC : Base
    {
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models.Masters
{
    [Table("M_ZoomAccount")]
    public class ZoomAccount : Base
    {
        public string Name { get; set; }
    }
}

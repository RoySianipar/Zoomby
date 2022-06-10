using WebApplication2.Models.Masters;

namespace WebApplication2.Models.Transaction
{
    public class ZoomScheduler : Base
    {
        public string? Agenda { get; set; }
        public string? LinkAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //untuk join
        public virtual PIC? PIC { get; set; }
        public int PICId { get; set; }
        public virtual ZoomAccount? Account { get; set; }
        public int ZoomAccountId { get; set; }

    }
}

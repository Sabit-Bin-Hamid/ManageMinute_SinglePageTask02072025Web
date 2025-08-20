using System.ComponentModel.DataAnnotations;

namespace Single_Page_Task_02072025.Models
{
    public class MeetingMinute
    {
        [Key]
        public int MeetingMinuteId { get; set; }

        [Required(ErrorMessage = "Customer type is required")]
        public string? CustomerType { get; set; }
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MeetingDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? MeetingTime { get; set; }

        [Required(ErrorMessage = "Meeting place is required")]
        public string? MeetingPlace { get; set; }

        [Required(ErrorMessage = "Attends From Client Side is required")]
        public string? AttendsFromClientSide { get; set; }

        [Required(ErrorMessage = "Attends From Host Side is required")]
        public string? AttendsFromHostSide { get; set; }

        [Required(ErrorMessage = "Meeting Agenda is required")]
        public string? MeetingAgenda { get; set; }

        [Required(ErrorMessage = "Meeting Discussion is required")]
        public string? MeetingDiscussion { get; set; }

        [Required(ErrorMessage = "Meeting Decision is required")]
        public string? MeetingDecision { get; set; }
        public List<MeetingMinuteDetail> Details { get; set; } = new List<MeetingMinuteDetail>();
    }
}

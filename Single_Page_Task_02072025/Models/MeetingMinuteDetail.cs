using System.ComponentModel.DataAnnotations;

namespace Single_Page_Task_02072025.Models
{
    public class MeetingMinuteDetail
    {
        [Key]
        public int MeetingMinuteDetailId { get; set; }

        [Required]
        public int MeetingMinuteId { get; set; }

        [Required(ErrorMessage = "Product/Service is required")]
        public int ProductServiceId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Unit is required")]
        public string? Unit { get; set; }
        public MeetingMinute? MeetingMinute { get; set; }
        public ProductService? ProductService { get; set; }
    }
}

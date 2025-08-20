namespace Single_Page_Task_02072025.Models.DTO
{
    public class MeetingMinuteViewDTO
    {
        public MeetingMinute? Meeting { get; set; }
        public List<MeetingMinuteDetail>? Details { get; set; } 

        public int? SelectedProductId { get; set; }
        public decimal? Quantity { get; set; }
        public string? Unit { get; set; }
     
        //public string MeetingTimeFormatted
        //{
        //    get
        //    {
        //        if (Meeting != null && Meeting.MeetingTime.HasValue)
        //        {
        //            return Meeting.MeetingTime.Value.ToString("hh:mm tt");
        //        }
        //        return string.Empty;
        //    }
        //}

    }
}

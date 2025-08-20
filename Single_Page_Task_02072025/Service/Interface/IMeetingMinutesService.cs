using Single_Page_Task_02072025.Models;

namespace Single_Page_Task_02072025.Service.Interface
{
    public interface IMeetingMinutesService
    {
        Task<int> SaveAsync(MeetingMinute master,IEnumerable<MeetingMinuteDetail> details);
    }
}

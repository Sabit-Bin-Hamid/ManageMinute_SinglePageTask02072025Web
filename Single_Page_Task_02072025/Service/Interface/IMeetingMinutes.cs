using Single_Page_Task_02072025.Models;

namespace Single_Page_Task_02072025.Service.Interface
{
    public interface IMeetingMinutes
    {
        Task<List<CorporateCustomer>> GetCorporateCustomerAsync();
        Task<List<IndividualCustomer>> GetIndividualCustomerAsync();

    }
}

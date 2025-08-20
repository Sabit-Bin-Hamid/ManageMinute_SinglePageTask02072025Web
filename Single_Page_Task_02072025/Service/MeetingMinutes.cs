using Microsoft.EntityFrameworkCore;
using Single_Page_Task_02072025.Data;
using Single_Page_Task_02072025.Models;
using Single_Page_Task_02072025.Service.Interface;

namespace Single_Page_Task_02072025.Service
{
    public class MeetingMinutes : IMeetingMinutes
    {
        private readonly AppDbContext _context;
        public MeetingMinutes(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<List<CorporateCustomer>> GetCorporateCustomerAsync()
        {
            return await  _context.Corporate_Customer_Tbl.Select(c => new CorporateCustomer { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        public async Task<List<IndividualCustomer>> GetIndividualCustomerAsync()
        {
            return await _context.Individual_Customer_Tbl.Select(c => new IndividualCustomer { Id = c.Id, Name = c.Name }).ToListAsync();
        }

    }
}

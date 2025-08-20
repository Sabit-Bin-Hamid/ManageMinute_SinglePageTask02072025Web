using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Single_Page_Task_02072025.Data;
using Single_Page_Task_02072025.Models;
using Single_Page_Task_02072025.Service.Interface;
using System.Data;

namespace Single_Page_Task_02072025.Service
{
    public class MeetingMinutesService : IMeetingMinutesService
    {
        private readonly AppDbContext _db;
        public MeetingMinutesService(AppDbContext context)
        {
            _db = context;
        }
        public async Task<int> SaveAsync(MeetingMinute master, IEnumerable<MeetingMinuteDetail> details)
        {
            if (master == null)
            {
                throw new ArgumentNullException(nameof(master));
            }
            if(details == null)
            {
                details = Enumerable.Empty<MeetingMinuteDetail>();
            }
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@CustomerType", (object?)master.CustomerType ?? DBNull.Value),
                    new SqlParameter("@CustomerId",master.CustomerId),
                    new SqlParameter("@MeetingDate",(object?)master.MeetingDate ?? DBNull.Value),
                    new SqlParameter("@MeetingTime",(object?)master.MeetingTime ?? DBNull.Value),
                    new SqlParameter("@MeetingPlace",(object?)master.MeetingPlace ?? DBNull.Value),
                    new SqlParameter("@AttendsFromClientSide",(object?)master.AttendsFromClientSide ?? DBNull.Value),
                    new SqlParameter("@AttendsFromHostSide", (object?)master.AttendsFromHostSide ?? DBNull.Value),
                    new SqlParameter("@MeetingAgenda", (object?)master.MeetingAgenda ?? DBNull.Value),
                    new SqlParameter("@MeetingDiscussion", (object?)master.MeetingDiscussion ?? DBNull.Value),
                    new SqlParameter("@MeetingDecision", (object?)master.MeetingDecision ?? DBNull.Value),
                    new SqlParameter{
                        ParameterName = "@NewId",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                };

                await _db.Database.ExecuteSqlRawAsync( @"EXEC dbo.Meeting_Minutes_Master_Save_SP 
                                @CustomerType, @CustomerId, @MeetingDate, @MeetingTime, @MeetingPlace,
                                @AttendsFromClientSide, @AttendsFromHostSide, @MeetingAgenda,
                                @MeetingDiscussion, @MeetingDecision, @NewId OUTPUT",
                                parameters
                );
                master.MeetingMinuteId = (int)(parameters.Last().Value ?? 0);

                foreach (var d in details.Where(x => x.ProductServiceId > 0))
                {
                    var detailParams = new[]
                    {
                        new SqlParameter("@MeetingMinuteId", master.MeetingMinuteId),
                        new SqlParameter("@ProductServiceId", d.ProductServiceId),
                        new SqlParameter("@Quantity", d.Quantity),
                        new SqlParameter("@Unit", (object?)d.Unit ?? DBNull.Value)
                    };

                    await _db.Database.ExecuteSqlRawAsync(@"EXEC dbo.Meeting_Minutes_Details_Save_SP 
                        @MeetingMinuteId, @ProductServiceId, @Quantity,@Unit",
                        detailParams);
                }
                await transaction.CommitAsync();
                return master.MeetingMinuteId;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
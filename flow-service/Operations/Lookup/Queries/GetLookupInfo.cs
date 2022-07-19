using System.Threading.Tasks;
using Core.Meteor.Dto;
using Flow.Operations.Lookup.Dtos;
using Meteor.Operation.Db;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupInfo : DbOperationAsync<DbSelectInDto, LookupInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Flow.sp_LookupInfo @Id = @Id
                          ,@TenantId = @TenantId ").QueryFirstOrDefaultAsync<LookupInfoDto>();
        }
    }
}
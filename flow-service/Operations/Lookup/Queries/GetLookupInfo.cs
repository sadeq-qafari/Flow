using System.Threading.Tasks;
using Flow.Operations.Lookup.Dtos;
using Meteor.Operation.Db;
using Saanaa.Core.Meteor.Dto;

namespace Flow.Operations.Lookup.Queries
{
    public class GetLookupInfo : DbOperationAsync<SaanaaDbSelectInDto,LookupInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Flow.sp_LookupInfo @Id = @Id
                          ,@TenantId = @TenantId ").QueryFirstOrDefaultAsync<LookupInfoDto>();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Meteor;
using Core.Operations.Service.Dto;
using Meteor.Operation.Db;

namespace Core.Operations.Service.Queries
{
    public class GetServices : DbOperationAsync<GetServicesInDto, ServicesDto>
    {
        protected override async Task ExecutionAsync()
        {
            var requestedVersion = Input.Version.GetValueOrDefault(0);
            if (requestedVersion <= 0 || requestedVersion != SqServices.LatestVersion)
            {
                var names = await NewSql(sql => sql.Select("[Identity].[TenantService] TenantService","Service.Name")
                    .InnerJoin("[Core].[Service] Service", "Service.Id = TenantService.ServiceId AND TenantService.TenantId = @TenantId AND TenantService.IsDeleted = 0 AND Service.IsDeleted = 0")
                ).QueryAsync<string>();
                Output = GetServicesDto(string.Join(',', names));
            }
            else
            {
                Output = null;
            }
        }

        private static ServicesDto GetServicesDto(string? names)
        {
            var serviceNames = names?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            return new ServicesDto
            {
                Services = SqServices.GetServices(serviceNames),
                Version = SqServices.LatestVersion
            };
        }
    }
}
